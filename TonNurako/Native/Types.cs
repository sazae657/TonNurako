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
    public class NativeWidget {
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        /// <param name="ptr">Widget</param>
        public NativeWidget(System.IntPtr ptr) {
            if (IntPtr.Zero == ptr) {
                throw new NullReferenceException("Null Widget!!");
            }
            Widget = new X11.Widget(ptr);

            Display = new X11.Display(Native.Xt.XtSports.XtDisplay(ptr));
            Window = new X11.Window(Native.Xt.XtSports.XtWindow(ptr));
            Screen = new X11.Screen(Native.Xt.XtSports.XtScreen(ptr));

            Hash = ptr.ToInt64().ToString().GetHashCode();
        }

        /// <summary>
        /// Widget
        /// </summary>
        /// <returns>Widget</returns>
        public X11.Widget Widget {
            get;
        }

        /// <summary>
        /// Display
        /// </summary>
        /// <returns>Display</returns>
        public X11.Display Display { get; }

        /// <summary>
        /// Window
        /// </summary>
        /// <returns>Window</returns>
        public X11.Window Window { get; }


        /// <summary>
        /// RootWindowOfScreen
        /// </summary>
        /// <returns>RootWindowOfScreen</returns>
        public X11.Window RootWindowOfScreen { get; }


        /// <summary>
        /// Screen
        /// </summary>
        /// <returns>Screen</returns>
        public X11.Screen Screen { get; }

        /// <summary>
        /// Name
        /// </summary>
        /// <returns>Name</returns>
        public string XtName =>
            Native.Xt.XtSports.XtName(Widget.Handle);
        

        /// <summary>
        /// 比較
        /// </summary>
        /// <param name="with">比較元</param>
        /// <returns>比較結果</returns>
        public bool Equals(NativeWidget with) => (this.Widget == with.Widget);
        
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
    public class NativeWidgetComparer : IEqualityComparer<NativeWidget>
    {
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns></returns>
        public bool Equals(NativeWidget x, NativeWidget y) => x.Equals(y);
        
        /// <summary>
        /// ﾊｯｼｭ
        /// </summary>
        /// <param name="obj">WidgetHandle</param>
        /// <returns>ﾊｯｼｭ</returns>
        public int GetHashCode(NativeWidget obj) => obj.Hash;
    }
}
