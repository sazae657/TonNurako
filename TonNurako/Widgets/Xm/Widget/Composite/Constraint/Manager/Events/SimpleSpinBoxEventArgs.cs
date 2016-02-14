﻿//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System.Runtime.InteropServices;
using TonNurako.Data;

namespace TonNurako.Events
{
    public class SimpleSpinBoxEventArgs : TnkEventArgs {

        public SimpleSpinBoxEventArgs() : base() {
        }

        public string Value {
            get; internal set;
        }

        public int Position {
            get; internal set;
        }
        public bool DoIt {
            set {
                var wsb = (Native.Motif.XmStruct.XmSimpleSpinBoxCallbackStruct)
                    Marshal.PtrToStructure(rawCallData, typeof(Native.Motif.XmStruct.XmSimpleSpinBoxCallbackStruct ) );
                wsb.doit = value;
                Marshal.StructureToPtr(wsb, rawCallData, false);
            }
        }

        private System.IntPtr rawCallData = System.IntPtr.Zero;

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client)  {
            rawCallData = call;

            var callData = (Native.Motif.XmStruct.XmSimpleSpinBoxCallbackStruct)
                Marshal.PtrToStructure(call, typeof(Native.Motif.XmStruct.XmSimpleSpinBoxCallbackStruct ) );

            Value = CompoundString.AsString(callData.value);
            Position = callData.position;

            System.Diagnostics.Debug.WriteLine(DumpStruct(callData));
            Reason = ConvertReason(callData.reason);
        }

    }

}
