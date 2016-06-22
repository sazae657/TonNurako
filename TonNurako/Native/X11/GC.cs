//
// ﾄﾝﾇﾗｺ
//
// Xlibﾗｯﾊﾟー
//

using System.Runtime.InteropServices;

namespace TonNurako.Native.X11
{
	/// <summary>
	/// GCのﾏｽｸ
	/// </summary>
    [System.Flags]
    public enum GCMask : ulong {
        GCFunction   =  (1<<0),
        GCPlaneMask  =  (1<<1),
        GCForeground = (1<<2),
        GCBackground = (1<<3),
        GCLineWidth  = (1<<4),
        GCLineStyle  = (1<<5),
        GCCapStyle   = (1<<6),
        GCJoinStyle  = (1<<7),
        GCFillStyle  = (1<<8),
        GCFillRule   = (1<<9),
        GCTile       = (1<<10),
        GCStipple    = (1<<11),
        GCTileStipXOrigin   =  (1<<12),
        GCTileStipYOrigin   =  (1<<13),
        GCFont              = (1<<14),
        GCSubwindowMode     =  (1<<15),
        GCGraphicsExposures = (1<<16),
        GCClipXOrigin       =  (1<<17),
        GCClipYOrigin       =  (1<<18),
        GCClipMask          = (1<<19),
        GCDashOffset        =  (1<<20),
        GCDashList          = (1<<21),
        GCArcMode           = (1<<22),
        GCLastBit           = 22
    }


	/// <summary>
	/// XGCValues
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
    public struct XGCValues {
        public int function; // int
        public ulong plane_mask; // unsigned long
        public ulong foreground; // unsigned long
        public ulong background; // unsigned long
        public int line_width; // int
        public int line_style; // int
        public int cap_style; // int
        public int join_style; // int
        public int fill_style; // int
        public int fill_rule; // int
        public int arc_mode; // int
        internal System.IntPtr tile; // Pixmap
        internal System.IntPtr stipple; // Pixmap
        public int ts_x_origin; // int
        public int ts_y_origin; // int
        public int font; // Font
        public int subwindow_mode; // int
        public bool graphics_exposures; // Bool
        public int clip_x_origin; // int
        public int clip_y_origin; // int
        internal System.IntPtr clip_mask; // Pixmap
        public int dash_offset; // int
        public byte dashes; // char
    }


	/// <summary>
	/// 点の定義(XPointに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct XPoint
	{
		/// <summary>
		/// X座標
		/// </summary>
        public short x;
		/// <summary>
		/// Y座標
		/// </summary>
		public short y;
        public XPoint(short X, short Y) {
            x = X;
            y = Y;
        }
	}

    [StructLayout(LayoutKind.Sequential)]
    public struct XSegment {
        int noop;
    }

	/// <summary>
	/// 矩形の定義(XRectangleに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct XRectangle
	{
		/// <summary>
		/// 左上角のX座標
		/// </summary>
		public short x;
		/// <summary>
		/// 左上角のY座標
		/// </summary>
		public short y;
		/// <summary>
		/// 幅
		/// </summary>
		public ushort w;
		/// <summary>
		/// 高さ
		/// </summary>
		public ushort h;
	}

	/// <summary>
	/// 円弧の定義(XArcに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct XArc
	{
		/// <summary>
		/// 左上角のX座標
		/// </summary>
		public short x;
		/// <summary>
		/// 左上角のX座標
		/// </summary>
		public short y;
		/// <summary>
		/// 幅
		/// </summary>
		public short w;
		/// <summary>
		/// 高さ
		/// </summary>
		public short h;
		/// <summary>
		/// 開始角
		/// </summary>
		public short  startAngle;
		/// <summary>
		/// 終了角
		/// </summary>
		public short  sweepAngle;
	}


	/// <summary>
	/// 折れ線の座標定義方法
	/// </summary>
	public enum CoordMode
	{
		/// <summary>
		/// 絶対座標
		/// </summary>
		Origin = 0,
		/// <summary>
		/// 相対座標
		/// </summary>
		Previous = 1,
	}

	/// <summary>
	/// 線の終端形状
	/// </summary>
	public enum CapStyle
	{
		/// <summary>
		/// 何もしない
		/// </summary>
		NotLast = 0,
		/// <summary>
		/// 始点と終端で切り落とす
		/// </summary>
		Butt = 1,
		/// <summary>
		/// 始点と終端を半円で閉じる
		/// </summary>
		Round = 2,
		/// <summary>
		/// 始点と終端に線幅の半分だけ突き出す
		/// </summary>
		Projecting = 3,
	}

	/// <summary>
	/// 折れ曲がりの形状
	/// </summary>
	public enum JoinStyle
	{
		/// <summary>
		/// 線分の外縁を延長して公差させる
		/// </summary>
		Miter = 0,
		/// <summary>
		/// 角の外側を丸める
		/// </summary>
		Round = 1,
		/// <summary>
		/// 角の外側を切り落とす
		/// </summary>
		Bevel = 2
	}

	/// <summary>
	/// 線の形状
	/// </summary>
	public enum LineStyle
	{
		/// <summary>
		/// 直線
		/// </summary>
		Solid = 0,
		/// <summary>
		/// 破線
		/// 奇数番目の要素を前景色で描画
		/// </summary>
		OnOffDash = 1,
		/// <summary>
		/// 破線
		/// 奇数番目の要素を前景色で、偶数番目の要素を背景色で描画
		/// </summary>
		DoubleDash = 2
	}

}
