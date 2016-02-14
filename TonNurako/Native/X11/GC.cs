//
// ﾄﾝﾇﾗｺ
// 
// Xlibﾗｯﾊﾟー
//

using System.Runtime.InteropServices;

namespace TonNurako.Native.X11
{
	/// <summary>
	/// 点の定義(XPointに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=4)]
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
	}

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct XSegment {
        int noop;
    }

	/// <summary>
	/// 矩形の定義(XRectangleに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=4)]
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
	[StructLayout(LayoutKind.Sequential, Pack=4)]
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
