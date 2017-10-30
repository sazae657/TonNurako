using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;

namespace TonNurako.Extension.Xft {
    public enum FcResult :int {
        Match = TonNurako.X11.Constant.FcResultMatch,
        NoMatch = TonNurako.X11.Constant.FcResultNoMatch,
        TypeMismatch = TonNurako.X11.Constant.FcResultTypeMismatch,
        NoId = TonNurako.X11.Constant.FcResultNoId,
        OutOfMemory = TonNurako.X11.Constant.FcResultOutOfMemory,
    }
    

    public class FcPattern :IX11Interop {
        internal static class NativeMethods {
            // void: FcPatternDestroy FcPattern*:p  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcPatternDestroy(IntPtr p);

            // FcPattern*: XftXlfdParse char*:xlfd_orig  Bool:ignore_scalable  Bool:complete  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftXlfdParse_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftXlfdParse(
                [MarshalAs(UnmanagedType.LPStr)] string xlfd_orig, [MarshalAs(UnmanagedType.U1)] bool ignore_scalable, [MarshalAs(UnmanagedType.U1)] bool complete);

            // FcPattern*: FcNameParse FcChar8*:name  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcNameParse_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcNameParse([MarshalAs(UnmanagedType.LPStr)]string name);

        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        public FcPattern() {
        }

        internal FcPattern(IntPtr ptr) {
            handle = ptr;
        }

        public void Destroy() {
            if (handle == IntPtr.Zero) {
                return;
            }
            NativeMethods.FcPatternDestroy(handle);
            handle = IntPtr.Zero;
        }

        #region staticおじさん
        public static FcPattern ParseXlfd(string xlfd_orig, bool ignore_scalable, bool complete) {
            var r = NativeMethods.XftXlfdParse(xlfd_orig, ignore_scalable, complete);
            if (r == IntPtr.Zero) {
                return null;
            }
            return (new FcPattern(r));
        }

        public static FcPattern Parse(string name) {
            var r = NativeMethods.FcNameParse(name);
            if (r == IntPtr.Zero) {
                return null;
            }
            return (new FcPattern(r));
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        // ~Region() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
