//
// ﾄﾝﾇﾗｺ
//
// Xlibﾗｯﾊﾟー
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Native.X11
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct XCharStruct {
        public Int16 lbearing; // short
        public Int16 rbearing; // short
        public Int16 width; // short
        public Int16 ascent; // short
        public Int16 descent; // short
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XFontProp {
        public ulong name; // Atom
        public ulong card32; // unsigned long
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XChar2b {
        public byte byte1; // unsigned char
        public byte byte2; // unsigned char
    }


	[StructLayout(LayoutKind.Sequential)]
    internal struct XFontStruct {
        public IntPtr ext_data; // XExtData*
        public int fid; // Font
        public uint direction; // unsigned
        public uint min_char_or_byte2; // unsigned
        public uint max_char_or_byte2; // unsigned
        public uint min_byte1; // unsigned
        public uint max_byte1; // unsigned
        [MarshalAs(UnmanagedType.U1)] public bool all_chars_exist; // Bool
        public uint default_char; // unsigned
        public int n_properties; // int
        public IntPtr properties; // XFontProp*
        public TonNurako.Native.X11.XCharStruct min_bounds; // XCharStruct
        public TonNurako.Native.X11.XCharStruct max_bounds; // XCharStruct
        public IntPtr per_char; // XCharStruct*
        public int ascent; // int
        public int descent; // int
    }
}
