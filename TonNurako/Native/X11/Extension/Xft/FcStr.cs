﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {

    public class FcStrList : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcStrList*: FcStrListCreate FcStrSet*:set  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcStrListCreate(IntPtr set);

            // void: FcStrListFirst FcStrList*:list  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListFirst_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcStrListFirst(IntPtr list);

            // FcChar8*: FcStrListNext FcStrList*:list  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListNext_TNK", CharSet = CharSet.Auto)]
            internal static extern string FcStrListNext(IntPtr list);

            // void: FcStrListDone FcStrList*:list  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListDone_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcStrListDone(IntPtr list);

        }
        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        internal FcStrList(IntPtr ptr) {
            handle = ptr;
        }

        public static FcStrList Create(FcStrSet set) =>
            new FcStrList(NativeMethods.FcStrListCreate(set.Handle));


        public void First() =>
            NativeMethods.FcStrListFirst(Handle);


        public string Next() =>
            NativeMethods.FcStrListNext(Handle);

        public void Done() {
            if (IntPtr.Zero != handle) {
                NativeMethods.FcStrListDone(Handle);
                handle = IntPtr.Zero;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Done();
            }
        }

        // ~FcStrList() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class FcStrSet : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcStrSet*: FcStrSetCreate 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcStrSetCreate();

            // FcBool: FcStrSetMember FcStrSet*:set  const FcChar8*:s  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetMember_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcStrSetMember(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // FcBool: FcStrSetEqual FcStrSet*:sa  FcStrSet*:sb  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetEqual_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcStrSetEqual(IntPtr sa, IntPtr sb);

            // FcBool: FcStrSetAdd FcStrSet*:set  const FcChar8*:s  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetAdd_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcStrSetAdd(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // FcBool: FcStrSetAddFilename FcStrSet*:set  const FcChar8*:s  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetAddFilename_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcStrSetAddFilename(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // FcBool: FcStrSetDel FcStrSet*:set  const FcChar8*:s  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetDel_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcStrSetDel(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // void: FcStrSetDestroy FcStrSet*:set  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcStrSetDestroy(IntPtr set);

        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        public FcStrSet() {
        }

        internal FcStrSet(IntPtr ptr) {
            this.intPtr = ptr;
        }

        public static FcStrSet Create() =>
            new FcStrSet(NativeMethods.FcStrSetCreate());


        public bool Member(string s) =>
            NativeMethods.FcStrSetMember(Handle, s);


        public bool Equal(FcStrSet sb) =>
            NativeMethods.FcStrSetEqual(Handle, sb.handle);


        public bool Add(string s) =>
            NativeMethods.FcStrSetAdd(Handle, s);


        public bool AddFilename(string s) =>
            NativeMethods.FcStrSetAddFilename(Handle, s);

        public bool Del(string s) =>
            NativeMethods.FcStrSetDel(Handle, s);

        public void Destroy() =>
            NativeMethods.FcStrSetDestroy(Handle);



        #region IDisposable Support
        private bool disposedValue = false;
        private IntPtr intPtr;



        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        // ~FcStrSet() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}