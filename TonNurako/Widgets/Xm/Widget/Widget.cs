//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Native;
using TonNurako.Native.Xt;
using TonNurako.Events;
using TonNurako.GC;
using TonNurako.Data;
using TonNurako.Data.Resource;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// RectObj相当
    /// </summary>
    public abstract class Widget : WidgetBase, Widgets.IChild, GC.IDrawable
    {

		//親Widget
		private IWidget parentWidget = null;

		//ﾌﾟﾛﾊﾟﾃｨの値
		private WidgetProperties prop = null;
        
        // ﾄﾞﾛﾜﾎﾞー
        protected Drawable drawable;

		public Widget() : base() {
			prop = new WidgetProperties();
            drawable = new Drawable();
            InitializeConstraint();
            InitializeBase();
        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();

			this.Name = Application.CreateTempName(this.GetType().Name);
			InitProperties();
        }

		/// <summary>
		/// 子ｳｲｼﾞｪｯﾄの作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public virtual int Create(IWidget parent )
		{
            System.Diagnostics.Debug.WriteLine($"Create: {this.ToString()}:{this.GetHashCode()} Parent:{parent.ToString()}:{parent.GetHashCode()}");

			//親ｳｲｼﾞｪｯﾄのｲﾝｽﾀﾝｽを保持
            parentWidget = parent;

            // AppContextの参照保持
            AppContext = parent.AppContext;

			//作成用ﾘｿーｽのｸﾘｱ
			ToolkitResources.Clear();
            
			//ｺーﾙﾊﾞｯｸを追加
            CallbackQueue.Apply();
            XEventQueue.Apply();

			//Loadｲﾍﾞﾝﾄを通知
			UIeventTable.CallHandler(TonNuraEventId.WidgetCreated, this);
            
            // 名前解決ﾃーﾌﾞﾙに追加
            if (null != AppContext) {
                AppContext.RegisterWidget(this);
            }

			foreach(IChild c in this.Children) {
				c.Create( this );
			}
            // WidgetNowAvailable通知
            OnWidgetNowAvailable(new TnkWidgetEventArgs(this));

			ToolkitResources.Clear();

			return 0;
		}


		#region 子ｳｲｼﾞｪｯﾄ管理
		/// <summary>
		/// 子を全員ﾏﾈーｼﾞする
		/// </summary>
		public override void ManageChildren()
		{
			//残りﾘｿーｽを全て適用
			ToolkitResources.SetWidget(true );

			if( this.Visible == true ) {
                if (true == this.AllowAutoManage && ! this.IsManaged) {
                    System.Diagnostics.Debug.WriteLine($"XtManageChild:{this.GetType()}");
                    Native.Xt.XtSports.XtManageChild(this);
                    OnWidgetManaged(new TnkWidgetEventArgs(this));
                }
			}

			foreach(IChild c in this.Children.GetCreationList()) {
				c.ManageChildren();
			}
		}

		/// <summary>
		/// 子をﾃﾞｽﾄﾛｲする
		/// </summary>
		public override void DestroyChildren()
		{
			//残りﾘｿーｽを全て適用
			foreach(IChild c in this.Children.GetCreationList()) {
				c.DestroyChildren();
                //TODO: ｷﾓい
                ((Widget)c).DestroyInternal();
			}
            this.Children.RemoveAll();
		}

        internal void DestroyInternal() {
            // 名前解決ﾃーﾌﾞﾙから削除
            if (null != AppContext) {
                AppContext.UnregisterWidget(this);
            }
            base.Destroy();
        }

		/// <summary>
		/// 子ｳｲｼﾞｪｯﾄを破壊
		/// </summary>
		public override void Destroy()
		{
            // 名前解決ﾃーﾌﾞﾙから削除
            if (null != AppContext) {
                AppContext.UnregisterWidget(this);
            }

			base.Destroy();
			//管理対象から削除
            if(null != Parent) {
                Parent.Children.Remove( this );
            }
		}
        #endregion

        #region IDisposable
        protected override void Dispose(bool disposing)
        {
            CallbackQueue.RemoveAlll();
            XEventQueue.RemoveAll();
            base.Dispose(disposing);
        }
        #endregion



        #region Properties 定義

        /// <summary>
        /// ﾌﾟﾛﾊﾟﾃｨの値を管理する
        /// </summary>
        internal class WidgetProperties
		{
			// 可視/不可視
			public bool visible = true;

			//入力を受け付けるか否か
			public bool Sensitive = true;

		}

        /// <summary>
        /// ﾌﾟﾛﾊﾟﾃｨの値を初期化
        /// </summary>
		protected override void InitProperties()
		{
            base.InitProperties();
		}


		/// <summary>
		/// 境界線の幅
		/// </summary>
        [SportyResource(Access.CSG)]
		public virtual int BorderWidth
		{
			get
			{
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNborderWidth, 2, Data.Resource.Access.CSG);
			}
			set
			{
                XSports.SetInt(Native.Motif.ResourceId.XmNborderWidth, value);
			}
		}
		/// <summary>
		/// 幅と高さ
		/// </summary>
        [SportyResource(Access.CSG)]
        public virtual int Width
		{
			get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNwidth, 0);
			}
			set {
                XSports.SetInt(Native.Motif.ResourceId.XmNwidth, value);
			}
		}
        /// <summary>
        /// 幅と高さ
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int Height
		{
			get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNheight, 0);
			}
			set {
                XSports.SetInt(Native.Motif.ResourceId.XmNheight, value);
			}
		}

        [SportyResource(Access.CSG)]
        public virtual int X {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNx, (int)0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNx, value);
            }
        }

        [SportyResource(Access.CSG)]
        public virtual int Y {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNy, (int)0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNy, value);
            }
        }
        /// <summary>
        /// 入力を受け付けるか否か
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual bool Sensitive
		{
			get
			{
				return prop.Sensitive;
			}
			set
			{
				prop.Sensitive = value;
				XSports.SetBool(Native.Motif.ResourceId.XmNsensitive, value);
			}

		}

        /// <summary>
        /// 可視/不可視
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual bool Visible
		{
			get
			{
                //if (IsAvailable) {
                //    prop.visible = Native.Xt.XtCall.XtIsManaged(this);
               // }
				return prop.visible;
			}
			set
			{
                if (! IsAvailable) {
                    prop.visible = value;
                    return;
                }

				//if (value !=  Native.Xt.XtCall.XtIsManaged(this)) {
                    if( value == true ) {
                        Native.Xt.XtSports.XtManageChild(this);
                    }
                    else {
                        Native.Xt.XtSports.XtUnmanageChild(this);
                    }
					prop.visible = value;
				//}
			}
		}

        #region ﾚｲｱｳﾄ(ﾀﾞｻい)
        /// <summary>
        /// XmNbottomAttachment
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual AttachmentType BottomAttachment {
            get {
                return XSports.GetValue<AttachmentType>(Native.Motif.ResourceId.XmNbottomAttachment, AttachmentType.None);
            }
            set {
                XSports.SetValue<AttachmentType>(Native.Motif.ResourceId.XmNbottomAttachment, value);
            }
        }

        /// <summary>
        /// XmNbottomOffset XmCOffset int 0 CSG
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int BottomOffset {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNbottomOffset, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNbottomOffset, value);
            }
        }

        /// <summary>
        /// XmNbottomPosition
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int BottomPosition {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNbottomPosition, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNbottomPosition, value);
            }
        }

        /// <summary>
        /// XmNbottomWidget
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual IWidget BottomWidget {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNbottomWidget);
            }
            set {
                XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNbottomWidget, value);
            }
        }

        /// <summary>
        /// XmNleftAttachment
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual AttachmentType LeftAttachment {
            get {
                return XSports.GetValue<AttachmentType>(Native.Motif.ResourceId.XmNleftAttachment, AttachmentType.None);
            }
            set {
            XSports.SetValue<AttachmentType>(Native.Motif.ResourceId.XmNleftAttachment, value);
            }
        }

        /// <summary>
        /// XmNleftOffset
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int LeftOffset {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNleftOffset, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNleftOffset, value);
            }
        }

        /// <summary>
        /// XmNleftPosition
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int LeftPosition {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNleftPosition, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNleftPosition, value);
            }
        }

        /// <summary>
        /// XmNleftWidget
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual IWidget LeftWidget {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNleftWidget);
            }
            set {
                XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNleftWidget, value);
            }
        }

        /// <summary>
        /// XmNresizable
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual bool Resizable {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNresizable, true);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNresizable, value);
            }
        }

        /// <summary>
        /// XmNrightAttachment
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual AttachmentType RightAttachment {
            get {
                return XSports.GetValue<AttachmentType>(Native.Motif.ResourceId.XmNrightAttachment, AttachmentType.None);
            }
            set {
                XSports.SetValue<AttachmentType>(Native.Motif.ResourceId.XmNrightAttachment, value);
            }
        }

        /// <summary>
        /// XmNrightOffset
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int RightOffset {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNrightOffset, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNrightOffset, value);
            }
        }

        /// <summary>
        /// XmNrightPosition
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int RightPosition {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNrightPosition, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNrightPosition, value);
            }
        }

        /// <summary>
        /// XmNrightWidget
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual IWidget RightWidget {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNrightWidget);
            }
            set {
                XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNrightWidget, value);
            }
        }

        /// <summary>
        /// XmNtopAttachment
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual AttachmentType TopAttachment {
            get {
                return XSports.GetValue<AttachmentType>(Native.Motif.ResourceId.XmNtopAttachment, AttachmentType.None);
            }
            set {
                XSports.SetValue<AttachmentType>(Native.Motif.ResourceId.XmNtopAttachment, value);
            }
        }

        /// <summary>
        /// XmNtopOffset
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int TopOffset {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtopOffset, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNtopOffset, value);
            }
        }

        /// <summary>
        /// XmNtopPosition
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual int TopPosition {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtopPosition, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNtopPosition, value);
            }
        }

        /// <summary>
        /// XmNtopWidget
        /// </summary>
        [SportyResource(Access.CSG)]
        public virtual IWidget TopWidget {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNtopWidget);
            }
            set {
                XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNtopWidget, value);
            }
        }
        #endregion

		/// <summary>
		/// 色深度の取得
		/// </summary>
        [SportyResource(Access.CG)]
		public int ColorDepth
		{
			get
			{
                return XSports.GetInt(Native.Motif.ResourceId.XmNdepth, 0, Data.Resource.Access.CG);
			}

		}

		/// <summary>
		/// 親ｳｲｼﾞｪｯﾄ
		/// </summary>
		public IWidget Parent
		{
			get
			{
				return parentWidget;
			}

		}

        #endregion

		#region Constraint

		/// <summary>
		/// ﾃﾞﾌｫﾙﾄｺﾝｽﾄﾗｸﾀ
		/// </summary>
		internal void InitializeConstraint()
		{
            TabStackConstraint = new TabStackConstraint(this);
            FrameConstraint = new FrameConstraint(this);
            PanedConstraint = new PanedConstraint(this);
            PanedWindowConstraint = new PanedWindowConstraint(this);
            HierarchyConstraint = new HierarchyConstraint(this);
            RowColumnConstraint = new RowColumnConstraint(this);
		}


		/// <summary>
		/// TabStack用
		/// </summary>
        public TabStackConstraint TabStackConstraint {
            get; private set;
        }

        /// <summary>
		/// Frame用
		/// </summary>
        public FrameConstraint FrameConstraint {
            get;  private set;
        }


        /// <summary>
		/// Paned用
		/// </summary>
        public PanedConstraint PanedConstraint {
            get; private set;
        }

        /// <summary>
		/// PanedWindow用
		/// </summary>
        public PanedWindowConstraint PanedWindowConstraint {
            get; private set;
        }

        /// <summary>
        /// Hierarchy用
        /// </summary>
        public HierarchyConstraint HierarchyConstraint {
            get; private set;
        }

        /// <summary>
        /// RowColumn用
        /// </summary>
        public RowColumnConstraint RowColumnConstraint {
            get; private set;
        }

        public Drawable Drawable
        {
            get
            {
                // ﾄﾞﾛﾜﾎﾞー
                this.drawable.Display = NativeHandle.Display;
                this.drawable.Target = NativeHandle.Window;                
                return this.drawable;
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄ

        /// <summary>
        /// 破壊後に呼ばれる
        /// </summary>
        public override event EventHandler<Events.TnkEventArgs> DestroyEvent
		{
			add
			{
				if (! UIeventTable.HasHandler(TonNuraEventId.Destroyed))
				{
					CallbackQueue.AddXtCallback( Native.Motif.EventId.XmNdestroyCallback,
						new G.XtCallBack( this.NdestroyCallback ) );
				}

				base.DestroyEvent += value;
			}
			remove
			{
				base.DestroyEvent -= value;
			}
		}



		#endregion

		#region ｺーﾙﾊﾞｯｸ

        /// <summary>
        /// XmNdestroyCallbackで呼ばれる
        /// </summary>
		internal virtual void NdestroyCallback( IntPtr w, IntPtr client, IntPtr call )
		{
			//Destroyedｲﾍﾞﾝﾄが通知可能な場合は通知
			UIeventTable.CallHandler(TonNuraEventId.Destroyed, this);
		}


		#endregion
    }
}
