//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class TextVerifyEventArgs : TnkEventArgs {

        public TextVerifyEventArgs() : base() {
        }

        public bool DoIt {
            set {
                var wsb = (Native.Motif.XmStruct.XmTextVerifyCallbackStruct)
                    Marshal.PtrToStructure(rawCallData, typeof(Native.Motif.XmStruct.XmTextVerifyCallbackStruct ) );
                wsb.doit = value;
                Marshal.StructureToPtr(wsb, rawCallData, false);
            }
        }

        public string InputString {
            get; internal set;
        }

        public int InputLength {
            get; internal set;
        }

        private System.IntPtr rawCallData = System.IntPtr.Zero;

        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            rawCallData = call;
            var callData = (Native.Motif.XmStruct.XmTextVerifyCallbackStruct)
                Marshal.PtrToStructure(call, typeof(Native.Motif.XmStruct.XmTextVerifyCallbackStruct ) );

            System.Diagnostics.Debug.WriteLine(DumpStruct(callData));

            Reason = ConvertReason(callData.reason);

            if (IntPtr.Zero != callData.textBlock &&
                Reason != CallReason.MOVING_INSERT_CURSOR)
            {
                var block = (Native.Motif.XmStruct.XmTextBlockRec)
                    Marshal.PtrToStructure(callData.textBlock, typeof(Native.Motif.XmStruct.XmTextBlockRec ) );

                System.Diagnostics.Debug.WriteLine(DumpStruct(block));
                InputLength = block.length;
                if (block.length > 0) {
                    InputString = Marshal.PtrToStringAnsi(block.ptr, block.length);
                }
            }
        }

    }
}
