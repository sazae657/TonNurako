using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Xt.Core {

    [StructLayout(LayoutKind.Sequential)]
    internal struct CorePart {
        public IntPtr self;    // Widget
        public IntPtr widget_class;    // WidgetClass
        public IntPtr parent;    // Widget
        public int xrm_name;    // XrmName
        [MarshalAs(UnmanagedType.U1)] public bool being_destroyed;    // Boolean
        public IntPtr destroy_callbacks;    // XtCallbackList
        public IntPtr constraints;    // XtPointer
        public Int16 x;    // Position
        public Int16 y;    // Position
        public int width;    // Dimension
        public int height;    // Dimension
        public int border_width;    // Dimension
        [MarshalAs(UnmanagedType.U1)] public bool managed;    // Boolean
        [MarshalAs(UnmanagedType.U1)] public bool sensitive;    // Boolean
        [MarshalAs(UnmanagedType.U1)] public bool ancestor_sensitive;    // Boolean
        public IntPtr event_table;    // XtEventTable
        public XtTMRec tm;    // XtTMRec
        public IntPtr accelerators;    // XtTranslations
        public ulong border_pixel;    // Pixel
        public IntPtr border_pixmap;    // Pixmap
        public IntPtr popup_list;    // WidgetList
        public int num_popups;    // Cardinal
        public IntPtr name;    // String
        public IntPtr screen;    // Screen*
        public ulong colormap;    // Colormap
        public ulong window;    // Window
        public int depth;    // Cardinal
        public ulong background_pixel;    // Pixel
        public IntPtr background_pixmap;    // Pixmap
        [MarshalAs(UnmanagedType.U1)] public bool visible;    // Boolean
        [MarshalAs(UnmanagedType.U1)] public bool mapped_when_managed;    // Boolean
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct _WidgetRec {
        public CorePart core;
    }

    public class WidgetRec {
        internal _WidgetRec Record;

        internal IntPtr Self {
            get => Record.core.self;
            set => Record.core.self = value;
        }
        internal IntPtr WidgetClass {
            get => Record.core.widget_class;
            set => Record.core.widget_class = value;
        }
        internal IntPtr Parent {
            get => Record.core.parent;
            set => Record.core.parent = value;
        }
        public int XrmName {
            get => Record.core.xrm_name;
            set => Record.core.xrm_name = value;
        }
        public bool BeingDestroyed {
            get => Record.core.being_destroyed;
            set => Record.core.being_destroyed = value;
        }
        internal IntPtr DestroyCallbacks {
            get => Record.core.destroy_callbacks;
            set => Record.core.destroy_callbacks = value;
        }
        internal IntPtr Constraints {
            get => Record.core.constraints;
            set => Record.core.constraints = value;
        }
        public short X {
            get => Record.core.x;
            set => Record.core.x = value;
        }
        public short Y {
            get => Record.core.y;
            set => Record.core.y = value;
        }
        public int Width {
            get => Record.core.width;
            set => Record.core.width = value;
        }
        public int Height {
            get => Record.core.height;
            set => Record.core.height = value;
        }
        public int BorderWidth {
            get => Record.core.border_width;
            set => Record.core.border_width = value;
        }
        public bool Managed {
            get => Record.core.managed;
            set => Record.core.managed = value;
        }
        public bool Sensitive {
            get => Record.core.sensitive;
            set => Record.core.sensitive = value;
        }
        public bool AncestorSensitive {
            get => Record.core.ancestor_sensitive;
            set => Record.core.ancestor_sensitive = value;
        }
        internal IntPtr EventTable {
            get => Record.core.event_table;
            set => Record.core.event_table = value;
        }

        internal XtTMRec Tm {
            get => Record.core.tm;
            set => Record.core.tm = value;
        }

        internal IntPtr Accelerators {
            get => Record.core.accelerators;
            set => Record.core.accelerators = value;
        }
        public ulong BorderPixel {
            get => Record.core.border_pixel;
            set => Record.core.border_pixel = value;
        }
        internal IntPtr BorderPixmap {
            get => Record.core.border_pixmap;
            set => Record.core.border_pixmap = value;
        }
        internal IntPtr PopupList {
            get => Record.core.popup_list;
            set => Record.core.popup_list = value;
        }
        public int NumPopups {
            get => Record.core.num_popups;
            set => Record.core.num_popups = value;
        }
        internal IntPtr Name {
            get => Record.core.name;
            set => Record.core.name = value;
        }
        public IntPtr Screen {
            get => Record.core.screen;
            set => Record.core.screen = value;
        }
        public ulong Colormap {
            get => Record.core.colormap;
            set => Record.core.colormap = value;
        }
        public ulong Window {
            get => Record.core.window;
            set => Record.core.window = value;
        }
        public int Depth {
            get => Record.core.depth;
            set => Record.core.depth = value;
        }
        public ulong BackgroundPixel {
            get => Record.core.background_pixel;
            set => Record.core.background_pixel = value;
        }
        public IntPtr BackgroundPixmap {
            get => Record.core.background_pixmap;
            set => Record.core.background_pixmap = value;
        }
        public bool Visible {
            get => Record.core.visible;
            set => Record.core.visible = value;
        }
        public bool MappedWhenManaged {
            get => Record.core.mapped_when_managed;
            set => Record.core.mapped_when_managed = value;
        }
    }
}
