//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Data;
using TonNurako.Native.Xt;
using TonNurako.Widgets;
namespace TonNurako.Native {

    public struct TonNurakoExVersion {
        public int Major;
        public int Minor;

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

        internal static class NativeMethods
        {
            // ﾊﾞーｼﾞｮﾝ
            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern uint TNK_GetVersion();

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern uint TNK_GetMotifVersion();

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr TNK_GetMotifVersionString();



            //ﾒｲﾝﾙーﾌﾟ
		    [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
		    public static extern void TNK_IMP_Xt_XtAppMainLoop( IntPtr appcontext );

		    // ﾒｲﾝﾙーﾌﾟを抜ける
		    [ DllImport (ExtremeSports.Lib, CharSet=CharSet.Auto) ]
		    public static extern void TNK_IMP_Xt_XtAppSetExitFlag( IntPtr appcontext );

		    //ﾘｿーｽの更新
            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern void TNK_IMP_Xt_XtSetValues( IntPtr wgt,
                Native.Xt.XtArg [] args, int argc );

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto) ]
            public static extern int TNK_IMP_TnkConvertResource(
                Native.Xt.XtArg [] inArg, IntPtr outArg, int argc, [MarshalAs(UnmanagedType.U1)] bool deepCopy);

            [ DllImport(ExtremeSports.Lib, CharSet=CharSet.Auto, EntryPoint = "TNK_IMP_TnkConvertResource") ]
            public static extern int TNK_IMP_TnkConvertResourceEx(
                Native.Xt.XtArg [] inArg,
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
			     out TnkAppContext context,
                 [MarshalAs(UnmanagedType.LPStr)]string title,  string[] argv, int argc, string[] res, int resc);

		    //最上位ｳｲｼﾞｪｯﾄ作成
		    [ DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
		    public static extern IntPtr TNK_XtAppCreateShell(
			[In]ref TnkAppContext context,
            [MarshalAs(UnmanagedType.LPStr)] string title,  ref string[] argv, int argc , Native.Xt.NativeXtArg[] res, int resc);

            [ DllImport(Lib, CharSet=CharSet.Auto) ]
            public static extern int TNK_IMP_Xt_XCreateColormap(IntPtr w);

            [ DllImport(Lib, CharSet=CharSet.Auto) ]
            public static extern void TNK_IMP_TnkAssignColorMap([In]TnkAppContext pCtx, int cmap);

            [DllImport(Lib, CharSet=CharSet.Auto) ]
            public static extern int TNK_IMP_Xt_XAllocColor(out XColor color,
                                IntPtr widget, byte r, byte g, byte b, byte a);

            [DllImport(Lib, CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern int TNK_IMP_Xt_XParseColorW(out XColor color,
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

        public static uint GetVersionInt() {
            return NativeMethods.TNK_GetVersion();
        }



        public static TonNurakoExVersion GetVersion() {
            uint v = NativeMethods.TNK_GetVersion();
            var r = new TonNurakoExVersion();
            r.Minor = (int)v % 1000;
            r.Major = ((int)v - r.Minor)/1000;
            return r;
        }


        public static uint GetMotifVersion() {
            return NativeMethods.TNK_GetMotifVersion();
        }

        public static string GetMotifVersionString() {
            return Marshal.PtrToStringAnsi(NativeMethods.TNK_GetMotifVersionString());
        }

		/// <summary>
		/// ﾒｲﾝﾙーﾌﾟ
		/// </summary>
		/// <param name="app">XtAppContext</param>
		public static void AppMainLoop( IntPtr app )
		{
            NativeMethods.TNK_IMP_Xt_XtAppMainLoop( app );
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

		#region ﾘｿーｽ関連

		/// <summary>
		/// ﾘｿーｽの更新
		/// </summary>
		/// <param name="w">ｳｲｼﾞｪｯﾄ</param>
		/// <param name="args">ﾘｿーｽ</param>
		public static void SetValues(
			IWidget w,  Native.Xt.XtArg [] args )
		{
            NativeMethods.TNK_IMP_Xt_XtSetValues( w.NativeHandle.Widget,  args, args.Length );
		}
		public static void SetValues(
			IntPtr w,  Native.Xt.XtArg [] args )
		{
            NativeMethods.TNK_IMP_Xt_XtSetValues( w, args, args.Length );
		}

        public static int TnkConvertResource(
            Native.Xt.XtArg [] inArg, IntPtr outArg, int argc,  bool deepCopy) {
            return NativeMethods.TNK_IMP_TnkConvertResource(inArg, outArg, argc, deepCopy);
        }

        public static  int TnkConvertResourceEx(
            Native.Xt.XtArg [] inArg, NativeXtArg []outArg, bool deepCopy) {
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

		/// <summary>
		/// ｱﾌﾟﾘｹーｼｮﾝの情報の保持
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TnkAppContext
		{
            internal IntPtr context;
            internal IntPtr display;
            //public int   colormap;
		}


		public static int XtInitialize(out TnkAppContext context,string title, string[] argv, string[] res)
		{
            return NativeMethods.TNK_XtInitialize(out context, title, argv, argv.Length, res, res.Length);
		}


		public static IntPtr XtAppCreateShell(ref TnkAppContext context,string title, ref string[] argv, Native.Xt.XtArg[] res)
		{
            if (null == res || 0 == res.Length) {
                return NativeMethods.TNK_XtAppCreateShell(ref context, title, ref argv, argv.Length, null, 0);
            }

            Native.Xt.NativeXtArg[] au = new Native.Xt.NativeXtArg[res.Length];
            int argc = ExtremeSports.TnkConvertResourceEx(res, au, true);
            System.Diagnostics.Debug.WriteLine($"XM_CVT {au.Length} -> {argc}");

            var result = NativeMethods.TNK_XtAppCreateShell(ref context, title, ref argv, argv.Length, au, argc);

            ExtremeSports.TnkFreeDeepCopyArg(au);

            foreach(Native.Xt.NativeXtArg k in au) {
                System.Diagnostics.Debug.WriteLine($"NA<F>: {k.Name} : {k.Value}");
            }
            return result;

		}

		public static int XCreateColormap(IWidget w)
		{
			return NativeMethods.TNK_IMP_Xt_XCreateColormap(w.NativeHandle.Widget);
		}

		public static void TnkAssignColorMap([In,Out]TnkAppContext pCtx, int cmap)
		{
			NativeMethods.TNK_IMP_TnkAssignColorMap(pCtx, cmap);
		}


 		public static XColor XAllocColor(IWidget widget, byte r, byte g, byte b, byte a)
		{
            XColor color;
			int rv = NativeMethods.TNK_IMP_Xt_XAllocColor(out color, widget.NativeHandle.Widget, r, g, b, a);
            if (0 == rv) {
                throw new Exception("XAllocColor :" + r.ToString());
            }
            return color;
		}

 		public static XColor XParseColor(IWidget widget, string name)
		{
            XColor color = new XColor();
			color.pixel = NativeMethods.TNK_IMP_Xt_XParseColorM(widget.NativeHandle.Widget, name);

            return color;
		}



		public static void XmAddWMProtocolCallback( Native.WidgetHandle w, string name, Xt.G.XtCallBack call )
		{
			NativeMethods.TNK_IMP_Xm_XmAddWMProtocolCallback(w.Widget, name, call );
		}

		public static void XmRemoveWMProtocolCallback( Native.WidgetHandle w, string name, Xt.G.XtCallBack call )
		{
			NativeMethods.TNK_IMP_Xm_XmRemoveWMProtocolCallback(w.Widget, name, call );
		}


		#region ﾘｿーｽ取得

		public static void XtGetValues( Native.WidgetHandle w, string val, out byte data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesByte(w.Widget, val, out data );
		}


		public static void XtGetValues( Native.WidgetHandle w, string val, out bool data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesBoolean( w.Widget, val, out data );
		}

		public static void XtGetValues( Native.WidgetHandle w, string val, out ushort data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesDimension( w.Widget, val, out data );
		}

		public static void XtGetValues( Native.WidgetHandle w, string val, out int data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesInt( w.Widget, val, out data );
		}

		public static void XtGetValues( Native.WidgetHandle w, string val, out long data  )
		{
			NativeMethods.TNK_IMP_Xt_XtGetValuesLong( w.Widget, val, out data );
		}

		public static CompoundString XtGetValuesCS( Native.WidgetHandle w, string val)
		{
			IntPtr cs = NativeMethods.TNK_IMP_Xt_XtGetValuesCompoundString( w.Widget, val);
            if (IntPtr.Zero == cs) {
                return null;
            }
            return new CompoundString(cs);
		}

		public static string XtGetValuesAS( Native.WidgetHandle w, string val, bool callFree)
		{
			IntPtr cs = NativeMethods.TNK_IMP_Xt_XtGetValuesAnsiString(w.Widget, val);
            if (IntPtr.Zero == cs) {
                return null;
            }
            string ret = Marshal.PtrToStringAnsi(cs);
            if(callFree) {
                Native.Xt.XtSports.XtFree(cs);
            }
            return ret;
		}

		#endregion

    }
}
