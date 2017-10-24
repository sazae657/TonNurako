using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;
using TonNurako.X11.Event;

namespace TonNurako.Xt {

    internal delegate void XtActionHookProc(
          IntPtr w, // Widget 
          IntPtr client_data, //XtPointer
          string action_name, //String
          IntPtr xevent, // XEvent
          IntPtr xparams, //String*
          IntPtr num_params //Cardinal*
    );

    internal delegate void XtActionProc(
          IntPtr widget, //Widget
          IntPtr xevent, //XEvent*
          IntPtr xparams, // String* 
          IntPtr num_params // Cardinal*
    );

    public delegate void XtActionDelegate(
        Widgets.IWidget widget,
        XEventArg xevent,
        string[] xparams
    );

    [StructLayout(LayoutKind.Sequential)]
    internal struct XtActionsRec
    {
        [MarshalAs(UnmanagedType.LPStr)] string str;
        [MarshalAs(UnmanagedType.FunctionPtr)] XtActionProc proc;
        public XtActionsRec(string str, XtActionProc d) {
            this.str = str;
            this.proc = d;
        }
    }


    public struct XtAction {
        public string Str;
        public XtActionDelegate Delegaty;

        public XtAction(string str, XtActionDelegate d) {
            Str = str;
            Delegaty = d;
        }
    }

    internal delegate void XtTimerCallbackProc(
        XtTimerCallbackDelegate closure, //XtPointer
        IntPtr id //XtIntervalId*
    );

    public delegate void XtTimerCallbackDelegate(ulong id);

    public class XtAppContext : IX11Interop {
        #region NativeMethods
        internal static class NativeMethods {

            // XtActionHookId: XtAppAddActionHook XtAppContext:app_context XtActionHookProc:proc XtPointer:client_data
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddActionHook_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtAppAddActionHook(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)]XtActionHookProc proc, IntPtr client_data);

            // void: XtRemoveActionHook XtActionHookId:id
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveActionHook_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveActionHook(IntPtr id);

            // XtTranslations: XtParseTranslationTable String:table
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtParseTranslationTable_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtParseTranslationTable([MarshalAs(UnmanagedType.LPStr)] string table);


            // void: XtAppAddActions XtAppContext:app_context XtActionList:actions Cardinal:num_actions
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddActions_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppAddActions(IntPtr app_context, [MarshalAs(UnmanagedType.LPArray)]XtActionsRec[] actions, int num_actions);


            // XtIntervalId: XtAppAddTimeOut XtAppContext:app_context  long:interval  XtTimerCallbackProc:proc  XtPointer:client_data  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddTimeOut_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XtAppAddTimeOut(
                IntPtr app_context, long interval, [MarshalAs(UnmanagedType.FunctionPtr)]XtTimerCallbackProc proc, [MarshalAs(UnmanagedType.FunctionPtr)]XtTimerCallbackDelegate client_data);

            // void: XtRemoveTimeOut XtIntervalId:timer  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveTimeOut_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveTimeOut(ulong timer);


            /*
            // void: XtAugmentTranslations Widget:w XtTranslations:translations
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAugmentTranslations_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAugmentTranslations(IntPtr w, IntPtr translations);

            // void: XtOverrideTranslations Widget:w XtTranslations:translations
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtOverrideTranslations_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtOverrideTranslations(IntPtr w, IntPtr translations);

            // void: XtUninstallTranslations Widget:w
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtUninstallTranslations_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtUninstallTranslations(IntPtr w);
            */

        }
        #endregion


        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        internal XtAppContext(IntPtr ptr) {
            handle = ptr;
        }

        void xtTimerCallbackProc(
            XtTimerCallbackDelegate closure, //XtPointer
            IntPtr id //XtIntervalId*
        ) {
            closure((ulong)Marshal.ReadInt64(id));
        }

        public ulong XtAppAddTimeOut(long interval, XtTimerCallbackDelegate proc) {
            return NativeMethods.XtAppAddTimeOut(this.handle, interval, xtTimerCallbackProc, proc);
        }

        public void XtRemoveTimeOut(ulong timer) {
            NativeMethods.XtRemoveTimeOut(timer);
        }
    }
}
