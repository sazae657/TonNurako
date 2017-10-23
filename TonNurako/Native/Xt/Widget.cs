using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.Widgets;
using TonNurako.Xt.Core;

namespace TonNurako.Xt {
    public class Widget : X11.IX11Interop, IEquatable<Widget> {

        internal static class NativeMethods {

            // Widget: XtCreateManagedWidget String:name WidgetClass:widget_class Widget:parent ArgList:args Cardinal:num_args
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtCreateManagedWidget_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtCreateManagedWidget([MarshalAs(UnmanagedType.LPStr)] string name, [In]IntPtr widget_class, IntPtr parent, IntPtr args, int num_args);

            // Widget: XtCreateWidget String:name WidgetClass:widget_class Widget:parent ArgList:args Cardinal:num_args
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtCreateWidget_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtCreateWidget([MarshalAs(UnmanagedType.LPStr)] string name, [In]IntPtr widget_class, IntPtr parent, IntPtr args, int num_args);
        }

        public static Widget CreateWidget(string name, CoreWidgetClass widget_class, IWidget parent) {
            var w = new Widget();
            w.handle = NativeMethods.XtCreateWidget(name, widget_class.Pounter, parent.Handle.Widget.Handle, IntPtr.Zero, 0);
            return w;
        }

        public static Widget CreateManagedWidget(string name, CoreWidgetClass widget_class, IWidget parent) {
            var w = new Widget();
            w.handle = NativeMethods.XtCreateManagedWidget(name, widget_class.Pounter, parent.Handle.Widget.Handle, IntPtr.Zero, 0);
            return w;
        }

        public Widget() {
        }

        public Widget(IntPtr widget) {
            handle = widget;
        }

        IntPtr handle;
        public IntPtr Handle => handle;

        bool IEquatable<Widget>.Equals(Widget other) => this.Handle == other.Handle;

    }
}
