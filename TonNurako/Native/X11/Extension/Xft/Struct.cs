using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.Extension.Xft
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
    

}


