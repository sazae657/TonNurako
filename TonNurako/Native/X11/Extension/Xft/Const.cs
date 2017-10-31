using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11.Extension.Xft {
    public enum FcType :int{
        FcTypeUnknown = TonNurako.X11.Constant.FcTypeUnknown,
        FcTypeVoid = TonNurako.X11.Constant.FcTypeVoid,
        FcTypeInteger = TonNurako.X11.Constant.FcTypeInteger,
        FcTypeDouble = TonNurako.X11.Constant.FcTypeDouble,
        FcTypeString = TonNurako.X11.Constant.FcTypeString,
        FcTypeBool = TonNurako.X11.Constant.FcTypeBool,
        FcTypeMatrix = TonNurako.X11.Constant.FcTypeMatrix,
        FcTypeCharSet = TonNurako.X11.Constant.FcTypeCharSet,
        FcTypeFTFace = TonNurako.X11.Constant.FcTypeFTFace,
        FcTypeLangSet = TonNurako.X11.Constant.FcTypeLangSet,
        FcTypeRange = TonNurako.X11.Constant.FcTypeRange,
    }
}
