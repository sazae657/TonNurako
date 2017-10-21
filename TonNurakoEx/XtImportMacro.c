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