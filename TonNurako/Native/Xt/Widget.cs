using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Xt {
    public class Widget : X11.IX11Interop, IEquatable<Widget> {

        public Widget() {
        }

        public Widget(IntPtr widget) {
            Handle = widget;
        }

        public IntPtr Handle { get; }

        bool IEquatable<Widget>.Equals(Widget other) => this.Handle == other.Handle;

    }
}
