//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Data;
using TonNurako.Xt;
using TonNurako.Widgets;
namespace TonNurako.Native {

    /// <summary>
    /// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂのﾊﾞーｼﾞｮﾝ構造体
    /// </summary>
    public class TonNurakoExVersion {
        /// <summary>
        /// ﾒｼﾞｬー
        /// </summary>
        public int Major {get; internal set;} = 0;

        /// <summary>
        /// ﾏｲﾅー
        /// </summary>
        public int Minor {get; internal set;} = 0;

        /// <summary>
        /// 文字列に
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString() {
            return $"{Major}.{Minor}";
        }
    }
    public class ExtremeSports {
        public const string Lib = "libTonNurako.extremesports";

        public enum TnkCode {
                Ok          = 0,
                AllocFailed,
                CreateContextFailed,
                CannotOpenDisplay
        }

		#region ﾌﾟﾛｾｽ関連

        public delegate void AppMainLoopCalback();

        internal static class NativeMethods
        {
            // ﾊﾞーｼﾞｮﾝ
            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern uint TNK_GetVersion();

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern uint TNK_GetMotifVersion();

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr TNK_GetMotifVersionString();

            // 関数ﾎﾟｳﾝﾀーを呼ぶ
            [DllImport(ExtremeSports.Lib, CharSet = CharSet.Auto)]
            public static extern int TNK_CallPtrArg1ReturnInt([In]IntPtr fn, [In, Out] IntPtr ptr);

            //ﾒｲﾝﾙーﾌﾟ
            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
		    public static extern void TNK_IMP_Xt_XtAppMainLoop( IntPtr appcontext, AppMainLoopCalback callback);

		    // ﾒｲﾝﾙーﾌﾟを抜ける
		    [ DllImport (ExtremeSports.Lib, CharSet=CharSet.Auto) ]
		    public static extern void TNK_IMP_Xt_XtAppSetExitFlag( IntPtr appcontext );

		    //ﾘｿーｽの更新
            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern void TNK_IMP_Xt_XtSetValues( IntPtr wgt,
                TonNurako.Xt.XtArg [] args, int argc );

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern int TNK_IMP_TnkConvertResource(
                TonNurako.Xt.XtArg [] inArg, IntPtr outArg, int argc, [MarshalAs(UnmanagedType.U1)] bool deepCopy);

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto, EntryPoint = "TNK_IMP_TnkConvertResource") ]
            public static extern int TNK_IMP_TnkConvertResourceEx(
                TonNurako.Xt.XtArg [] inArg,
                [In, Out] NativeXtArg []outArg,
                int argc,
                [MarshalAs(UnmanagedType.U1)] bool deepCopy);

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern IntPtr TNK_IMP_TnkFreeDeepCopyArg([In, Out] NativeXtArg []args, int argc);

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern IntPtr TNK_IMP_TnkAllocArg(int argc);

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern void TNK_IMP_TnkFreeArg([In]IntPtr arg, int argc);

		    //最上位ｳｲｼﾞｪｯﾄ作成
		    [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
		    public static extern int TNK_XtInitialize(
			     out TnkAppContextRec context,
                 [MarshalAs(UnmanagedType.LPStr)]string title,  string[] argv, int argc, string[] res, int resc);

		    //最上位ｳｲｼﾞｪｯﾄ作成
		    [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
		    public static extern IntPtr TNK_XtAppCreateShell(
			[In]ref TnkAppContextRec context,
            [MarshalAs(UnmanagedType.LPStr)] string title,  ref string[] argv, int argc , TonNurako.Xt.NativeXtArg[] res, int resc);

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_TriggerPrivateEvent([In]ref TnkAppContextRec context,[In] IntPtr widget);

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Flush([In]ref TnkAppContextRec context,[In] IntPtr widget);



            [ DllImport(Lib, CharSet=CharSet.Auto) ]
            public static extern int TNK_IMP_Xt_XCreateColormap(IntPtr w);

            [ DllImport(Lib, CharSet=CharSet.Auto) ]
            public static extern void TNK_IMP_TnkAssignColorMap([In]TnkAppContextRec pCtx, int cmap);

            [DllImport(Lib, CharSet=CharSet.Auto) ]
            public static extern int TNK_IMP_Xt_XAllocColor(out TonNurako.X11.XColor color,
                                IntPtr widget, byte r, byte g, byte b, byte a);

            [DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern int TNK_IMP_Xt_XParseColorW(out TonNurako.X11.XColor color,
                                IntPtr widget, [MarshalAs(UnmanagedType.LPStr)] string name);

            [DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern ulong TNK_IMP_Xt_XParseColorM(IntPtr widget, [MarshalAs(UnmanagedType.LPStr)] string name);

            //MWM用ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗの追加
            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Xm_XmAddWMProtocolCallback( IntPtr w,
                [MarshalAs(UnmanagedType.LPStr)] string name, Xt.G.XtCallBack call );

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Xm_XmRemoveWMProtocolCallback( IntPtr w,
                [MarshalAs(UnmanagedType.LPStr)] string name, Xt.G.XtCallBack call );


            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Xt_XtGetValuesByte( IntPtr wid, string val, out byte data  );

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Xt_XtGetValuesBoolean( IntPtr wid, [MarshalAs(UnmanagedType.LPStr)] string val, out bool data  );


            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Xt_XtGetValuesDimension( IntPtr wid, [MarshalAs(UnmanagedType.LPStr)] string val, out ushort data  );

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Xt_XtGetValuesInt( IntPtr wid, [MarshalAs(UnmanagedType.LPStr)] string val, out int data  );

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void TNK_IMP_Xt_XtGetValuesLong( IntPtr wid, [MarshalAs(UnmanagedType.LPStr)] string val, out long data  );

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr TNK_IMP_Xt_XtGetValuesCompoundString( IntPtr wid, [MarshalAs(UnmanagedType.LPStr)] string val);

            [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr TNK_IMP_Xt_XtGetValuesAnsiString( IntPtr wid, [MarshalAs(UnmanagedType.LPStr)] string val);

        }

        /// <summary>
		/// ExtremeSportsのﾊﾞーｼﾞｮﾝ取得
        /// </summary>
        /// <returns>ﾊﾞーｼﾞｮﾝ</returns>
        public static uint GetVersionInt() {
            return NativeMethods.TNK_GetVersion();
        }


        /// <summary>
        /// ExtremeSportsのﾊﾞーｼﾞｮﾝ取得
        /// </summary>
        /// <returns>ﾊﾞーｼﾞｮﾝ構造体</returns>
        public static TonNurakoExVersion GetVersion() {
            uint v = NativeMethods.TNK_GetVersion();
            var r = new TonNurakoExVersion();
            r.Minor = (int)v % 1000;
            r.Major = ((int)v - r.Minor)/1000;
            return r;
        }

        /// <summary>
        /// Motifのﾊﾞーｼﾞｮﾝ取得
        /// </summary>
        /// <returns>ﾊﾞーｼﾞｮﾝ</returns>
        public static uint GetMotifVersion() {
            return NativeMethods.TNK_GetMotifVersion();
        }

        /// <summary>
        /// Motifのﾊﾞーｼﾞｮﾝ文字列取得
        /// </summary>
        /// <returns>ﾊﾞーｼﾞｮﾝ文字列</returns>
        public static string GetMotifVersionString() {
            return Marshal.PtrToStringAnsi(NativeMethods.TNK_GetMotifVersionString());
        }

		/// <summary>
		/// ﾒｲﾝﾙーﾌﾟ
		/// </summary>
		/// <param name="app">XtAppContext</param>
		public static void AppMainLoop( IntPtr app, AppMainLoopCalback callback )
		{
            NativeMethods.TNK_IMP_Xt_XtAppMainLoop( app,callback );
		}

		/// <summary>
		/// ﾌﾟﾗｲﾍﾞーﾄｲﾍﾞﾝﾄ発行
		/// </summary>
        public static void TriggerPrivateEvent(TnkAppContext context, IWidget w) {
            NativeMethods.TNK_IMP_TriggerPrivateEvent(ref context.Record, w.Handle.Widget.Handle);
        }

		/// <summary>
		/// XFlushを呼ぶ
		/// </summary>
        public static void Flush(TnkAppContext context, IWidget w) {
            NativeMethods.TNK_IMP_Flush(ref context.Record, w.Handle.Widget.Handle);
        }



		/// <summary>
		/// ﾒｲﾝﾙーﾌﾟを抜ける
		/// </summary>
		/// <param name="app">XtAppContext</param>
		public static void AppSetExitFlag( IntPtr app )
		{
			NativeMethods.TNK_IMP_Xt_XtAppSetExitFlag( app );
		}

        #endregion

        /// <summary>
        /// 関数ﾎﾟｳﾝﾀーを呼ぶ
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static int CallPtrArg1ReturnInt(IntPtr fn, IntPtr ptr) {
            return NativeMethods.TNK_CallPtrArg1ReturnInt(fn, ptr);
        }

        #region ﾘｿーｽ関連

        /// <summary>
        /// ﾘｿーｽの更新
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="args">ﾘｿーｽ</param>
        public static void SetValues(
			IWidget w,  TonNurako.Xt.XtArg [] args )
		{
            NativeMethods.TNK_IMP_Xt_XtSetValues( w.Handle.Widget.Handle,  args, args.Length );
		}
		public static void SetValues(
			IntPtr w,  TonNurako.Xt.XtArg [] args )
		{
            NativeMethods.TNK_IMP_Xt_XtSetValues( w, args, args.Length );
		}

        public static int TnkConvertResource(
            TonNurako.Xt.XtArg [] inArg, IntPtr outArg, int argc,  bool deepCopy) {
            return NativeMethods.TNK_IMP_TnkConvertResource(inArg, outArg, argc, deepCopy);
        }

        public static  int TnkConvertResourceEx(
            TonNurako.Xt.XtArg [] inArg, NativeXtArg []outArg, bool deepCopy) {
            return NativeMethods.TNK_IMP_TnkConvertResourceEx(inArg, outArg, inArg.Length, deepCopy);
        }


        public static void TnkFreeDeepCopyArg(NativeXtArg []args) {
            NativeMethods.TNK_IMP_TnkFreeDeepCopyArg(args, args.Length);
        }


        public static IntPtr TnkAllocArg(int argc) {
            return NativeMethods.TNK_IMP_TnkAllocArg(argc);
        }


        public static void TnkFreeArg(IntPtr arg, int argc) {
            NativeMethods.TNK_IMP_TnkFreeArg(arg, argc);
        }
		#endregion

        public delegate void TnkAppRefreshHandler();

		/// <summary>
		/// ｱﾌﾟﾘｹーｼｮﾝの情報の保持
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct TnkAppContextRec
		{
            internal IntPtr context;
            internal IntPtr display;
            internal TnkAppRefreshHandler comm;
            internal int   colormap;
		}

        public class TnkAppContext {
            internal TnkAppContextRec Record;

            internal XtAppContext appContext = null;

            public TnkAppContext() {
                Record = new TnkAppContextRec();
            }

            internal TnkAppContext(TnkAppContextRec r) {
                Record = r;
            }

            internal void Assign() {
                appContext = new XtAppContext(Record.context);
            }

            public XtAppContext Context {
                get => appContext;
               // set => Record.context = value;
            }
            public IntPtr Display {
                get => Record.display;
                set => Record.display = value;
            }
            public TnkAppRefreshHandler Comm {
                get => Record.comm;
                set => Record.comm = value;
            }
            public int Colormap {
                get => Record.colormap;
                set => Record.colormap = value;
            }
        }

        public static int XtInitialize(TnkAppContext context,string title, string[] argv, string[] res)
		{
            int r =  NativeMethods.TNK_XtInitialize(out context.Record, title, argv, argv.Length, res, res.Length);
            context.Assign();
            return r;
		}


		public static IntPtr XtAppCreateShell(TnkAppContext context,string title, ref string[] argv, TonNurako.Xt.XtArg[] res)
		{
            if (null == res || 0 == res.Length) {
                return NativeMethods.TNK_XtAppCreateShell(ref context.Record, title, ref argv, argv.Length, null, 0);
            }

            TonNurako.Xt.NativeXtArg[] au = new TonNurako.Xt.NativeXtArg[res.Length];
            int argc = ExtremeSports.TnkConvertResourceEx(res, au, true);
            System.Diagnostics.Debug.WriteLine($"XM_CVT {au.Length} -> {argc}");

            var result = NativeMethods.TNK_XtAppCreateShell(ref context.Record, title, ref argv, argv.Length, au, argc);

            ExtremeSports.TnkFreeDeepCopyArg(au);

            return result;

		}

		public static int XCreateColormap(IWidget w)
		{
			return NativeMethods.TNK_IMP_Xt_XCreateColormap(w.Handle.Widget.Handle);
		}

		public static void TnkAssignColorMap(TnkAppContext pCtx, int cmap)
		{
			NativeMethods.TNK_IMP_TnkAssignColorMap(pCtx.Record, cmap);
		}


 		public static TonNurako.X11.XColor XAllocColor(IWidget widget, byte r, byte g, byte b, byte a)
		{
            TonNurako.X11.XColor color;
			int rv = NativeMethods.TNK_IMP_Xt_XAllocColor(out color, widget.Handle.Widget.Handle, r, g, b, a);
            if (0 == rv) {
                throw new Exception("XAllocColor :" + r.ToString());
            }
            return color;
		}

 		public static TonNurako.X11.XColor XParseColor(IWidget widget, string name)
		{
            var color = new TonNurako.X11.XColor();
			color.pixel = NativeMethods.TNK_IMP_Xt_XParseColorM(widget.Handle.Widget.Handle, name);

            return color;
		}



		public static void XmAddWMProtocolCallback( Native.NativeWidget w, string name, Xt.G.XtCallBack call )
		{
			NativeMethods.TNK_IMP_Xm_XmAddWMProtocolCallback(w.Widget.Handle, name, call );
		}

		public static void XmRemoveWMProtocolCallback( Native.NativeWidget w, string name, Xt.G.XtCallBack call )
		{
			NativeMethods.TNK_IMP_Xm_XmRemoveWMProtocolCallback(w.Widget.Handle, name, call );
		}


		#region ﾘｿーｽ取得

		public static void XtGetValues( Native.NativeWidget w, string val, out byte data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesByte(w.Widget.Handle, val, out data );
		}


		public static void XtGetValues( Native.NativeWidget w, string val, out bool data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesBoolean( w.Widget.Handle, val, out data );
		}

		public static void XtGetValues( Native.NativeWidget w, string val, out ushort data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesDimension( w.Widget.Handle, val, out data );
		}

		public static void XtGetValues( Native.NativeWidget w, string val, out int data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesInt( w.Widget.Handle, val, out data );
		}

		public static void XtGetValues( Native.NativeWidget w, string val, out long data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesLong( w.Widget.Handle, val, out data );
		}

		public static CompoundString XtGetValuesCS( Native.NativeWidget w, string val)
		{
			IntPtr cs = NativeMethods.TNK_IMP_Xt_XtGetValuesCompoundString( w.Widget.Handle, val);
            if (IntPtr.Zero == cs) {
                return null;
            }
            return new CompoundString(cs);
		}

		public static string XtGetValuesAS( Native.NativeWidget w, string val, bool callFree)
		{
			IntPtr cs = NativeMethods.TNK_IMP_Xt_XtGetValuesAnsiString(w.Widget.Handle, val);
            if (IntPtr.Zero == cs) {
                return null;
            }
            string ret = Marshal.PtrToStringAnsi(cs);
            if(callFree) {
                TonNurako.Xt.XtSports.XtFree(cs);
            }
            return ret;
		}

		#endregion

    }
}
