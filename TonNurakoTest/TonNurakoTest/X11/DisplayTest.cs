using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TonNurakoTest.X11 {
    public class DisplayTest : IDisposable {

        TonNurako.X11.Display display;

        public DisplayTest() {
            display = null;

            TonNurako.Application.RegisterGlobals();
            TonNurako.X11.Xi.SetIOErrorHandler((dpy) => throw new Exception("IOE"));
            TonNurako.X11.Xi.SetErrorHandler((dpy, ev) => throw new Exception($"XError {ev.error_code}"));
        }

        public void Dispose() {
            if (display != null) {
                display.Close();
            }
        }

        [Fact]
        public void StandardSqeuence() {
            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Assert.True(TonNurako.X11.Xi.SupportsLocale());
            Assert.NotNull(TonNurako.X11.Xi.SetLocaleModifiers(""));

            var dpy = TonNurako.X11.Display.Open(null);
            Assert.NotNull(dpy);

            Assert.Equal(0, dpy.Close());
        }

        [Fact]
        public void DisplayContext() {
            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Assert.True(TonNurako.X11.Xi.SupportsLocale());
            Assert.NotNull(TonNurako.X11.Xi.SetLocaleModifiers(""));

            display = TonNurako.X11.Display.Open(null);
            Assert.NotNull(display);

            var dpy = display;

            
            Assert.NotNull(dpy.GetDisplayName());
            Assert.NotNull(dpy.DefaultColormap);
            Assert.NotNull(dpy.GetDefaultColormap(0));
            Assert.NotNull(dpy.GetRootWindow(0));
            Assert.NotNull(dpy.DefaultRootWindow);

            Assert.NotNull(dpy.GetScreenOfDisplay(0));
            Assert.NotNull(dpy.DefaultScreenOfDisplay);

            Assert.NotNull(dpy.DefaultVisual);
            Assert.NotNull(dpy.GetDefaultVisual(0));

            Assert.NotNull(dpy.ServerVendor);
            Assert.NotNull(dpy.DisplayString);

            var ks = dpy.KeysymToKeycode(TonNurako.X11.KeySym.XK_F5);
            Assert.NotEqual<uint>(0, ks);

            Assert.Equal(TonNurako.X11.KeySym.XK_F5, dpy.KeycodeToKeysym(ks, 0, 0));

            Assert.Equal(TonNurako.X11.KeySym.XK_F5, dpy.StringToKeysym("F5"));
            Assert.Equal("F5", dpy.KeysymToString(TonNurako.X11.KeySym.XK_F5));


        }

        [Fact]
        public void AbnormalSqeuence() {
            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Assert.True(TonNurako.X11.Xi.SupportsLocale());
            Assert.NotNull(TonNurako.X11.Xi.SetLocaleModifiers(""));

            var dpy = TonNurako.X11.Display.Open(@"ｳﾁｮﾑーﾁｮ");
            Assert.Null(dpy);
        }

    }
}
