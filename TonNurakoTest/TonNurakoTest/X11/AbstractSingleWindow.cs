using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public abstract class AbstractSingleWindowTest : IDisposable {
        protected Display display { get; private set; }
        protected Window window { get; private set; }
        protected Unity unity { get; private set; }

        public AbstractSingleWindowTest() {
            unity = new Unity();
            TonNurako.Application.RegisterGlobals();
            TonNurako.X11.Xi.SetIOErrorHandler((dpy) => throw new Exception("IOE"));
            TonNurako.X11.Xi.SetErrorHandler((dpy, ev) => throw new Exception($"XError {ev.error_code}"));

            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Assert.True(TonNurako.X11.Xi.SupportsLocale());
            Assert.NotNull(TonNurako.X11.Xi.SetLocaleModifiers(""));
        }

        protected virtual void BeforeCreateWindow() {
        }

        protected virtual void BeforeMapWindow() {
        }

        protected virtual void AfterMapWindow() {
        }

        public void Open() {
            this.display = TonNurako.X11.Display.Open(null);
            Assert.NotNull(this.display);

            var visual = this.display.DefaultVisual;
            Assert.NotNull(visual);

            var wsa = new TonNurako.X11.XSetWindowAttributes();
            wsa.background_pixel = this.display.WhitePixel;
            wsa.event_mask = TonNurako.X11.EventMask.ExposureMask;
            var wam = TonNurako.X11.ChangeWindowAttributes.CWEventMask|TonNurako.X11.ChangeWindowAttributes.CWBackPixel;

            BeforeCreateWindow();

            this.window = this.display.CreateWindow(
                this.display.DefaultRootWindow, 50, 50, 50, 50, 0,
                this.display.DefaultDepth, TonNurako.X11.WindowClass.InputOutput, visual, wam, wsa);
            Assert.NotNull(this.window);

            BeforeMapWindow();

            Assert.Equal(XStatus.True, this.window.MapWindow());
            Assert.Equal(XStatus.True, display.Flush());
            window.ClearWindow();

            AfterMapWindow();
        }

        public void Close() {
            unity.Asset();
            if (null != this.window) {
                this.window.DestroyWindow();
                this.window = null;
            }

            if (display != null) {
                display.Sync(true);
                Assert.True(display.Close() >= 0);
                display = null;
            }
            Thread.Sleep(10);
        }

        public virtual void Dispose() {
            Close();
        }
    }
}
