#include "TonNurako.h"


TNK_EXPORT WidgetClass TNK_GetUltraSuperWidgetClass(void) {
    return &widgetClassRec;
}

// C#ではどーにもならねえので構造体に詰める
typedef struct
tagXtInheritTNK
{
    String              InheritTranslations;
    XtRealizeProc       InheritRealize;
    XtWidgetProc        InheritResize;
    XtExposeProc        InheritExpose;
    XtAlmostProc        InheritSetValuesAlmost;
    XtAcceptFocusProc   InheritAcceptFocus;
    XtGeometryHandler   InheritQueryGeometry;
    XtStringProc        InheritDisplayAccelerator;
}XtInheritTNK;

TNK_EXPORT void TNK_GetXtInheritance(XtInheritTNK* p)
{
    p->InheritTranslations = XtInheritTranslations;
    p->InheritRealize =XtInheritRealize;
    p->InheritResize =XtInheritResize;
    p->InheritExpose =XtInheritExpose;
    p->InheritSetValuesAlmost =XtInheritSetValuesAlmost;
    p->InheritAcceptFocus =XtInheritAcceptFocus;
    p->InheritQueryGeometry =XtInheritQueryGeometry;
    p->InheritDisplayAccelerator =XtInheritDisplayAccelerator;
}

TNK_EXPORT void TNK_InitializeXtWidgetClass(WidgetClassRec* p)
{
    (p->core_class).tm_table = XtInheritTranslations;
    (p->core_class).realize = XtInheritRealize;
    (p->core_class).resize = XtInheritResize;
    (p->core_class).expose = XtInheritExpose;
    (p->core_class).set_values_almost = XtInheritSetValuesAlmost;
    (p->core_class).accept_focus = XtInheritAcceptFocus;
    (p->core_class).query_geometry = XtInheritQueryGeometry;
    (p->core_class).display_accelerator = XtInheritDisplayAccelerator;
    (p->core_class).version = XtVersion;
}

TNK_EXPORT Widget XtCreateManagedWidget_TNK(String name, WidgetClass widget_class, Widget parent, ArgList args, Cardinal num_args) {
    return XtCreateManagedWidget(name,widget_class,parent,args,num_args);
}

TNK_EXPORT Widget XtCreateWidget_TNK(String name, WidgetClass widget_class, Widget parent, ArgList args, Cardinal num_args) {
    return XtCreateWidget(name,widget_class,parent,args,num_args);
}

TNK_EXPORT void XtCreateWindow_TNK(Widget widget, int window_class, Visual* visual, XtValueMask value_mask, XSetWindowAttributes* attributes) {
    XtCreateWindow(widget,window_class,visual,value_mask,attributes);
}

TNK_EXPORT XtIntervalId XtAppAddTimeOut_TNK(XtAppContext app_context, long interval, XtTimerCallbackProc proc, XtPointer client_data) {
    return XtAppAddTimeOut(app_context,interval,proc,client_data);
}
TNK_EXPORT void XtRemoveTimeOut_TNK(XtIntervalId timer) {
    XtRemoveTimeOut(timer);
}

TNK_EXPORT Widget XtParent_TNK(Widget w) {
    return XtParent(w);
}
