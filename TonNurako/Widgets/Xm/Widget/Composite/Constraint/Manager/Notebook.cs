using System;

namespace TonNurako.Widgets.Xm
{

    public enum NotebookChildType : byte{
        Page = Native.Motif.Constant.XmPAGE,
        MajorTab = Native.Motif.Constant.XmMAJOR_TAB,
        MinorTab = Native.Motif.Constant.XmMINOR_TAB,
        StatusArea = Native.Motif.Constant.XmSTATUS_AREA,
        PageScroller = Native.Motif.Constant.XmPAGE_SCROLLER
    }

    public enum BackPagePlacement : byte{
        TopLeft  = Native.Motif.Constant.XmTOP_LEFT,
        BottomLeft = Native.Motif.Constant.XmBOTTOM_LEFT,
        TopRight = Native.Motif.Constant.XmTOP_RIGHT,
        BottomRight = Native.Motif.Constant.XmBOTTOM_RIGHT,
    }

    public enum NotebookBindingType : byte {
        None = Native.Motif.Constant.XmNONE,
        Solid = Native.Motif.Constant.XmSOLID,
        Spiral= Native.Motif.Constant.XmSPIRAL,
        Pixmap = Native.Motif.Constant.XmPIXMAP,
        PixmapOverlapOnly = Native.Motif.Constant.XmPIXMAP_OVERLAP_ONLY
    }

	/// <summary>
	/// Notebook (XmNotebook.txt)
	/// </summary>
	public class Notebook : Manager, IDefectiveWidget
	{

		#region 生成

		public Notebook() : base() {
            NotebookEventTable = new TnkXtEvents<Events.NotebookEventArgs> ();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// Notebook生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateNotebook, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// <summary>
        /// XmNbackPageBackground XmCBackPageBackground Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color BackPageBackground {
            get {
                return XSports.GetColor(
                Native.Motif.ResourceId.XmNbackPageBackground, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                Native.Motif.ResourceId.XmNbackPageBackground, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPageForeground XmCBackPageForeground Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color BackPageForeground {
            get {
                return XSports.GetColor(
                Native.Motif.ResourceId.XmNbackPageForeground, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                Native.Motif.ResourceId.XmNbackPageForeground, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPageNumber XmCBackPageNumber Cardinal 2 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BackPageNumber {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNbackPageNumber, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNbackPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPagePlacement XmCBackPagePlacement unsigned char dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual BackPagePlacement BackPagePlacement {
            get {
                return XSports.GetValue<BackPagePlacement>(
                Native.Motif.ResourceId.XmNbackPagePlacement, BackPagePlacement.TopLeft, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<BackPagePlacement>(
                Native.Motif.ResourceId.XmNbackPagePlacement, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPageSize XmCBackPageSize Dimension 8 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BackPageSize {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNbackPageSize, 8, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNbackPageSize, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbindingPixmap XmCBindingPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap BindingPixmap {
            get {
                return XSports.GetPixmap(
                Native.Motif.ResourceId.XmNbindingPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                Native.Motif.ResourceId.XmNbindingPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbindingType XmCBindingType unsigned char XmSPIRAL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual NotebookBindingType BindingType {
            get {
                return XSports.GetValue<NotebookBindingType>(
                Native.Motif.ResourceId.XmNbindingType, NotebookBindingType.Spiral, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<NotebookBindingType>(
                Native.Motif.ResourceId.XmNbindingType, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbindingWidth XmCBindingWidth Dimension 25 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BindingWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNbindingWidth, 25, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNbindingWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNcurrentPageNumber XmCCurrentPageNumber int dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int CurrentPageNumber {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNcurrentPageNumber, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNcurrentPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNfirstPageNumber XmCFirstPageNumber int 1 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int FirstPageNumber {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNfirstPageNumber, 1, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNfirstPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNframeBackground XmCFrameBackground Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color FrameBackground {
            get {
                return XSports.GetColor(
                Native.Motif.ResourceId.XmNframeBackground, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                Native.Motif.ResourceId.XmNframeBackground, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNframeShadowThickness XmCShadowThickness Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int FrameShadowThickness {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNframeShadowThickness, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNframeShadowThickness, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNinnerMarginHeight XmCInnerMarginHeight Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int InnerMarginHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNinnerMarginHeight, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNinnerMarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNinnerMarginWidth XmCInnerMarginWidth Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int InnerMarginWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNinnerMarginWidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNinnerMarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlastPageNumber XmCLastPageNumber int dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int LastPageNumber {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNlastPageNumber, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNlastPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminorTabSpacing XmCMinorTabSpacing Dimension 3 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinorTabSpacing {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNminorTabSpacing, 3, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNminorTabSpacing, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmajorTabSpacing XmCMajorTabSpacing Dimension 3 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MajorTabSpacing {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmajorTabSpacing, 3, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmajorTabSpacing, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNorientation XmCOrientation unsigned char XmHORIZONTAL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(
                Native.Motif.ResourceId.XmNorientation, Orientation.Horizontal, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<Orientation>(
                Native.Motif.ResourceId.XmNorientation, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ
        internal TnkXtEvents<Events.NotebookEventArgs> NotebookEventTable {
            get;
        }

        /// <summary>
        /// XmNpageChangedCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.NotebookEventArgs> PageChangedEvent
        {
            add {
                NotebookEventTable.AddHandler(this, Native.Motif.EventId.XmNpageChangedCallback ,  value );
            }
            remove {
                NotebookEventTable.RemoveHandler(Native.Motif.EventId.XmNpageChangedCallback ,  value );
            }
        }

		#endregion

	}
}
