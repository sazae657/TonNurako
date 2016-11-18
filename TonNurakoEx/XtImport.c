#include "TonNurako.h"

TNK_DECLARE_BEGIN

typedef void(*process_cb)(void);


TNK_EXPORT void
TNK_IMP_Xt_XtAppMainLoop(XtAppContext app, process_cb cb)
{
    XtAppMainLoop(app);
}

TNK_EXPORT void
TNK_IMP_Xt_XtAppSetExitFlag(  XtAppContext a )
{
	XtAppSetExitFlag( a );
}

TNK_EXPORT void
XtInitializeWidgetClass_TNK(WidgetClass object_class)
{
    XtInitializeWidgetClass(object_class);
}

TNK_EXPORT int
TNK_IMP_Xt_XCreateColormap(Widget w) {
    XColor color;
    memset(&color, 0x00, sizeof(XColor));
    color.flags = DoRed|DoGreen|DoBlue;

    return DefaultColormapOfScreen(XtScreen(w));
}

TNK_EXPORT int
TNK_IMP_Xt_XAllocColor(XColor* color, Widget w, int r, int g, int b, int a)
{
    Arg ar[1];
    Colormap cm;
    color->red = 257 * r;
    color->green = 257 * g;
    color->blue = 257 * b;
    color->flags = DoRed|DoGreen|DoBlue;

    XtSetArg(ar[0], XmNcolormap, (XtArgVal)&cm);
    XtGetValues(w, ar, 1);
    CONS25W(stderr, "cm=%ld\n", cm);

    return XAllocColor(
        XtDisplay(w),
        cm,
        color);

}

TNK_EXPORT int
TNK_IMP_Xt_XParseColorW(XColor* color,
                            Widget w, char* name)
{
    XColor c;
    Colormap cm;
    Arg ar[1];

    XtSetArg(ar[0], XmNcolormap, (XtArgVal)&cm);
    XtGetValues(w, ar, 1);
    CONS25W(stderr, "cm=%ld\n", cm);

    memset(&c, 0x00, sizeof(XColor));


    if (0 == XParseColor(XtDisplay(w), cm, name, color)) {
        CONS25W(stderr, "XParseColor<%s> FAILED!!!\n", name);
        return 0;
    }

    return XAllocColor(
        XtDisplay(w),
        cm,
        color);

}

TNK_EXPORT Pixel
TNK_IMP_Xt_XParseColorM(Widget widget, char *name)
{
    XrmValue from_value, to_value;

    from_value.addr = name;
    from_value.size = strlen(name) + 1;
    to_value.addr = NULL;
    XtConvertAndStore (widget, XmRString, &from_value, XmRPixel, &to_value);

    if (to_value.addr) {
        CONS25W(stderr,"TNK_IMP_Xt_XParseColorM<%s> pixel=%lx\n", name, *((Pixel*) to_value.addr));
        return (*((Pixel*) to_value.addr));
    }
    CONS25W(stderr,"TNK_IMP_Xt_XParseColorM<%s> FAILED\n", name);

    return XmUNSPECIFIED_PIXEL;
}


TNK_EXPORT void
TNK_IMP_TnkAssignColorMap(LPTNK_APP_CONTEXT pCtx, int cmap)
{
    pCtx->colormap = cmap;
}

TNK_EXPORT GC XtGetGC_TNK(Widget w, XtGCMask value_mask, XGCValues* values) {
    return XtGetGC(w,value_mask,values);
}

TNK_EXPORT void XtReleaseGC_TNK(Widget w, GC gc) {
    XtReleaseGC(w,gc);
}

#define MAX_STACK_ARG 25

TNK_EXPORT int
TNK_IMP_TnkConvertResource(TNK_RESOURCE* in, Arg* args, int count, Boolean deepCopy)
{
    int i  = 0;
    int argc = 0;

    for (i = 0; i < count; ++i) {
        args[argc].name = NULL;
        switch(in[i].type) {
            case TNK_RT_INT:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].intVal);
                break;
            case TNK_RT_UINT:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].uintVal);
                break;
            case TNK_RT_LONG:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].longVal);
                break;
            case TNK_RT_ULONG:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].ulongVal);
                break;
            case TNK_RT_OBJECT:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].ptrVal);
                break;
            case TNK_RT_STRING:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].strVal);
                break;
            case TNK_RT_COMPOUND_STRING:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].xmStr);
                break;
            case TNK_RT_XCOLOR:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].color);
                break;
            case TNK_RT_CALLBACK:
                XtSetArg(args[argc], (String)in[i].name, (XtArgVal)in[i].callback);
                break;
            case TNK_RT_UNDEFINED:
            default:
                continue;
        }
        if (True == deepCopy) {
            args[argc].name = (String)calloc(strlen(in[i].name)+1, sizeof(char));
            memcpy(args[argc].name, in[i].name, strlen(in[i].name));
        }

        #ifdef _DEBUG
        CONS25W(stderr, "IMP_CVT<%p><%s> RES[%d] n=%s t=%d iv=%d uv=%d long=%ld ulong=%ld pv=%p, sv=%s cs=%p color=%04lx cb=%p\n",
            args,
            (True == deepCopy) ? "DC" : "SC",
            argc,
            in[i].name,
            in[i].type,
            in[i].intVal,
            in[i].uintVal,
            in[i].longVal,
            in[i].ulongVal,
            in[i].ptrVal,
            in[i].strVal,
            in[i].xmStr,
            in[i].color,
            in[i].callback
        );
        #endif
        argc++;
    }
    return argc;
}

TNK_EXPORT void
TNK_IMP_TnkFreeDeepCopyArg(Arg* args, int count) {
    int i;
    if (NULL == args) {
        return;
    }
    #ifdef _DEBUG
    CONS25W(stderr, "IMP_FREE_DC<%p>(%d)\n", args, count);
    #endif
    for (i = 0; i < count; i++) {
        if (NULL != args[i].name) {
            free(args[i].name);
            args[i].name = NULL;
        }
    }
}

TNK_EXPORT Arg*
TNK_IMP_TnkAllocArg(int count) {
    Arg* args;

    args = (Arg*)malloc(sizeof(Arg) * (1+count));
    memset(args, 0x00, sizeof(Arg) * count);
    #ifdef _DEBUG
    CONS25W(stderr, "IMP_ALLOC<%p>(%d)\n", args, count);
    #endif

    return args;
}

TNK_EXPORT void
TNK_IMP_TnkFreeArg(Arg* args) {
    if (NULL == args) {
        return;
    }
    #ifdef _DEBUG
    CONS25W(stderr, "IMP_FREE(%p)\n", args);
    #endif
    free(args);
}

//
// ﾘｿーｽ関連
//
TNK_EXPORT void
TNK_IMP_Xt_XtSetValues( Widget w, TNK_RESOURCE* a, int c )
{
    int argc = 0;
    Boolean isHeap = False;
    Arg* args;
    Arg stacked[MAX_STACK_ARG];

    if (c >= MAX_STACK_ARG) {
        args = (Arg*)malloc(sizeof(Arg) * (1+c));
        isHeap = True;
    }
    else {
        #ifdef _DEBUG
        CONS25W( stderr, "%p: XtSetValues using STACK(%d)\n", w, c);
        #endif
        args = stacked;
    }
    memset(args, 0x00, sizeof(Arg) * c);
    argc = TNK_IMP_TnkConvertResource(a, args, c, False);

	XtSetValues( w, args, argc);
    if (True == isHeap) {
        free(args);
    }
}

//
//
// ﾘｿーｽ取得用
//
//
//
//

TNK_EXPORT void
TNK_IMP_Xt_XtGetValuesByte( Widget w, char *value, unsigned char *dst )
{
	Arg a[1];

	XtSetArg(a[0], value, (XtArgVal)dst );

	XtGetValues( w, a, 1);

	#ifdef _DEBUG
	CONS25W(stderr, "GetValuesBY: %s = %d\n", value , *dst );
	#endif
}


TNK_EXPORT void
TNK_IMP_Xt_XtGetValuesBoolean( Widget w, char *value, char *dst )
{
	Arg a[1];

	XtSetArg(a[0], value, (XtArgVal)dst );

	XtGetValues( w, a, 1);

	#ifdef _DEBUG
	CONS25W(stderr, "GetValuesB: %s = %d\n", value , *dst );
	#endif
}


TNK_EXPORT void
TNK_IMP_Xt_XtGetValuesDimension( Widget w, char *value, Dimension *dst )
{
	Arg a[1];

	XtSetArg(a[0], value, (XtArgVal)dst );

	XtGetValues( w, a, 1);

	#ifdef _DEBUG
	CONS25W(stderr, "GetValuesD: %s = %d\n", value , *dst );
	#endif
}


TNK_EXPORT void
TNK_IMP_Xt_XtGetValuesInt( Widget w, char *value, int *dst )
{
	Arg a[1];

	XtSetArg(a[0], value, (XtArgVal)dst );

	XtGetValues( w, a, 1);

	#ifdef _DEBUG
	CONS25W(stderr, "GetValuesD: %s = %d\n", value , *dst );
	#endif
}


TNK_EXPORT void
TNK_IMP_Xt_XtGetValuesLong( Widget w, char *value, long *dst )
{
	Arg a[1];

	XtSetArg(a[0], value, (XtArgVal)dst );

	XtGetValues( w, a, 1);

	#ifdef _DEBUG
	CONS25W(stderr, "GetValuesL: %s = %ld\n", value , *dst );
	#endif
}


TNK_EXPORT XmString
TNK_IMP_Xt_XtGetValuesCompoundString( Widget w, char *value)
{
	Arg a[1];
    XmString dest = NULL;

	XtSetArg(a[0], value, (XtArgVal)&dest );

	XtGetValues( w, a, 1);

	#ifdef _DEBUG
	CONS25W(stderr, "GetValuesCS: %s = %p\n", value , dest );
	#endif
    return dest;
}

TNK_EXPORT String
TNK_IMP_Xt_XtGetValuesAnsiString( Widget w, char *value)
{
	Arg a[1];
    String dest = NULL;

	XtSetArg(a[0], value, (XtArgVal)&dest );

	XtGetValues( w, a, 1);

	#ifdef _DEBUG
	CONS25W(stderr, "GetValuesAS: %s = %p\n", value , dest );
	#endif
    return dest;
}

TNK_EXPORT void
XtFree_TNK(void* ptr)
{
    XtFree(ptr);
}

TNK_EXPORT Widget
XtNameToWidget_TNK(Widget parent, String name)
{
    return XtNameToWidget(parent, name);
}

TNK_EXPORT void
XtRealizeWidget_TNK(Widget w) {
    XtRealizeWidget(w);
}

TNK_EXPORT void
XtManageChild_TNK(Widget w) {
    XtManageChild(w);
}

TNK_EXPORT void
XtUnmanageChild_TNK(Widget w) {
    XtUnmanageChild(w);
}

TNK_EXPORT void
XtDestroyWidget_TNK(Widget w) {
    XtDestroyWidget(w);
}

TNK_EXPORT void
XtMapWidget_TNK(Widget w) {
    XtMapWidget(w);
}

TNK_EXPORT void
XtUnmapWidget_TNK(Widget w) {
    XtUnmapWidget(w);
}
TNK_EXPORT Boolean
XtIsManaged_TNK(Widget w) {
    return XtIsManaged(w);
}

TNK_EXPORT Display*
XtDisplay_TNK(Widget w) {
    return XtDisplay(w);
}

TNK_EXPORT Screen*
XtScreen_TNK(Widget w)
{
    return XtScreen(w);
}
TNK_EXPORT Window
XtWindow_TNK(Widget w)
{
    return XtWindow(w);
}

TNK_EXPORT String
XtName_TNK(Widget w)
{
    return XtName(w);
}

TNK_EXPORT Time XtLastTimestampProcessed_TNK(Display* display) {
    return XtLastTimestampProcessed(display);
}

TNK_EXPORT void
XtAddCallback_TNK(Widget w,
    String name, XtCallbackProc callback, XtPointer client_data)
{
    XtAddCallback(w, name, callback, client_data);
}

TNK_EXPORT void
XtRemoveCallback_TNK(Widget w,
    String name, XtCallbackProc callback, XtPointer client_data) {
    XtRemoveCallback(w, name, callback, client_data);
}

TNK_EXPORT XtTranslations XtParseTranslationTable_TNK(String table) {
    return XtParseTranslationTable(table);
}

TNK_EXPORT void XtAugmentTranslations_TNK(Widget w, XtTranslations translations) {
    XtAugmentTranslations(w,translations);
}

TNK_EXPORT void XtOverrideTranslations_TNK(Widget w, XtTranslations translations) {
    XtOverrideTranslations(w,translations);
}

TNK_EXPORT void XtUninstallTranslations_TNK(Widget w) {
    XtUninstallTranslations(w);
}

TNK_EXPORT XtAccelerators XtParseAcceleratorTable_TNK(String source) {
    return XtParseAcceleratorTable(source);
}

TNK_EXPORT void XtInstallAccelerators_TNK(Widget destination, Widget source) {
    XtInstallAccelerators(destination,source);
}

TNK_EXPORT void XtInstallAllAccelerators_TNK(Widget destination, Widget source) {
    XtInstallAllAccelerators(destination,source);
}

TNK_EXPORT void XtAddEventHandler_TNK(Widget w, EventMask event_mask, Boolean nonmaskable, XtEventHandler proc, XtPointer client_data) {
    XtAddEventHandler(w,event_mask,nonmaskable,proc,client_data);
}

TNK_EXPORT void XtRemoveEventHandler_TNK(Widget w, EventMask event_mask, Boolean nonmaskable, XtEventHandler proc, XtPointer client_data) {
    XtRemoveEventHandler(w,event_mask,nonmaskable,proc,client_data);
}

TNK_EXPORT void XtPopup_TNK(Widget popup_shell, XtGrabKind grab_kind) {
    XtPopup(popup_shell,grab_kind);
}

TNK_EXPORT void XtPopdown_TNK(Widget popup_shell) {
    XtPopdown(popup_shell);
}

TNK_DECLARE_END
