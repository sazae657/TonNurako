using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public class FontConfig {
        internal static class NativeMethods {
            // FcBool: FcInit 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcInit_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcInit();

            // void: FcFini 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFini_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcFini();
        }

        public static bool FcInit() {
            return NativeMethods.FcInit();
        }

        public static void FcFini() {
            NativeMethods.FcFini();
        }

    }
}
