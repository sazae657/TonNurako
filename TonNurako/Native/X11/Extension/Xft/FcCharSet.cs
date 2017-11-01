using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public class FcCharSet : IX11Interop, IDisposable {
        #region ﾈーﾁﾌﾞ
        internal static class NativeMethods {
            // FcCharSet*: FcCharSetCreate 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcCharSetCreate();

            // void: FcCharSetDestroy FcCharSet*:fcs  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcCharSetDestroy(IntPtr fcs);

            // FcBool: FcCharSetAddChar FcCharSet*:fcs  FcChar32:ucs4  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetAddChar_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcCharSetAddChar(IntPtr fcs, uint ucs4);

            // FcBool: FcCharSetDelChar FcCharSet*:fcs  FcChar32:ucs4  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetDelChar_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcCharSetDelChar(IntPtr fcs, uint ucs4);

            // FcCharSet*: FcCharSetCopy FcCharSet*:src  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetCopy_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcCharSetCopy(IntPtr src);

            // FcBool: FcCharSetEqual const FcCharSet*:a  const FcCharSet*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetEqual_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcCharSetEqual(IntPtr a, IntPtr b);

            // FcCharSet*: FcCharSetIntersect const FcCharSet*:a  const FcCharSet*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetIntersect_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcCharSetIntersect(IntPtr a, IntPtr b);

            // FcCharSet*: FcCharSetUnion const FcCharSet*:a  const FcCharSet*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetUnion_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcCharSetUnion(IntPtr a, IntPtr b);

            // FcCharSet*: FcCharSetSubtract const FcCharSet*:a  const FcCharSet*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetSubtract_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcCharSetSubtract(IntPtr a, IntPtr b);

            // FcBool: FcCharSetMerge FcCharSet*:a  const FcCharSet*:b  FcBool*:changed  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetMerge_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcCharSetMerge(IntPtr a, IntPtr b, out bool changed);

            // FcBool: FcCharSetHasChar const FcCharSet*:fcs  FcChar32:ucs4  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetHasChar_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcCharSetHasChar(IntPtr fcs, uint ucs4);

            // FcChar32: FcCharSetCount const FcCharSet*:a  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetCount_TNK", CharSet = CharSet.Auto)]
            internal static extern uint FcCharSetCount(IntPtr a);

            // FcChar32: FcCharSetIntersectCount const FcCharSet*:a  const FcCharSet*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetIntersectCount_TNK", CharSet = CharSet.Auto)]
            internal static extern uint FcCharSetIntersectCount(IntPtr a, IntPtr b);

            // FcChar32: FcCharSetSubtractCount const FcCharSet*:a  const FcCharSet*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetSubtractCount_TNK", CharSet = CharSet.Auto)]
            internal static extern uint FcCharSetSubtractCount(IntPtr a, IntPtr b);

            // FcBool: FcCharSetIsSubset const FcCharSet*:a  const FcCharSet*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetIsSubset_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcCharSetIsSubset(IntPtr a, IntPtr b);

            // FcChar32: FcCharSetFirstPage const FcCharSet*:a  FcChar32:map[FC_CHARSET_MAP_SIZE]  FcChar32*:next  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetFirstPage_TNK", CharSet = CharSet.Auto)]
            internal static extern uint FcCharSetFirstPage(IntPtr a, uint []map, out int next);

            // FcChar32: FcCharSetNextPage const FcCharSet*:a  FcChar32:map[FC_CHARSET_MAP_SIZE]  FcChar32*:next  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCharSetNextPage_TNK", CharSet = CharSet.Auto)]
            internal static extern uint FcCharSetNextPage(IntPtr a, uint [] map, out int next);
        }
        #endregion
        public const int FC_CHARSET_MAP_SIZE = (int)TonNurako.X11.Constant.FC_CHARSET_MAP_SIZE;
        public const int FC_CHARSET_DONE = (int)TonNurako.X11.Constant.FC_CHARSET_DONE;

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        internal FcCharSet(IntPtr ptr) {
            if (IntPtr.Zero == ptr) {
                throw new NullReferenceException("handle == NULL");
            }
            handle = ptr;
        }
        static FcCharSet WrapReturn(IntPtr p) => (new FcCharSet(p));


        public static FcCharSet Create() =>
            WrapReturn(NativeMethods.FcCharSetCreate());

        public void Destroy() {
            if (IntPtr.Zero != handle) {
                NativeMethods.FcCharSetDestroy(Handle);
                handle = IntPtr.Zero;
            }
        }

        public bool AddChar(uint ucs4) => 
            NativeMethods.FcCharSetAddChar(Handle, ucs4);
        

        public bool DelChar(uint ucs4) => 
            NativeMethods.FcCharSetDelChar(Handle, ucs4);
        

        public FcCharSet Copy() =>
            WrapReturn(NativeMethods.FcCharSetCopy(Handle));

        public uint FirstPage(uint[] map, out int next) =>
            NativeMethods.FcCharSetFirstPage(Handle, map, out next);
        

        public uint NextPage(uint[] map, out int next) =>
            NativeMethods.FcCharSetNextPage(Handle, map, out next);

        public bool HasChar(uint ucs4) =>
            NativeMethods.FcCharSetHasChar(Handle, ucs4);
        

        public uint Count() =>
            NativeMethods.FcCharSetCount(Handle);
        

        #region staticおじさん

        public static bool Equal(FcCharSet a, FcCharSet b) =>
            NativeMethods.FcCharSetEqual(a.Handle, b.Handle);

        public static FcCharSet Intersect(FcCharSet a, FcCharSet b) =>
            WrapReturn(NativeMethods.FcCharSetIntersect(a.Handle, b.Handle));


        public static FcCharSet Union(FcCharSet a, FcCharSet b) =>
            WrapReturn(NativeMethods.FcCharSetUnion(a.Handle, b.Handle));
        

        public static FcCharSet Subtract(FcCharSet a, FcCharSet b) =>
            WrapReturn(NativeMethods.FcCharSetSubtract(a.Handle, b.Handle));
        

        public static bool Merge(FcCharSet a, FcCharSet b, out bool changed) =>
            NativeMethods.FcCharSetMerge(a.Handle, b.Handle, out changed);
        


        public static uint IntersectCount(FcCharSet a, FcCharSet b) =>
            NativeMethods.FcCharSetIntersectCount(a.Handle, b.Handle);
        

        public static uint SubtractCount(FcCharSet a, FcCharSet b) =>
            NativeMethods.FcCharSetSubtractCount(a.Handle, b.Handle);
        

        public static bool SetIsSubset(FcCharSet a, FcCharSet b) =>
            NativeMethods.FcCharSetIsSubset(a.Handle, b.Handle);
        

#endregion


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                this.Destroy();
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }
        #endregion

    }
}
