//
// ﾄﾝﾇﾗｺ
//
// XToolkit
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Native.Xt
{
    /// <summary>
    /// Xtﾛーﾀﾞー
    /// </summary>
    public class XtSports : Native.ExtremeSportsLoader {
        private static XtSports Instance {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="libXtName"></param>
        public static void Register(string libXtName) {
            if (null != Instance) {
                return;
            }
            Instance = new XtSports(libXtName);
        }

        public static void Unregister() {
            if (null == Instance) {
                return;
            }
            System.Diagnostics.Debug.WriteLine("Xt: unregister");
            Instance.Dispose();
            Instance = null;
        }

        private XtSports(string lib) : base(lib) {
        }


        internal static class NativeMethods
        {
            [DllImport(ExtremeSports.Lib, EntryPoint="XtFree_TNK", CharSet=CharSet.Auto) ]
            public static extern void XtFree( IntPtr str );

            [DllImport(ExtremeSports.Lib, EntryPoint="XtNameToWidget_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr XtNameToWidget(IntPtr parent, [MarshalAs(UnmanagedType.LPStr)]string name);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtDestroyWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtDestroyWidget(IntPtr wgt);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtUnmanageChild_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtUnmanageChild(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtManageChild_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtManageChild(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtUnmapWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtUnmapWidget(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtRealizeWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtRealizeWidget(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtMapWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtMapWidget(IntPtr wgt);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtIsManaged_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtIsManaged(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtDisplay_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtDisplay(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtScreen_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtScreen(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtWindow_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtWindow(IntPtr wgt);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtName_TNK", CharSet=CharSet.Auto)]
            public static extern IntPtr XtName(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtRemoveCallback_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void XtRemoveCallback(IntPtr w,
                [MarshalAs(UnmanagedType.LPStr)]string type, G.XtCallBack call ,IntPtr client);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtAddCallback_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void XtAddCallback(IntPtr w,
                [MarshalAs(UnmanagedType.LPStr)]string type, G.XtCallBack call ,IntPtr client);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtLastTimestampProcessed_TNK", CharSet=CharSet.Auto)]
            public static extern uint XtLastTimestampProcessed(IntPtr display);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtParseTranslationTable_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XtParseTranslationTable([MarshalAs(UnmanagedType.LPStr)] string table);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtAugmentTranslations_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtAugmentTranslations(IntPtr w, IntPtr translations);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtOverrideTranslations_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtOverrideTranslations(IntPtr w, IntPtr translations);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtUninstallTranslations_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtUninstallTranslations(IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtParseAcceleratorTable_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XtParseAcceleratorTable([MarshalAs(UnmanagedType.LPStr)] string source);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtInstallAccelerators_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtInstallAccelerators(IntPtr destination, IntPtr source);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtInstallAllAccelerators_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtInstallAllAccelerators(IntPtr destination, IntPtr source);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtAddEventHandler_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtAddEventHandler(IntPtr w, ulong event_mask,
                    [MarshalAs(UnmanagedType.U1)] bool nonmaskable, TonNurako.Native.Xt.G.XtEventHandler proc, IntPtr client_data);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtRemoveEventHandler_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtRemoveEventHandler(IntPtr w, ulong event_mask,
                    [MarshalAs(UnmanagedType.U1)] bool nonmaskable, TonNurako.Native.Xt.G.XtEventHandler proc, IntPtr client_data);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtInitializeWidgetClass_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtInitializeWidgetClass(IntPtr glass);

            [DllImport(ExtremeSports.Lib, EntryPoint="TNK_GetWidgetClass", CharSet=CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetClass(Motif.WidgetClass glass);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtGetGC_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XtGetGC(IntPtr w, X11.GCMask value_mask, [In,Out]ref X11.XGCValues values);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtGetGC_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XtGetGC(IntPtr w, X11.GCMask value_mask, IntPtr values);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtReleaseGC_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtReleaseGC(IntPtr w, [In]IntPtr gc);
        }

        public static void XtFree(IntPtr str) {
            NativeMethods.XtFree(str);
        }

        public static Widgets.IWidget XtNameToWidget(Widgets.IWidget parent, string name)
        {
            var handle = NativeMethods.XtNameToWidget(parent.NativeHandle.Widget, name);
            if (IntPtr.Zero == handle) {
                return null;
            }
            var widget = parent.AppContext.FindWidgetByHandle(handle);
            if (null != widget) {
                return widget;
            }
            return (new Widgets.ﾄﾝﾇﾗｼﾞｪｯﾄ(handle, parent));
        }

        public static void  XtDestroyWidget(Widgets.IWidget wgt) {
            NativeMethods.XtDestroyWidget(wgt.NativeHandle.Widget);
        }
        public static  void  XtUnmanageChild(Widgets.IWidget wgt) {
            NativeMethods.XtUnmanageChild(wgt.NativeHandle.Widget);
        }
        public static  void  XtManageChild(Widgets.IWidget wgt) {
            NativeMethods.XtManageChild(wgt.NativeHandle.Widget);
        }

        public static  void  XtUnmapWidget(Widgets.IWidget wgt) {
            NativeMethods.XtUnmapWidget(wgt.NativeHandle.Widget);
        }

        public static  void  XtRealizeWidget(Widgets.IWidget wgt) {
            NativeMethods.XtRealizeWidget(wgt.NativeHandle.Widget);
        }

        public static  bool  XtIsManaged(Widgets.IWidget wgt) {
            return (NativeMethods.XtIsManaged(wgt.NativeHandle.Widget).ToInt32() == 0) ? false : true;
        }

        public static  void  XtMapWidget(Widgets.IWidget wgt) {
            NativeMethods.XtMapWidget(wgt.NativeHandle.Widget);
        }

        public static  IntPtr  XtScreen(Widgets.IWidget wgt) {
            return NativeMethods.XtScreen(wgt.NativeHandle.Widget);
        }
        public static  IntPtr  XtScreen(IntPtr wgt) {
            return NativeMethods.XtScreen(wgt);
        }

        public static  IntPtr  XtDisplay(Widgets.IWidget wgt) {
            return NativeMethods.XtDisplay(wgt.NativeHandle.Widget);
        }

        public static  IntPtr  XtDisplay(IntPtr wgt) {
            return NativeMethods.XtDisplay(wgt);
        }

        public static  IntPtr  XtWindow(Widgets.IWidget wgt) {
            return NativeMethods.XtWindow(wgt.NativeHandle.Widget);
        }
        public static  IntPtr  XtWindow(IntPtr wgt) {
            return NativeMethods.XtWindow(wgt);
        }

        public static string XtName(IntPtr wgt) {
            IntPtr ip = NativeMethods.XtName(wgt);
            if (IntPtr.Zero != ip) {
                return Marshal.PtrToStringAnsi(ip);
            }
            return null;
        }

        public static  void  XtRemoveCallback(Widgets.IWidget wgt, string type, G.XtCallBack call) {
            NativeMethods.XtRemoveCallback(wgt.NativeHandle.Widget, type, call, IntPtr.Zero);
        }

        public static  void  XtAddCallback(Widgets.IWidget wgt, string type, G.XtCallBack call ) {
            NativeMethods.XtAddCallback(wgt.NativeHandle.Widget, type, call, IntPtr.Zero);
        }
        public static uint XtLastTimestampProcessed(IntPtr display) {
            return NativeMethods.XtLastTimestampProcessed(display);
        }


        public static IntPtr XtParseTranslationTable(string table) {
            return NativeMethods.XtParseTranslationTable(table);
        }


        public static void XtAugmentTranslations(Widgets.IWidget wgt, IntPtr translations) {
            NativeMethods.XtAugmentTranslations(wgt.NativeHandle.Widget,translations);
        }


        public static void XtOverrideTranslations(Widgets.IWidget wgt, IntPtr translations) {
            NativeMethods.XtOverrideTranslations(wgt.NativeHandle.Widget,translations);
        }


        public static void XtUninstallTranslations(Widgets.IWidget wgt) {
            NativeMethods.XtUninstallTranslations(wgt.NativeHandle.Widget);
        }


        public static IntPtr XtParseAcceleratorTable(string source) {
            return NativeMethods.XtParseAcceleratorTable(source);
        }


        public static void XtInstallAccelerators(Widgets.IWidget destination, Widgets.IWidget source) {
            NativeMethods.XtInstallAccelerators(destination.NativeHandle.Widget, source.NativeHandle.Widget);
        }


        public static void XtInstallAllAccelerators(Widgets.IWidget destination, Widgets.IWidget source) {
            NativeMethods.XtInstallAllAccelerators(destination.NativeHandle.Widget, source.NativeHandle.Widget);
        }

        public static void XtAddEventHandler(Widgets.IWidget w, ulong event_mask, bool nonmaskable,
                     TonNurako.Native.Xt.G.XtEventHandler proc, IntPtr client_data) {
            NativeMethods.XtAddEventHandler(w.NativeHandle.Widget, event_mask,nonmaskable,proc,client_data);
        }


        public static void XtRemoveEventHandler(Widgets.IWidget w, ulong event_mask, bool nonmaskable,
            TonNurako.Native.Xt.G.XtEventHandler proc, IntPtr client_data) {
            NativeMethods.XtRemoveEventHandler(w.NativeHandle.Widget,event_mask,nonmaskable,proc,client_data);
        }

        public static IntPtr XtGetGC(Widgets.IWidget w, X11.GCMask value_mask, ref X11.XGCValues values) {
            return NativeMethods.XtGetGC(w.NativeHandle.Widget, value_mask, ref values);
        }

        public static IntPtr XtGetGC(Widgets.IWidget w) {
            return NativeMethods.XtGetGC(w.NativeHandle.Widget, 0, IntPtr.Zero);
        }

        internal static void XtReleaseGC(Widgets.IWidget w, IntPtr gc) {
            NativeMethods.XtReleaseGC(w.NativeHandle.Widget, gc);
        }

        // 一時的
        public static void XtInitializeWidgetClass(Native.Motif.WidgetClass glass) {
            var ptr = NativeMethods.TNK_GetWidgetClass(glass);
            if (IntPtr.Zero == ptr) {
                throw new Exception($"NullWidget {glass.ToString()}");
            }
            NativeMethods.XtInitializeWidgetClass(ptr);

        }
    }
}
