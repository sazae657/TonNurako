using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Native.X11 {
    public interface X11Interop {
        /// <summary>
        /// ﾄﾞﾙﾊﾝ
        /// </summary>
        IntPtr Handle { get; }
    }

    public class Widget : X11Interop, IEquatable<Widget> {

        public Widget() {
        }

        public Widget(IntPtr widget) {
            Handle = widget;
        }

        public IntPtr Handle { get; }

        bool IEquatable<Widget>.Equals(Widget other) => this.Handle == other.Handle;
        
    }

    public class Display : X11Interop {

        public Display() {
        }

        Widget widget;
        IntPtr display;

        public Display(Widget window) {
            widget = window;
        }

        public Display(Widgets.IWidget window) {
            widget = window.Handle.Widget;
        }

        public Display(IntPtr dpy) {
            display = dpy;
        }

        public IntPtr Handle =>
            (widget != null) ? Native.Xt.XtSports.XtDisplay(widget.Handle) : display;
    }


    public class Screen : X11Interop {

        Widget widget;
        IntPtr screen;

        public Screen(Widget widget) {
            this.widget = widget;
            
        }

        public Screen(Widgets.IWidget window) {
            widget = window.Handle.Widget;
        }

        public Screen(IntPtr window) {
            screen = window;
        }

        public IntPtr Handle =>
            (widget != null) ? Native.Xt.XtSports.XtScreen(widget.Handle) : screen;

    }

    public class Window : X11Interop {

        Widget widget;
        IntPtr window;

        public Window(Widget widget) {
            this.widget = widget;
        }

        public Window(Widgets.IWidget window) {
            widget = window.Handle.Widget;
        }

        public Window(IntPtr window) {
            this.window = window;
        }

        public IntPtr Handle =>
            (widget != null) ? Native.Xt.XtSports.XtWindow(widget.Handle) : window;


    }
}
