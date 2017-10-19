using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11.Extension {
    [StructLayout(LayoutKind.Sequential)]
    internal struct XRenderDirectFormatRec {
        public short Red;
        public short RedMask;
        public short Green;
        public short GreenMask;
        public short Blue;
        public short BlueMask;
        public short Alpha;
        public short AlphaMask;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class XRenderDirectFormat {
        internal XRenderDirectFormatRec Record;
        internal XRenderDirectFormat(XRenderDirectFormatRec rec) {
            Record = rec;
        }

        public short Red => Record.Red;
        public short RedMask => Record.RedMask;
        public short Green => Record.Green;
        public short GreenMask => Record.GreenMask;
        public short Blue => Record.Blue;
        public short BlueMask => Record.BlueMask;
        public short Alpha => Record.Alpha;
        public short AlphaMask => Record.AlphaMask;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XRenderPictFormatRec {
        public PictFormat id;
        public int type;
        public int depth;
        public XRenderDirectFormatRec direct;
        public int colormap; //Colormap
    }

    public class XRenderPictFormat {
        internal XRenderPictFormatRec Record;
        internal XRenderDirectFormat direct;
        IntPtr ptr;

        Display display;
        internal Display Display => display;
        Colormap colormap;

        public XRenderPictFormat(Display dpy, IntPtr p) {
            ptr = p;
            display = dpy;
            Record = Marshal.PtrToStructure<XRenderPictFormatRec>(ptr);
            colormap = new Colormap(Record.colormap, dpy);
            direct = new XRenderDirectFormat(Record.direct);
        }

        public PictFormat Id => Record.id;
        public int Type => Record.type;
        public int Depth => Record.depth;
        public XRenderDirectFormat Direct => direct;
        public Colormap Colormap => colormap;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XRenderPictureAttributesRec {
        public bool repeat;
        public int alpha_map; // Picture = XID
        public int alpha_x_origin;
        public int alpha_y_origin;
        public int clip_x_origin;
        public int clip_y_origin;
        public IntPtr clip_mask; //Pixmap
        public bool graphics_exposures;
        public int subwindow_mode;
        public int poly_edge;
        public int poly_mode;
        public IntPtr dither; //Atom
        public bool component_alpha;
    }

    public class XRenderPictureAttributes {
        internal XRenderPictureAttributesRec Record;
        Pixmap clip_mask;
        Atom dither;

        public XRenderPictureAttributes() {
            Record = new XRenderPictureAttributesRec();
        }

        internal void Assign() {
            clip_mask = new Pixmap(Record.clip_mask, null);
            dither = new Atom(Record.dither);
        }

        public bool Repeat {
            get => Record.repeat;
            set => Record.repeat = value;
        }
        public int AlphaMap {
            get => Record.alpha_map; // Picture
            set => Record.alpha_map = value;
        }

        public int AlphaXOrigin {
            get => Record.alpha_x_origin;
            set => Record.alpha_x_origin = value;
        }

        public int AlphaYOrigin {
            get => Record.alpha_y_origin;
            set => Record.alpha_y_origin = value;
        }

        public int ClipXOrigin {
            get => Record.clip_x_origin;
            set => Record.clip_x_origin = value;
        }

        public int ClipYOrigin {
            get => Record.clip_y_origin;
            set => Record.clip_y_origin = value;
        }

        public Pixmap ClipMask {
            get => clip_mask;
            set {
                clip_mask = value;
                Record.clip_mask = value.Handle;
            }
        }

        public bool GraphicsExposures {
            get => Record.graphics_exposures;
            set => Record.graphics_exposures = value;
        }

        public int SubwindowMode {
            get => Record.subwindow_mode;
            set => Record.subwindow_mode = value;
        }

        public int PolyEdge {
            get => Record.poly_edge;
            set => Record.poly_edge = value;
        }

        public int PolyMode {
            get => Record.poly_mode;
            set => Record.poly_mode = value;
        }
        

        public Atom Dither {
            get => dither;
            set {
                dither = value;
                Record.dither = value.Handle;
            }
        }
        public bool ComponentAlpha {
            get => Record.component_alpha;
            set => Record.component_alpha = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XRenderColor {
        public ushort Red;
        public ushort Green;
        public ushort Blue;
        public ushort Alpha;

        public XRenderColor(ushort r, ushort g, ushort b, ushort a) {
            Red     = r;
            Green   = g;
            Blue    = b;
            Alpha   = a;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XGlyphInfo {
        public ushort width;
        public ushort height;
        public short x;
        public short y;
        public short xOff;
        public short yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XGlyphElt8 {
        public int glyphset; //GlyphSet=XID
        public IntPtr chars; // _Xconst char*
        public int nchars;
        public int xOff;
        public int yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGlyphElt16 {
        public int glyphset; //GlyphSet=XID
        public IntPtr chars; //unsigned short*
        public int nchars;
        public int xOff;
        public int yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGlyphElt32 {
        public int glyphset; //GlyphSet=XID
        public IntPtr chars; //int*
        public int nchars;
        public int xOff;
        public int yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XPointDouble {
        public double x, y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XPointFixed {
        public int X;
        public int Y;
        public XPointFixed(int x, int y) {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XLineFixed {
        public XPointFixed P1;
        public XPointFixed P2;

        public XLineFixed(XPointFixed p1, XPointFixed p2) {
            P1 = p1;
            P2 = p2;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTriangle {
        public XPointFixed p1, p2, p3;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XCircle {
        public int X;
        public int Y;
        public int Radius;
        public XCircle(int x, int y, int radius) {
            X = x;
            Y = y;
            Radius = radius;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTrapezoid {
        public int Top;
        public int Bottom;
        public XLineFixed Left;
        public XLineFixed Right;

        public XTrapezoid(int top, int bottom, XLineFixed left, XLineFixed right) {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XTransform {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 9)]
        public int[] matrix; //matrix[3][3]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XFilters {
        public int nfilter;
        public IntPtr filter; //char**
        public int nalias;
        public IntPtr alias; //short*
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XIndexValue {
        public ulong pixel;
        public ushort red, green, blue, alpha;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XAnimCursor {
        public int cursor; //Cursor
        public long delay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XSpanFix {
        public int left, right, y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTrap {
        public XSpanFix top, bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XLinearGradient {
        public XPointFixed P1;
        public XPointFixed P2;

        public XLinearGradient(XPointFixed x1, XPointFixed x2) {
            P1 = x1;
            P2 = x2;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XRadialGradient {
        public XCircle Inner;
        public XCircle Outer;

        public XRadialGradient(XCircle inner, XCircle outer) {
            Inner = inner;
            Outer = outer;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XConicalGradient {
        public XPointFixed Center;
        public int Angle; /* in degrees */

        public XConicalGradient(XPointFixed center, int angle) {
            Center = center;
            Angle = angle;
        }
    }
}
