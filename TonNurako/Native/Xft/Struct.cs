using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.Xft
{
#if XFT
    struct XftFont {
        int         ascent;
        int         descent;
        int         height;
        int         max_advance_width;
        IntPtr   charset; // FcCharSet*
        IntPtr   pattern; //FcPattern*
    }
 /*struct XftColor {
    ulong   pixel;
    XRenderColor    color;
} ;*/

 struct XftCharSpec {
    uint    ucs4;//FcChar32
    short       x;
    short       y;
}

 struct XftCharFontSpec {
    IntPtr     font; //XftFont*
    uint    ucs4; //FcChar32
    short       x;
    short       y;
}

 struct XftGlyphSpec {
    uint     glyph; //FT_UInt
    short       x;
    short       y;
}
 struct XftGlyphFontSpec {
    IntPtr      font; //XftFont*
    uint     glyph; //FT_UInt
    short       x;
    short       y;
}
#endif
}


