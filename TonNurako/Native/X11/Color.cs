using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {

    [StructLayout(LayoutKind.Sequential)]
    public struct XColor {
        public ulong pixel;
        public ushort red;
        public ushort green;
        public ushort blue;
        public char flags;
        public char pad;
    };

    #region ColorCell
    // TODO: PseudoColorな環境が要る
    public class ColorCell : IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocColorCells_TNK", CharSet = CharSet.Auto)]
            internal static extern int XAllocColorCells(
                IntPtr display, int colormap, [MarshalAs(UnmanagedType.U1)] bool contig, 
                [In, Out] ulong[] plane_masks_return, uint nplanes, [In, Out] ulong[] pixels_return, uint npixels);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeColors_TNK", CharSet = CharSet.Auto)]
            internal static extern int XFreeColors(IntPtr display, int colormap, [In] ulong[] pixels, int npixels, ulong planes);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocColorPlanes_TNK", CharSet = CharSet.Auto)]
            internal static extern int XAllocColorPlanes(IntPtr display, int colormap, 
                [MarshalAs(UnmanagedType.U1)] bool contig, out IntPtr pixels_return, int ncolors, int nreds, int ngreens, int nblues, out IntPtr rmask_return, out IntPtr gmask_return, out IntPtr bmask_return);

        }

        Colormap colormap;
        Display display;

        public ColorCell(Display display, Colormap colormap, int masks, int pixels) {
            this.colormap = colormap;
            this.display = display;
            this.masks = new ulong[masks];
            this.pixels = new ulong[pixels];
        }

        ulong[] masks;
        public ulong[] Masks => masks;

        ulong[] pixels;
        public ulong[] Pixels => pixels;

        public static ColorCell AllocColorCells(
            Display display, Colormap colormap, int masks, int pixels) {

            if (display.DefaultVisual.Class != VisualClass.PseudoColor) {
                throw new System.ArgumentException($"この環境ではｶﾗーｾﾙは使えないよ: {display.DefaultVisual.Class}");
            }

            var r = new ColorCell(display, colormap, masks, pixels);
            var res = NativeMethods.XAllocColorCells(display.Handle, colormap.Handle, true,
                r.masks, (uint)masks,
                r.pixels, (uint)pixels);
            if (XStatus.True != res) {
                throw new System.ArgumentException($"XAllocColorCells FAILED R/C={res}");
            }
            return r;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                NativeMethods.XFreeColors(
                    display.Handle, colormap.Handle, pixels, pixels.Length, (ulong)masks.Length);
                disposedValue = true;
            }
        }


        // ~ColorCell() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
    #endregion

    public class Color : IX11Interop<ulong> {

        internal static class NativeMethods {
            // Status: XAllocColor [{'type': 'Display*', 'name': 'display'}, {'type': 'Colormap', 'name': 'colormap'}, {'type': 'XColor*', 'name': 'screen_in_out'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocColor_TNK", CharSet = CharSet.Auto)]
            internal static extern int XAllocColor(IntPtr display, int colormap, [In,Out] ref XColor screen_in_out);

            // Status: XAllocNamedColor [{'type': 'Display*', 'name': 'display'}, {'type': 'Colormap', 'name': 'colormap'}, {'type': 'char*', 'name': 'color_name'}, {'type': 'XColor*', 'name': 'screen_def_return'}, {'type': 'XColor*', 'name': 'exact_def_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocNamedColor_TNK", CharSet = CharSet.Auto)]
            internal static extern int XAllocNamedColor(IntPtr display, int colormap, [MarshalAs(UnmanagedType.LPStr)] string color_name, out XColor screen_def_return, out XColor exact_def_return);
        }

        public ulong Handle => color.pixel;

        XColor color;
        public XColor XColor => color;

        public ulong Pixel => color.pixel;

        Colormap colormap;
        Display display;

        public Color() {
            colormap = null;
            display = null;
            color = new XColor();
        }

        public Color(Display dpy, Colormap cmap) {
            colormap = cmap;
            display = dpy;
        }

        public static Color AllocNamedColor(Display dpy, Colormap cmap, string name) {
            var near = new XColor();
            var far  = new XColor();
            NativeMethods.XAllocNamedColor(dpy.Handle, cmap.Handle, name, out near, out far);
            var k = new Color(dpy, cmap);
            k.color = near;
            return k;
        }

        public static Color AllocColor(Display dpy, Colormap cmap, int r, int g, int b) {
            var k = new Color(dpy, cmap);
            k.color.red = (ushort)(256*r);
            k.color.green = (ushort)(256 * g);
            k.color.blue = (ushort)(256 * b);
            if (XStatus.True != NativeMethods.XAllocColor(dpy.Handle, cmap.Handle, ref k.color)) {
                throw new System.ArgumentException($"r#{r} g#{g} #b{b}");
            }
            return k;
        }

    }
}
