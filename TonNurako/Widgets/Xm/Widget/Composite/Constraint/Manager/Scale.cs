//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Scale
	/// </summary>
	public class Scale : Manager, IDefectiveWidget
	{

		#region 生成

		public Scale() : base() {
            ScaleEventTable =  new TnkXtEvents<Events.ScaleEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// Scale生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateScale, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// <summary>
        /// XmNdecimalPoints XmCDecimalPoints short 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DecimalPoints {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNdecimalPoints, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNdecimalPoints, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNeditable XmCEditable Boolean True CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Editable {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNeditable, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNeditable, value, Data.Resource.Access.CSG);
            }
        }

        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Core

        /// <summary>
        ///  XmNhighlightOnEnter XmCHighlightOnEnter Boolean False CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool HighlightOnEnter {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNhighlightOnEnter, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNhighlightOnEnter, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNhighlightThickness XmCHighlightThickness Dimension 2 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HighlightThickness {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNhighlightThickness, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNhighlightThickness, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmaximum XmCMaximum int 100 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Maximum {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmaximum, 100, Data.Resource.Access.CSG);
            }
            set {
             XSports.SetInt(
                  Native.Motif.ResourceId.XmNmaximum, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminimum XmCMinimum int 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Minimum {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNminimum, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                  Native.Motif.ResourceId.XmNminimum, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNorientation XmCOrientation unsigned char XmVERTICAL CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(
                Native.Motif.ResourceId.XmNorientation, Orientation.Vertical, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<Orientation>(
                    Native.Motif.ResourceId.XmNorientation, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNprocessingDirection XmCProcessingDirection unsigned char dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ProcessingDirection ProcessingDirection {
            get {
                return XSports.GetValue<ProcessingDirection>(
                    Native.Motif.ResourceId.XmNprocessingDirection, ProcessingDirection.Left, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ProcessingDirection>(
                    Native.Motif.ResourceId.XmNprocessingDirection, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNscaleHeight XmCScaleHeight Dimension 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScaleHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNscaleHeight, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNscaleHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNscaleMultiple XmCScaleMultiple int dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScaleMultiple {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNscaleMultiple, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNscaleMultiple, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNscaleWidth XmCScaleWidth Dimension 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScaleWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNscaleWidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNscaleWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable RenderTable {
            get {
                return XSports.GetRenderTable(
                    Native.Motif.ResourceId.XmNrenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    Native.Motif.ResourceId.XmNrenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNshowArrows XmCShowArrows XtEnum XmNONE CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShowArrows ShowArrows {
            get {
                return XSports.GetValue<ShowArrows>(
                Native.Motif.ResourceId.XmNshowArrows, ShowArrows.None, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<ShowArrows>(
                Native.Motif.ResourceId.XmNshowArrows, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNshowValue XmCShowValue XtEnum XmNONE CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShowValuePosition ShowValue {
            get {
                return XSports.GetValue<ShowValuePosition>(
                    Native.Motif.ResourceId.XmNshowValue, ShowValuePosition.None, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ShowValuePosition>(
                    Native.Motif.ResourceId.XmNshowValue, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsliderMark XmCSliderMark XtEnum dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderMark SliderMark {
            get {
                return XSports.GetValue<SliderMark>(
                    Native.Motif.ResourceId.XmNsliderMark, SliderMark.EtchedLine, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<SliderMark>(
                    Native.Motif.ResourceId.XmNsliderMark, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsliderVisual XmCSliderVisual XtEnum dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderVisual SliderVisual {
            get {
                return XSports.GetValue<SliderVisual>(
                Native.Motif.ResourceId.XmNsliderVisual, SliderVisual.BackgroundColor, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<SliderVisual>(
                    Native.Motif.ResourceId.XmNsliderVisual, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNslidingMode XmCSlidingMode XtEnum XmSLIDER CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SlidingMode SlidingMode {
            get {
                return XSports.GetValue<SlidingMode>(
                Native.Motif.ResourceId.XmNslidingMode, SlidingMode.Slider, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<SlidingMode>(
                Native.Motif.ResourceId.XmNslidingMode, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNtitleString XmCTitleString XmString NULL CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string TitleString {
            get {
                return XSports.GetString(
                Native.Motif.ResourceId.XmNtitleString, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                Native.Motif.ResourceId.XmNtitleString, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNvalue XmCValue int dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Value {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNvalue, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNvalue, value, Data.Resource.Access.CSG);
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄ
        TnkXtEvents<Events.ScaleEventArgs> ScaleEventTable {
            get;
        }

        /// <summary>
        /// XmNconvertCallback
        /// </summary>
        public virtual event EventHandler<Events.ScaleEventArgs> ConvertEvent
        {
            add {
                ScaleEventTable.AddHandler(this, Native.Motif.EventId.XmNconvertCallback ,  value );
            }
            remove {
                ScaleEventTable.RemoveHandler(Native.Motif.EventId.XmNconvertCallback ,  value );
            }
        }

        /// <summary>
        /// XmNdragCallback
        /// </summary>
        public virtual event EventHandler<Events.ScaleEventArgs> DragEvent
        {
            add {
                ScaleEventTable.AddHandler(this, Native.Motif.EventId.XmNdragCallback ,  value );
            }
            remove {
                ScaleEventTable.RemoveHandler(Native.Motif.EventId.XmNdragCallback ,  value );
            }
        }

        /// <summary>
        /// XmNvalueChangedCallback
        /// </summary>
        public virtual event EventHandler<Events.ScaleEventArgs> ValueChangedEvent
        {
            add {
                ScaleEventTable.AddHandler(this, Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                ScaleEventTable.RemoveHandler(Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
