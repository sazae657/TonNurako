using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class EmptyWindowRule : AbstractSingleWindowTest {
        public EmptyWindowRule() : base() {
        }

        protected override void BeforeCreateWindow() {
        }

        protected override void BeforeMapWindow() {
        }

        protected override void AfterMapWindow() {
        }

        public override void Dispose() {
            base.Dispose();
        }

        [Fact]
        public void EmptyRule() {
        }
    }
}
