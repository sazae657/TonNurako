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

        Widgets.IWidget widget;
        IntPtr display;

        public Display(Widgets.IWidget window) {
            widget = window;
        }

        public Display(IntPtr dpy) {
            display = dpy;
        }

        public IntPtr Handle =>
            (widget != null) ? Native.Xt.XtSports.XtDisplay(widget.Handle.Widget.Handle) : display;
    }


    public class Screen : X11Interop {

        Widgets.IWidget widget;
        IntPtr screen;

        public Screen(Widgets.IWidget widget) {
            this.widget = widget;
            
        }

        public Screen(IntPtr window) {
            screen = window;
        }

        public IntPtr Handle =>
            (widget != null) ? Native.Xt.XtSports.XtScreen(widget.Handle.Widget.Handle) : screen;

    }

    public class Window : X11Interop {

        Widgets.IWidget widget;
        IntPtr window;

        public Window(Widgets.IWidget widget) {
            this.widget = widget;
        }

        public Window(IntPtr window) {
            this.window = window;
        }

        public IntPtr Handle =>
            (widget != null) ? Native.Xt.XtSports.XtWindow(widget.Handle.Widget.Handle) : window;


    }
}
