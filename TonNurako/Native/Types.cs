//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Collections.Generic;

namespace TonNurako.Native {
    public class WidgetHandle
    {
        public WidgetHandle(System.IntPtr ptr) {
            if (IntPtr.Zero == ptr) {
                throw new NullReferenceException("Null Widget!!");
            }
            Widget = ptr;
            Hash = ptr.ToInt64().ToString().GetHashCode();
        }
        internal IntPtr Widget {
            get;
        }
        internal IntPtr Display {
            get { return Native.Xt.XtSports.XtDisplay(Widget);}
        }
        
        internal IntPtr Window {
            get { return Native.Xt.XtSports.XtWindow(Widget);}
        }
        
        internal IntPtr Screen {
            get { return Native.Xt.XtSports.XtScreen(Widget);}
        }

        internal string XtName {
            get { return Native.Xt.XtSports.XtName(Widget);}
        }

        public bool Equals(WidgetHandle with) {
            return (this.Widget == with.Widget);
        }

        public int Hash {
            get;
        }
    }

    public class WidgetHandleComparer : IEqualityComparer<WidgetHandle>
    {
        public bool Equals(WidgetHandle x, WidgetHandle y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(WidgetHandle obj)
        {
            return obj.Hash;
        }
    }
}
