using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11 {

    public enum VisualClass : int {
        StaticGray = TonNurako.X11.Constant.StaticGray,
        GrayScale = TonNurako.X11.Constant.GrayScale,
        StaticColor = TonNurako.X11.Constant.StaticColor,
        PseudoColor = TonNurako.X11.Constant.PseudoColor,
        TrueColor = TonNurako.X11.Constant.TrueColor,
        DirectColor = TonNurako.X11.Constant.DirectColor,
    }

    public class Visual : IX11Interop {
        [StructLayout(LayoutKind.Sequential)]
        class VisualC {
            public IntPtr ext_data; // XExtData*
            public ulong visualid; // VisualID
            public VisualClass klass; // int
            public ulong red_mask; // unsigned long
            public ulong green_mask; // unsigned long
            public ulong blue_mask; // unsigned long
            public int bits_per_rgb; // int
            public int map_entries; // int
        }

        // TODO: どうすっか考え中
        [StructLayout(LayoutKind.Sequential)]
        class XExtData {
            public int number;
            public IntPtr next; // XExtData*
            public IntPtr free_private;    //int(* free_private)(struct _XExtData *extension);
            public IntPtr private_data;  /* data private to this extension. */
        }

        VisualC visual = new VisualC();
        XExtData extdata = null;

        public ulong VisualId => visual.visualid;
        public VisualClass Class => visual.klass;
        public ulong RedMask => visual.visualid;
        public ulong GreenMask => visual.visualid;
        public ulong BlueMask => visual.visualid;
        public int BitsPerRgb => visual.bits_per_rgb;
        public int MapEntries => visual.map_entries;


        IntPtr handle;
        public IntPtr Handle => handle;

        public Visual(IntPtr v) {
            if (IntPtr.Zero == v) {
                return;
            }
            handle = v;
            visual = (VisualC)Marshal.PtrToStructure(v, typeof(VisualC));
            if (IntPtr.Zero != visual.ext_data) {
                extdata = (XExtData)Marshal.PtrToStructure(visual.ext_data, typeof(XExtData));
            }
        }

        public int Free() {
            return TonNurako.Native.ExtremeSports.CallPtrArg1ReturnInt(extdata.free_private, visual.ext_data);
        }
    }
}
