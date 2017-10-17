using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {

    public enum XICCEncodingStyle  {
        XStringStyle = TonNurako.X11.Constant.XStringStyle,
        XCompoundTextStyle = TonNurako.X11.Constant.XCompoundTextStyle,
        XTextStyle = TonNurako.X11.Constant.XTextStyle,
        XStdICCTextStyle = TonNurako.X11.Constant.XStdICCTextStyle,
        XUTF8StringStyle = TonNurako.X11.Constant.XUTF8StringStyle,
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XTextPropertyRec {
        public IntPtr value;
        public IntPtr encoding; // ATOM
        public int format;
        public ulong nitems;
    }

    public class XTextProperty {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XwcTextListToTextProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern int XwcTextListToTextProperty(
                IntPtr display, IntPtr list, int count, XICCEncodingStyle style, ref XTextPropertyRec text_prop_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XmbTextPropertyToTextList_TNK", CharSet = CharSet.Auto)]
            internal static extern int XmbTextPropertyToTextList(IntPtr display, ref XTextPropertyRec text_prop, out IntPtr list_return, out int count_return);

            // TODO: UTF-32の上手いﾏーｼｬﾘﾝｸﾞ方法思いついたら替える
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XwcTextPropertyToTextList_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XwcTextPropertyToTextList(IntPtr display, ref XTextPropertyRec text_prop, out IntPtr list_return, out int count_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XwcFreeStringList_TNK", CharSet = CharSet.Auto)]
            internal static extern void XwcFreeStringList([In] IntPtr list);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeStringList_TNK", CharSet = CharSet.Auto)]
            internal static extern void XFreeStringList([In] IntPtr list);
        }

        internal XTextPropertyRec record;
        public XTextProperty() {
            record = new XTextPropertyRec();
        }

        public string[] TextPropertyToTextList(Display display) {
            int count = 0;
            IntPtr list;

            NativeMethods.XmbTextPropertyToTextList(display.Handle, ref record, out list , out count);
            var arr = new IntPtr[count];
            var ret = new string[count];
            Marshal.Copy(list, arr, 0, count);
            for (int i = 0; i < count; ++i) {
                ret[i] = Marshal.PtrToStringAnsi(arr[i]);
            }
            NativeMethods.XFreeStringList(list);
            return ret;
        }

        public static XTextProperty TextListToTextProperty(Display dpy, string [] list, XICCEncodingStyle style) {
            var r = new XTextProperty();

            var arr = new IntPtr[list.Length+1];
            for (int i = 0; i < list.Length; ++i) {
                byte[] b = 
                    Encoding.Convert(Encoding.Default, Encoding.UTF32, Encoding.Default.GetBytes(list[i]));

                arr[i] = Marshal.AllocCoTaskMem(b.Length+1);
                Marshal.Copy(b, 0, arr[i], b.Length);
            }
            arr[list.Length] = IntPtr.Zero;
            var addrOfArray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)) * arr.Length);
            Marshal.Copy(arr, 0, addrOfArray, arr.Length);

            int k = NativeMethods.XwcTextListToTextProperty(dpy.Handle, addrOfArray, 1, style, ref r.record);

            for (int i = 0; i < arr.Length; ++i) {
                if (arr[i] != IntPtr.Zero) {
                    Marshal.FreeCoTaskMem(arr[i]);
                }
            }
            Marshal.FreeCoTaskMem(addrOfArray);

            return r;
        }

    }
}
