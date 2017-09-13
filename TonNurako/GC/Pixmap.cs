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
    /// <summary>
    /// Pixmap
    /// </summary>
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

        internal Pixmap() {
            drawable = new Drawable();
        }


        /// <summary>
        /// 新規生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="depth">色深度</param>
        public Pixmap(Widgets.IWidget w, int width, int height, int depth) {

            drawable = new Drawable();
            //Display取得
			drawable.Display = w.NativeHandle.Display;

			//Window取得
			IntPtr window = w.NativeHandle.Window;
            
			System.Diagnostics.Debug.WriteLine($"Pixmap window={window}<0x{w.NativeHandle.Widget:x}> width={width} height={height} depth={depth}");
            
			drawable.Target =
                X11Sports.XCreatePixmap(drawable.Display, window, (uint)width, (uint)height, (uint)depth);
            System.Diagnostics.Debug.WriteLine($"Pixmap {drawable.Target}");


            DestroyPixmapFunc = () => {
                X11Sports.XFreePixmap(drawable.Display, drawable.Target);
            };
        }

        /// <summary>
        /// ﾌｧｲﾙから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromFile(Widgets.Xm.Primitive w, string path) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = XtSports.XtDisplay(w);
            pm.drawable.Screen = XtSports.XtScreen(w);
            pm.drawable.Target = (IntPtr)Native.Motif.XmSports.XmGetPixmap(pm.drawable.Screen, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.drawable.Display, pm.drawable.Target);
            };
            return pm;
        }

        /// <summary>
        /// ﾌｧｲﾙから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromFile(Widgets.Xm.Manager w, string path) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = XtSports.XtDisplay(w);
            pm.drawable.Screen = XtSports.XtScreen(w);
            var xpm = Native.Motif.XmSports.XmGetPixmap(pm.drawable.Screen, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.drawable.Target = (IntPtr)xpm;
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.drawable.Screen, pm.drawable.Target);
            };
            return pm;
        }

        /// <summary>
        /// ﾊﾞｯﾌｧーから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="buffer">ﾊﾞｯﾌｧー</param>
        /// <returns></returns>
        public static Pixmap FromBuffer(Widgets.IWidget w, byte[] buffer) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = XtSports.XtDisplay(w);
            pm.drawable.Screen = XtSports.XtScreen(w);
            pm.PixMax = new TNK_PIXMAX();

            IntPtr buf = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * (buffer.Length+1));
            Marshal.Copy(buffer, 0, buf, buffer.Length);
	        int r = NativeMethods.TNK_LoadPixmapFromBuffer(pm.drawable.Display, w.NativeHandle.Widget, ref pm.PixMax, buf);
            Marshal.FreeCoTaskMem(buf);
            if ( 0 != r) {
                pm = null;
                return null;
            }

	        pm.drawable.Target = pm.PixMax.pix;
            pm.DestroyPixmapFunc = () => {
                NativeMethods.TNK_FreePixmapBuffer(ref pm.PixMax);
            };

            return pm;
        }

        /// <summary>
        /// XImageから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromXImage(Widgets.IWidget w, XImage image) {
            var pm = new Pixmap(w, image.Width, image.Height, image.Depth);
            using (GraphicsContext gc = new GraphicsContext(pm)) {
                gc.PutImage(image);
            }
            return pm;
        }

        /// <summary>
        /// Bitmapから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromBitmap(Widgets.IWidget w, System.Drawing.Bitmap bitmap) {
            var pm = new Pixmap(w, bitmap.Width, bitmap.Height, 24);
            using(var image = XImage.FromBitmap(w, bitmap))
            using(var gc = new GraphicsContext(pm)) {
                gc.PutImage(image);
            }
            return pm;
        }

        public Drawable Drawable
        {
            get {
                return drawable;
            }
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~Pixmap() {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IntPtr.Zero != drawable.Target) {
                if (null != DestroyPixmapFunc) {
                    DestroyPixmapFunc();
                }
                drawable.Display = IntPtr.Zero;
                drawable.Target = IntPtr.Zero;
                drawable.Screen = IntPtr.Zero;
            }
        }
        #endregion
    }
}
