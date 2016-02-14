//
// ﾄﾝﾇﾗｺ
//
// XToolkit
//
using System;
using System.Runtime.InteropServices;

//
// Xt周り
//
namespace TonNurako.Native.Xt
{
    /// <summary>
    /// CallBack
    /// </summary>
    public sealed class G
    {
	    /// <summary>
	    /// 汎用ｺーﾙﾊﾞｯｸ
	    /// </summary>
	    public delegate void XtCallBack( IntPtr w, IntPtr client, IntPtr call );

	    /// <summary>
	    /// List widgetの選択項目列挙用
	    /// </summary>
	    public delegate void ListEnumCallback( int count, IntPtr list );

        /// <summary>
	    /// EventHandler
	    /// </summary>
        public delegate void XtEventHandler( IntPtr widget, IntPtr closure, IntPtr xevent, IntPtr continue_to_dispatch);
    }

    /// <summary>
    /// Extremesports - TonNurakoのﾃﾞーﾀﾀｲﾌﾟ
    /// </summary>
    public enum XtArgType {
        Undefined = 0,
        Int = 1,
        UInt = 2,
        Long = 3,
        ULong = 4,
        Object = 5,

        String = 6,
        CompoundString = 7,
        Color = 8,
        Callback = 9

    }

    /// <summary>
    /// Arg 相当
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NativeXtArg {
        internal IntPtr Name ;
        internal IntPtr Value;
    }

    /// <summary>
    /// ExtremeSportsにﾘｿーｽの処理を強要する用
    /// 共用体にしたかったけど無理だった
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct XtArg
    {
        [MarshalAs(UnmanagedType.LPStr)] public string name ;

        XtArgType type ;

        internal int intVal;
        internal uint uintVal;
        internal long longVal;
        internal ulong ulongVal;
        internal IntPtr ptrVal;

        [MarshalAs(UnmanagedType.LPStr)] public string strVal;
        internal IntPtr compoundStr;

        public ulong color;

        public G.XtCallBack callback;

        public XtArg(string _Name, int _Val) {
            name = _Name;
            intVal  = _Val;
            type = XtArgType.Int;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";

            compoundStr = IntPtr.Zero;

            color = 0;
            callback = null;

        }
        public XtArg(string _Name, uint _Val) {
            name = _Name;
            uintVal  = _Val;
            type = XtArgType.UInt;

            longVal = 0;
            intVal = 0;
            ulongVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            compoundStr = IntPtr.Zero;
            color = 0;
            callback = null;
        }

        public XtArg(string _Name, long _Val) {
            name = _Name;
            longVal  = _Val;
            type = XtArgType.Long;

            uintVal = 0;
            intVal = 0;
            ulongVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            compoundStr = IntPtr.Zero;
            color = 0;
            callback = null;
        }

        public XtArg(string _Name, ulong _Val) {
            name = _Name;
            ulongVal  = _Val;
            type = XtArgType.ULong;

            uintVal = 0;
            intVal = 0;
            longVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            compoundStr = IntPtr.Zero;
            color = 0;
            callback = null;
        }

        public XtArg(string _Name, IntPtr _Val) {
            name = _Name;
            ptrVal = _Val;
            type = XtArgType.Object;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            strVal = "";
            compoundStr = IntPtr.Zero;

            color = 0;
            callback = null;
        }

        public XtArg(string _Name, string _Val) {
            name = _Name;
            strVal = _Val;
            type = XtArgType.String;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            ptrVal = IntPtr.Zero;
            compoundStr = IntPtr.Zero;

            color = 0;
            callback = null;
        }
        public XtArg(string _Name, Data.CompoundString _Val) {
            name = _Name;
            compoundStr = _Val.NativeString;
            type = XtArgType.CompoundString;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            color = 0;
            callback = null;
        }

        public XtArg(string _Name, XColor _Val) {
            name = _Name;
            color = _Val.pixel;

            type = XtArgType.Color;

            compoundStr = IntPtr.Zero;
            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            strVal = "";
            ptrVal = IntPtr.Zero;
            callback = null;
        }

        public XtArg(string _Name, G.XtCallBack _Val) {
            name = _Name;
            callback = _Val;
            type = XtArgType.Callback;

            compoundStr = IntPtr.Zero;
            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            strVal = "";
            ptrVal = IntPtr.Zero;
            color = 0;
        }

        /// <summary>
        /// ﾘｿーｽ文字列にする(ﾎﾟｲﾝﾀーとかは無視)
        /// </summary>
        /// <returns></returns>
        public string ToXrmString() {
            string ret = name + ": ";
            switch(type) {
                case XtArgType.Int:
                    ret += intVal.ToString();
                    break;

                case XtArgType.UInt:
                    ret += uintVal.ToString();
                    break;

                case XtArgType.Long:
                    ret += longVal.ToString();
                    break;

                case XtArgType.ULong:
                    ret += ulongVal.ToString();
                    break;

                case XtArgType.Object:
                    return null;

                case XtArgType.String:
                    ret += strVal;
                    break;

                case XtArgType.CompoundString:
                    ret += Data.CompoundString.AsString(this.compoundStr);
                    break;
                case XtArgType.Undefined:
                case XtArgType.Callback:
                default:
                    return null;
            }
            return ret.Replace("\n", @"\n");
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XColor {
        public ulong pixel;
        public ushort red;
        public ushort green;
        public ushort blue;
        public char flags;
        public char pad;
    };

    /// <summary>
    /// Xのｺーﾙﾊﾞｯｸに来るよ
    /// </summary>
    public class XEventStruct
    {
        #region
        /// <summary>
        /// XAnyEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XAnyEvent
        {
            public int type;
            public int serial;      //ulong?
            public int send_event;
            internal IntPtr display;
            public int window;      //ulong?
        }

        /// <summary>
        /// XKeyEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XKeyEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong root;
            public ulong subwindow;
            public ulong time;
            public int x;
            public int y;
            public int x_root;
            public int y_root;
            public uint state;
            public uint keycode;
            public int same_screen;

        }
        /// <summary>
        /// XButtonEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XButtonEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong root;
            public ulong subwindow;
            public ulong time;
            public int x;
            public int y;
            public int x_root;
            public int y_root;
            public uint state;
            public uint button;
            public int same_screen;
        }

        /// <summary>
        /// XMotionEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XMotionEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong root;
            public ulong subwindow;
            public ulong time;
            public int x;
            public int y;
            public int x_root;
            public int y_root;
            public ulong state;
            public char is_hint;
            public int same_screen;
        }

        /// <summary>
        /// XCrossingEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XCrossingEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong root;
            public ulong subwindow;
            public ulong time;
            public int x;
            public int y;
            public int x_root;
            public int y_root;
            public int mode;
            public int detail;
            public int same_screen;
            public int focus;
            public uint state;
        }

        /// <summary>
        /// XFocusChangeEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XFocusChangeEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public int mode;
            public int detail;
        }

        /// <summary>
        /// XExposeEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XExposeEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public int x;
            public int y;
            public int width;
            public int height;
            public int count;
        }
        /// <summary>
        /// XGraphicsExposeEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XGraphicsExposeEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong drawable;
            public int x;
            public int y;
            public int width;
            public int height;
            public int count;
            public int major_code;
            public int minor_code;
        }

        /// <summary>
        /// XNoExposeEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XNoExposeEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong drawable;
            public int major_code;
            public int minor_code;
        }

        /// <summary>
        /// XVisibilityEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XVisibilityEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public int state;
        }

        /// <summary>
        /// XCreateWindowEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XCreateWindowEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong parent;
            public ulong window;
            public int x;
            public int y;
            public int width;
            public int height;
            public int border_width;
            public int override_redirect;
        }

        /// <summary>
        /// XDestroyWindowEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XDestroyWindowEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong xevent;
            public ulong window;
        }

        /// <summary>
        /// XUnmapEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XUnmapEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong xevent;
            public ulong window;
            public int from_configure;
        }

        /// <summary>
        /// XMapEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XMapEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong xevent;
            public ulong window;
            public int override_redirect;
        }

        /// <summary>
        /// XMapRequestEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XMapRequestEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong parent;
            public ulong window;
        }

        /// <summary>
        /// XReparentEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XReparentEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong xevent;
            public ulong window;
            public ulong parent;
            public int x;
            public int y;
            public int override_redirect;
        }

        /// <summary>
        /// XConfigureEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XConfigureEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong xevent;
            public ulong window;
            public int x;
            public int y;
            public int width;
            public int height;
            public int border_width;
            public ulong above;
            public int override_redirect;
        }

        /// <summary>
        /// XGravityEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XGravityEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong xevent;
            public ulong window;
            public int x;
            public int y;
        }

        /// <summary>
        /// XResizeRequestEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XResizeRequestEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public int width;
            public int height;
        }

        /// <summary>
        /// XConfigureRequestEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XConfigureRequestEvent
        {

            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong parent;
            public ulong window;
            public int x;
            public int y;
            public int width;
            public int height;
            public int border_width;
            public ulong above;
            public int detail;
            public ulong value_mask;
        }

        /// <summary>
        /// XCirculateEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XCirculateEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong xevent;
            public ulong window;
            public int place;
        }

        /// <summary>
        /// XCirculateRequestEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XCirculateRequestEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong parent;
            public ulong window;
            public int place;
        }

        /// <summary>
        /// XPropertyEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XPropertyEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong atom;
            public ulong time;
            public int state;
        }

        /// <summary>
        /// XSelectionClearEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XSelectionClearEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong selection;
            public ulong time;
        }

        /// <summary>
        ///  XSelectionRequestEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XSelectionRequestEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong owner;
            public ulong requestor;
            public ulong selection;
            public ulong target;
            public ulong property;
            public ulong time;
        }

        /// <summary>
        ///  XSelectionEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XSelectionEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong requestor;
            public ulong selection;
            public ulong target;
            public ulong property;
            public ulong time;
        }

        /// <summary>
        /// XColormapEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XColormapEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong colormap;
            public int xnew;
            public int state;
        }

        /// <summary>
        /// XClientMessageEventData( XClientMessageEvent内のdata共用体)
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XClientMessageEventData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public char[] b;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public short[] s;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public long[] l;
        }

        /// <summary>
        /// XClientMessageEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XClientMessageEvent
        {

            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public ulong message_type;
            public int format;
            public XClientMessageEventData data;
        }

        /// <summary>
        /// XMappingEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XMappingEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;
            public int request;
            public int first_keycode;
            public int count;
        }

        /// <summary>
        ///  XErrorEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XErrorEvent
        {
            public int type;
            internal IntPtr display;
            public ulong resourceid;
            public ulong serial;
            public byte error_code;
            public byte request_code;
            public byte minor_code;
        }

        /// <summary>
        /// XKeymapEvent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XKeymapEvent
        {
            public int type;
            public ulong serial;
            public int send_event;
            internal IntPtr display;
            public ulong window;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] key_vector;
        }

        /// <summary>
        /// すげえ XEvent
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct XEvent
        {
            [FieldOffset(0)] public int type;
            [FieldOffset(0)] public XAnyEvent xany;
            [FieldOffset(0)] public XKeyEvent xkey;
            [FieldOffset(0)] public XButtonEvent xbutton;
            [FieldOffset(0)] public XMotionEvent xmotion;
            [FieldOffset(0)] public XCrossingEvent xcrossing;
            [FieldOffset(0)] public XFocusChangeEvent xfocus;
            [FieldOffset(0)] public XExposeEvent xexpose;
            [FieldOffset(0)] public XGraphicsExposeEvent xgraphicsexpose;
            [FieldOffset(0)] public XNoExposeEvent xnoexpose;
            [FieldOffset(0)] public XVisibilityEvent xvisibility;
            [FieldOffset(0)] public XCreateWindowEvent xcreatewindow;
            [FieldOffset(0)] public XDestroyWindowEvent xdestroywindow;
            [FieldOffset(0)] public XUnmapEvent xunmap;
            [FieldOffset(0)] public XMapEvent xmap;
            [FieldOffset(0)] public XMapRequestEvent xmaprequest;
            [FieldOffset(0)] public XReparentEvent xreparent;
            [FieldOffset(0)] public XConfigureEvent xconfigure;
            [FieldOffset(0)] public XGravityEvent xgravity;
            [FieldOffset(0)] public XResizeRequestEvent xresizerequest;
            [FieldOffset(0)] public XConfigureRequestEvent xconfigurerequest;
            [FieldOffset(0)] public XCirculateEvent xcirculate;
            [FieldOffset(0)] public XCirculateRequestEvent xcirculaterequest;
            [FieldOffset(0)] public XPropertyEvent xproperty;
            [FieldOffset(0)] public XSelectionClearEvent xselectionclear;
            [FieldOffset(0)] public XSelectionRequestEvent xselectionrequest;
            [FieldOffset(0)] public XSelectionEvent xselection;
            [FieldOffset(0)] public XColormapEvent xcolormap;
            [FieldOffset(0)] public XClientMessageEvent xclient;
            [FieldOffset(0)] public XMappingEvent xmapping;
            [FieldOffset(0)] public XErrorEvent xerror;
            [FieldOffset(0)] public XKeymapEvent xkeymap;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
            [FieldOffset(0)] public long[] pad;
        }
        #endregion
    }
}
