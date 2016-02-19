//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Widgets.Xm;

namespace TonNurako.Events
{
    /// <summary>
    /// PushButtonEventArgs
    /// </summary>
    public class PushButtonEventArgs : TnkEventArgs {

        public int ClickCount {
            get;
            private set;
        }

        public PushButtonEventArgs() : base() {
        }

        internal override void ParseXEvent(IntPtr call, System.IntPtr client) {
            var callData = (Native.Motif.XmStruct.XmPushButtonCallbackStruct)
            Marshal.PtrToStructure(call, typeof(Native.Motif.XmStruct.XmPushButtonCallbackStruct ) );
            Reason = ConvertReason(callData.reason);
            ClickCount = callData.click_count;

        }


    }

    /// <summary>
    /// ToggleButtonEventArgs
    /// </summary>
    public class ToggleButtonEventArgs : TnkEventArgs {

        public ToggleButtonState Set {
            get;
            private set;
        }

        public ToggleButtonEventArgs() : base() {
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client) {
            var callData = (Native.Motif.XmStruct.XmToggleButtonCallbackStruct)
                Marshal.PtrToStructure(call, typeof(Native.Motif.XmStruct.XmToggleButtonCallbackStruct ));

            Reason = ConvertReason(callData.reason);
            Set = (ToggleButtonState)callData.set;
        }
    }
}
