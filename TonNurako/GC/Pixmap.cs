﻿//
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
        Drawable drawable = null;

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

        public Pixmap(Widgets.IWidget w, int width, int height, int depth) {
            
            drawable = new Drawable();
            //Display取得
			drawable.Display = XtSports.XtDisplay( w );

			//Window取得
			IntPtr window = XtSports.XtWindow( w );

            System.Diagnostics.Debug.WriteLine($"Pixmap window={window}<0x{w.NativeHandle.Widget:x}> width={width} height={height} depth={depth}");

            drawable.Target =
                X11Sports.XCreatePixmap(drawable.Display, window, (uint)width, (uint)height, (uint)depth);

            DestroyPixmapFunc = () => {
                X11Sports.XFreePixmap(drawable.Display, drawable.Target);
            };
        }
        internal Pixmap() {
            drawable = new Drawable();
        }

        public static Pixmap FromFile(Widgets.Xm.Primitive w, string path) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = XtSports.XtDisplay(w);
            pm.ScreenHandle = XtSports.XtScreen(w);
            pm.drawable.Target = (IntPtr)Native.Motif.XmSports.XmGetPixmap(pm.ScreenHandle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.drawable.Display, pm.drawable.Target);
            };
            return pm;
        }

        public static Pixmap FromFile(Widgets.Xm.Manager w, string path) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = XtSports.XtDisplay(w);
            pm.ScreenHandle = XtSports.XtScreen(w);
            var xpm = Native.Motif.XmSports.XmGetPixmap(pm.ScreenHandle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.drawable.Target = (IntPtr)xpm;
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.ScreenHandle, pm.drawable.Target);
            };
            return pm;
        }

        public static Pixmap FromBuffer(Widgets.IWidget w, byte[] buffer) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = XtSports.XtDisplay(w);
            pm.ScreenHandle = XtSports.XtScreen(w);
            pm.PixMax = new TNK_PIXMAX();

            IntPtr buf = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * (buffer.Length+1));
            Marshal.Copy(buffer, 0, buf, buffer.Length);
	        int r = NativeMethods.TNK_LoadPixmapFromBuffer(pm.drawable.Display, w.NativeHandle.Widget, ref pm.PixMax, buf);
            Marshal.FreeCoTaskMem(buf);
            if ( 0 != r) {
                return null;
            }

	        pm.drawable.Target = pm.PixMax.pix;
            pm.DestroyPixmapFunc = () => {
                NativeMethods.TNK_FreePixmapBuffer(ref pm.PixMax);
            };

            return pm;
        }


        public IntPtr ScreenHandle
        {
            get; internal set;
        }

        public Drawable Drawable
        {
            get {
                return drawable;
            }
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
            if (IntPtr.Zero != drawable.Target) {
                if (null != DestroyPixmapFunc) {
                    DestroyPixmapFunc();
                }
                drawable.Display = IntPtr.Zero;
                drawable.Target = IntPtr.Zero;
            }
        }
    }
}
