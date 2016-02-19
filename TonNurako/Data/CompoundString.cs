//
// ﾄﾝﾇﾗｺ
//
// 文字列
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TonNurako.Data {

	/// <summary>
	/// ｺﾝﾊﾟｳﾝﾄﾞｽﾄﾘﾝｸﾞ
	/// </summary>
	public class CompoundString :IDisposable
	{
		#region ｲﾝｽﾀﾝｽ変数

		//変換したXmStringへのﾎﾟｲﾝﾀ
		private IntPtr xmString;
        private IntPtr lastConvertStr;
        private string vstr;

        bool isReference = false;
		#endregion

		#region ｺﾝｽﾄﾗｸﾀー
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
		public CompoundString()
		{
            xmString = IntPtr.Zero;
            lastConvertStr = IntPtr.Zero;
		}

		/// <summary>
		/// 変換とｲﾝｽﾀﾝｽの生成
		/// </summary>
		/// <param name="src">変換元の文字列</param>
		public CompoundString( string src )
		{
            xmString = IntPtr.Zero;
            lastConvertStr = IntPtr.Zero;
			Convert( src );
		}

		/// <summary>
		/// 変換とｲﾝｽﾀﾝｽの生成
		/// </summary>
		/// <param name="src">ﾗｯﾌﾟ元</param>
        /// <param name="isRef">それ参照？</param>
		public CompoundString(IntPtr src, bool isRef = false)
		{
			xmString = src;
            lastConvertStr = IntPtr.Zero;
            isReference = isRef;
		}


		#endregion

		#region 生成/解放

		/// <summary>
		/// XmStringへの変換を行う
		/// </summary>
		/// <param name="src">変換元の文字列</param>
		public void Convert( string src )
		{
            Release();
            isReference = false;
            xmString = Native.Motif.XmSports.XmStringCreateLocalized( src );
		}

        public string AsString() {
            if (IntPtr.Zero == xmString) {
                return "";
            }
            if (lastConvertStr == xmString) {
                return vstr;
            }
            lastConvertStr = xmString;

            vstr = CompoundString.AsString(xmString);

            return vstr;
        }
        public static string AsString(IntPtr _Xm) {
            if (IntPtr.Zero == _Xm) {
                return "";
            }
            System.Diagnostics.Debug.WriteLine("CompoundString: KONVERT Xm -> String");

            IntPtr pStr =  Native.Motif.XmSports.XmStringUnparse(_Xm,
                (int)Native.Motif.Constant.XmCHARSET_TEXT,
                (int)Native.Motif.Constant.XmCHARSET_TEXT,
                (int)Native.Motif.Constant.XmOUTPUT_ALL);

            string ret = Marshal.PtrToStringAnsi(pStr);
            Native.Xt.XtSports.XtFree(pStr);

            return ret;
        }

        /// <summary>
        /// 変換済みのﾊﾞｯﾌｧを解放する
        /// </summary>
        public void Release()
		{
            if (isReference) {
                // 何もしない
                return;
            }

			if( xmString != IntPtr.Zero ) {
				Native.Motif.XmSports.XmStringFree( xmString );
                xmString = IntPtr.Zero;
			}
            lastConvertStr = IntPtr.Zero;
		}

		#endregion

		#region 型変換

        internal IntPtr NativeString {
            get {
                return xmString;
            }
        }

        public string String {
            get {
                return AsString();
            }
        }

		#endregion

        #region IDisposable
        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        internal virtual void Dispose(bool disposing)
        {
            if (disposedValue) {
                return;
            }

            System.Diagnostics.Debug.WriteLine("Dispose:" + this.ToString());
            Release();
            disposedValue = true;
        }

        ~CompoundString() {
            Dispose(false);
        }
        #endregion
	}

	/// <summary>
	/// ｺﾝﾊﾟｳﾝﾄﾞｽﾄﾘﾝｸﾞ配列のような物
	/// </summary>
    public class CompoundStringTable :IDisposable
    {
        public List<CompoundString> StringTable {
            get;
        }
        private bool isReference = false;
        private IntPtr addrOfArray = IntPtr.Zero;

        public int Count {
            get;
        }

        public CompoundStringTable() {
            StringTable  = new List<CompoundString>();
        }

        public CompoundStringTable(System.IntPtr src, int size, bool isRef) {
            StringTable  = new List<CompoundString>();
            Count = size;
            isReference = isRef;
            IntPtr [] ps = new IntPtr[size+1];
            Marshal.Copy(src, ps, 0, size);
            for (int i = 0;i < size;i++) {
                StringTable.Add(new CompoundString(ps[i], isRef));
            }
        }

        public CompoundStringTable(string[] src) {
            StringTable  = new List<CompoundString>();
            Count = src.Length;
            isReference = false;
            for (int i = 0;i < src.Length;i++) {
                StringTable.Add(new CompoundString(src[i]));
            }
        }

        public IntPtr [] ToNativeArray(bool NullTerm) {
            IntPtr [] ps = new IntPtr[NullTerm ? StringTable.Count+1: StringTable.Count];
            for (int i = 0;i < StringTable.Count;i++) {
                ps[i] = StringTable[i].NativeString;
            }
            if(NullTerm) {
                ps[StringTable.Count] = IntPtr.Zero;
            }
            return ps;
        }

        public IntPtr ToPointer() {
            if (IntPtr.Zero != addrOfArray) {
                Marshal.FreeCoTaskMem(addrOfArray);
            }
            IntPtr[] arr =  ToNativeArray(true);
            addrOfArray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)) * arr.Length);
            Marshal.Copy(arr, 0, addrOfArray, arr.Length);
            return addrOfArray;
        }

        public List<string> ToStringList() {
            var ret = new List<string>(StringTable.Count);
            foreach(var c in StringTable) {
                ret.Add(c.String);
            }
            return ret;
        }

        public string [] ToStringArray() {
            var ret = new string[StringTable.Count];
            for(int i =0; i < StringTable.Count; ++i) {
                ret[i] = StringTable[i].String;
            }
            return ret;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) {
                return;
            }

            if (! isReference) {
                foreach (CompoundString s in StringTable) {
                    s.Dispose();
                }
                StringTable.Clear();
            }
            if (IntPtr.Zero != addrOfArray) {
                Marshal.FreeCoTaskMem(addrOfArray);
                addrOfArray = IntPtr.Zero;
            }
            System.Diagnostics.Debug.WriteLine("Dispose:" + this.ToString());

            disposedValue = true;
        }


        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~CompoundStringTable() {
            Dispose(false);
        }
        #endregion
    }

    /// <summary>
	/// ｺﾝﾊﾟｳﾝﾄﾞｽﾄﾘﾝｸﾞ
	/// </summary>
	public class TextProperty :IDisposable
	{
        [StructLayout(LayoutKind.Sequential)]
        internal struct XTextProperty {
            public IntPtr xvalue; // unsigned char*
            public ulong encoding; // Atom
            public int format; // int
            public ulong nitems; // unsigned
        }
        internal static class NativeMethods {

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_CreateCompoundTextProperty", CharSet=CharSet.Auto)]
            internal static extern int TNK_CreateCompoundTextProperty(
                        [In,Out]ref XTextProperty tprop,
                        IntPtr display,
                        [MarshalAs(UnmanagedType.LPStr)]string text
                        );

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_FreeCompoundTextProperty", CharSet=CharSet.Auto)]
            internal static extern void TNK_FreeCompoundTextProperty([In,Out]ref XTextProperty tprop);

        }
        XTextProperty textProperty;

        internal IntPtr Value {
            get {return textProperty.xvalue;}
        }

        public ulong Encoding {
            get {return textProperty.encoding;}
        }
        public int Format {
            get {return textProperty.format;}
        }

        public ulong Items {
            get {return textProperty.nitems;}
        }

        public TextProperty() {
            textProperty = new XTextProperty();
        }


        public int Create(Widgets.IWidget widget, string text) {
            var result = NativeMethods.TNK_CreateCompoundTextProperty(ref textProperty, widget.NativeHandle.Display, text);
            return result;
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) {
                return;
            }
            if(IntPtr.Zero != textProperty.xvalue) {
                NativeMethods.TNK_FreeCompoundTextProperty(ref textProperty);
                textProperty.xvalue = IntPtr.Zero;
            }

            System.Diagnostics.Debug.WriteLine("Dispose:" + this.ToString());

            disposedValue = true;
        }


        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~TextProperty() {
            Dispose(false);
        }
        #endregion
    }
}
