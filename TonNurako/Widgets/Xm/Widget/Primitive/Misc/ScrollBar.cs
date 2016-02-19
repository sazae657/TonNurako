//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    ///
    /// </summary>
    public enum ProcessingDirection{
        Top = Native.Motif.Constant.XmMAX_ON_TOP,
        Bottom = Native.Motif.Constant.XmMAX_ON_BOTTOM,
        Left = Native.Motif.Constant.XmMAX_ON_LEFT,
        Right = Native.Motif.Constant.XmMAX_ON_RIGHT,
    }

    /// <summary>
    ///
    /// </summary>
    public enum ShowArrows {
        None = Native.Motif.Constant.XmNONE,
        EachSide = Native.Motif.Constant.XmEACH_SIDE,
        MaxSide = Native.Motif.Constant.XmMAX_SIDE,
        MinSide = Native.Motif.Constant.XmMIN_SIDE,
    }

    /// <summary>
    ///
    /// </summary>
    public enum SliderMark {
        EtchedLine    = Native.Motif.Constant.XmETCHED_LINE,
        None          = Native.Motif.Constant.XmNONE,
        RoundMark    = Native.Motif.Constant.XmROUND_MARK,
        ThumbMark    = Native.Motif.Constant.XmTHUMB_MARK,

    }

    /// <summary>
    ///
    /// </summary>
    public enum SliderVisual {
        BackgroundColor = Native.Motif.Constant.XmMAX_SIDE,
        ForegroundColor = Native.Motif.Constant.XmMAX_SIDE,
        ShadowedBackground = Native.Motif.Constant.XmMAX_SIDE,
        TroughColor = Native.Motif.Constant.XmMAX_SIDE,
    }

    /// <summary>
    ///
    /// </summary>
    public enum SlidingMode {
        Slider = Native.Motif.Constant.XmSLIDER,
        Thermometer = Native.Motif.Constant.XmTHERMOMETER,
    }

	/// <summary>
	/// ScrollBar
	/// </summary>
	public class ScrollBar : Primitive, IDefectiveWidget
	{
		public ScrollBar() : base()
		{
            ScrollBarEventTable = new TnkXtEvents<Events.ScrollBarEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// ScrollBar生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateScrollBar, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNeditable XmCEditable Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Editable {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNeditable, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNeditable, value);
            }
        }

        /// XmNincrement XmCIncrement int 1 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Increment {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNincrement, 1);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNincrement, value);
            }
        }

        /// XmNinitialDelay XmCInitialDelay int 250 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int InitialDelay {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNinitialDelay, 250);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNinitialDelay, value);
            }
        }

        /// XmNmaximum XmCMaximum int 100 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Maximum {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmaximum, 100);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmaximum, value);
            }
        }

        /// XmNminimum XmCMinimum int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Minimum {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNminimum, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNminimum, value);
            }
        }

        /// XmNorientation XmCOrientation unsigned char XmVERTICAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(Native.Motif.ResourceId.XmNorientation, Orientation.Vertical);
            }
            set {
                XSports.SetValue<Orientation>(Native.Motif.ResourceId.XmNorientation, value);
            }
        }

        /// XmNpageIncrement XmCPageIncrement int 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PageIncrement {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNpageIncrement, 10);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNpageIncrement, value);
            }
        }

        /// XmNprocessingDirection XmCProcessingDirection unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ProcessingDirection ProcessingDirection {
            get {
                return XSports.GetValue<ProcessingDirection>(
                        Native.Motif.ResourceId.XmNprocessingDirection, ProcessingDirection.Bottom);
            }
            set {
                XSports.SetValue<ProcessingDirection>(Native.Motif.ResourceId.XmNprocessingDirection, value);
            }
        }

        /// XmNrepeatDelay XmCRepeatDelay int 50 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int RepeatDelay {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNrepeatDelay, 50);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNrepeatDelay, value);
            }
        }

        /// XmNshowArrows XmCShowArrows XtEnum XmEACH_SIDE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShowArrows ShowArrows {
            get {
                return XSports.GetValue<ShowArrows>(Native.Motif.ResourceId.XmNshowArrows, ShowArrows.EachSide);
            }
            set {
                XSports.SetValue<ShowArrows>(Native.Motif.ResourceId.XmNshowArrows, value);
            }
        }

        /// XmNsliderSize XmCSliderSize int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SliderSize {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNsliderSize, 1);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNsliderSize, value);
            }
        }

        /// XmNsliderMark XmCSliderMark XtEnum dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderMark SliderMark {
            get {
                return XSports.GetValue<SliderMark>(Native.Motif.ResourceId.XmNsliderMark, SliderMark.EtchedLine);
            }
            set {
            XSports.SetValue<SliderMark>(Native.Motif.ResourceId.XmNsliderMark, value);
            }
        }

        /// XmNsliderVisual XmCSliderVisual XtEnum XmSHADOWED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderVisual SliderVisual {
            get {
                return XSports.GetValue<SliderVisual>(Native.Motif.ResourceId.XmNsliderVisual, SliderVisual.ShadowedBackground);
            }
            set {
            XSports.SetValue<SliderVisual>(Native.Motif.ResourceId.XmNsliderVisual, value);
            }
        }

        /// XmNslidingMode XmCSlidingMode XtEnum XmSLIDER CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SlidingMode SlidingMode {
            get {
                return XSports.GetValue<SlidingMode>(Native.Motif.ResourceId.XmNslidingMode, SlidingMode.Slider);
            }
            set {
            XSports.SetValue<SlidingMode>(Native.Motif.ResourceId.XmNslidingMode, value);
            }
        }
        /// XmNsnapBackMultiple XmCSnapBackMultiple unsigned short MaxValue CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SnapBackMultiple {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNsnapBackMultiple, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNsnapBackMultiple, value);
            }
        }

        /// XmNtroughColor XmCTroughColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color TroughColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNtroughColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNtroughColor, value);
            }
        }

        /// XmNvalue XmCValue int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Value {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNvalue, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNvalue, value);
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄ

        TnkXtEvents<Events.ScrollBarEventArgs> ScrollBarEventTable {
            get;
        }

        /// XmNdecrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> DecrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNdecrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNdecrementCallback ,  value );
            }
        }

        /// XmNdragCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> DragEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNdragCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNdragCallback ,  value );
            }
        }

        /// XmNincrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> IncrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNincrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNincrementCallback ,  value );
            }
        }

        /// XmNpageDecrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> PageDecrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNpageDecrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNpageDecrementCallback ,  value );
            }
        }

        /// XmNpageIncrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> PageIncrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNpageIncrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNpageIncrementCallback ,  value );
            }
        }

        /// XmNtoBottomCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> ToBottomEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNtoBottomCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNtoBottomCallback ,  value );
            }
        }

        /// XmNtoTopCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> ToTopEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNtoTopCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNtoTopCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> ValueChangedEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
