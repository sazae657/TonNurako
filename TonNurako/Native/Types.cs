//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Collections.Generic;

namespace TonNurako.Native {

    /// <summary>
    /// ﾈーﾁﾌﾞなﾊﾝﾄﾞﾙへのｱｸｾｯｻー
    /// </summary>
    public class WidgetHandle
    {
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        /// <param name="ptr">Widget</param>
        public WidgetHandle(System.IntPtr ptr) {
            if (IntPtr.Zero == ptr) {
                throw new NullReferenceException("Null Widget!!");
            }
            Widget = ptr;
            Hash = ptr.ToInt64().ToString().GetHashCode();
        }

        /// <summary>
        /// Widget
        /// </summary>
        /// <returns>Widget</returns>
        public IntPtr Widget {
            get;
        }

        /// <summary>
        /// Display
        /// </summary>
        /// <returns>Display</returns>
        public IntPtr Display {
            get { return Native.Xt.XtSports.XtDisplay(Widget);}
        }

        /// <summary>
        /// Window
        /// </summary>
        /// <returns>Window</returns>
        public IntPtr Window {
            get { return Native.Xt.XtSports.XtWindow(Widget);}
        }

        /// <summary>
        /// Screen
        /// </summary>
        /// <returns>Screen</returns>
        public IntPtr Screen {
            get { return Native.Xt.XtSports.XtScreen(Widget);}
        }

        /// <summary>
        /// Name
        /// </summary>
        /// <returns>Name</returns>
        public string XtName {
            get { return Native.Xt.XtSports.XtName(Widget);}
        }

        /// <summary>
        /// 比較
        /// </summary>
        /// <param name="with">比較元</param>
        /// <returns>比較結果</returns>
        public bool Equals(WidgetHandle with) {
            return (this.Widget == with.Widget);
        }

        /// <summary>
        /// ﾊｯｼｭ
        /// </summary>
        /// <returns>ﾊｯｼｭ</returns>
        public int Hash {
            get;
        }
    }


    /// <summary>
    /// WidgetHandleの比較演算子
    /// </summary>
    public class WidgetHandleComparer : IEqualityComparer<WidgetHandle>
    {
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns></returns>
        public bool Equals(WidgetHandle x, WidgetHandle y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// ﾊｯｼｭ
        /// </summary>
        /// <param name="obj">WidgetHandle</param>
        /// <returns>ﾊｯｼｭ</returns>
        public int GetHashCode(WidgetHandle obj)
        {
            return obj.Hash;
        }
    }
}
