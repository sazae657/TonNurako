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

    public class Display : X11Interop {

        public Display() {
        }

        public Display(Widgets.IWidget widget) {
            Handle = Native.Xt.XtSports.XtDisplay(widget.Handle.Widget);
        }

        public Display(IntPtr dpy) {
            Handle = dpy;
        }


        public IntPtr Handle { get; }
    }


    public class Screen : X11Interop {

        public Screen(Widgets.IWidget widget) {
            Handle = Native.Xt.XtSports.XtScreen(widget.Handle.Widget);
        }

        public Screen(IntPtr window) {
            Handle = window;
        }

        public IntPtr Handle { get; }
    }

    public class Window : X11Interop {

        public Window(Widgets.IWidget widget) {
            Handle = Native.Xt.XtSports.XtWindow(widget.Handle.Widget);
        }

        public Window(IntPtr window) {
            Handle = window;
        }

        public IntPtr Handle { get; }
    }
}
