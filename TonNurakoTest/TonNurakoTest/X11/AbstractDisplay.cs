using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public abstract class AbstractDisplayTest : IDisposable {
        protected Display display{get;private set;} = null;

        public AbstractDisplayTest() {
            TonNurako.Application.RegisterGlobals();
            TonNurako.X11.Xi.SetIOErrorHandler((dpy) => throw new Exception("IOE"));
            TonNurako.X11.Xi.SetErrorHandler((dpy, ev) => throw new Exception($"XError {ev.error_code}"));
            Open();
        }

        public void Open() {
            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));

            display = TonNurako.X11.Display.Open(null);
            Assert.NotNull(display);
        }

        public void Close() {
            if (display != null) {
                Assert.True(display.Close() >= 0);
                display = null;
            }
            else {
                throw new NullReferenceException("display is NULL");
            }
            System.Threading.Thread.Sleep(10);
        }

        public virtual void Dispose() {
            Close();
        }
    }
}
