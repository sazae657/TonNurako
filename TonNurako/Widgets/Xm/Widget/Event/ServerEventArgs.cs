//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Native.Xt;

//
// 全然実装してないよ
//

namespace TonNurako.Events.Server
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TnkServerEventArgs<T> : TnkEventArgs {
        public T XEvent {
            get;
            internal set;
        }
        public TnkServerEventArgs() : base() {
        }
        public TnkServerEventArgs(Widgets.IWidget _Sender) {
            Sender = _Sender;
        }


        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            base.ParseXEvent(call, client);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class AnyEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XAnyEvent> {
        public AnyEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent = (XEventStruct.XAnyEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XAnyEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ButtonEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XButtonEvent> {
        public ButtonEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent = (XEventStruct.XButtonEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XButtonEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MotionEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XMotionEvent> {
        public MotionEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent = (XEventStruct.XMotionEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XMotionEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CrossingEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XCrossingEvent> {
        public CrossingEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XCrossingEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XCrossingEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FocusChangeEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XFocusChangeEvent> {
        public FocusChangeEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XFocusChangeEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XFocusChangeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExposeEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XExposeEvent> {
        public ExposeEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XExposeEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XExposeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GraphicsExposeEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XGraphicsExposeEvent> {
        public GraphicsExposeEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XGraphicsExposeEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XGraphicsExposeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NoExposeEventEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XNoExposeEvent> {
        public NoExposeEventEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XNoExposeEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XNoExposeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VisibilityEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XVisibilityEvent> {
        public VisibilityEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XVisibilityEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XVisibilityEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateWindowEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XCreateWindowEvent> {
        public CreateWindowEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XCreateWindowEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XCreateWindowEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DestroyWindowEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XDestroyWindowEvent> {
        public DestroyWindowEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XDestroyWindowEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XDestroyWindowEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MapEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XMapEvent> {
        public MapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XMapEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XMapEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MapRequestEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XMapRequestEvent> {
        public MapRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XMapRequestEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XMapRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UnmapEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XUnmapEvent> {
        public UnmapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XUnmapEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XUnmapEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ReparentEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XReparentEvent> {
        public ReparentEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XReparentEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XReparentEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConfigureEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XConfigureEvent> {
        public ConfigureEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XConfigureEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XConfigureEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GravityEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XGravityEvent> {
        public GravityEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XGravityEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XGravityEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResizeRequestEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XResizeRequestEvent> {
        public ResizeRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XResizeRequestEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XResizeRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConfigureRequestEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XConfigureRequestEvent> {
        public ConfigureRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XConfigureRequestEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XConfigureRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CirculateEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XCirculateEvent> {
        public CirculateEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XCirculateEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XCirculateEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CirculateRequestEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XCirculateRequestEvent> {
        public CirculateRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XCirculateRequestEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XCirculateRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PropertyEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XPropertyEvent> {
        public PropertyEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XPropertyEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XPropertyEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SelectionClearEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XSelectionClearEvent> {
        public SelectionClearEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XSelectionClearEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XSelectionClearEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SelectionRequestEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XSelectionRequestEvent> {
        public SelectionRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XSelectionRequestEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XSelectionRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SelectionEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XSelectionEvent> {
        public SelectionEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XSelectionEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XSelectionEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ColormapEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XColormapEvent> {
        public ColormapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XColormapEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XColormapEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClientMessageEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XClientMessageEvent> {
        public ClientMessageEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            // 中に XClientMessageEventDataが入ってる
            XEvent =
                (XEventStruct.XClientMessageEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XClientMessageEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MappingEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XMappingEvent> {
        public MappingEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XMappingEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XMappingEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ErrorEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XErrorEvent> {
        public ErrorEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XErrorEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XErrorEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class KeymapEventArgs :TnkServerEventArgs<Native.Xt.XEventStruct.XKeymapEvent> {
        public KeymapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (XEventStruct.XKeymapEvent)Marshal.PtrToStructure(call, typeof(XEventStruct.XKeymapEvent));
        }
    }
}
