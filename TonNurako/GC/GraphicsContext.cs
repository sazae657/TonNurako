//
// ﾄﾝﾇﾗｺ
//
// GC
//
using System;
using TonNurako.Native.Xt;

namespace TonNurako.GC
{
    /// <summary>
    /// ﾄﾞﾛﾜﾎﾞー
    /// </summary>
    public interface IDrawable {
        /// <summary>
        /// ﾄﾞﾛﾜﾎﾞー
        /// </summary>
        Drawable Drawable{get;}
    }

    /// <summary>
    /// ﾄﾞﾛﾜﾎﾞー
    /// </summary>
    public class Drawable {
        /// <summary>
        /// ﾀーｹﾞｯﾄ(Window or Pixmap)
        /// </summary>
        internal IntPtr Target { get; set; }

        /// <summary>
        /// ﾃﾞｽﾌﾟﾚー
        /// </summary>
        internal IntPtr Display { get; set; }

        /// <summary>
        /// ｽｸﾘーﾝ
        /// </summary>
        internal IntPtr Screen { get; set; }

        public Drawable() {
            Target = IntPtr.Zero;
            Display = IntPtr.Zero;
            Screen = IntPtr.Zero;
        }
    }

	/// <summary>
	/// GC
	/// </summary>
	public class GraphicsContext : IDisposable
	{
		#region ｲﾝｽﾀﾝｽ変数

		//作成したGCが入る
		private IntPtr gc = IntPtr.Zero;

		//Displayが入る
		private IntPtr display = IntPtr.Zero;

		//Windowが入る
		private IntPtr target = IntPtr.Zero;

        private bool disposed;
        
        internal delegate void SysDestroyGC();
        internal SysDestroyGC DestroyGcFunc = null;        

		#endregion

		#region ｺﾝｽﾄﾗｸﾀー
        
        private GraphicsContext() {
            disposed = false;
        }
        
		/// <summary>
		/// 共有GC取得
		/// </summary>
		/// <param name="w">Widget</param>
		public static GraphicsContext FromSharedGC(Widgets.IWidget w)
		{
            var gc = new GraphicsContext();
            
            gc.gc = Native.Xt.XtSports.XtGetGC(w);
            gc.display = w.NativeHandle.Display;
			gc.target = w.NativeHandle.Window;
            gc.DestroyGcFunc = () => {
                //GC解放
                if (gc.gc != IntPtr.Zero) {
                    Native.Xt.XtSports.XtReleaseGC(w, gc.gc);
                    gc.gc = IntPtr.Zero;
                }    
            };            
            return gc;       
		}


		/// <summary>
		/// GCの作成
		/// </summary>
		/// <param name="w">ﾄﾞﾛﾜﾎﾞー</param>
		public GraphicsContext(IDrawable w)
		{
            disposed = false;
            display = w.Drawable.Display;
			target = w.Drawable.Target;
			//
			// 単純なGCを生成
			// 属性は後でｾｯﾄさせる
			//
            gc = Native.X11.X11Sports.XCreateGC( display , target);
            
            DestroyGcFunc = () => {
                //GC解放
                if (gc != IntPtr.Zero) {
                    Native.X11.X11Sports.XFreeGC(display, gc);
                    gc = IntPtr.Zero;
                    System.Diagnostics.Debug.WriteLine("GC : Dispose");
                }          
            };
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

        ~GraphicsContext() {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed) {
                return;
            }
            
            if (null != DestroyGcFunc) {
                DestroyGcFunc();
            }
            disposed = true;
        }

        #endregion

        #region ｸﾘｱ

        /// <summary>
        /// 表示内容のｸﾘｱ
        /// </summary>
        public void Clear()
		{
			if( gc != IntPtr.Zero )
			{
				Native.X11.X11Sports.XClearWindow(display, target );
			}
		}

        public void SetForeground(XColor color) {
            if (gc == IntPtr.Zero) {
                return;
            }
            Native.X11.X11Sports.XSetForeground(display, gc, color.pixel);
        }

        public void SetForeground(TonNurako.Data.Color color) {
            if (gc == IntPtr.Zero) {
                return;
            }
            Native.X11.X11Sports.XSetForeground(display, gc, color.Pixel);
        }
        
        public void CopyArea(IDrawable dest, int x, int y, int w, int h, int dx, int dy) {
            if (gc == IntPtr.Zero) {
                return;
            }
            Native.X11.X11Sports.XCopyArea(display,
                target, dest.Drawable.Target,
                this.gc,
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
			if( gc != IntPtr.Zero )
			{
				Native.X11.X11Sports.XDrawPoint( display, target, gc, x, y );
			}
		}
		/// <summary>
		/// 複数の点を描画する
		/// </summary>
		/// <param name="points">点の座標定義</param>
		/// <param name="mode">点の座標指定ﾓーﾄﾞ</param>
		public void DrawPoints( TonNurako.Native.X11.XPoint [] points, TonNurako.Native.X11.CoordMode mode )
		{
			if( gc != IntPtr.Zero )
			{
				Native.X11.X11Sports.XDrawPoints( display, target, gc, points, points.Length, (int)mode );
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
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawLine( display, target, gc, ax, ay, fx, fy );
			}
		}

		/// <summary>
		/// 折れ線の描画
		/// </summary>
		/// <param name="points">折れ線の座標定義</param>
		/// <param name="mode">折れ線の座標指定ﾓーﾄﾞ</param>
		public void DrawLines( TonNurako.Native.X11.XPoint [] points, TonNurako.Native.X11.CoordMode mode )
		{
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawLines( display, target, gc, points, points.Length, (int)mode );
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
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawRectangle( display, target, gc, x, y, (uint)w, (uint)h );
			}
		}

		/// <summary>
		/// 複数矩形の描画
		/// </summary>
		/// <param name="rects">矩形の定義</param>
		public void DrawRectangle( TonNurako.Native.X11.XRectangle [] rects )
		{
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawRectangles( display, target, gc, rects, rects.Length );
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
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillRectangle( display, target, gc, x, y, (uint)w, (uint)h );
			}
		}

		/// <summary>
		/// 複数の塗りつぶし矩形の描画
		/// </summary>
		/// <param name="rects">矩形の定義</param>
		public void FillRectangles( TonNurako.Native.X11.XRectangle [] rects )
		{
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillRectangles( display, target, gc, rects, rects.Length );
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
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawArc( display, target, gc,
					x, y, (uint)w, (uint)h, startAngle, sweepAngle );
			}
		}

		/// <summary>
		/// 複数の円弧の描画
		/// </summary>
		/// <param name="arcs">円弧の定義</param>
		public void DrawArcs( TonNurako.Native.X11.XArc [] arcs )
		{
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XDrawArcs( display, target, gc,
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
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillArc( display, target, gc,
					x, y, (uint)w, (uint)h, startAngle, sweepAngle );
			}
		}

		/// <summary>
		/// 複数の塗りつぶし円弧の描画
		/// </summary>
		/// <param name="arcs">円弧の定義</param>
		public void FillArcs( TonNurako.Native.X11.XArc [] arcs )
		{
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XFillArcs( display, target, gc,
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
			if( gc != IntPtr.Zero )
			{
				TonNurako.Native.X11.X11Sports.XSetLineAttributes( display, gc,
					w, (int)line, (int)cap, (int)join );
			}
		}
		#endregion

	}
}
