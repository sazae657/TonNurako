using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Extension.Xft;
using Xunit;

namespace TonNurakoTest.X11 {
    static class Extensions {
        public static IEnumerable<uint> GetUTF32CodePoints(this string s) {
            for (int i = 0; i < s.Length; i++) {
                int unicodeCodePoint = char.ConvertToUtf32(s, i);
                if (unicodeCodePoint > 0xffff) {
                    i++;
                }
                yield return (uint)unicodeCodePoint;
            }
        }
    }
    public class XftTest : AbstractSingleWindowTest {
        public XftTest() : base() {
        }

        public override void Dispose() {
            unity.Asset();
            base.Dispose();
        }

        protected override void BeforeCreateWindow() {
            Assert.True(FontConfig.Reinitialize());
        }


        const string UNCODE = "💩";
        const uint   UNCODE_C = 0x0001F4A9;
        const string UNICODE_S = "ぉ";
        const uint   UNICODE_C = 0x00003049;

        const string STRING = "AAAA";

        void StandardRule() {
            Open();
            try {
                var font = new XftFont[4];
                for (int i = 1; i < font.Length + 1; ++i) {
                    font[i - 1] =
                        XftFont.OpenName(display, display.DefaultScreen, $"IPAGothic:style=Regular:size={16 * i}");
                    Assert.NotNull(font[i - 1]);
                }
                unity.Store<XftFont>(font);

                Assert.True(font[0].CharExists(UNICODE_S));
                Assert.True(font[0].CharExists(UNICODE_C));
                Assert.NotEqual(0, (int)font[0].CharIndex(UNICODE_S));
                Assert.NotEqual(0, (int)font[0].CharIndex(UNICODE_C));
                Assert.Equal(font[0].CharIndex(UNICODE_S), font[0].CharIndex(UNICODE_C));
            }
            finally {
                unity.Asset();
                Close();
            }
        }

        [Fact]
        void ColorTest() {
            Open();
            try {
                Assert.NotNull(
                    unity.Store(XftColor.AllocName(display, display.DefaultVisual, display.DefaultColormap, "green")));

                Assert.NotNull(
                    unity.Store(XftColor.AllocValue(display, display.DefaultVisual, display.DefaultColormap,
                        new TonNurako.X11.Extension.XRenderColor(0x0000, 0xffff, 0x0000, 0xffff)))
                );
            }
            finally {
                unity.Asset();
                Close();
            }
        }

        public void DrawTest() {
            Open();
            try {
                using (var font = XftFont.OpenName(display, display.DefaultScreen, ":style=Regular")) {
                    Assert.NotNull(font);
                    DrawPrimitive(window, font);
                }
            }
            finally {
                Close();
            }
        }

        void DrawPrimitive(IDrawable drawable, XftFont font) {
            var color = unity.Store(XftColor.AllocName(display, display.DefaultVisual, display.DefaultColormap, "green"));
            Assert.NotNull(color);
            using (var d = XftDraw.Create(display, drawable, display.DefaultVisual, display.DefaultColormap.Handle)) {
                Assert.NotNull(d);
                //Assert.NotNull(
                //8    unity.Store(d.SrcPicture(XftColor.AllocName(display, display.DefaultVisual, display.DefaultColormap, "green"))));
                d.DrawString(color, font, 10, 10, STRING);
                d.DrawString16(color, font, 0, 0, STRING);


                var ar = Encoding.UTF8.GetBytes(STRING);
                d.DrawString8(color, font, 0, 0, ar);
                d.DrawStringUtf16(color, font, 0, 0, STRING);

                var chars = new XftCharSpec[STRING.Length];
                int k = 0;
                foreach (var u in STRING.GetUTF32CodePoints()) {
                    chars[k] = new XftCharSpec(u, (short)k, (short)k);
                    k++;
                }
                d.DrawCharSpec(color, font, chars);

                var cfs = new XftCharFontSpec[STRING.Length];
                k = 0;
                foreach (var u in STRING.GetUTF32CodePoints()) {
                    cfs[k] = new XftCharFontSpec(font, u, (short)k, (short)k);
                    k++;
                }
                d.DrawCharFontSpec(color, cfs);
            }
            unity.Asset();
        }



    }
}