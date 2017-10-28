using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Event {

    /// <summary>
    /// ｲﾍﾞﾝﾄ定数
    /// </summary>
    public enum XEventType : int {
        KeyPress            = TonNurako.X11.Constant.KeyPress,
        KeyRelease          = TonNurako.X11.Constant.KeyRelease,
        ButtonPress         = TonNurako.X11.Constant.ButtonPress,
        ButtonRelease       = TonNurako.X11.Constant.ButtonRelease,
        MotionNotify        = TonNurako.X11.Constant.MotionNotify,
        EnterNotify         = TonNurako.X11.Constant.EnterNotify,
        LeaveNotify         = TonNurako.X11.Constant.LeaveNotify,
        FocusIn             = TonNurako.X11.Constant.FocusIn,
        FocusOut            = TonNurako.X11.Constant.FocusOut,
        KeymapNotify        = TonNurako.X11.Constant.KeymapNotify,
        Expose              = TonNurako.X11.Constant.Expose,
        GraphicsExpose      = TonNurako.X11.Constant.GraphicsExpose,
        NoExpose            = TonNurako.X11.Constant.NoExpose,
        VisibilityNotify    = TonNurako.X11.Constant.VisibilityNotify,
        CreateNotify        = TonNurako.X11.Constant.CreateNotify,
        DestroyNotify       = TonNurako.X11.Constant.DestroyNotify,
        UnmapNotify         = TonNurako.X11.Constant.UnmapNotify,
        MapNotify           = TonNurako.X11.Constant.MapNotify,
        MapRequest          = TonNurako.X11.Constant.MapRequest,
        ReparentNotify      = TonNurako.X11.Constant.ReparentNotify,
        ConfigureNotify     = TonNurako.X11.Constant.ConfigureNotify,
        ConfigureRequest    = TonNurako.X11.Constant.ConfigureRequest,
        GravityNotify       = TonNurako.X11.Constant.GravityNotify,
        ResizeRequest       = TonNurako.X11.Constant.ResizeRequest,
        CirculateNotify     = TonNurako.X11.Constant.CirculateNotify,
        CirculateRequest    = TonNurako.X11.Constant.CirculateRequest,
        PropertyNotify      = TonNurako.X11.Constant.PropertyNotify,
        SelectionClear      = TonNurako.X11.Constant.SelectionClear,
        SelectionRequest    = TonNurako.X11.Constant.SelectionRequest,
        SelectionNotify     = TonNurako.X11.Constant.SelectionNotify,
        ColormapNotify      = TonNurako.X11.Constant.ColormapNotify,
        ClientMessage       = TonNurako.X11.Constant.ClientMessage,
        MappingNotify       = TonNurako.X11.Constant.MappingNotify,
        GenericEvent        = TonNurako.X11.Constant.GenericEvent,
        LASTEvent           = TonNurako.X11.Constant.LASTEvent,
    }

    /// <summary>
    /// ﾓーﾄﾞ
    /// </summary>
    public enum EventMode : uint {
        AsyncPointer = TonNurako.X11.Constant.AsyncPointer,
        SyncPointer = TonNurako.X11.Constant.SyncPointer,
        ReplayPointer = TonNurako.X11.Constant.ReplayPointer,
        AsyncKeyboard = TonNurako.X11.Constant.AsyncKeyboard,
        SyncKeyboard = TonNurako.X11.Constant.SyncKeyboard,
        ReplayKeyboard = TonNurako.X11.Constant.ReplayKeyboard,
        AsyncBoth = TonNurako.X11.Constant.AsyncBoth,
        SyncBoth = TonNurako.X11.Constant.SyncBoth,
    }

    /// <summary>
    /// XAnyEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XAnyEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public int serial;      //ulong?
        public int send_event;
        public ulong display;
        public int window;      //ulong?
    }

    /// <summary>
    /// XKeyEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XKeyEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XButtonEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XMotionEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XCrossingEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XFocusChangeEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public int mode;
        public int detail;
    }

    /// <summary>
    /// XExposeEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XExposeEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XGraphicsExposeEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XNoExposeEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong drawable;
        public int major_code;
        public int minor_code;
    }

    /// <summary>
    /// XVisibilityEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XVisibilityEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public int state;
    }

    /// <summary>
    /// XCreateWindowEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XCreateWindowEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XDestroyWindowEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong xevent;
        public ulong window;
    }

    /// <summary>
    /// XUnmapEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XUnmapEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong xevent;
        public ulong window;
        public int from_configure;
    }

    /// <summary>
    /// XMapEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMapEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong xevent;
        public ulong window;
        public int override_redirect;
    }

    /// <summary>
    /// XMapRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMapRequestEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong parent;
        public ulong window;
    }

    /// <summary>
    /// XReparentEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XReparentEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XConfigureEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XGravityEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong xevent;
        public ulong window;
        public int x;
        public int y;
    }

    /// <summary>
    /// XResizeRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XResizeRequestEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public int width;
        public int height;
    }

    /// <summary>
    /// XConfigureRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XConfigureRequestEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XCirculateEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong xevent;
        public ulong window;
        public int place;
    }

    /// <summary>
    /// XCirculateRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XCirculateRequestEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong parent;
        public ulong window;
        public int place;
    }

    /// <summary>
    /// XPropertyEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XPropertyEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public ulong atom;
        public ulong time;
        public int state;
    }

    /// <summary>
    /// XSelectionClearEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XSelectionClearEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public ulong selection;
        public ulong time;
    }

    /// <summary>
    ///  XSelectionRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XSelectionRequestEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XSelectionEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
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
    public struct XColormapEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public ulong colormap;
        public int xnew;
        public int state;
    }
#region むり
    /// <summary>
    /// XClientMessageEventData( XClientMessageEvent内のdata共用体)
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct _XClientMessageEventData {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 20)]
        [FieldOffset(0)] public byte[] b;
        
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 10)]
        [FieldOffset(0)] public short[] s;

        [MarshalAs(UnmanagedType.LPArray, SizeConst = 5)]
        [FieldOffset(0)] public long[] l;
    }

    /// <summary>
    /// XClientMessageEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct _XClientMessageEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public ulong message_type;
        public int format;
        public _XClientMessageEventData data;
    }
#endregion

    /// <summary>
    /// XClientMessageEventData( XClientMessageEvent内のdata共用体)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XClientMessageEventData {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] b;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] s;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public long[] l;
    }

    /// <summary>
    /// XClientMessageEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XClientMessageEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public ulong message_type;
        public int format;
        public XClientMessageEventData data;
    }


    /// <summary>
    /// XMappingEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMappingEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public int request;
        public int first_keycode;
        public int count;
    }

    /// <summary>
    ///  XErrorEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XErrorEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong display;
        public int resourceid;
        public ulong serial;

        [MarshalAs(UnmanagedType.U1)]
        public ErrorCode error_code;

        [MarshalAs(UnmanagedType.U1)]
        public RequestCode request_code;
        public byte minor_code;
    }

    /// <summary>
    /// XKeymapEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XKeymapEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] key_vector;
    }

    /// <summary>
    /// XEvent
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct XEvent {
        [FieldOffset(0)] [MarshalAs(UnmanagedType.I4)] public XEventType type;
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
        [FieldOffset(0)] public _XClientMessageEvent xclient;
        [FieldOffset(0)] public XMappingEvent xmapping;
        [FieldOffset(0)] public XErrorEvent xerror;
        [FieldOffset(0)] public XKeymapEvent xkeymap;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        [FieldOffset(0)]
        public long[] pad;
    }

    public class XEventArg : IX11Interop, IDisposable {

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_IMP_SplitXClientMessageEventData", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr TNK_IMP_SplitXClientMessageEventData(IntPtr src, [Out] out XClientMessageEvent ev);
        }

        internal IntPtr handle;
        public IntPtr Handle => handle;

        bool handleAllocated = false;

        XAnyEvent xevent;
        public XAnyEvent XEvent => xevent;

        public XEventType Type => xevent.type;

        Display display;
        public Display Display => display;

        Window window;
        public Window Window => window;

        Dictionary<Type, object> even;

        bool cmSplitted;
        XClientMessageEvent clientMessageEvent;

        public XEventArg() {
            display = new Display();
            window = new Window();
            even = new Dictionary<Type, object>();
            handle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(XEvent)));
            handleAllocated = true;
            cmSplitted = false;
        }

        internal XEventArg(IntPtr href) {
            handle = href;
            handleAllocated = false;
            cmSplitted = false;
        }

        public void Assign() {
            this.xevent = (XAnyEvent)Marshal.PtrToStructure(Handle, typeof(XAnyEvent));
            display.Assign((IntPtr)XEvent.display, false);
            window.Assign((IntPtr)XEvent.window, display);
            cmSplitted = false;
            even.Clear();
        }

        T CastReturn<T>() {
            Type t = typeof(T);
            if (! even.ContainsKey(t)) {
                even[t] = Marshal.PtrToStructure(Handle, typeof(T));
            }
            return (T)even[t];
        }

        public XAnyEvent            Any => CastReturn<XAnyEvent>();
        public XKeyEvent            Key => CastReturn<XKeyEvent>();
        public XButtonEvent         Button => CastReturn<XButtonEvent>();
        public XMotionEvent         Motion => CastReturn<XMotionEvent>();
        public XCrossingEvent       Crossing => CastReturn<XCrossingEvent>();
        public XFocusChangeEvent    FocusChange => CastReturn<XFocusChangeEvent>();
        public XExposeEvent         Expose => CastReturn<XExposeEvent>();
        public XGraphicsExposeEvent GraphicsExpose => CastReturn<XGraphicsExposeEvent>();
        public XNoExposeEvent       NoExpose => CastReturn<XNoExposeEvent>();
        public XVisibilityEvent     Visibility => CastReturn<XVisibilityEvent>();
        public XCreateWindowEvent   CreateWindow => CastReturn<XCreateWindowEvent>();
        public XDestroyWindowEvent  DestroyWindow => CastReturn<XDestroyWindowEvent>();
        public XUnmapEvent          Unmap => CastReturn<XUnmapEvent>();
        public XMapEvent            Map => CastReturn<XMapEvent>();
        public XMapRequestEvent     MapRequest => CastReturn<XMapRequestEvent>();
        public XReparentEvent       Reparent => CastReturn<XReparentEvent>();
        public XConfigureEvent      Configure => CastReturn<XConfigureEvent>();
        public XGravityEvent        Gravity => CastReturn<XGravityEvent>();
        public XResizeRequestEvent  ResizeRequest => CastReturn<XResizeRequestEvent>();
        public XConfigureRequestEvent ConfigureRequest => CastReturn<XConfigureRequestEvent>();
        public XCirculateEvent      Circulate => CastReturn<XCirculateEvent>();
        public XCirculateRequestEvent CirculateRequest => CastReturn<XCirculateRequestEvent>();
        public XPropertyEvent       Property => CastReturn<XPropertyEvent>();
        public XSelectionClearEvent SelectionClear => CastReturn<XSelectionClearEvent>();
        public XSelectionRequestEvent SelectionRequest => CastReturn<XSelectionRequestEvent>();
        public XSelectionEvent      Selection => CastReturn<XSelectionEvent>();
        public XColormapEvent       Colormap => CastReturn<XColormapEvent>();
        public XMappingEvent        Mapping => CastReturn<XMappingEvent>();
        public XErrorEvent          Error => CastReturn<XErrorEvent>();
        public XKeymapEvent         Keymap => CastReturn<XKeymapEvent>();

        public XClientMessageEvent ClientMessage {
            get {
                if (! cmSplitted) {
                    clientMessageEvent = new XClientMessageEvent();
                    NativeMethods.TNK_IMP_SplitXClientMessageEventData(Handle, out clientMessageEvent);
                    cmSplitted = true;
                }
                return clientMessageEvent;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (handle != IntPtr.Zero) {
                    if (handleAllocated) {
                        Marshal.FreeHGlobal(handle);
                    }
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        ~XEventArg() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion

    }
}
