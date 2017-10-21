using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

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
        IntPtr args, //ArgList
        IntPtr num_args // Cardinal*
    );

    public delegate void XtAlmostProc(
          IntPtr old, //Widget
          IntPtr xnew, //Widget
          IntPtr request, //XtWidgetGeometry*
          IntPtr reply //XtWidgetGeometry*
      );

    public delegate bool XtAcceptFocusProc(
       IntPtr widget, //Widget
       IntPtr time // Time*
    );

    public delegate void XtGeometryHandler(
          IntPtr widget, //Widget
          IntPtr request, //XtWidgetGeometry*
          IntPtr reply //XtWidgetGeometry*
      );

    public delegate void XtStringProc(
          IntPtr widget,//Widget
          IntPtr str //String
    );


    [StructLayout(LayoutKind.Sequential)]
    internal struct CoreClassPart {
        public IntPtr superclass;     // WidgetClassRec
        [MarshalAs(UnmanagedType.LPStr)] public string class_name;
        public int widget_size;   // Cardinal
        public XtProc class_initialize;
        public XtWidgetClassProc class_part_initialize;
        public byte class_inited;     // XtEnum
        public XtInitProc initialize;
        public XtArgsProc initialize_hook;
        public XtRealizeProc realize;
        public IntPtr actions;  // XtActionList
        public int num_actions; //Cardinal
        public IntPtr resources;  // XtResource*
        public int num_resources;
        public int xrm_class;     // XrmClass
        public bool compress_motion;
        public byte compress_exposure;  //XtEnum
        public bool compress_enterleave;
        public bool visible_interest;
        public XtWidgetProc destroy;
        public XtWidgetProc resize;
        public XtExposeProc expose;
        public XtSetValuesFunc set_values;
        public XtArgsProc set_values_hook;
        public XtAlmostProc set_values_almost;
        public XtArgsProc get_values_hook;
        public XtAcceptFocusProc accept_focus;
        public ulong version;  //XtVersionType
        public IntPtr callback_private; //XtPointer
        [MarshalAs(UnmanagedType.LPStr)] public string tm_table;
        public XtGeometryHandler query_geometry;
        public XtStringProc display_accelerator;
        public IntPtr extension;     // IntPtr
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct WidgetClass {
        public CoreClassPart core_class;
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

    [StructLayout(LayoutKind.Sequential)]
    internal struct XtInheritTNK {
        public IntPtr InheritTranslations;
        public XtRealizeProc InheritRealize;
        public XtWidgetProc InheritResize;
        public XtExposeProc InheritExpose;
        public XtAlmostProc InheritSetValuesAlmost;
        public XtAcceptFocusProc InheritAcceptFocus;
        public XtGeometryHandler InheritQueryGeometry;
        public XtStringProc InheritDisplayAccelerator;
    }

    public class CoreWidgetClass : IDisposable {
        internal static class NativeMethods {
            // WidgetClass*: TNK_GetUltraSuperWidgetClass
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetUltraSuperWidgetClass", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetUltraSuperWidgetClass();

            // void: TNK_GetXtInheritance XtInheritTNK*:p
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXtInheritance", CharSet = CharSet.Auto)]
            internal static extern void TNK_GetXtInheritance(ref XtInheritTNK p);
        }
        public static CoreWidgetClass GetDefaultSuperClass() {

            var inh = new XtInheritTNK();
            NativeMethods.TNK_GetXtInheritance(ref inh);
            var p = NativeMethods.TNK_GetUltraSuperWidgetClass();
            return (new CoreWidgetClass(p));
        }

        public CoreWidgetClass() {
            isPounterAllocated = true;
            pounter = Marshal.AllocCoTaskMem(Marshal.SizeOf<WidgetClass>());
        }

        internal CoreWidgetClass(IntPtr ptr) {
            isPounterAllocated = false;
            Record = Marshal.PtrToStructure<WidgetClass>(ptr);
            pounter = ptr;
            if (IntPtr.Zero != Record.core_class.superclass) {
                superClass = new CoreWidgetClass(Record.core_class.superclass);
            }
        }

        internal IntPtr SuperClassPtr = IntPtr.Zero;

        bool isPounterAllocated = false;
        IntPtr pounter;
        internal IntPtr Pounter {
            get {
                if (isPounterAllocated) {
                    Marshal.StructureToPtr<WidgetClass>(Record, pounter, false);
                    throw new Exception("isPounterAllocated == true");
                }
                return pounter;
            }
        }

        WidgetClass Record;
        CoreWidgetClass superClass = null;

        public CoreWidgetClass SuperClass {
            get => superClass;
            set {
                superClass = value;
                Record.core_class.superclass = value.Pounter;
            }
        }

        public string ClassName {
            get => Record.core_class.class_name;
            set => Record.core_class.class_name = value;
        }
        public int WidgetSize {
            get => Record.core_class.widget_size;
            set => Record.core_class.widget_size = value;
        }
        public XtProc ClassInitialize {
            get => Record.core_class.class_initialize;
            set => Record.core_class.class_initialize = value;
        }
        public XtWidgetClassProc ClassPartInitialize {
            get => Record.core_class.class_part_initialize;
            set => Record.core_class.class_part_initialize = value;
        }
        public byte ClassInited {
            get => Record.core_class.class_inited;
            set => Record.core_class.class_inited = value;
        }
        public XtInitProc Initialize {
            get => Record.core_class.initialize;
            set => Record.core_class.initialize = value;
        }
        public XtArgsProc InitializeHook {
            get => Record.core_class.initialize_hook;
            set => Record.core_class.initialize_hook = value;
        }
        public XtRealizeProc Realize {
            get => Record.core_class.realize;
            set => Record.core_class.realize = value;
        }
        public IntPtr Actions {
            get => Record.core_class.actions;
            set => Record.core_class.actions = value;
        }
        public int NumActions {
            get => Record.core_class.num_actions;
            set => Record.core_class.num_actions = value;
        }
        public IntPtr Resources {
            get => Record.core_class.resources;
            set => Record.core_class.resources = value;
        }
        public int NumResources {
            get => Record.core_class.num_resources;
            set => Record.core_class.num_resources = value;
        }
        public int XrmClass {
            get => Record.core_class.xrm_class;
            set => Record.core_class.xrm_class = value;
        }
        public bool CompressMotion {
            get => Record.core_class.compress_motion;
            set => Record.core_class.compress_motion = value;
        }
        public byte CompressExposure {
            get => Record.core_class.compress_exposure;
            set => Record.core_class.compress_exposure = value;
        }
        public bool CompressEnterleave {
            get => Record.core_class.compress_enterleave;
            set => Record.core_class.compress_enterleave = value;
        }
        public bool VisibleInterest {
            get => Record.core_class.visible_interest;
            set => Record.core_class.visible_interest = value;
        }
        public XtWidgetProc Destroy {
            get => Record.core_class.destroy;
            set => Record.core_class.destroy = value;
        }
        public XtWidgetProc Resize {
            get => Record.core_class.resize;
            set => Record.core_class.resize = value;
        }
        public XtExposeProc Expose {
            get => Record.core_class.expose;
            set => Record.core_class.expose = value;
        }
        public XtSetValuesFunc SetValues {
            get => Record.core_class.set_values;
            set => Record.core_class.set_values = value;
        }
        public XtArgsProc SetValuesHook {
            get => Record.core_class.set_values_hook;
            set => Record.core_class.set_values_hook = value;
        }
        public XtAlmostProc SetValuesAlmost {
            get => Record.core_class.set_values_almost;
            set => Record.core_class.set_values_almost = value;
        }
        public XtArgsProc GetValuesHook {
            get => Record.core_class.get_values_hook;
            set => Record.core_class.get_values_hook = value;
        }
        public XtAcceptFocusProc AcceptFocus {
            get => Record.core_class.accept_focus;
            set => Record.core_class.accept_focus = value;
        }
        public ulong Version {
            get => Record.core_class.version;
            set => Record.core_class.version = value;
        }
        public IntPtr CallbackPrivate {
            get => Record.core_class.callback_private;
            set => Record.core_class.callback_private = value;
        }
        public string TmTable {
            get => Record.core_class.tm_table;
            set => Record.core_class.tm_table = value;
        }
        public XtGeometryHandler QueryGeometry {
            get => Record.core_class.query_geometry;
            set => Record.core_class.query_geometry = value;
        }
        public XtStringProc DisplayAccelerator {
            get => Record.core_class.display_accelerator;
            set => Record.core_class.display_accelerator = value;
        }
        public IntPtr Extension {
            get => Record.core_class.extension;
            set => Record.core_class.extension = value;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                if (isPounterAllocated && IntPtr.Zero != Pounter) {
                    Marshal.FreeCoTaskMem(pounter);
                    pounter = IntPtr.Zero;
                }
            }
        }

        // ~Region() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
