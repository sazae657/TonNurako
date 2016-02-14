//
// ﾄﾝﾇﾗｺ
//
// GC
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Native.X11;
using TonNurako.Native.Xt;
namespace TonNurako.GC
{
    public class Pixmap : IDrawable, IDisposable {

        internal delegate void SysDestroyPixmap();

        internal SysDestroyPixmap DestroyPixmapFunc = null;

        [StructLayout(LayoutKind.Sequential)]
        internal struct TNK_PIXMAX
        {
            public IntPtr display;
            public IntPtr pix;
            public IntPtr mask;
            public IntPtr attr;
        };
        internal TNK_PIXMAX PixMax = new TNK_PIXMAX();

        internal static class NativeMethods {

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_LoadPixmapFromBuffer", CharSet=CharSet.Auto)]
            internal static extern int TNK_LoadPixmapFromBuffer(
                        IntPtr display,
                        IntPtr widget,
                        [In,Out]ref TNK_PIXMAX pixmax,
                        [In]IntPtr buffer
                        );

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_FreePixmapBuffer", CharSet=CharSet.Auto)]
            internal static extern void TNK_FreePixmapBuffer([In,Out]ref TNK_PIXMAX pixmax);

        }

        public Pixmap(Widgets.IWidget w, uint width, uint height, uint depth) {
            //Display取得
			DisplayHandle = XtSports.XtDisplay( w );

			//Window取得
			IntPtr window = XtSports.XtWindow( w );

            System.Diagnostics.Debug.WriteLine($"Pixmap window={window}<0x{w.NativeHandle.Widget:x}> width={width} height={height} depth={depth}");

            DrawableHandle =
                X11Sports.XCreatePixmap(DisplayHandle, window, width, height, depth);

            DestroyPixmapFunc = () => {
                X11Sports.XFreePixmap(DisplayHandle, DrawableHandle);
            };
        }
        internal Pixmap() {
        }

        public static Pixmap FromFile(Widgets.Xm.Primitive w, string path) {
            Pixmap pm = new Pixmap();
            pm.DisplayHandle = XtSports.XtDisplay(w);
            pm.ScreenHandle = XtSports.XtScreen(w);
            pm.DrawableHandle = (IntPtr)Native.Motif.XmSports.XmGetPixmap(pm.ScreenHandle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.DisplayHandle, pm.DrawableHandle);
            };
            return pm;
        }

        public static Pixmap FromFile(Widgets.Xm.Manager w, string path) {
            Pixmap pm = new Pixmap();
            pm.DisplayHandle = XtSports.XtDisplay(w);
            pm.ScreenHandle = XtSports.XtScreen(w);
            var xpm = Native.Motif.XmSports.XmGetPixmap(pm.ScreenHandle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.DrawableHandle = (IntPtr)xpm;
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.ScreenHandle, pm.DrawableHandle);
            };
            return pm;
        }

        public static Pixmap FromBuffer(Widgets.IWidget w, byte[] buffer) {
            Pixmap pm = new Pixmap();
            pm.DisplayHandle = XtSports.XtDisplay(w);
            pm.ScreenHandle = XtSports.XtScreen(w);
            pm.PixMax = new TNK_PIXMAX();

            IntPtr buf = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * (buffer.Length+1));
            Marshal.Copy(buffer, 0, buf, buffer.Length);
	        int r = NativeMethods.TNK_LoadPixmapFromBuffer(pm.DisplayHandle, w.NativeHandle.Widget, ref pm.PixMax, buf);
            Marshal.FreeCoTaskMem(buf);
            if ( 0 != r) {
                return null;
            }

	        pm.DrawableHandle = pm.PixMax.pix;
            pm.DestroyPixmapFunc = () => {
                NativeMethods.TNK_FreePixmapBuffer(ref pm.PixMax);
            };

            return pm;
        }

        public IntPtr DisplayHandle
        {
            get; internal set;
        }

        public IntPtr DrawableHandle
        {
            get; internal set;
        }

        public IntPtr ScreenHandle
        {
            get; internal set;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~Pixmap() {
            Dispose(false);
        }

        internal virtual void Dispose(bool disposing)
        {
            if (IntPtr.Zero != DrawableHandle) {
                if (null != DestroyPixmapFunc) {
                    DestroyPixmapFunc();
                }
                DisplayHandle = IntPtr.Zero;
                DrawableHandle = IntPtr.Zero;
            }
        }
    }
}
