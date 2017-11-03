using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;
using TonNurako.X11.Extension;

namespace TonNurakoTest.X11.Ext {
    public class RenderTest : AbstractSingleWindowTest {
        public RenderTest() : base() {
        }
        protected override void BeforeMapWindow() {
            var attr = new TonNurako.X11.XSetWindowAttributes();
            attr.backing_store = TonNurako.X11.BackingStoreHint.WhenMapped;
            Assert.Equal(XStatus.True, window.ChangeWindowAttributes(TonNurako.X11.ChangeWindowAttributes.CWBackingStore, attr));
        }

        public override void Dispose() {
            base.Dispose();
        }

        [Fact]
        public void StandardFunction() {
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

        }

    }
}
