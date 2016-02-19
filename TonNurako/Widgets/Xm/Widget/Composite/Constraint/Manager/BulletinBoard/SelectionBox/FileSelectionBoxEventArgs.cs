//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System.Runtime.InteropServices;

namespace TonNurako.Events {
    /// <summary>
    /// 
    /// </summary>
    public class FileSelectionBoxEventArgs : TnkEventArgs {

        public FileSelectionBoxEventArgs() {
        }
        
        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client) {
            var callData = (Native.Motif.XmStruct.XmFileSelectionBoxCallbackStruct)
            Marshal.PtrToStructure(call, typeof(Native.Motif.XmStruct.XmFileSelectionBoxCallbackStruct) );

            Reason = ConvertReason(callData.reason);
        }

    }
}
