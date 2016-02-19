//
// ﾄﾝﾇﾗｺ
// 
// Xlibﾗｯﾊﾟー
//
using System;
namespace TonNurako.Native.X11
{
    /// <summary>
    /// ｲﾍﾞﾝﾄﾏｽｸ
    /// </summary>
    [Flags]
    public enum Masks {
        NoEventMask	= 0x0,
        KeyPressMask	= 0x1,
        KeyReleaseMask	= 0x2,
        ButtonPressMask	= 0x4,
        ButtonReleaseMask	= 0x8,
        EnterWindowMask	= 0x10,
        LeaveWindowMask	= 0x20,
        PointerMotionMask	= 0x40,
        PointerMotionHintMask	= 0x80,
        Button1MotionMask	= 0x100,
        Button2MotionMask	= 0x200,
        Button3MotionMask	= 0x400,
        Button4MotionMask	= 0x800,
        Button5MotionMask	= 0x1000,
        ButtonMotionMask	= 0x2000,
        KeymapStateMask	= 0x4000,
        ExposureMask	= 0x8000,
        VisibilityChangeMask	= 0x10000,
        StructureNotifyMask	= 0x20000,
        ResizeRedirectMask	= 0x40000,
        SubstructureNotifyMask	= 0x80000,
        SubstructureRedirectMask	= 0x100000,
        FocusChangeMask	= 0x200000,
        PropertyChangeMask	= 0x400000,
        ColormapChangeMask	= 0x800000,
        OwnerGrabButtonMask	= 0x1000000,
        ShiftMask	= 0x1,
        LockMask	= 0x2,
        ControlMask	= 0x4,
        Mod1Mask	= 0x8,
        Mod2Mask	= 0x10,
        Mod3Mask	= 0x20,
        Mod4Mask	= 0x40,
        Mod5Mask	= 0x80,
        Button1Mask	= 0x100,
        Button2Mask	= 0x200,
        Button3Mask	= 0x400,
        Button4Mask	= 0x800,
        Button5Mask	= 0x1000,
        CWEventMask	= 0x800,
        GCPlaneMask	= 0x2,
        GCClipMask	= 0x80000,
    }
}
