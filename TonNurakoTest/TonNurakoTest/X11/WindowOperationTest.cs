using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Event;
using Xunit;

namespace TonNurakoTest.X11 {
    public class WindowOperationTest : IClassFixture<WindowFixture>, IDisposable {
        WindowFixture fix;
        Unity unity;
        public WindowOperationTest(WindowFixture fixture) {
            fix = fixture;
            unity = new Unity();
        }

        public void Dispose() {
            unity.Asset();
        }

        [Fact]
        public void InputFocus() {
            Assert.Equal(XStatus.True, fix.Display.SetInputFocus(fix.Window, RevertTo.Parent, 0));
            var f = fix.Display.GetInputFocus();
            Assert.NotNull(f);
            Assert.Equal(fix.Window.Handle, f.Window.Handle);

            using (var arg = new XEventArg()) {
                Assert.False(fix.Window.CheckWindowEvent(EventMask.ExposureMask, arg));
                Assert.False(fix.Window.CheckTypedWindowEvent(XEventType.Expose, arg));
            }

            Assert.Equal(XStatus.True, fix.Display.WarpPointer(null, fix.Window, 0, 0, 0, 0, 100, 100));

            Assert.NotNull(fix.Window.GetMotionEvents(0, 0));
        }

        [Fact]
        public void CursorTest() {
            var window = fix.Window;
            Assert.NotNull(window);
            using (var c = Cursor.CreateFontCursor(fix.Display, XCursorShape.XC_arrow)) {
                Assert.NotNull(c);
                Assert.Equal(XStatus.True, window.DefineCursor(c));
                Assert.Equal(XStatus.True, window.UndefineCursor());
            }
        }
    }
}
