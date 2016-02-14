#include "TonNurako.h"

TNK_EXPORT GC XCreateGC_TNK(Display* display, Drawable d, unsigned long valuemask, XGCValues* values) {
    return XCreateGC(display,d,valuemask,values);
}
TNK_EXPORT int XFreeGC_TNK(Display* display, GC gc) {
    return XFreeGC(display,gc);
}
TNK_EXPORT Pixmap XCreatePixmap_TNK(Display* display, Drawable d, unsigned int width, unsigned int height, unsigned int depth) {
    return XCreatePixmap(display,d,width,height,depth);
}
TNK_EXPORT int XFreePixmap_TNK(Display* display, Pixmap pixmap) {
    return XFreePixmap(display,pixmap);
}
TNK_EXPORT int XSetForeground_TNK(Display* display, GC gc, unsigned long foreground) {
    return XSetForeground(display,gc,foreground);
}
TNK_EXPORT int XSetBackground_TNK(Display* display, GC gc, unsigned long background) {
    return XSetBackground(display,gc,background);
}
TNK_EXPORT int XCopyPlane_TNK(Display* display, Drawable src, Drawable dest, GC gc, int src_x, int src_y, unsigned int width, unsigned int height, int dest_x, int dest_y, unsigned long plane) {
    return XCopyPlane(display,src,dest,gc,src_x,src_y,width,height,dest_x,dest_y,plane);
}
TNK_EXPORT int XCopyArea_TNK(Display* display, Drawable src, Drawable dest, GC gc, int src_x, int src_y, unsigned int width, unsigned int height, int dest_x, int dest_y) {
    return XCopyArea(display,src,dest,gc,src_x,src_y,width,height,dest_x,dest_y);
}
TNK_EXPORT int XClearWindow_TNK(Display* display, Window w) {
    return XClearWindow(display,w);
}
TNK_EXPORT int XClearArea_TNK(Display* display, Window w, int x, int y, unsigned width, unsigned height, Bool exposures) {
    return XClearArea(display,w,x,y,width,height,exposures);
}
TNK_EXPORT int XDrawPoint_TNK(Display* display, Drawable d, GC gc, int x, int y) {
    return XDrawPoint(display,d,gc,x,y);
}
TNK_EXPORT int XDrawPoints_TNK(Display* display, Drawable d, GC gc, XPoint* points, int npoints, int mode) {
    return XDrawPoints(display,d,gc,points,npoints,mode);
}
TNK_EXPORT int XDrawLine_TNK(Display* display, Drawable d, GC gc, int x1, int y1, int x2, int y2) {
    return XDrawLine(display,d,gc,x1,y1,x2,y2);
}
TNK_EXPORT int XDrawLines_TNK(Display* display, Drawable d, GC gc, XPoint* points, int npoints, int mode) {
    return XDrawLines(display,d,gc,points,npoints,mode);
}
TNK_EXPORT int XDrawSegments_TNK(Display* display, Drawable d, GC gc, XSegment* segments, int nsegments) {
    return XDrawSegments(display,d,gc,segments,nsegments);
}
TNK_EXPORT int XDrawRectangle_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height) {
    return XDrawRectangle(display,d,gc,x,y,width,height);
}
TNK_EXPORT int XDrawRectangles_TNK(Display* display, Drawable d, GC gc, XRectangle* rectangles, int nrectangles) {
    return XDrawRectangles(display,d,gc,rectangles,nrectangles);
}
TNK_EXPORT int XFillRectangle_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height) {
    return XFillRectangle(display,d,gc,x,y,width,height);
}
TNK_EXPORT int XFillRectangles_TNK(Display* display, Drawable d, GC gc, XRectangle* rectangles, int nrectangles) {
    return XFillRectangles(display,d,gc,rectangles,nrectangles);
}
TNK_EXPORT int XFillPolygon_TNK(Display* display, Drawable d, GC gc, XPoint* points, int npoints, int shape, int mode) {
    return XFillPolygon(display,d,gc,points,npoints,shape,mode);
}
TNK_EXPORT int XFillArc_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height, int angle1, int angle2) {
    return XFillArc(display,d,gc,x,y,width,height,angle1,angle2);
}
TNK_EXPORT int XFillArcs_TNK(Display* display, Drawable d, GC gc, XArc* arcs, int narcs) {
    return XFillArcs(display,d,gc,arcs,narcs);
}
TNK_EXPORT int XDrawArc_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height, int angle1, int angle2) {
    return XDrawArc(display,d,gc,x,y,width,height,angle1,angle2);
}
TNK_EXPORT int XDrawArcs_TNK(Display* display, Drawable d, GC gc, XArc* arcs, int narcs) {
    return XDrawArcs(display,d,gc,arcs,narcs);
}
TNK_EXPORT int XSetLineAttributes_TNK(Display* display, GC gc, unsigned int line_width, int line_style, int cap_style, int join_style) {
    return XSetLineAttributes(display,gc,line_width,line_style,cap_style,join_style);
}
TNK_EXPORT int XSetDashes_TNK(Display* display, GC gc, int dash_offset, char* dash_list, int n) {
    return XSetDashes(display,gc,dash_offset,dash_list,n);
}

TNK_EXPORT Status XGetGeometry_TNK(Display* display, Drawable d, Window* root_return, int* x_return, int* y_return, unsigned int* width_return, unsigned int* height_return, unsigned int* border_width_return, unsigned int* depth_return) {
    return XGetGeometry(display,d,root_return,x_return,y_return,width_return,height_return,border_width_return,depth_return);
}

TNK_EXPORT Status XGetWindowAttributes_TNK(Display* display, Window w, XWindowAttributes* window_attributes_return) {
    return XGetWindowAttributes(display,w,window_attributes_return);
}

TNK_EXPORT KeySym XStringToKeysym_TNK(char* string) {
    return XStringToKeysym(string);
}

TNK_EXPORT char *XKeysymToString_TNK(KeySym keysym) {
    return XKeysymToString(keysym);
}

TNK_EXPORT Font XLoadFont_TNK(Display* display, char* name) {
    return XLoadFont(display,name);
}

TNK_EXPORT XFontStruct* XQueryFont_TNK(Display* display, XID font_ID) {
    return XQueryFont(display,font_ID);
}

TNK_EXPORT XFontStruct* XLoadQueryFont_TNK(Display* display, char* name) {
    return XLoadQueryFont(display,name);
}

TNK_EXPORT int XFreeFont_TNK(Display* display, XFontStruct* font_struct) {
    return XFreeFont(display,font_struct);
}

TNK_EXPORT Bool XGetFontProperty_TNK(XFontStruct* font_struct, Atom atom, unsigned long* value_return) {
    return XGetFontProperty(font_struct,atom,value_return);
}

TNK_EXPORT int XUnloadFont_TNK(Display* display, Font font) {
    return XUnloadFont(display,font);
}

