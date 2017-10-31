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

TNK_EXPORT FcCharSet* FcCharSetCreate_TNK() {
    return FcCharSetCreate();
}
TNK_EXPORT void FcCharSetDestroy_TNK(FcCharSet* fcs) {
    FcCharSetDestroy(fcs);
}
TNK_EXPORT FcBool FcCharSetAddChar_TNK(FcCharSet* fcs, FcChar32 ucs4) {
    return FcCharSetAddChar(fcs,ucs4);
}
TNK_EXPORT FcBool FcCharSetDelChar_TNK(FcCharSet* fcs, FcChar32 ucs4) {
    return FcCharSetDelChar(fcs,ucs4);
}
TNK_EXPORT FcCharSet* FcCharSetCopy_TNK(FcCharSet* src) {
    return FcCharSetCopy(src);
}
TNK_EXPORT FcBool FcCharSetEqual_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetEqual(a,b);
}
TNK_EXPORT FcCharSet* FcCharSetIntersect_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetIntersect(a,b);
}
TNK_EXPORT FcCharSet* FcCharSetUnion_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetUnion(a,b);
}
TNK_EXPORT FcCharSet* FcCharSetSubtract_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetSubtract(a,b);
}
TNK_EXPORT FcBool FcCharSetMerge_TNK(FcCharSet* a, const FcCharSet* b, FcBool* changed) {
    return FcCharSetMerge(a,b,changed);
}
TNK_EXPORT FcBool FcCharSetHasChar_TNK(const FcCharSet* fcs, FcChar32 ucs4) {
    return FcCharSetHasChar(fcs,ucs4);
}
TNK_EXPORT FcChar32 FcCharSetCount_TNK(const FcCharSet* a) {
    return FcCharSetCount(a);
}
TNK_EXPORT FcChar32 FcCharSetIntersectCount_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetIntersectCount(a,b);
}
TNK_EXPORT FcChar32 FcCharSetSubtractCount_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetSubtractCount(a,b);
}
TNK_EXPORT FcBool FcCharSetIsSubset_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetIsSubset(a,b);
}
TNK_EXPORT FcChar32 FcCharSetFirstPage_TNK(const FcCharSet* a, FcChar32 map[FC_CHARSET_MAP_SIZE], FcChar32* next) {
    return FcCharSetFirstPage(a,map,next);
}
TNK_EXPORT FcChar32 FcCharSetNextPage_TNK(const FcCharSet* a, FcChar32 map[FC_CHARSET_MAP_SIZE], FcChar32* next) {
    return FcCharSetNextPage(a,map,next);
}

//FcPattern
TNK_EXPORT FcPattern* FcPatternCreate_TNK() {
    return FcPatternCreate();
}
TNK_EXPORT FcPattern* FcPatternDuplicate_TNK(const FcPattern* p) {
    return FcPatternDuplicate(p);
}
TNK_EXPORT void FcPatternReference_TNK(FcPattern* p) {
    FcPatternReference(p);
}
TNK_EXPORT FcPattern* FcPatternFilter_TNK(FcPattern* p, const FcObjectSet* os) {
    return FcPatternFilter(p,os);
}
TNK_EXPORT FcBool FcValueEqual_TNK(FcValue va, FcValue vb) {
    return FcValueEqual(va,vb);
}
TNK_EXPORT FcValue FcValueSave_TNK(FcValue v) {
    return FcValueSave(v);
}

TNK_EXPORT FcBool FcPatternEqual_TNK(const FcPattern* pa, const FcPattern* pb) {
    return FcPatternEqual(pa,pb);
}
TNK_EXPORT FcBool FcPatternEqualSubset_TNK(const FcPattern* pa, const FcPattern* pb, const FcObjectSet* os) {
    return FcPatternEqualSubset(pa,pb,os);
}
TNK_EXPORT FcChar32 FcPatternHash_TNK(const FcPattern* p) {
    return FcPatternHash(p);
}
TNK_EXPORT FcBool FcPatternAdd_TNK(FcPattern* p, const char* obzekt, FcValue value, FcBool append) {
    return FcPatternAdd(p,obzekt,value,append);
}
TNK_EXPORT FcBool FcPatternAddWeak_TNK(FcPattern* p, const char* obzekt, FcValue value, FcBool append) {
    return FcPatternAddWeak(p,obzekt,value,append);
}
TNK_EXPORT FcResult FcPatternGet_TNK(const FcPattern* p, const char* obzekt, int id, FcValue* v) {
    return FcPatternGet(p,obzekt,id,v);
}
TNK_EXPORT FcBool FcPatternDel_TNK(FcPattern* p, const char* obzekt) {
    return FcPatternDel(p,obzekt);
}
TNK_EXPORT FcBool FcPatternRemove_TNK(FcPattern* p, const char* obzekt, int id) {
    return FcPatternRemove(p,obzekt,id);
}
TNK_EXPORT FcBool FcPatternAddInteger_TNK(FcPattern* p, const char* obzekt, int i) {
    return FcPatternAddInteger(p,obzekt,i);
}
TNK_EXPORT FcBool FcPatternAddDouble_TNK(FcPattern* p, const char* obzekt, double d) {
    return FcPatternAddDouble(p,obzekt,d);
}
TNK_EXPORT FcBool FcPatternAddString_TNK(FcPattern* p, const char* obzekt, const FcChar8* s) {
    return FcPatternAddString(p,obzekt,s);
}
TNK_EXPORT FcBool FcPatternAddMatrix_TNK(FcPattern* p, const char* obzekt, const FcMatrix* s) {
    return FcPatternAddMatrix(p,obzekt,s);
}
TNK_EXPORT FcBool FcPatternAddCharSet_TNK(FcPattern* p, const char* obzekt, const FcCharSet* c) {
    return FcPatternAddCharSet(p,obzekt,c);
}
TNK_EXPORT FcBool FcPatternAddBool_TNK(FcPattern* p, const char* obzekt, FcBool b) {
    return FcPatternAddBool(p,obzekt,b);
}
TNK_EXPORT FcBool FcPatternAddLangSet_TNK(FcPattern* p, const char* obzekt, const FcLangSet* ls) {
    return FcPatternAddLangSet(p,obzekt,ls);
}
TNK_EXPORT FcBool FcPatternAddRange_TNK(FcPattern* p, const char* obzekt, const FcRange* r) {
    return FcPatternAddRange(p,obzekt,r);
}
TNK_EXPORT FcResult FcPatternGetInteger_TNK(const FcPattern* p, const char* obzekt, int n, int* i) {
    return FcPatternGetInteger(p,obzekt,n,i);
}
TNK_EXPORT FcResult FcPatternGetDouble_TNK(const FcPattern* p, const char* obzekt, int n, double* d) {
    return FcPatternGetDouble(p,obzekt,n,d);
}
TNK_EXPORT FcResult FcPatternGetString_TNK(const FcPattern* p, const char* obzekt, int n, FcChar8** s) {
    return FcPatternGetString(p,obzekt,n,s);
}
TNK_EXPORT FcResult FcPatternGetMatrix_TNK(const FcPattern* p, const char* obzekt, int n, FcMatrix** s) {
    return FcPatternGetMatrix(p,obzekt,n,s);
}
TNK_EXPORT FcResult FcPatternGetCharSet_TNK(const FcPattern* p, const char* obzekt, int n, FcCharSet** c) {
    return FcPatternGetCharSet(p,obzekt,n,c);
}
TNK_EXPORT FcResult FcPatternGetBool_TNK(const FcPattern* p, const char* obzekt, int n, FcBool* b) {
    return FcPatternGetBool(p,obzekt,n,b);
}
TNK_EXPORT FcResult FcPatternGetLangSet_TNK(const FcPattern* p, const char* obzekt, int n, FcLangSet** ls) {
    return FcPatternGetLangSet(p,obzekt,n,ls);
}
TNK_EXPORT FcResult FcPatternGetRange_TNK(const FcPattern* p, const char* obzekt, int id, FcRange** r) {
    return FcPatternGetRange(p,obzekt,id,r);
}
TNK_EXPORT FcChar8* FcPatternFormat_TNK(FcPattern* pat, const FcChar8* format) {
    return FcPatternFormat(pat,format);
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