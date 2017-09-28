//
// ﾄﾝﾇﾗｺ
//
// 色
//

namespace TonNurako.Data
{
    public class Color {
        public byte R { get; set;}
        public byte G { get; set;}
        public byte B { get; set;}

        public uint Pixel {
            get; set;
        }

        private Widgets.IWidget Widget {
            get; set;
        }

        public Color(Widgets.IWidget widget) {
            this.Widget = widget;
        }

        public Color(TonNurako.Native.Xt.XColor xcolor) {
                //((koror >> 24) & 0xff),
                R = (byte)((xcolor.pixel >> 16) & 0xff);
                G = (byte)((xcolor.pixel >> 8) & 0xff);
                B = (byte)((xcolor.pixel) & 0xff);
                Pixel = (uint)xcolor.pixel;
        }

        public Color(TonNurako.Widgets.IWidget widget, string xcolor) {
            Native.Xt.XColor c = Native.ExtremeSports.XParseColor(widget, xcolor);
            SetWidgetColor((uint)c.pixel);
            this.Widget = widget;
        }

        public static Color FromName(TonNurako.Widgets.IWidget widget, string name) {
            return new Color(widget, name);
        }

        public TonNurako.Native.Xt.XColor ToXColor(TonNurako.Widgets.IWidget widget) {
            return Native.ExtremeSports.XAllocColor((null == widget.Handle) ? this.Widget : widget, R, G, B, 255);
        }

        public override string ToString() {
            return $"#{R:x2}{G:x2}{B:x2}";
        }

        internal Color(uint wgtColor) {
            SetWidgetColor(wgtColor);
            Pixel = wgtColor;
        }

        internal void SetWidgetColor(uint wgtColor) {
                R = (byte)((wgtColor >> 16) & 0xff);
                G = (byte)((wgtColor >> 8) & 0xff);
                B = (byte)((wgtColor) & 0xff);
                Pixel = wgtColor;
        }
    }
}
