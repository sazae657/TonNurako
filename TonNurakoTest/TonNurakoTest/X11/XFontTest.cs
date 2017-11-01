using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class XFontTest : IDisposable {

        TonNurako.X11.Display display = null;

        public XFontTest() {
            TonNurako.Application.RegisterGlobals();
            TonNurako.X11.Xi.SetIOErrorHandler((dpy) => throw new Exception("IOE"));
            TonNurako.X11.Xi.SetErrorHandler((dpy, ev) => throw new Exception($"XError {ev.error_code}"));
            TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, "");
            TonNurako.X11.Xi.SupportsLocale();
            TonNurako.X11.Xi.SetLocaleModifiers("");
            display = TonNurako.X11.Display.Open(null);
        }

        public void Dispose() {
            if (display != null) {
                display.Close();
            }
        }

        [Fact]
        public void FontSetTest() {

            
            Assert.ThrowsAny<System.Exception>(() => FontSet.ListFonts(display, "【神】俺様が考えたすごいフォント【降臨】", 100));
            Assert.NotNull(FontSet.ListFonts(display, "*", 10));

            Assert.ThrowsAny<System.Exception>(() => FontSet.CreateFontSet(display, "【神】俺様が考えたすごいフォント【降臨】"));
            var fs = TonNurako.X11.FontSet.CreateFontSet(display, "*misc*");
            Assert.NotNull(fs);

            /*var rc1 = new TonNurako.X11.TextExtents();
            var r = fs.TextExtentsMultiByte("A", rc1);

            var rc2 = new TonNurako.X11.TextExtents();
            Assert.Equal(0, fs.TextExtents("A", rc2));
            //Assert.True(rc1.Equals(rc2));
            */

            using (var xe = fs.XExtentsOfFontSet()) {
                Assert.NotNull(xe);
            }

            fs.Dispose();
        }

    }
}
