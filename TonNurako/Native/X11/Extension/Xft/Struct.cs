using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft
{

    [StructLayout(LayoutKind.Sequential)]
    public struct XftCharSpec {
        uint    Ucs4;//FcChar32
        short       X;
        short       Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XftCharFontSpec {
        internal IntPtr Font; //XftFont*
        public uint Ucs4; //FcChar32
        public short X;
        public short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XftGlyphSpec {
        public uint Glyph; //FT_UInt
        public short X;
        public short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XftGlyphFontSpec {
        internal IntPtr Font; //XftFont*
        public uint Glyph; //FT_UInt
        public short X;
        public short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FcObjectSet {
        public int nobject;
        public int sobject;
        public IntPtr objects; //const char**
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _FcValue {
        FcType type;
        /* TODO:どーすっかなｺﾚ
        union {
		const FcChar8* s;
        int i;
        FcBool b;
        double d;
        const FcMatrix* m;
        const FcCharSet* c;
        void* f;
        const FcLangSet* l;
        const FcRange* r;
        }unchecked;
        */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FcMatrix {
        public double XX;
        public double XY;
        public double YX;
        public double YY;
    }


}


