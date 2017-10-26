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

Widget GetWidgetRecSelf(WidgetRec* ptr) { return ptr->core.self; }
void SetWidgetRecSelf(WidgetRec* ptr, Widget value) { ptr->core.self = value; }
WidgetClass GetWidgetRecWidgetClass(WidgetRec* ptr) { return ptr->core.widget_class; }
void SetWidgetRecWidgetClass(WidgetRec* ptr, WidgetClass value) { ptr->core.widget_class = value; }
Widget GetWidgetRecParent(WidgetRec* ptr) { return ptr->core.parent; }
void SetWidgetRecParent(WidgetRec* ptr, Widget value) { ptr->core.parent = value; }
XrmName GetWidgetRecXrmName(WidgetRec* ptr) { return ptr->core.xrm_name; }
void SetWidgetRecXrmName(WidgetRec* ptr, XrmName value) { ptr->core.xrm_name = value; }
Boolean GetWidgetRecBeingDestroyed(WidgetRec* ptr) { return ptr->core.being_destroyed; }
void SetWidgetRecBeingDestroyed(WidgetRec* ptr, Boolean value) { ptr->core.being_destroyed = value; }
XtCallbackList GetWidgetRecDestroyCallbacks(WidgetRec* ptr) { return ptr->core.destroy_callbacks; }
void SetWidgetRecDestroyCallbacks(WidgetRec* ptr, XtCallbackList value) { ptr->core.destroy_callbacks = value; }
XtPointer GetWidgetRecConstraints(WidgetRec* ptr) { return ptr->core.constraints; }
void SetWidgetRecConstraints(WidgetRec* ptr, XtPointer value) { ptr->core.constraints = value; }
Position GetWidgetRecX(WidgetRec* ptr) { return ptr->core.x; }
void SetWidgetRecX(WidgetRec* ptr, Position value) { ptr->core.x = value; }
Position GetWidgetRecY(WidgetRec* ptr) { return ptr->core.y; }
void SetWidgetRecY(WidgetRec* ptr, Position value) { ptr->core.y = value; }
Dimension GetWidgetRecWidth(WidgetRec* ptr) { return ptr->core.width; }
void SetWidgetRecWidth(WidgetRec* ptr, Dimension value) { ptr->core.width = value; }
Dimension GetWidgetRecHeight(WidgetRec* ptr) { return ptr->core.height; }
void SetWidgetRecHeight(WidgetRec* ptr, Dimension value) { ptr->core.height = value; }
Dimension GetWidgetRecBorderWidth(WidgetRec* ptr) { return ptr->core.border_width; }
void SetWidgetRecBorderWidth(WidgetRec* ptr, Dimension value) { ptr->core.border_width = value; }
Boolean GetWidgetRecManaged(WidgetRec* ptr) { return ptr->core.managed; }
void SetWidgetRecManaged(WidgetRec* ptr, Boolean value) { ptr->core.managed = value; }
Boolean GetWidgetRecSensitive(WidgetRec* ptr) { return ptr->core.sensitive; }
void SetWidgetRecSensitive(WidgetRec* ptr, Boolean value) { ptr->core.sensitive = value; }
Boolean GetWidgetRecAncestorSensitive(WidgetRec* ptr) { return ptr->core.ancestor_sensitive; }
void SetWidgetRecAncestorSensitive(WidgetRec* ptr, Boolean value) { ptr->core.ancestor_sensitive = value; }
XtEventTable GetWidgetRecEventTable(WidgetRec* ptr) { return ptr->core.event_table; }
void SetWidgetRecEventTable(WidgetRec* ptr, XtEventTable value) { ptr->core.event_table = value; }
XtTMRec GetWidgetRecTm(WidgetRec* ptr) { return ptr->core.tm; }
void SetWidgetRecTm(WidgetRec* ptr, XtTMRec value) { ptr->core.tm = value; }
XtTranslations GetWidgetRecAccelerators(WidgetRec* ptr) { return ptr->core.accelerators; }
void SetWidgetRecAccelerators(WidgetRec* ptr, XtTranslations value) { ptr->core.accelerators = value; }
Pixel GetWidgetRecBorderPixel(WidgetRec* ptr) { return ptr->core.border_pixel; }
void SetWidgetRecBorderPixel(WidgetRec* ptr, Pixel value) { ptr->core.border_pixel = value; }
Pixmap GetWidgetRecBorderPixmap(WidgetRec* ptr) { return ptr->core.border_pixmap; }
void SetWidgetRecBorderPixmap(WidgetRec* ptr, Pixmap value) { ptr->core.border_pixmap = value; }
WidgetList GetWidgetRecPopupList(WidgetRec* ptr) { return ptr->core.popup_list; }
void SetWidgetRecPopupList(WidgetRec* ptr, WidgetList value) { ptr->core.popup_list = value; }
Cardinal GetWidgetRecNumPopups(WidgetRec* ptr) { return ptr->core.num_popups; }
void SetWidgetRecNumPopups(WidgetRec* ptr, Cardinal value) { ptr->core.num_popups = value; }
String GetWidgetRecName(WidgetRec* ptr) { return ptr->core.name; }
void SetWidgetRecName(WidgetRec* ptr, String value) { ptr->core.name = value; }
Screen* GetWidgetRecScreen(WidgetRec* ptr) { return ptr->core.screen; }
void SetWidgetRecScreen(WidgetRec* ptr, Screen* value) { ptr->core.screen = value; }
Colormap GetWidgetRecColormap(WidgetRec* ptr) { return ptr->core.colormap; }
void SetWidgetRecColormap(WidgetRec* ptr, Colormap value) { ptr->core.colormap = value; }
Window GetWidgetRecWindow(WidgetRec* ptr) { return ptr->core.window; }
void SetWidgetRecWindow(WidgetRec* ptr, Window value) { ptr->core.window = value; }
Cardinal GetWidgetRecDepth(WidgetRec* ptr) { return ptr->core.depth; }
void SetWidgetRecDepth(WidgetRec* ptr, Cardinal value) { ptr->core.depth = value; }
Pixel GetWidgetRecBackgroundPixel(WidgetRec* ptr) { return ptr->core.background_pixel; }
void SetWidgetRecBackgroundPixel(WidgetRec* ptr, Pixel value) { ptr->core.background_pixel = value; }
Pixmap GetWidgetRecBackgroundPixmap(WidgetRec* ptr) { return ptr->core.background_pixmap; }
void SetWidgetRecBackgroundPixmap(WidgetRec* ptr, Pixmap value) { ptr->core.background_pixmap = value; }
Boolean GetWidgetRecVisible(WidgetRec* ptr) { return ptr->core.visible; }
void SetWidgetRecVisible(WidgetRec* ptr, Boolean value) { ptr->core.visible = value; }
Boolean GetWidgetRecMappedWhenManaged(WidgetRec* ptr) { return ptr->core.mapped_when_managed; }
void SetWidgetRecMappedWhenManaged(WidgetRec* ptr, Boolean value) { ptr->core.mapped_when_managed = value; }
