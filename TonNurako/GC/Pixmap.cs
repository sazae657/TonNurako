//
// ﾄﾝﾇﾗｺ
//
// GC
//
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Native.X11;
using TonNurako.Native.Xt;
using TonNurako.XImageFormat;

namespace TonNurako.GC
{
    /// <summary>
    /// XPM用の原色実装
    /// </summary>
    public class X11ColorResolver :
        TonNurako.XImageFormat.I原色 {

        public X11ColorResolver(Widgets.IWidget widget) {
            Widget = widget;
            colorMap = new Dictionary<string, XImageFormat.Xi.ぉ>();
        }

        public X11ColorResolver(Widgets.IWidget widget, XImageFormat.Xi.ぉ bg, XImageFormat.Xi.ぉ fg) {
            Widget = widget;
            colorMap = new Dictionary<string, XImageFormat.Xi.ぉ>();
        }

        Dictionary<string, XImageFormat.Xi.ぉ> colorMap;

        Widgets.IWidget Widget;

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.Black => Lookup(XImageFormat.Xi.ColorFormat.Name, "black");

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.White => Lookup(XImageFormat.Xi.ColorFormat.Name, "white");

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.None => Lookup(XImageFormat.Xi.ColorFormat.Name, "none");

        XImageFormat.Xi.ぉ
            XImageFormat.I原色.Foreground => Lookup(XImageFormat.Xi.ColorFormat.Name, "foreground");

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.Background => Lookup(XImageFormat.Xi.ColorFormat.Name, "background");


        public TonNurako.XImageFormat.Xi.ぉ Lookup(XImageFormat.Xi.ColorFormat fmt, string color) {
            var key = color.ToLower();
            if (colorMap.ContainsKey(key)) {
                return colorMap[key];
            }
            var c = Data.Color.FromName(Widget, color);

            var k = new XImageFormat.Xi.ぉ(c.R, c.G, c.B);
            colorMap.Add(key, k);
            return k;
        }

    }

    /// <summary>
    /// Pixmap
    /// </summary>
    public class Pixmap : IDrawable, IDisposable {

        internal delegate void SysDestroyPixmap();

        internal SysDestroyPixmap DestroyPixmapFunc = null;

#if TNK_USE_LIBXPM
        [StructLayout(LayoutKind.Sequential)]
        internal struct TNK_PIXMAX
        {
            public IntPtr display;
            public IntPtr pix;
            public IntPtr mask;
            public IntPtr attr;
        };
        internal TNK_PIXMAX PixMax = new TNK_PIXMAX();
#endif
        Drawable drawable = null;


        internal static class NativeMethods {
#if TNK_USE_LIBXPM
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_LoadPixmapFromBuffer", CharSet=CharSet.Auto)]
            internal static extern int TNK_LoadPixmapFromBuffer(
                        IntPtr display,
                        IntPtr widget,
                        [In,Out]ref TNK_PIXMAX pixmax,
                        [In]IntPtr buffer
                        );

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_FreePixmapBuffer", CharSet=CharSet.Auto)]
            internal static extern void TNK_FreePixmapBuffer([In,Out]ref TNK_PIXMAX pixmax);
#endif

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
			drawable.Display = w.Handle.Display;

			//Window取得
			IntPtr window = w.Handle.Window.Handle;

			System.Diagnostics.Debug.WriteLine($"Pixmap window={window}<0x{w.Handle.Widget.Handle:x}> width={width} height={height} depth={depth}");

			drawable.Target =
                X11Sports.XCreatePixmap(drawable.Display, window, (uint)width, (uint)height, (uint)depth);
            System.Diagnostics.Debug.WriteLine($"Pixmap {drawable.Target}");


            DestroyPixmapFunc = () => {
                X11Sports.XFreePixmap(drawable.Display, drawable.Target);
            };
        }

		/// <summary>
        /// 新規生成2
        /// </summary>
        /// <param name="display">ﾃﾞｽﾌﾟﾚー</param>
        /// <param name="window">ｳｲﾝﾄﾞー</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="depth">色深度</param>
        public Pixmap(Display display, Window window, int width, int height, int depth) {
            drawable = new Drawable();
			drawable.Display = display;

			System.Diagnostics.Debug.WriteLine($"Pixmap(N) window=<0x{window.Handle:x}> display=<0x{display.Handle:x}> width={width} height={height} depth={depth}");

			drawable.Target =
                X11Sports.XCreatePixmap(drawable.Display, window.Handle, (uint)width, (uint)height, (uint)depth);
            System.Diagnostics.Debug.WriteLine($"Pixmap(N) <{drawable.Target}>");

            DestroyPixmapFunc = () => {
				System.Diagnostics.Debug.WriteLine($"Pixmap(N) Dispose <{drawable.Target}>");
                X11Sports.XFreePixmap(drawable.Display, drawable.Target);
            };
        }


        /// <summary>
        /// ﾌｧｲﾙから生成(Motif)
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromFile(Widgets.Xm.Primitive w, string path) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = new TonNurako.Native.X11.Display(w);
            pm.drawable.Screen = new TonNurako.Native.X11.Screen(w);
            pm.drawable.Target = (IntPtr)Native.Motif.XmSports.XmGetPixmap(pm.drawable.Screen.Handle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.drawable.Display.Handle, pm.drawable.Target);
            };
            return pm;
        }

        /// <summary>
        /// ﾌｧｲﾙから生成(Motif)
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromFile(Widgets.Xm.Manager w, string path) {
            Pixmap pm = new Pixmap();
            pm.drawable.Display = new Display(w);
            pm.drawable.Screen = new Screen(w);
            var xpm = Native.Motif.XmSports.XmGetPixmap(pm.drawable.Screen.Handle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.drawable.Target = (IntPtr)xpm;
            pm.DestroyPixmapFunc = () => {
                Native.Motif.XmSports.XmDestroyPixmap(pm.drawable.Screen.Handle, pm.drawable.Target);
            };
            return pm;
        }

        /// <summary>
        /// ﾊﾞｯﾌｧーから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="buffer">ﾊﾞｯﾌｧー</param>
        /// <returns></returns>
        public static Pixmap FromXpm(Widgets.IWidget w, byte[] buffer) {
            var loader = new XImageFormat.XpmLoader(new X11ColorResolver(w));
            XImageFormat.Xpm 画像 = null;
            using (var ms = new System.IO.MemoryStream(buffer)) {
                画像 = loader.Load(ms);
            }

            var buf = 画像.Toぉ();
            var mp = XImageFormat.Xi.おやさい.原色配列に変換(
                    XImageFormat.Xi.ぉ.画素.B,
                    XImageFormat.Xi.ぉ.画素.G,
                    XImageFormat.Xi.ぉ.画素.R,
                    XImageFormat.Xi.ぉ.画素.A, ref buf);
            TonNurako.GC.Pixmap pixmap = null;
            using (
                var img = TonNurako.GC.XImage.FromBuffer(w, mp, 画像.Width, 画像.Height, 24, 32)) {
                pixmap = TonNurako.GC.Pixmap.FromXImageEx(w, img);
            }
            return pixmap;

#if TNK_USE_LIBXPM
            IntPtr buf = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * (buffer.Length+1));
            Marshal.Copy(buffer, 0, buf, buffer.Length);
	        int r = NativeMethods.TNK_LoadPixmapFromBuffer(pm.drawable.Display.Handle, w.Handle.Widget.Handle, ref pm.PixMax, buf);
            Marshal.FreeCoTaskMem(buf);
            if ( 0 != r) {
                pm = null;
                return null;
            }

	        pm.drawable.Target = pm.PixMax.pix;
            pm.DestroyPixmapFunc = () => {
                NativeMethods.TNK_FreePixmapBuffer(ref pm.PixMax);
            };
#endif
        }

        /// <summary>
        /// ﾌｧｲﾙから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="buffer">ﾊﾞｯﾌｧー</param>
        /// <returns></returns>
        public static Pixmap FromXpm(Widgets.IWidget w, string path) {
            var loader = new XImageFormat.XpmLoader(new X11ColorResolver(w));
            XImageFormat.Xpm 画像 = null;
            using (var ms = new System.IO.FileStream(path, System.IO.FileMode.Open)) {
                画像 = loader.Load(ms);
            }

            var buf = 画像.Toぉ();
            var mp = XImageFormat.Xi.おやさい.原色配列に変換(
                    XImageFormat.Xi.ぉ.画素.B,
                    XImageFormat.Xi.ぉ.画素.G,
                    XImageFormat.Xi.ぉ.画素.R,
                    XImageFormat.Xi.ぉ.画素.A, ref buf);
            TonNurako.GC.Pixmap pixmap = null;
            using (
                var img = TonNurako.GC.XImage.FromBuffer(w, mp, 画像.Width, 画像.Height, 24, 32)) {
                pixmap = TonNurako.GC.Pixmap.FromXImageEx(w, img);
            }
            return pixmap;
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
        /// XImageから生成 (Root)
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromXImageEx(Widgets.IWidget w, XImage image) {
            var pm = new Pixmap(w.Handle.Display,
                w.Handle.RootWindowOfScreen, image.Width, image.Height, image.Depth);
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
                drawable.Display = null;
                drawable.Target = IntPtr.Zero;
                drawable.Screen = null;
            }
        }
#endregion
    }
}
