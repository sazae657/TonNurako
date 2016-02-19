//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System;

namespace TonNurako.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class ServerEvent {
        internal Widgets.WidgetBase Widget {
            get;
        }

        internal ServerEvent(Widgets.WidgetBase widget) {
            ButtonEventTable = new XMaskEventQueue<Events.Server.ButtonEventArgs>();
            MotionEventTable = new XMaskEventQueue<Events.Server.MotionEventArgs>();
            Widget = widget;
        }

        internal XMaskEventQueue<Events.Server.ButtonEventArgs> ButtonEventTable {
            get;
        }
        internal XMaskEventQueue<Events.Server.MotionEventArgs> MotionEventTable {
            get;
        }

        internal XMaskEventQueue<Events.Server.KeymapEventArgs> KeyMapEventTable {
            get;
        }


        public void AddButtonEvent(Native.X11.Masks _Mask, EventHandler<Events.Server.ButtonEventArgs> listener) {
            ulong mask = (ulong)_Mask;
            ButtonEventTable.AddHandler(Widget, mask , listener);
        }

        public void AddMotionEvent(Native.X11.Masks _Mask, EventHandler<Events.Server.MotionEventArgs> listener) {
            ulong mask = (ulong)_Mask;
            MotionEventTable.AddHandler(Widget, mask , listener);
        }

        public virtual event EventHandler<Events.Server.ButtonEventArgs> ButtonPressEvent
        {
            add {
                ButtonEventTable.AddHandler(Widget, (ulong)Native.X11.Masks.ButtonPressMask ,  value );
            }
            remove {
                ButtonEventTable.RemoveHandler((ulong)Native.X11.Masks.ButtonPressMask ,  value );
            }
        }


        public virtual event EventHandler<Events.Server.ButtonEventArgs> ButtonReleaseEvent
        {
            add {
                ButtonEventTable.AddHandler(Widget, (ulong)Native.X11.Masks.ButtonReleaseMask ,  value );
            }
            remove {
                ButtonEventTable.RemoveHandler((ulong)Native.X11.Masks.ButtonReleaseMask ,  value );
            }
        }

        public virtual event EventHandler<Events.Server.MotionEventArgs> PointerMotionEvent
        {
            add {
                MotionEventTable.AddHandler(Widget, (ulong)Native.X11.Masks.PointerMotionMask ,  value );
            }
            remove {
                MotionEventTable.RemoveHandler((ulong)Native.X11.Masks.PointerMotionMask ,  value );
            }
        }
    }
}
