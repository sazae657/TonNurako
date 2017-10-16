#include "TonNurako.h"

TNK_EXPORT Bool XSupportsLocale_TNK() {
    return XSupportsLocale();
}

TNK_EXPORT void XmbSetWMProperties_TNK(Display* display, Window w, char* window_name, char* icon_name, char* argv[], int argc, XSizeHints* normal_hints, XWMHints* wm_hints, XClassHint* class_hints) {
    XmbSetWMProperties(display,w,window_name,icon_name,argv,argc,normal_hints,wm_hints,class_hints);
}

TNK_EXPORT char* XSetLocaleModifiers_TNK(char* modifier_list) {
    return XSetLocaleModifiers(modifier_list);
}

TNK_EXPORT XFontSetExtents* XExtentsOfFontSet_TNK(XFontSet font_set) {
    return XExtentsOfFontSet(font_set);
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

TNK_EXPORT int XmbTextExtents_TNK(XFontSet font_set, char* string, int num_bytes, XRectangle* overall_ink_return, XRectangle* overall_logical_return) {
    return XmbTextExtents(font_set,string,num_bytes,overall_ink_return,overall_logical_return);
}

TNK_EXPORT int XwcTextExtents_TNK(XFontSet font_set, wchar_t* string, int num_wchars, XRectangle* overall_ink_return, XRectangle* overall_logical_return) {
    return XwcTextExtents(font_set,string,num_wchars,overall_ink_return,overall_logical_return);
}

TNK_EXPORT XFontSet XCreateFontSet_TNK(Display* display, char* base_font_name_list, char* **missing_charset_list_return, int* missing_charset_count_return, char* *def_string_return) {
    return XCreateFontSet(display,base_font_name_list,missing_charset_list_return,missing_charset_count_return,def_string_return);
}

TNK_EXPORT void XFreeFontSet_TNK(Display* display, XFontSet font_set) {
    XFreeFontSet(display,font_set);
}

TNK_EXPORT char** XListFonts_TNK(Display* display, char* pattern, int maxnames, int* actual_count_return) {
    return XListFonts(display,pattern,maxnames,actual_count_return);
}

TNK_EXPORT char** XListFontsWithInfo_TNK(Display* display, char* pattern, int maxnames, int* count_return, XFontStruct* *info_return) {
    return XListFontsWithInfo(display,pattern,maxnames,count_return,info_return);
}

TNK_EXPORT int XFreeFontNames_TNK(char** list) {
    return XFreeFontNames(list);
}

TNK_EXPORT int XFreeFontInfo_TNK(char* *names, XFontStruct* free_info, int actual_count) {
    return XFreeFontInfo(names,free_info,actual_count);
}
