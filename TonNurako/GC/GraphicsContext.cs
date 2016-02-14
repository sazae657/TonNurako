//
// ﾄﾝﾇﾗｺ
//
// GC
//
using System;
using TonNurako.Native.Xt;

namespace TonNurako.GC
{
    public interface IDrawable {
        IntPtr DrawableHandle {
            get;
        }
        IntPtr DisplayHandle {
            get;
        }
    }

	/// <summary>
	/// GC
	/// </summary>
	public class GraphicsContext : IDisposable
	{
		#region ｲﾝｽﾀﾝｽ変数

		//作成したGCが入る
		private IntPtr gcContext = IntPtr.Zero;

		//Displayが入る
		private IntPtr gcDisplay = IntPtr.Zero;

		//Windowが入る
		private IntPtr gcTarget = IntPtr.Zero;

        private bool isDisposed;

		#endregion

		#region ｺﾝｽﾄﾗｸﾀー
        /*
		/// <summary>
		/// Widgetに従ったGCの作成
		/// </summary>
		/// <param name="w">GCの基礎になるWidget</param>
		public GraphicsContext(IWidget w )
		{
			//Display取得
			gcDisplay = XtCall.XtDisplay( w );

			//Window取得
			gcTarget = XtCall.XtWindow( w );

			//
			// 単純なGCを生成
			// 属性は後でｾｯﾄさせる
			//
            gcContext = Native.X11.X11Call.XCreateGC( gcDisplay ,
				gcTarget, IntPtr.Zero, IntPtr.Zero );
		}*/


		/// <summary>
		/// Widgetに従ったGCの作成
		/// </summary>
		/// <param name="w">GCの基礎になるWidget</param>
		public GraphicsContext(IDrawable w )
		{
            isDisposed = false;

            //Display取得
            gcDisplay = w.DisplayHandle;

			//Window取得
			gcTarget = w.DrawableHandle;

			//
			// 単純なGCを生成
			// 属性は後でｾｯﾄさせる
			//
            IntPtr ow;
            gcContext = Native.X11.X11Sports.XCreateGC( gcDisplay ,
				gcTarget, 0, out ow );
		}

		#endregion

		#region IDisposable ﾒﾝﾊﾞ

        /// <summary>
        /// GCの後始末
        /// </summary>
		public void Dispose()
		{
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(isDisposed) {
                return;
            }

            //GC解放
            if (gcContext != IntPtr.Zero) {
                Native.X11.X11Sports.XFreeGC(gcDisplay, gcContext);

                gcContext = IntPtr.Zero;

#if _DEBUG
				System.Diagnostics.Debug.WriteLine("GC : Dispose");
#endif
            }
            isDisposed = true;
        }

        #endregion

        #region ｸﾘｱ

        /// <summary>
        /// 表示内容のｸﾘｱ
        /// </summary>
        public void Clear()
		{
			if( gcContext != IntPtr.Zero )
			{
				Native.X11.X11Sports.XClearWindow(gcDisplay, gcTarget );
			}
		}

        public void SetForeground(XColor color) {
            if (gcContext == IntPtr.Zero) {
                return;
            }
            Native.X11.X11Sports.XSetForeground(gcDisplay, gcContext, color.pixel);
        }

        public void CopyArea(IDrawable dest, int x, int y, int w, int h, int dx, int dy) {
            if (gcContext == IntPtr.Zero) {
                return;
            }
            Native.X11.X11Sports.XCopyArea(gcDisplay,
                gcTarget, dest.DrawableHandle,
                this.gcContext,
                x, y, (uint)w, (uint)h,
                dx, dy);
        }

		#endregion

		#region 図形描画

		/// <summary>
		/// 点を描画する
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		public void DrawPoint( int x, int y )
		{
			if( gcContext != IntPtr.Zero )
			{
				Native.X11.X11Sports.XDrawPoint( gcDisplay, gcTarget, gcContext, x, y );
			}
		}
		/// <summary>
		/// 複数の点を描画する
		/// </summary>
		/// <param name="points">点の座標定義</param>
		/// <param name="mode">点の座標指定ﾓーﾄﾞ</param>
		public void DrawPoints( TonNurako.Native.X11.XPoint [] points, TonNurako.Native.X11.CoordMode mode )
		{
			if( gcContext != IntPtr.Zero )
			{
				Native.X11.X11Sports.XDrawPoints( gcDisplay, gcTarget, gcContext, points, points.Length, (int)mode );
			}

		}

		/// <summary>
		/// 直線の描画
		/// </summary>
		/// <param name="ax">始点X座標</param>
		/// <param name="ay">始点Y座標</param>
		/// <param name="fx">終点X座標</param>
		/// <param name="fy">終点Y座標</param>
		public void DrawLine( int ax, int ay, int fx, int fy )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawLine( gcDisplay, gcTarget, gcContext, ax, ay, fx, fy );
			}
		}

		/// <summary>
		/// 折れ線の描画
		/// </summary>
		/// <param name="points">折れ線の座標定義</param>
		/// <param name="mode">折れ線の座標指定ﾓーﾄﾞ</param>
		public void DrawLines( TonNurako.Native.X11.XPoint [] points, TonNurako.Native.X11.CoordMode mode )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawLines( gcDisplay, gcTarget, gcContext, points, points.Length, (int)mode );
			}

		}

		/// <summary>
		/// 矩形の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		public void DrawRectangle( int x, int y, int w, int h )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawRectangle( gcDisplay, gcTarget, gcContext, x, y, (uint)w, (uint)h );
			}
		}

		/// <summary>
		/// 複数矩形の描画
		/// </summary>
		/// <param name="rects">矩形の定義</param>
		public void DrawRectangle( TonNurako.Native.X11.XRectangle [] rects )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawRectangles( gcDisplay, gcTarget, gcContext, rects, rects.Length );
			}

		}

		/// <summary>
		/// 塗りつぶし矩形の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		public void FillRectangle( int x, int y, int w, int h )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillRectangle( gcDisplay, gcTarget, gcContext, x, y, (uint)w, (uint)h );
			}
		}

		/// <summary>
		/// 複数の塗りつぶし矩形の描画
		/// </summary>
		/// <param name="rects">矩形の定義</param>
		public void FillRectangles( TonNurako.Native.X11.XRectangle [] rects )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillRectangles( gcDisplay, gcTarget, gcContext, rects, rects.Length );
			}

		}

		/// <summary>
		/// 円弧の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		/// <param name="startAngle">開始角(度数*64)</param>
		/// <param name="sweepAngle">角度(度数*64)</param>
		public void DrawArc( int x, int y, int w, int h, int startAngle, int sweepAngle )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawArc( gcDisplay, gcTarget, gcContext,
					x, y, (uint)w, (uint)h, startAngle, sweepAngle );
			}
		}

		/// <summary>
		/// 複数の円弧の描画
		/// </summary>
		/// <param name="arcs">円弧の定義</param>
		public void DrawArcs( TonNurako.Native.X11.XArc [] arcs )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawArcs( gcDisplay, gcTarget, gcContext,
					arcs, arcs.Length );
			}
		}

		/// <summary>
		/// 塗りつぶし円弧の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		/// <param name="startAngle">開始角(度数*64)</param>
		/// <param name="sweepAngle">角度(度数*64)</param>
		public void FillArc( int x, int y, int w, int h, int startAngle, int sweepAngle )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillArc( gcDisplay, gcTarget, gcContext,
					x, y, (uint)w, (uint)h, startAngle, sweepAngle );
			}
		}

		/// <summary>
		/// 複数の塗りつぶし円弧の描画
		/// </summary>
		/// <param name="arcs">円弧の定義</param>
		public void FillArcs( TonNurako.Native.X11.XArc [] arcs )
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillArcs( gcDisplay, gcTarget, gcContext,
					arcs, arcs.Length );
			}
		}

		#endregion

		#region 線の属性
		/// <summary>
		/// 線の属性の設定
		/// </summary>
		/// <param name="w">幅</param>
		/// <param name="line">線の形状</param>
		/// <param name="cap">端の形状</param>
		/// <param name="join">接合方法</param>
		public void SetLineAttributes( uint w, TonNurako.Native.X11.LineStyle line,
                TonNurako.Native.X11.CapStyle cap,
                TonNurako.Native.X11.JoinStyle join)
		{
			if( gcContext != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XSetLineAttributes( gcDisplay, gcContext,
					w, (int)line, (int)cap, (int)join );
			}
		}
		#endregion

	}
}
