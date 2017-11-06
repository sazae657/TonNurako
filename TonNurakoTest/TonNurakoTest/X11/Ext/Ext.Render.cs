using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;
using TonNurako.X11.Extension;
using System;

namespace TonNurakoTest.X11.Ext {
    public class RenderTest : AbstractSingleWindowTest {
        public RenderTest() : base() {
        }
        protected override void BeforeMapWindow() {

        }

        public override void Dispose() {
            base.Dispose();
        }

        [Fact]
        public void StandardFunction() {
            Open();
            Assert.True(XRender.QueryExtension(display));
            Assert.NotNull(XRender.QueryVersion(display));
            Assert.NotEqual(0, XRender.QueryFormats(display));

            var spo = XRender.QuerySubpixelOrder(display, display.DefaultScreen);
            Assert.True(XRender.SetSubpixelOrder(display, display.DefaultScreen, SubPixel.SubPixelVerticalRGB));
            Assert.Equal(SubPixel.SubPixelVerticalRGB, XRender.QuerySubpixelOrder(display, display.DefaultScreen));
            Assert.True(XRender.SetSubpixelOrder(display, display.DefaultScreen, spo));
            Assert.Equal(spo, XRender.QuerySubpixelOrder(display, display.DefaultScreen));

            Assert.NotNull(XRender.FindVisualFormat(display, display.DefaultVisual));
            Assert.NotNull(XRender.FindStandardFormat(display, PictStandard.ARGB32));

            //Assert.NotNull(XRender.QueryPictIndexValues(display, null));
            Assert.NotNull(XRender.QueryFilters(display, window));

            XRender.ParseColor(display, "green");
            Assert.ThrowsAny<System.Exception>(()=>XRender.ParseColor(display, "うんこ色"));
            Close();
        }

        [Fact]
        public void Picture() {
            Open();
            using (var pm = new Pixmap(window, 100, 100, 8)) {
                Assert.NotNull(pm);
                using(var pic = XRender.CreatePicture(
                    display, pm, XRender.FindStandardFormat(display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
                {
                    Assert.NotNull(pic);
                }
            }
            Close();
        }

        [Fact]
        public void StdDraw() {
            Open();
            var pm = new Pixmap(window, 100, 100, 8);
            Assert.NotNull(pm);
            using(var src = XRender.CreatePicture(
                display, pm, XRender.FindStandardFormat(display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
            using(var dest = XRender.CreatePicture(
                display, pm, XRender.FindStandardFormat(display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
            {
                Assert.NotNull(src);
                Assert.NotNull(dest);
                DrawFunc(pm, dest);
                FillFunc(100, 100);
                CompositeFunc(src, dest, 100, 100);
            }
            pm.Dispose();
            Close();
        }

        void DrawFunc(Pixmap pixmap, Picture picture) {
            XRender.ChangePicture(display, picture, CreatePictureMask.None, new XRenderPictureAttributes());
            XRender.SetPictureFilter(display, picture, Filter.FilterConvolution, CreateGaussianKernel2D(10));
            XRender.SetPictureClipRectangles(display, picture, 0, 0, new[]{new XRectangle(5,5,5,5)});
            using(var rgn = Region.Create()) {
                XRender.SetPictureClipRegion(display, picture, rgn);
            }
            var xt = new XTransform();
            XRender.SetPictureTransform(display, picture, xt);
            var color = XRender.ParseColor(display, "green");
            XRender.FillRectangle(display, PictOp.Over, picture, color, 0, 0, 100, 100);
            XRender.FillRectangles(display, PictOp.Over, picture, color, new[]{new XRectangle(0,0,100,100)});
        }

        void CompositeFunc(Picture src, Picture dest, int width, int height) {
            var trapezoid = new XTrapezoid(
                TonNurako.X11.Xi.DoubleToFixed(30.0f),
                TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f),
                new XLineFixed(
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed(30.0f),
                        TonNurako.X11.Xi.DoubleToFixed(30.0f)),
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed(30.0f),
                        TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f))),
                new XLineFixed(
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed((double)width - 30.0f),
                        TonNurako.X11.Xi.DoubleToFixed(30.0f)),
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed((double)width -  30.0f),
                        TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f)))
            );

            var pfm = XRender.FindStandardFormat(display, PictStandard.A8);
            XRender.CompositeTrapezoid(display, PictOp.Over, src, dest, pfm, 0, 0, trapezoid);
            XRender.CompositeTrapezoids(display, PictOp.Over, src, dest, pfm, 0, 0, new[]{trapezoid, trapezoid});

            var triangle = new XTriangle(new XPointFixed(50, 0), new XPointFixed(100, 100), new XPointFixed(0, 100));
            XRender.CompositeTriangles(
                display, PictOp.Over, src, dest, pfm, 0, 0, new[]{triangle});

            XRender.CompositeTriStrip(
                display, PictOp.Over, src, dest, pfm, 0, 0, new[]{new XPointFixed(50, 0), new XPointFixed(100, 100), new XPointFixed(0, 100)});
            XRender.CompositeTriFan(
                display, PictOp.Over, src, dest, pfm, 0, 0, new[]{new XPointFixed(50, 0), new XPointFixed(100, 100), new XPointFixed(0, 100)});

            XRender.CompositeDoublePoly(
                display, PictOp.Over, src, dest, pfm, 0, 0, 0, 0, new[]{new XPointDouble(50, 0), new XPointDouble(100, 100), new XPointDouble(0, 100)}, 0);

            using(var pm = new Pixmap(display, window, width, height, 8))
            using(var mask = XRender.CreatePicture(
                    display, pm, XRender.FindStandardFormat(display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
            {
                XRender.Composite(display, PictOp.Src, src, mask, dest, 0, 0, 0, 0, 0, 0, width, height);
            }

        }

        void FillFunc(int width, int height) {
            var colors = new XRenderColor[] {
                new XRenderColor(0xffff, 0x0000, 0x0000, 0xffff),
                new XRenderColor(0x0000, 0xffff, 0x0000, 0xffff),
                new XRenderColor(0x0000, 0x0000, 0xffff, 0xffff),
            };

            var linearGradient = new XLinearGradient(
                new XPointFixed(TonNurako.X11.Xi.DoubleToFixed(0.0f), TonNurako.X11.Xi.DoubleToFixed(0.0f)),
                new XPointFixed(TonNurako.X11.Xi.DoubleToFixed(0.0f), TonNurako.X11.Xi.DoubleToFixed((double)height/10))
            );

            var conicalGradient = new XConicalGradient(
                    new XPointFixed(TonNurako.X11.Xi.DoubleToFixed((double)width/2), TonNurako.X11.Xi.DoubleToFixed((double)height/2)),
                    TonNurako.X11.Xi.DoubleToFixed(123.0f)
                );

            var radialGradient = new XRadialGradient(
                new XCircle(TonNurako.X11.Xi.DoubleToFixed(50.0f), TonNurako.X11.Xi.DoubleToFixed(50.0f), TonNurako.X11.Xi.DoubleToFixed(45.0f)),
                new XCircle(TonNurako.X11.Xi.DoubleToFixed(100.0f), TonNurako.X11.Xi.DoubleToFixed(75.0f), TonNurako.X11.Xi.DoubleToFixed(200.0f))
            );

            var colorStops = new int[] {
                TonNurako.X11.Xi.DoubleToFixed(0.0f),
                TonNurako.X11.Xi.DoubleToFixed(0.33f),
                TonNurako.X11.Xi.DoubleToFixed(0.66f),
                TonNurako.X11.Xi.DoubleToFixed(1.0f)
            };

            using(var g  = TonNurako.X11.Extension.XRender.CreateSolidFill(display, colors[0])) {
                Assert.NotNull(g);
            }

            using(var g  = TonNurako.X11.Extension.XRender.CreateConicalGradient(display, conicalGradient, colorStops, colors)) {
                Assert.NotNull(g);
            }
            using(var g  = TonNurako.X11.Extension.XRender.CreateLinearGradient(display, linearGradient, colorStops, colors)) {
                Assert.NotNull(g);
            }
            using(var g  = TonNurako.X11.Extension.XRender.CreateRadialGradient(display, radialGradient, colorStops, colors)) {
                Assert.NotNull(g);
            }
        }


         int[] CreateGaussianKernel2D(int radius) {
            double fU;
            double fV;
            int iX;
            int iY;
            double fSum = 0.0f;

            double fSigma = (double)radius / 2.0f;
            var fScale2 = 2.0f * fSigma * fSigma;
            var fScale1 = 1.0f / (Math.PI * fScale2);

            var size = 4 * radius * radius;
            var pTmpKernel = new double[size];

            for (iX = 0; iX < 2 * radius; iX++) {
                for (iY = 0; iY < 2 * radius; iY++) {
                    fU = (double)iX;
                    fV = (double)iY;
                    pTmpKernel[iX + iY * 2 * radius] = fScale1 *
                                    Math.Exp(-(fU * fU + fV * fV) / fScale2);
                }
            }

            for (iX = 0; iX < radius; iX++)
                fSum += pTmpKernel[iX];

            for (iX = 0; iX < radius; iX++)
                pTmpKernel[iX] /= fSum;

            var pKernel = new int[size + 2];

            for (iX = 0; iX < size; iX++)
                pKernel[iX + 2] = TonNurako.X11.Xi.DoubleToFixed(pTmpKernel[iX]);

            //*piSize += 2;
            pKernel[0] = TonNurako.X11.Xi.DoubleToFixed(2 * radius);
            pKernel[1] = TonNurako.X11.Xi.DoubleToFixed(2 * radius);

            return pKernel;
        }
    }
}
