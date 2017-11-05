using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Extension;
using Xunit;

namespace TonNurakoTest.X11 {
    public class ShapeTest : AbstractSingleWindowTest {
        public ShapeTest() : base() {
        }

        public override void Dispose() {
            base.Dispose();
        }

        [Fact]
        public void StandardRule() {
            Assert.True(XShape.QueryExtension(display));
            Assert.NotNull(XShape.QueryVersion(display));
            using(var pm = new Pixmap(window, 80, 80, 1)) {
                XShape.CombineMask(display, window, ShapeKind.ShapeBounding, 0, 0, pm, ShapeOp.ShapeSet);
            }
            XShape.CombineRectangles(display, window, ShapeKind.ShapeBounding, 0, 0,
                new[]{new XRectangle(0, 0, 10, 10), new XRectangle(10, 10, 10, 10)}, ShapeOp.ShapeSet, Ordering.Unsorted);
            XShape.OffsetShape(display, window, ShapeKind.ShapeBounding, 0, 0);
            Assert.Equal(ShapeEventMask.None, XShape.InputSelected(display, window));
            XShape.SelectInput(display, window, ShapeEventMask.ShapeNotifyMask);
            Assert.Equal(ShapeEventMask.ShapeNotifyMask, XShape.InputSelected(display, window));
        }
    }
}
