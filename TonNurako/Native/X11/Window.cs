using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {
    public class Window : IX11Interop, IDrawable {
        ReturnPointerDelegaty delegaty;
        IntPtr window;
        Display display;

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultRootWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultRootWindow(IntPtr dpy);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSelectInput_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSelectInput(IntPtr display, IntPtr w, ulong event_mask);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMapWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XMapWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMapRaised_TNK", CharSet = CharSet.Auto)]
            internal static extern int XMapRaised(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMapSubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern int XMapSubwindows(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUnmapWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUnmapWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUnmapSubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUnmapSubwindows(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XRaiseWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRaiseWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XLowerWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XLowerWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMProtocols_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetWMProtocols(IntPtr display, IntPtr w, IntPtr protocols, int count);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMProtocols_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetWMProtocols(IntPtr display, IntPtr w, out IntPtr protocols_return, out int count_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDestroyWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XDestroyWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDestroySubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern int XDestroySubwindows(IntPtr display, IntPtr w);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XChangeWindowAttributes_TNK", CharSet = CharSet.Auto)]
            internal static extern int XChangeWindowAttributes(IntPtr display, IntPtr w, ulong valuemask, ref XSetWindowAttributesRec attributes);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBackground_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetWindowBackground(IntPtr display, IntPtr w, ulong background_pixel);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBorder_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetWindowBorder(IntPtr display, IntPtr w, ulong border_pixel);

            // int: XSetWindowBackgroundPixmap [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Pixmap', 'name': 'background_pixmap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBackgroundPixmap_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetWindowBackgroundPixmap(IntPtr display, IntPtr w, IntPtr background_pixmap);


            // int: XSetWindowBorderPixmap [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Pixmap', 'name': 'border_pixmap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBorderPixmap_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetWindowBorderPixmap(IntPtr display, IntPtr w, IntPtr border_pixmap);

            // int: XSetWindowColormap [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Colormap', 'name': 'colormap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowColormap_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetWindowColormap(IntPtr display, IntPtr w, IntPtr colormap);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWindowAttributes_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetWindowAttributes(IntPtr display, IntPtr w, out XWindowAttributesRec window_attributes_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetGeometry_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetGeometry(IntPtr display, IntPtr d,
                out IntPtr root_return, out int x_return, out int y_return, out int width_return, out int height_return, out int border_width_return, out int depth_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetClassHint_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetClassHint(IntPtr display, IntPtr w, ref XClassHint class_hints);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetClassHint_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetClassHint(IntPtr display, IntPtr w, out XClassHintRec class_hints_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGrabKey_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGrabKey(
                IntPtr display, int keycode, uint modifiers, IntPtr grab_window, [MarshalAs(UnmanagedType.U1)] bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUngrabKey_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUngrabKey(IntPtr display, int keycode, uint modifiers, IntPtr grab_window);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XGrabButton_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGrabButton(IntPtr display, uint button, uint modifiers, IntPtr grab_window, [MarshalAs(UnmanagedType.U1)] bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, IntPtr confine_to, int cursor);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUngrabButton_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUngrabButton(IntPtr display, uint button, uint modifiers, IntPtr grab_window);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XMoveWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XMoveWindow(IntPtr display, IntPtr w, int x, int y);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XResizeWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XResizeWindow(IntPtr display, IntPtr w, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMoveResizeWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XMoveResizeWindow(IntPtr display, IntPtr w, int x, int y, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBorderWidth_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetWindowBorderWidth(IntPtr display, IntPtr w, uint width);

            // int: XCirculateSubwindows [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'int', 'name': 'direction'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCirculateSubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern int XCirculateSubwindows(IntPtr display, IntPtr w, int direction);

            // int: XCirculateSubwindowsUp [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCirculateSubwindowsUp_TNK", CharSet = CharSet.Auto)]
            internal static extern int XCirculateSubwindowsUp(IntPtr display, IntPtr w);

            // int: XCirculateSubwindowsDown [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCirculateSubwindowsDown_TNK", CharSet = CharSet.Auto)]
            internal static extern int XCirculateSubwindowsDown(IntPtr display, IntPtr w);

            // int: XRestackWindows [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'windows[]'}, {'type': 'int', 'name': 'nwindows'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRestackWindows_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRestackWindows(IntPtr display, IntPtr[] windows, int nwindows);

            // int: XWindowEvent [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'long', 'name': 'event_mask'}, {'type': 'XEvent*', 'name': 'event_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XWindowEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern int XWindowEvent(IntPtr display, IntPtr w, long event_mask, out IntPtr event_return);

            // Bool: XCheckWindowEvent [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'long', 'name': 'event_mask'}, {'type': 'XEvent*', 'name': 'event_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckWindowEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckWindowEvent(IntPtr display, IntPtr w, long event_mask, out IntPtr event_return);

            // int: XMaskEvent [{'type': 'Display*', 'name': 'display'}, {'type': 'long', 'name': 'event_mask'}, {'type': 'XEvent*', 'name': 'event_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XMaskEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern int XMaskEvent(IntPtr display, long event_mask, out IntPtr event_return);

            // Bool: XCheckMaskEvent [{'type': 'Display*', 'name': 'display'}, {'type': 'long', 'name': 'event_mask'}, {'type': 'XEvent*', 'name': 'event_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckMaskEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckMaskEvent(IntPtr display, long event_mask, out IntPtr event_return);

            // Bool: XCheckTypedEvent [{'type': 'Display*', 'name': 'display'}, {'type': 'int', 'name': 'event_type'}, {'type': 'XEvent*', 'name': 'event_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckTypedEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckTypedEvent(IntPtr display, int event_type, out IntPtr event_return);

            // Bool: XCheckTypedWindowEvent [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'int', 'name': 'event_type'}, {'type': 'XEvent*', 'name': 'event_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckTypedWindowEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckTypedWindowEvent(IntPtr display, IntPtr w, int event_type, out IntPtr event_return);

            // int: XConfigureWindow [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'unsigned', 'name': 'value_mask'}, {'type': 'XWindowChanges*', 'name': 'changes'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XConfigureWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XConfigureWindow(IntPtr display, IntPtr w, uint value_mask, IntPtr changes);

            // Status: XQueryTree [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Window*', 'name': 'root_return'}, {'type': 'Window*', 'name': 'parent_return'}, {'type': 'Window*', 'name': '*children_return'}, {'type': 'unsigned int*', 'name': 'nchildren_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XQueryTree_TNK", CharSet = CharSet.Auto)]
            internal static extern int XQueryTree(IntPtr display, IntPtr w, out IntPtr root_return, out IntPtr parent_return, out IntPtr children_return, out IntPtr nchildren_return);

            // int: XSetTransientForHint [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Window', 'name': 'prop_window'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetTransientForHint_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetTransientForHint(IntPtr display, IntPtr w, IntPtr prop_window);

            // Status: XGetTransientForHint [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Window*', 'name': 'prop_window_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetTransientForHint_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetTransientForHint(IntPtr display, IntPtr w, out IntPtr prop_window_return);


            // int: XGetWindowProperty [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Atom', 'name': 'property'}, {'type': 'long', 'name': 'long_offset'}, {'type': 'long', 'name': 'long_length'}, {'type': 'Bool', 'name': 'delete'}, {'type': 'Atom', 'name': 'req_type'}, {'type': 'Atom*', 'name': 'actual_type_return'}, {'type': 'int*', 'name': 'actual_format_return'}, {'type': 'unsigned long*', 'name': 'nitems_return'}, {'type': 'unsigned long*', 'name': 'bytes_after_return'}, {'type': 'unsigned char*', 'name': '*prop_return'}]
            // [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWindowProperty_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            // internal static extern int XGetWindowProperty(IntPtr display, IntPtr w, ulong property, long long_offset, long long_length, [MarshalAs(UnmanagedType.U1)] bool delete, ulong req_type, IntPtr actual_type_return, out IntPtr actual_format_return, out IntPtr nitems_return, out IntPtr bytes_after_return, [MarshalAs(UnmanagedType.LPStr)] string prop_return);

            // Atom*: XListProperties [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'int*', 'name': 'num_prop_return'}]
            // [DllImport(ExtremeSports.Lib, EntryPoint = "XListProperties_TNK", CharSet = CharSet.Auto)]
            // internal static extern IntPtr XListProperties(IntPtr display, IntPtr w, out IntPtr num_prop_return);

            //[DllImport(ExtremeSports.Lib, EntryPoint = "XChangeProperty_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            //internal static extern int XChangeProperty(IntPtr display, IntPtr w, ulong property, ulong type, int format, int mode, [MarshalAs(UnmanagedType.LPStr)] string data, int nelements);

            //[DllImport(ExtremeSports.Lib, EntryPoint = "XRotateWindowProperties_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XRotateWindowProperties(IntPtr display, IntPtr w, ulong [] properties, int num_prop, int npositions);

            //[DllImport(ExtremeSports.Lib, EntryPoint = "XDeleteProperty_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XDeleteProperty(IntPtr display, IntPtr w, ulong property);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetTextProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetTextProperty(IntPtr display, IntPtr w, IntPtr text_prop, ulong property);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetTextProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetTextProperty(IntPtr display, IntPtr w, IntPtr text_prop_return, ulong property);

            /* [DllImport(ExtremeSports.Lib, EntryPoint = "XmbSetWMProperties_TNK", CharSet = CharSet.Auto)]
             internal static extern void XmbSetWMProperties(
                 IntPtr display, IntPtr w, [MarshalAs(UnmanagedType.LPStr)] string window_name, [MarshalAs(UnmanagedType.LPStr)] string icon_name, [MarshalAs(UnmanagedType.LPStr)] string[] argv, int argc, ref XSizeHints normal_hints, ref XWMHintsRec wm_hints, ref XClassHintRec class_hints);

             [DllImport(ExtremeSports.Lib, EntryPoint = "XmbSetWMProperties_TNK", CharSet = CharSet.Auto)]
             internal static extern void XmbSetWMProperties(
                 IntPtr display, IntPtr w, 
                 [In] byte[] window_name, [In] byte[] icon_name, [MarshalAs(UnmanagedType.LPStr)] string[] argv, int argc,
                 IntPtr normal_hints, IntPtr wm_hints, IntPtr class_hints);
                 */


            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMName_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetWMName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMName_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetWMName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XStoreName_TNK", CharSet = CharSet.Auto)]
            internal static extern int XStoreName(IntPtr display, IntPtr w, [MarshalAs(UnmanagedType.LPStr)] string window_name);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFetchName_TNK", CharSet = CharSet.Auto)]
            internal static extern int XFetchName(IntPtr display, IntPtr w, out IntPtr window_name_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMIconName_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetWMIconName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMIconName_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetWMIconName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetIconName_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetIconName(IntPtr display, IntPtr w, [MarshalAs(UnmanagedType.LPStr)] string icon_name);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetIconName_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetIconName(IntPtr display, IntPtr w, out IntPtr icon_name_return);

        }

        public static Window GetDefaultRootWindow(Display dpy) {
            return (new Window(NativeMethods.DefaultRootWindow(dpy.Handle), dpy));
        }

        public Window(ReturnPointerDelegaty delegaty, Display display) {
            this.delegaty = delegaty;
            this.display = display;
        }

        public Window(IntPtr window, Display display) {
            this.window = window;
            this.display = display;
        }

        public Window() {
        }

        public void Assign(IntPtr window, Display display) {
            this.window = window;
            this.display = display;
        }

        public void Assign(ReturnPointerDelegaty delegaty, Display display) {
            this.delegaty = delegaty;
            this.display = display;
        }

        public IntPtr Handle =>
            (delegaty != null) ? delegaty() : window;

        public Display Display => display;

        #region IDrawable
        IntPtr IDrawable.Drawable => Handle;
        #endregion

        public int SelectInput(EventMask mask) {
            return NativeMethods.XSelectInput(display.Handle, Handle, (ulong)mask);
        }


        public int SetWMProtocols(IEnumerable<Atom> atoms) {
            var arr = new List<IntPtr>();
            foreach (var a in atoms) {
                arr.Add(a.Handle);
            }
            var addrOfArray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)) * arr.Count);
            Marshal.Copy(arr.ToArray(), 0, addrOfArray, arr.Count);
            var rv = NativeMethods.XSetWMProtocols(display.Handle, Handle, addrOfArray, arr.Count);
            Marshal.FreeCoTaskMem(addrOfArray);
            return rv;
        }

        public IEnumerable<Atom> GetWMProtocols() {
            IntPtr arr;
            int count;
            var ret = new List<Atom>();
            NativeMethods.XGetWMProtocols(display.Handle, Handle, out arr, out count);
            if (0 == count) {
                return ret;
            }

            IntPtr[] ps = new IntPtr[count];
            Marshal.Copy(arr, ps, 0, count);
            foreach (var i in ps) {
                ret.Add(new Atom(i, display));
            }
            return ret;
        }

        public void SetWMName(XTextProperty property) {
            NativeMethods.XSetWMName(display.Handle, Handle, ref property.record);
        }

        public void SetWMIconName(XTextProperty property) {
            NativeMethods.XSetWMIconName(display.Handle, Handle, ref property.record);
        }

        public XTextProperty GetWMName() {
            var r = new XTextProperty();
            NativeMethods.XGetWMName(display.Handle, Handle, ref r.record);
            return r;
        }

        public XTextProperty XGetWMIconName() {
            var r = new XTextProperty();
            NativeMethods.XGetWMIconName(display.Handle, Handle, ref r.record);
            return r;
        }

        public int StoreName(string window_name) =>
            NativeMethods.XStoreName(display.Handle, Handle, window_name);

        string sfr(IntPtr str) {
            if (str == IntPtr.Zero) {
                return null;
            }
            var r = Marshal.PtrToStringAnsi(str);
            X11Sports.Free(str);
            return r;
        }

        public string FetchName() {
            IntPtr rw = IntPtr.Zero;
            NativeMethods.XFetchName(display.Handle, Handle, out rw);
            return sfr(rw);
        }

        public int SetIconName(string window_name) =>
            NativeMethods.XSetIconName(display.Handle, Handle, window_name);

        public string GetIconName() {
            IntPtr rw = IntPtr.Zero;
            NativeMethods.XGetIconName(display.Handle, Handle, out rw);
            return sfr(rw);
        }


        public int MapWindow() => NativeMethods.XMapWindow(display.Handle, Handle);
        public int MapRaised() => NativeMethods.XMapRaised(display.Handle, Handle);

        public int MapSubwindows() => NativeMethods.XMapSubwindows(display.Handle, Handle);

        public int UnmapWindow() => NativeMethods.XUnmapWindow(display.Handle, Handle);
        public int UnmapSubwindows() => NativeMethods.XUnmapSubwindows(display.Handle, Handle);

        public int RaiseWindow() => NativeMethods.XRaiseWindow(display.Handle, Handle);
        public int LowerWindow() => NativeMethods.XLowerWindow(display.Handle, Handle);

        public int DestroyWindow() => NativeMethods.XDestroyWindow(display.Handle, Handle);
        public int DestroySubwindows() => NativeMethods.XDestroySubwindows(display.Handle, Handle);

        public int SetWindowBackground(Color color) => NativeMethods.XSetWindowBackground(display.Handle, Handle, color.Pixel);
        public int SetWindowBorder(Color color) => NativeMethods.XSetWindowBorder(display.Handle, Handle, color.Pixel);


        public int SetWindowBackgroundPixmap(TonNurako.X11.Pixmap pixmap) =>
            NativeMethods.XSetWindowBackgroundPixmap(display.Handle, Handle, pixmap.Drawable);

        public int SetWindowBorderPixmap(TonNurako.X11.Pixmap pixmap) =>
            NativeMethods.XSetWindowBorderPixmap(display.Handle, Handle, pixmap.Drawable);

        public int MoveWindow(int x, int y)
            => NativeMethods.XMoveWindow(display.Handle, Handle, x, y);


        public int ResizeWindow(int width, int height)
            => NativeMethods.XResizeWindow(display.Handle, Handle, (uint)width, (uint)height);

        public int MoveResizeWindow(int x, int y, int width, int height)
            => NativeMethods.XMoveResizeWindow(display.Handle, Handle, x, y, (uint)width, (uint)height);

        public int SetWindowBorderWidth(int width)
            => NativeMethods.XSetWindowBorderWidth(display.Handle, Handle, (uint)width);

        public XWindowAttributes GetWindowAttributes() {
            var rw = new XWindowAttributes(Display);
            var k = NativeMethods.XGetWindowAttributes(this.Display.Handle, Handle, out rw.record);
            return rw;
        }

        public int ChangeWindowAttributes(ChangeWindowAttributes cw, XSetWindowAttributes attr) {
            return NativeMethods.XChangeWindowAttributes(this.Display.Handle, Handle, (ulong)cw, ref attr.record);
        }

        public int SetClassHint(XClassHint klass) {
            return NativeMethods.XSetClassHint(this.Display.Handle, Handle, ref klass);
        }

        public XClassHint GetClassHint() {
            XClassHintRec p;
            NativeMethods.XGetClassHint(this.Display.Handle, Handle, out p);
            return (new XClassHint(p));
        }

        int GrabKey(int keycode, uint modifiers, bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode) =>
            NativeMethods.XGrabKey(
                this.Display.Handle, keycode, modifiers, this.Handle, owner_events, pointer_mode, keyboard_mode);

        int UngrabKey(int keycode, uint modifiers) =>
            NativeMethods.XUngrabKey(this.Display.Handle, keycode, modifiers, this.Handle);


        int XGrabButton(uint button, uint modifiers, bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, Window confine_to, int cursor) =>
            NativeMethods.XGrabButton(this.Display.Handle, button, modifiers, this.Handle,
                owner_events, event_mask, pointer_mode, keyboard_mode, (null != confine_to) ? confine_to.Handle : IntPtr.Zero, cursor);

        int XUngrabButton(uint button, uint modifiers) =>
            NativeMethods.XUngrabButton(this.Display.Handle, button, modifiers, this.Handle);

        public Geometry GetGeometry() {
            var g = new Geometry(Display);
            NativeMethods.XGetGeometry(
                this.Display.Handle, Handle,
                out g.root_return,
                out g.x_return,
                out g.y_return,
                out g.width_return,
                out g.height_return,
                out g.border_width_return,
                out g.depth_return);
            return g;
        }

        /*public void SetWMProperties(string window_name, string icon_name, string[] argv, XSizeHints normal_hints, XWMHints wm_hints, ref XClassHint class_hints) {
            NativeMethods.XmbSetWMProperties(
                this.Display.Handle, Handle,
                window_name,
                icon_name,
                argv,
                argv.Length, 
                ref normal_hints, 
                ref wm_hints.record, ref class_hints.classHint);
        }

        public void SetWMProperties(string window_name, string icon_name, string[] argv) {
            NativeMethods.XmbSetWMProperties(
                this.Display.Handle, Handle,
                Encoding.Default.GetBytes(window_name),
                Encoding.Default.GetBytes(icon_name),
                argv,
                argv.Length,
                IntPtr.Zero,
                IntPtr.Zero, IntPtr.Zero);
        }*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XSizeHintsAspect {
        int x;   /* numerator */
        int y;   /* denominator */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XSizeHints {
        long flags;     /* marks which fields in this structure are defined */
        int x, y;       /* Obsolete */
        int width, height;      /* Obsolete */
        int min_width, min_height;
        int max_width, max_height;
        int width_inc, height_inc;
        XSizeHintsAspect min_aspect;
        XSizeHintsAspect max_aspect;
        int base_width, base_height;
        int win_gravity;
        /* this structure may be extended in the future */
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XWMHintsRec {
        public long flags; // long
        [MarshalAs(UnmanagedType.U1)] public bool input; // Bool
        public int initial_state; // int
        public IntPtr icon_pixmap; // Pixmap
        public IntPtr icon_window; // Window
        public int icon_x; // int
        public int icon_y; // int
        public IntPtr icon_mask; // Pixmap
        public int window_group; // XID
    }

    public class XWMHints : IX11Interop, IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocWMHints_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XAllocWMHints();
        }
        IntPtr handle;
        public IntPtr Handle => handle;

        internal XWMHintsRec record;

        public static XWMHints Alloc() {
            var r = new XWMHints();
            r.handle = NativeMethods.XAllocWMHints();
            return r;
        }
        public XWMHints() {
            record = new XWMHintsRec();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (handle != IntPtr.Zero) {
                    X11Sports.Free(handle);
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        //~XWMHints() {
        //    Dispose(false);
        //}

        public void Dispose() {
            Dispose(true);
         //  System.GC.SuppressFinalize(this);
        }
        #endregion
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XClassHintRec {
        public IntPtr res_name;
        public IntPtr res_class;
    }

    public class XClassHint : IX11Interop, IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocClassHint_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XAllocClassHint();
        }


        public XClassHint() {
        }

        internal XClassHint(XClassHintRec handle) {
            classHint = handle;
        }

        public static XClassHint Alloc() {
            var r = new XClassHint();
            r.allocRoot = NativeMethods.XAllocClassHint();
            r.raw = r.allocRoot;
            return r;
        }

        IntPtr allocRoot = IntPtr.Zero;
        IntPtr raw = IntPtr.Zero;
        internal XClassHintRec classHint;
        public string res_name => Marshal.PtrToStringAnsi(classHint.res_name);
        public string res_class => Marshal.PtrToStringAnsi(classHint.res_class);

        public IntPtr Handle => raw;

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (allocRoot != IntPtr.Zero) {
                    X11Sports.Free(allocRoot);
                    allocRoot = IntPtr.Zero;
                }
                else {
                    if (classHint.res_class != IntPtr.Zero) {
                        X11Sports.Free(classHint.res_class);
                        classHint.res_class = IntPtr.Zero;
                    }
                    if (classHint.res_name != IntPtr.Zero) {
                        X11Sports.Free(classHint.res_name);
                        classHint.res_name = IntPtr.Zero;
                    }
                }
                disposedValue = true;
            }
        }

        ~XClassHint() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }
}
