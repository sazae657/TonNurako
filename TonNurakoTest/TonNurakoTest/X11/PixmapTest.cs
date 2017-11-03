using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class PixmapTest : AbstractSingleWindowTest {
        public PixmapTest() : base() {
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
        public void StandardPixmap() {
            using(var pm = new Pixmap(display, window, 100, 100, display.DefaultDepth)) {
            }
            using(var pm = new Pixmap(window, 100, 100, display.DefaultDepth)) {
            }
        }
    }
}
