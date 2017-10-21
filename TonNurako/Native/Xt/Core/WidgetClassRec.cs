using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Xt.Core {
    public delegate void XtProc();
    public delegate void XtWidgetClassProc(IntPtr widgetClass); //WidgetClass
    public delegate void XtInitProc(
      IntPtr request, // Widget
      IntPtr xnew, // Widget
      IntPtr argList, //,
      IntPtr num_args //Cardinal* 
    );

    public delegate void XtArgsProc(
      IntPtr widget, // Widget
      IntPtr argList, // ArgList
      IntPtr num_args //Cardinal* 
    );

    public delegate void XtRealizeProc(
          IntPtr widget,
          IntPtr mask, //XtValueMask*
          IntPtr attributes //XSetWindowAttributes
      );

    public delegate void XtWidgetProc(
          IntPtr widget
      );

    public delegate void XtExposeProc(
          IntPtr widget,
          IntPtr xevent, //XEvent
          IntPtr region // Region
      );

    public delegate void XtSetValuesFunc(
        IntPtr old, // Widget
        IntPtr request,// Widget
        IntPtr xnew,// Widget
        IntPtr  args, //ArgList
        IntPtr  num_args // Cardinal*
    );

    public delegate void XtAlmostProc(
          IntPtr old, //Widget
          IntPtr xnew, //Widget
          IntPtr request, //XtWidgetGeometry*
          IntPtr reply //XtWidgetGeometry*
      );

    public delegate bool XtAcceptFocusProc(
       IntPtr  widget, //Widget
       IntPtr time // Time*
    );

    public delegate void XtGeometryHandler(
          IntPtr widget, //Widget
          IntPtr request, //XtWidgetGeometry*
          IntPtr reply //XtWidgetGeometry*
      );

    public delegate void XtStringProc(
          IntPtr  widget,//Widget
          IntPtr str //String
    );


    [StructLayout(LayoutKind.Sequential)]
    internal struct CoreClassPart {
        public IntPtr superclass;     // WidgetClassRec
        [MarshalAs(UnmanagedType.LPStr)] public string class_name;  
        int widget_size;   // Cardinal
        XtProc class_initialize;  
        XtWidgetClassProc class_part_initialize; 
        byte class_inited;     // XtEnum
        XtInitProc initialize;  
        XtArgsProc initialize_hook;
        XtRealizeProc realize;
        IntPtr actions;  // XtActionList
        int num_actions; //Cardinal
        IntPtr resources;  // XtResource*
        int num_resources;     
        int xrm_class;     // XrmClass
        bool compress_motion;    
        byte compress_exposure;  //XtEnum
        bool compress_enterleave;
        bool visible_interest;  
        XtWidgetProc destroy;      
        XtWidgetProc resize;       
        XtExposeProc expose;       
        XtSetValuesFunc set_values;  
        XtArgsProc set_values_hook;   
        XtAlmostProc set_values_almost;
        XtArgsProc get_values_hook;   
        XtAcceptFocusProc accept_focus; 
        ulong version;  //XtVersionType
        IntPtr callback_private; //XtPointer
        [MarshalAs(UnmanagedType.LPStr)] public string tm_table; 
        XtGeometryHandler query_geometry;
        XtStringProc display_accelerator;
        IntPtr extension;     // IntPtr
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct WidgetClass {
        CoreClassPart core_class;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XtResource {
        [MarshalAs(UnmanagedType.LPStr)] public string resource_name;
        [MarshalAs(UnmanagedType.LPStr)] public string resource_class; 
        [MarshalAs(UnmanagedType.LPStr)] public string resource_type;
        public int resource_size;
        public int resource_offset;
        [MarshalAs(UnmanagedType.LPStr)] public string default_type;
        public IntPtr default_addr; //XtPointer
    }

    public class CoreWidgetClass {
        public CoreWidgetClass() {
        }
    }

}
