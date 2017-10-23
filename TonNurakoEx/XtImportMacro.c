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

TNK_EXPORT Widget XtCreateManagedWidget_TNK(String name, WidgetClass widget_class, Widget parent, ArgList args, Cardinal num_args) {
    return XtCreateManagedWidget(name,widget_class,parent,args,num_args);
}

TNK_EXPORT Widget XtCreateWidget_TNK(String name, WidgetClass widget_class, Widget parent, ArgList args, Cardinal num_args) {
    return XtCreateWidget(name,widget_class,parent,args,num_args);
}
