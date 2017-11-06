using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class VisualTest : AbstractSingleWindowTest {
        public VisualTest() : base() {
        }
        protected override void BeforeMapWindow() {
        }

        public override void Dispose() {
            base.Dispose();
        }

        [Fact]
        public void ServerProps() {
            Open();
            try {
                var v = display.DefaultVisual;
                Assert.NotNull(v);
            }
            finally {
                Close();
            }
        }
    }
}
