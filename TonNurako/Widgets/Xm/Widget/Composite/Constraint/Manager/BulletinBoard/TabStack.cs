//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Events;

namespace TonNurako.Widgets.Xm
{

	/// <summary>
	/// TabStack
	/// </summary>
	public class TabStack : BulletinBoard
	{

		#region 生成

		public TabStack()  : base()
		{
            TabStackEventTable = new TnkXtEvents<TabStackEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// TabStack
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create( IWidget parent )
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateTabStack, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion

        #region prop
        /*
        XmTabStack Resource Set
        */

        // XmNfontList XmCFontList XmFontList Dynamic CSG
        // -> Coreで定義

        /// XmNhighlightThickness XmCHighlightThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HighlightThickness {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNhighlightThickness, 2);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNhighlightThickness, value);
            }
        }


        /// XmNstackedEffect XmCStackedEffect Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool StackedEffect {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNstackedEffect, true);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNstackedEffect, value);
            }
        }


        /// XmNtabAutoSelect XmCTabAutoSelect Boolean True CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool TabAutoSelect {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNtabAutoSelect, true, Data.Resource.Access.CG);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNtabAutoSelect, value, Data.Resource.Access.CG);
            }
        }


        /// XmNtabCornerPercent XmCTabCornerPercent int 40 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TabCornerPercent {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtabCornerPercent, 40);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNtabCornerPercent, value);
            }
        }


        /// XmNtabLabelSpacing XmCTabLabelSpacing Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TabLabelSpacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtabLabelSpacing, 2);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNtabLabelSpacing, value);
            }
        }


        /// XmNtabMarginHeight XmCTabMarginHeight Dimension 3 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TabMarginHeight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtabMarginHeight, 3);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNtabMarginHeight, value);
            }
        }


        /// XmNtabMarginWidth XmCTabMarginWidth Dimension 3 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TabMarginWidth {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtabMarginWidth, 3);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNtabMarginWidth, value);
            }
        }


        /// XmNtabMode XmCTabMode int XmTABS_BASIC CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual TabMode TabMode {
            get {
                return XSports.GetValue<TabMode>(Native.Motif.ResourceId.XmNtabMode, TabMode.Basic);
            }
            set {
                XSports.SetValue<TabMode>(Native.Motif.ResourceId.XmNtabMode, value);
            }
        }


        /// XmNtabOffset XmCTabOffset Dimension 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TabOffset {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtabOffset, 10);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNtabOffset, value);
            }
        }


        /// XmNtabOrientation XmCTabOrientation int Dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual TabOrientation TabOrientation {
            get {
                return XSports.GetValue<TabOrientation>(Native.Motif.ResourceId.XmNtabOrientation, TabOrientation.Dynamic);
            }
            set {
                XSports.SetValue<TabOrientation>(Native.Motif.ResourceId.XmNtabOrientation, value);
            }
        }


        /// XmNtabSelectColor XmCTabSelectColor Pixel Dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color TabSelectColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNtabSelectColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNtabSelectColor, value);
            }
        }


        /// XmNtabSelectPixmap XmCTabSelectPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap TabSelectPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNtabSelectPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNtabSelectPixmap, value);
            }
        }


        /// XmNtabSide XmCTabSide int XmTABS_ON_TOP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual TabSide TabSide {
            get {
                return XSports.GetValue<TabSide>(Native.Motif.ResourceId.XmNtabSide, TabSide.Top);
            }
            set {
                XSports.SetValue<TabSide>(Native.Motif.ResourceId.XmNtabSide, value);
            }
        }


        /// XmNtabStyle XmCTabStyle int XmTABS_BEVELED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual TabStyle TabStyle {
            get {
                return XSports.GetValue<TabStyle>(Native.Motif.ResourceId.XmNtabStyle,  TabStyle.Beveled);
            }
            set {
                XSports.SetValue<TabStyle>(Native.Motif.ResourceId.XmNtabStyle, value);
            }
        }


        /// XmNuniformTabSize XmCUniformTabSize Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool UniformTabSize {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNuniformTabSize, true);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNuniformTabSize, value);
            }
        }


        /// XmNuseImageCache XmCUseImageCache Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool UseImageCache {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNuseImageCache, true);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNuseImageCache, value);
            }
        }


        TnkXtEvents<TabStackEventArgs> TabStackEventTable {
            get;
        }

        /// XmNtabSelectedCallback XmCCallback XtCallbackList NULL CS
        public virtual event EventHandler<TabStackEventArgs> TabSelectedEvent
        {
            add {
                TabStackEventTable.AddHandler(this, Native.Motif.EventId.XmNtabSelectedCallback ,  value );
            }
            remove {
                TabStackEventTable.RemoveHandler(Native.Motif.EventId.XmNtabSelectedCallback ,  value );
            }
        }



        #endregion

	}
}
