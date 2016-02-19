//
// ﾄﾝﾇﾗｺ
//
// Xlibﾗｯﾊﾟー
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Native.X11
{
	/// <summary>
	/// Xlibﾛーﾀﾞー
	/// </summary>
	public class X11Sports : Native.ExtremeSportsLoader {
        private static X11Sports Instance {
            get;
            set;
        }

        public static void Register(string libXtName) {
            if (null != Instance) {
                return;
            }
            Instance = new X11Sports(libXtName);
        }

        public static void Unregister() {
            if (null == Instance) {
                return;
            }
            System.Diagnostics.Debug.WriteLine("X11: unregister");
            Instance.Dispose();
            Instance = null;
        }
        private X11Sports(string lib) : base(lib) {

        }
		#region 描画関連

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint="XCreateGC_TNK", CharSet=CharSet.Auto)]
            public static extern IntPtr XCreateGC(IntPtr display, IntPtr d, GCMask valuemask, [In,Out]ref XGCValues values);

            [DllImport(ExtremeSports.Lib, EntryPoint="XCreateGC_TNK", CharSet=CharSet.Auto)]
            public static extern IntPtr XCreateGC(IntPtr display, IntPtr d, GCMask valuemask, IntPtr values);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFreeGC_TNK", CharSet=CharSet.Auto)]
            public static extern int XFreeGC(IntPtr display, IntPtr gc);

            [DllImport(ExtremeSports.Lib, EntryPoint="XGetGCValues_TNK", CharSet=CharSet.Auto)]
            internal static extern int XGetGCValues(IntPtr display, IntPtr gc, GCMask valuemask, out XGCValues values_return);

            [DllImport(ExtremeSports.Lib, EntryPoint="XCreatePixmap_TNK", CharSet=CharSet.Auto)]
            public static extern IntPtr XCreatePixmap(IntPtr display, IntPtr d, uint width, uint height, uint depth);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFreePixmap_TNK", CharSet=CharSet.Auto)]
            public static extern int XFreePixmap(IntPtr display, IntPtr pixmap);

            [DllImport(ExtremeSports.Lib, EntryPoint="XSetForeground_TNK", CharSet=CharSet.Auto)]
            public static extern int XSetForeground(IntPtr display, IntPtr gc, ulong foreground);

            [DllImport(ExtremeSports.Lib, EntryPoint="XSetBackground_TNK", CharSet=CharSet.Auto)]
            public static extern int XSetBackground(IntPtr display, IntPtr gc, ulong background);

            [DllImport(ExtremeSports.Lib, EntryPoint="XCopyPlane_TNK", CharSet=CharSet.Auto)]
            public static extern int XCopyPlane(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y, ulong plane);

            [DllImport(ExtremeSports.Lib, EntryPoint="XCopyArea_TNK", CharSet=CharSet.Auto)]
            public static extern int XCopyArea(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y);

            [DllImport(ExtremeSports.Lib, EntryPoint="XClearWindow_TNK", CharSet=CharSet.Auto)]
            public static extern int XClearWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint="XClearArea_TNK", CharSet=CharSet.Auto)]
            public static extern int XClearArea(IntPtr display, IntPtr w, int x, int y, uint width, uint height, [MarshalAs(UnmanagedType.U1)] bool exposures);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawPoint_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawPoint(IntPtr display, IntPtr d, IntPtr gc, int x, int y);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawPoints_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawPoints(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XPoint [] points, int npoints, int mode);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawLine_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawLine(IntPtr display, IntPtr d, IntPtr gc, int x1, int y1, int x2, int y2);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawLines_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawLines(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XPoint [] points, int npoints, int mode);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawSegments_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawSegments(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XSegment [] segments, int nsegments);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawRectangle_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawRectangle(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawRectangles_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawRectangles(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XRectangle [] rectangles, int nrectangles);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFillRectangle_TNK", CharSet=CharSet.Auto)]
            public static extern int XFillRectangle(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFillRectangles_TNK", CharSet=CharSet.Auto)]
            public static extern int XFillRectangles(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XRectangle [] rectangles, int nrectangles);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFillPolygon_TNK", CharSet=CharSet.Auto)]
            public static extern int XFillPolygon(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XPoint [] points, int npoints, int shape, int mode);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFillArc_TNK", CharSet=CharSet.Auto)]
            public static extern int XFillArc(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFillArcs_TNK", CharSet=CharSet.Auto)]
            public static extern int XFillArcs(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XArc [] arcs, int narcs);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawArc_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawArc(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2);

            [DllImport(ExtremeSports.Lib, EntryPoint="XDrawArcs_TNK", CharSet=CharSet.Auto)]
            public static extern int XDrawArcs(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XArc [] arcs, int narcs);

            [DllImport(ExtremeSports.Lib, EntryPoint="XSetLineAttributes_TNK", CharSet=CharSet.Auto)]
            public static extern int XSetLineAttributes(IntPtr display, IntPtr gc, uint line_width, int line_style, int cap_style, int join_style);

            [DllImport(ExtremeSports.Lib, EntryPoint="XSetDashes_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            public static extern int XSetDashes(IntPtr display, IntPtr gc, int dash_offset, [MarshalAs(UnmanagedType.LPStr)] string dash_list, int n);


            [DllImport(ExtremeSports.Lib, EntryPoint="XGetGeometry_TNK", CharSet=CharSet.Auto)]
            public static extern int XGetGeometry(IntPtr display, IntPtr d, out IntPtr root_return, out IntPtr x_return,
                out IntPtr y_return, out IntPtr width_return, out IntPtr height_return, out IntPtr border_width_return, out IntPtr depth_return);

            //[DllImport(ExtremeSports.Lib, EntryPoint="XGetWindowAttributes_TNK", CharSet=CharSet.Auto)]
            //public static extern int XGetWindowAttributes(IntPtr display, IntPtr w, out XWindowAttributes window_attributes_return);


            [DllImport(ExtremeSports.Lib, EntryPoint="XStringToKeysym_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            public static extern int XStringToKeysym([MarshalAs(UnmanagedType.LPStr)] string xstring);

            [DllImport(ExtremeSports.Lib, EntryPoint="XKeysymToString_TNK", CharSet=CharSet.Auto)]
            public static extern IntPtr XKeysymToString(int keysym);

        }
        public static IntPtr XCreateGC(IntPtr display, IntPtr d, GCMask valuemask, ref XGCValues values) {
            return NativeMethods.XCreateGC(display,d,valuemask,ref values);
        }
        
        public static IntPtr XCreateGC(IntPtr display, IntPtr d) {
            return NativeMethods.XCreateGC(display, d, 0, IntPtr.Zero);
        }        

        public static int XFreeGC(IntPtr display, IntPtr gc) {
            return NativeMethods.XFreeGC(display,gc);
        }

        public static int XGetGCValues(IntPtr display, IntPtr gc, GCMask valuemask, out XGCValues values_return) {
            return NativeMethods.XGetGCValues(display, gc, valuemask, out values_return);
        }

        public static IntPtr XCreatePixmap(IntPtr display, IntPtr d, uint width, uint height, uint depth) {
            return NativeMethods.XCreatePixmap(display,d,width,height,depth);
        }

        public static int XFreePixmap(IntPtr display, IntPtr pixmap) {
            return NativeMethods.XFreePixmap(display,pixmap);
        }

        public static int XSetForeground(IntPtr display, IntPtr gc, ulong foreground) {
            return NativeMethods.XSetForeground(display,gc,foreground);
        }

        public static int XSetBackground(IntPtr display, IntPtr gc, ulong background) {
            return NativeMethods.XSetBackground(display,gc,background);
        }

        public static int XCopyPlane(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y, ulong plane) {
            return NativeMethods.XCopyPlane(display,src,dest,gc,src_x,src_y,width,height,dest_x,dest_y,plane);
        }

        public static int XCopyArea(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y) {
            return NativeMethods.XCopyArea(display,src,dest,gc,src_x,src_y,width,height,dest_x,dest_y);
        }

        public static int XClearWindow(IntPtr display, IntPtr w) {
            return NativeMethods.XClearWindow(display,w);
        }

        public static int XClearArea(IntPtr display, IntPtr w, int x, int y, uint width, uint height, [MarshalAs(UnmanagedType.U1)] bool exposures) {
            return NativeMethods.XClearArea(display,w,x,y,width,height,exposures);
        }

        public static int XDrawPoint(IntPtr display, IntPtr d, IntPtr gc, int x, int y) {
            return NativeMethods.XDrawPoint(display,d,gc,x,y);
        }

        public static int XDrawPoints(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XPoint [] points, int npoints, int mode) {
            return NativeMethods.XDrawPoints(display,d,gc,points,npoints,mode);
        }

        public static int XDrawLine(IntPtr display, IntPtr d, IntPtr gc, int x1, int y1, int x2, int y2) {
            return NativeMethods.XDrawLine(display,d,gc,x1,y1,x2,y2);
        }

        public static int XDrawLines(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XPoint [] points, int npoints, int mode) {
            return NativeMethods.XDrawLines(display,d,gc,points,npoints,mode);
        }


        public static int XDrawSegments(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XSegment [] segments, int nsegments) {
            return NativeMethods.XDrawSegments(display,d,gc,segments,nsegments);
        }


        public static int XDrawRectangle(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height) {
            return NativeMethods.XDrawRectangle(display,d,gc,x,y,width,height);
        }


        public static int XDrawRectangles(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XRectangle [] rectangles, int nrectangles) {
            return NativeMethods.XDrawRectangles(display,d,gc,rectangles,nrectangles);
        }


        public static int XFillRectangle(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height) {
            return NativeMethods.XFillRectangle(display,d,gc,x,y,width,height);
        }


        public static int XFillRectangles(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XRectangle [] rectangles, int nrectangles) {
            return NativeMethods.XFillRectangles(display,d,gc,rectangles,nrectangles);
        }


        public static int XFillPolygon(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XPoint [] points, int npoints, int shape, int mode) {
            return NativeMethods.XFillPolygon(display,d,gc,points,npoints,shape,mode);
        }


        public static int XFillArc(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2) {
            return NativeMethods.XFillArc(display,d,gc,x,y,width,height,angle1,angle2);
        }


        public static int XFillArcs(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XArc [] arcs, int narcs) {
            return NativeMethods.XFillArcs(display,d,gc,arcs,narcs);
        }


        public static int XDrawArc(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2) {
            return NativeMethods.XDrawArc(display,d,gc,x,y,width,height,angle1,angle2);
        }


        public static int XDrawArcs(IntPtr display, IntPtr d, IntPtr gc, TonNurako.Native.X11.XArc [] arcs, int narcs) {
            return NativeMethods.XDrawArcs(display,d,gc,arcs,narcs);
        }


        public static int XSetLineAttributes(IntPtr display, IntPtr gc, uint line_width, int line_style, int cap_style, int join_style) {
            return NativeMethods.XSetLineAttributes(display,gc,line_width,line_style,cap_style,join_style);
        }


        public static int XSetDashes(IntPtr display, IntPtr gc, int dash_offset, string dash_list, int n) {
            return NativeMethods.XSetDashes(display,gc,dash_offset,dash_list,n);
        }

       /* たぶんやらない
        public static int XGetGeometry(IntPtr display, IntPtr gc) {
            IntPtr root_return;
            IntPtr x_return;
            IntPtr y_return;
            IntPtr width_return;
            IntPtr height_return;
            IntPtr border_width_return;
            IntPtr depth_return;
            int r = NativeMethods.XGetGeometry(
                display, gc, out root_return,out x_return,out y_return, out width_return,out height_return,out border_width_return,out depth_return);
            string msg = $"XGetGeometry<{r}> => \n";
            if (IntPtr.Zero != root_return) msg += $"    root_return = {(root_return)} \n";
            if (IntPtr.Zero != x_return) msg += $"    x_return = {(x_return)} \n" ;
            if (IntPtr.Zero != y_return) msg += $"    y_return = {(y_return)} \n";
            if (IntPtr.Zero != width_return) msg += $"    width_return = {(width_return)} \n";
            if (IntPtr.Zero != height_return) msg += $"    height_return = {(height_return)} \n";
            if (IntPtr.Zero != border_width_return) msg += $"    border_width_return = {(border_width_return)}\n";
            if (IntPtr.Zero != depth_return) msg += $"    depth_return = {(depth_return)} \n";

            return r;
        }
        */


        //public static int XGetWindowAttributes(IntPtr display, IntPtr w, out XWindowAttributes window_attributes_return) {
        //    return NativeMethods.XGetWindowAttributes(display,w,window_attributes_return);
        //}

        public static int XStringToKeysym(string _String) {
            return NativeMethods.XStringToKeysym(_String);
        }

        public static string XKeysymToString(int keysym) {
            return Marshal.PtrToStringAnsi(NativeMethods.XKeysymToString(keysym));
        }

		#endregion
	}
}
