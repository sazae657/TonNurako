//
// ﾄﾝﾇﾗｺ
//
// Xlibﾗｯﾊﾟー
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.X11
{

    [StructLayout(LayoutKind.Sequential)]
    internal struct XWindowChanges{
            int x, y;
            int width, height;
            int border_width;
            IntPtr sibling; //Window
            int stack_mode;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XModifierKeymap {
            int max_keypermod;
            IntPtr modifiermap;  // KeyCode *
    } ;


    [StructLayout(LayoutKind.Sequential)]
    internal struct XTimeCoord{
        uint time;
        short x, y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTextProperty {
        IntPtr value;   // unsigned char*
        Atom encoding;  /* type of property */
        int format;     /* 8, 16, or 32 */
        ulong nitems;   /* number of items in value */
    }

}
