using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Extension.Xft;
using Xunit;

namespace TonNurakoTest.X11 {
    public class XftTest : AbstractSingleWindowTest {
        public XftTest() : base() {
        }

        public override void Dispose() {
            unity.Asset();
            base.Dispose();
        }

        [Fact]
        public void StandardRule() {
            var font = new XftFont[4];
            for (int i = 1; i < font.Length + 1; ++i) {
                font[i - 1] =
                    XftFont.OpenName(display, display.DefaultScreen, $":size={16 * i}");
                Assert.NotNull(font[i - 1]);
            }
            unity.Store<XftFont>(font);

        }
        [Fact]
        public void ColorTest() {
            Assert.NotNull(
                unity.Store(XftColor.AllocName(display, display.DefaultVisual, display.DefaultColormap, "green"))
            );

            Assert.NotNull(
                unity.Store(XftColor.AllocValue(display, display.DefaultVisual, display.DefaultColormap,
                    new TonNurako.X11.Extension.XRenderColor(0x0000, 0xffff, 0x0000, 0xffff)))
            );
        }

    }
}