#include "TonNurako.h"

TNK_EXPORT FcBool FcInit_TNK() {
    return FcInit();
}
TNK_EXPORT void FcFini_TNK() {
    FcFini();
}

TNK_EXPORT void FcPatternDestroy_TNK(FcPattern* p) {
    FcPatternDestroy(p);
}

TNK_EXPORT FcPattern* XftXlfdParse_TNK(char* xlfd_orig, Bool ignore_scalable, Bool complete) {
    return XftXlfdParse(xlfd_orig,ignore_scalable,complete);
}
TNK_EXPORT FcPattern* FcNameParse_TNK(FcChar8* name) {
    return FcNameParse(name);
}

TNK_EXPORT XftFont* XftFontOpenName_TNK(Display* dpy, int screen, const char* name) {
    return XftFontOpenName(dpy,screen,name);
}
TNK_EXPORT XftFont* XftFontOpenPattern_TNK(Display* dpy, FcPattern* fontpattern) {
    return XftFontOpenPattern(dpy,fontpattern);
}

TNK_EXPORT XftFont* XftFontOpenXlfd_TNK(Display* dpy, int screen, const char* xlfd) {
    return XftFontOpenXlfd(dpy,screen,xlfd);
}

TNK_EXPORT void XftFontClose_TNK(Display* dpy, XftFont* font) {
    XftFontClose(dpy,font);
}

TNK_EXPORT Bool XftColorAllocName_TNK(Display* dpy, Visual* visual, Colormap cmap, char* name, XftColor* result) {
    return XftColorAllocName(dpy,visual,cmap,name,result);
}
TNK_EXPORT Bool XftColorAllocValue_TNK(Display* dpy, Visual* visual, Colormap cmap, XRenderColor* color, XftColor* result) {
    return XftColorAllocValue(dpy,visual,cmap,color,result);
}
TNK_EXPORT void XftColorFree_TNK(Display* dpy, Visual* visual, Colormap cmap, XftColor* color) {
    XftColorFree(dpy,visual,cmap,color);
}

TNK_EXPORT XftDraw* XftDrawCreate_TNK(Display* dpy, Drawable drawable, Visual* visual, Colormap colormap) {
    return XftDrawCreate(dpy,drawable,visual,colormap);
}
TNK_EXPORT XftDraw* XftDrawCreateBitmap_TNK(Display* dpy, Pixmap bitmap) {
    return XftDrawCreateBitmap(dpy,bitmap);
}
TNK_EXPORT XftDraw* XftDrawCreateAlpha_TNK(Display* dpy, Pixmap pixmap, int depth) {
    return XftDrawCreateAlpha(dpy,pixmap,depth);
}
TNK_EXPORT void XftDrawChange_TNK(XftDraw* draw, Drawable drawable) {
    XftDrawChange(draw,drawable);
}
TNK_EXPORT Display* XftDrawDisplay_TNK(XftDraw* draw) {
    return XftDrawDisplay(draw);
}
TNK_EXPORT Drawable XftDrawDrawable_TNK(XftDraw* draw) {
    return XftDrawDrawable(draw);
}
TNK_EXPORT Colormap XftDrawColormap_TNK(XftDraw* draw) {
    return XftDrawColormap(draw);
}
TNK_EXPORT Visual* XftDrawVisual_TNK(XftDraw* draw) {
    return XftDrawVisual(draw);
}
TNK_EXPORT void XftDrawDestroy_TNK(XftDraw* draw) {
    XftDrawDestroy(draw);
}
TNK_EXPORT Picture XftDrawPicture_TNK(XftDraw* draw) {
    return XftDrawPicture(draw);
}
TNK_EXPORT Picture XftDrawSrcPicture_TNK(XftDraw* draw, XftColor* color) {
    return XftDrawSrcPicture(draw,color);
}

TNK_EXPORT void XftDrawString16_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar16* string, int len) {
    XftDrawString16(draw,color,pub,x,y,string,len);
}

TNK_EXPORT void XftDrawGlyphs_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FT_UInt* glyphs, int nglyphs) {
    XftDrawGlyphs(draw,color,pub,x,y,glyphs,nglyphs);
}
TNK_EXPORT void XftDrawString8_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar8* string, int len) {
    XftDrawString8(draw,color,pub,x,y,string,len);
}
TNK_EXPORT void XftDrawString32_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar32* string, int len) {
    XftDrawString32(draw,color,pub,x,y,string,len);
}
TNK_EXPORT void XftDrawStringUtf8_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar8* string, int len) {
    XftDrawStringUtf8(draw,color,pub,x,y,string,len);
}
TNK_EXPORT void XftDrawStringUtf16_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar8* string, FcEndian endian, int len) {
    XftDrawStringUtf16(draw,color,pub,x,y,string,endian,len);
}
TNK_EXPORT void XftDrawCharSpec_TNK(XftDraw* draw, XftColor* color, XftFont* pub, XftCharSpec* chars, int len) {
    XftDrawCharSpec(draw,color,pub,chars,len);
}
TNK_EXPORT void XftDrawCharFontSpec_TNK(XftDraw* draw, XftColor* color, XftCharFontSpec* chars, int len) {
    XftDrawCharFontSpec(draw,color,chars,len);
}
TNK_EXPORT void XftDrawGlyphSpec_TNK(XftDraw* draw, XftColor* color, XftFont* pub, XftGlyphSpec* glyphs, int len) {
    XftDrawGlyphSpec(draw,color,pub,glyphs,len);
}
TNK_EXPORT void XftDrawGlyphFontSpec_TNK(XftDraw* draw, XftColor* color, XftGlyphFontSpec* glyphs, int len) {
    XftDrawGlyphFontSpec(draw,color,glyphs,len);
}
TNK_EXPORT void XftDrawRect_TNK(XftDraw* draw, XftColor* color, int x, int y, unsigned int width, unsigned int height) {
    XftDrawRect(draw,color,x,y,width,height);
}
TNK_EXPORT Bool XftDrawSetClip_TNK(XftDraw* draw, Region r) {
    return XftDrawSetClip(draw,r);
}
TNK_EXPORT Bool XftDrawSetClipRectangles_TNK(XftDraw* draw, int xOrigin, int yOrigin, XRectangle* rects, int n) {
    return XftDrawSetClipRectangles(draw,xOrigin,yOrigin,rects,n);
}
TNK_EXPORT void XftDrawSetSubwindowMode_TNK(XftDraw* draw, int mode) {
    XftDrawSetSubwindowMode(draw,mode);
}


//XftFont ｱｸｾｯｻー
int TNK_GetXftFontAscent(XftFont* ptr) { return ptr->ascent; }
void TNK_SetXftFontAscent(XftFont* ptr, int value) { ptr->ascent = value; }

int TNK_GetXftFontDescent(XftFont* ptr) { return ptr->descent; }
void TNK_SetXftFontDescent(XftFont* ptr, int value) { ptr->descent = value; }

int TNK_GetXftFontHeight(XftFont* ptr) { return ptr->height; }
void TNK_SetXftFontHeight(XftFont* ptr, int value) { ptr->height = value; }

int TNK_GetXftFontMaxAdvanceWidth(XftFont* ptr) { return ptr->max_advance_width; }
void TNK_SetXftFontMaxAdvanceWidth(XftFont* ptr, int value) { ptr->max_advance_width = value; }

FcCharSet* TNK_GetXftFontCharset(XftFont* ptr) { return ptr->charset; }
void TNK_SetXftFontCharset(XftFont* ptr, FcCharSet* value) { ptr->charset = value; }

FcPattern* TNK_GetXftFontPattern(XftFont* ptr) { return ptr->pattern; }
void TNK_SetXftFontPattern(XftFont* ptr, FcPattern* value) { ptr->pattern = value; }