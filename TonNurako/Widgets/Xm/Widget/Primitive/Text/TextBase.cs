//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm {

    /// <summary>
    /// Text系の親玉
    /// </summary>
    public abstract class TextBase : Primitive
    {

		public TextBase()  : base()
		{
            TextVerifyEventTable = new TnkXtEvents<Events.TextVerifyEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        public override int Create(IWidget parent)
		{
			return base.Create (parent);
		}

        #region ﾘｿーｽ
        /*
        *** XmText Resource Set
        Name	Class	Type	Default	Access
        XmNsource	XmCSource	XmTextSource	Default source	CSG
        XmNvalue	XmCValue	String	""	CSG
        */

        /// XmNautoShowCursorPosition XmCAutoShowCursorPosition Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AutoShowCursorPosition {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNautoShowCursorPosition, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNautoShowCursorPosition, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNcursorPosition XmCCursorPosition XmTextPosition 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int CursorPosition {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNcursorPosition, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNcursorPosition, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNeditable XmCEditable Boolean True CSG
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

        /// XmNeditMode XmCEditMode int XmSINGLE_LINE_EDIT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual EditMode EditMode {
            get {
                return XSports.GetValue<EditMode>(
                    Native.Motif.ResourceId.XmNeditMode, EditMode.Single, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<EditMode>(
                    Native.Motif.ResourceId.XmNeditMode, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginHeight XmCMarginHeight Dimension 5 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmarginHeight, 5, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 5 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNmarginWidth, 5, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmaxLength XmCMaxLength int largest integer CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxLength {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNmaxLength, Int32.MaxValue, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmaxLength, value, Data.Resource.Access.CSG);
            }
        }

        // XmtotalLines XmCTotalLines int dynamic C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual int TotalLines {
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNtotalLines, value, Data.Resource.Access.C);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNsource XmCSource XmTextSource Default source CSG

        /// XmNtopCharacter XmCTopCharacter XmTextPosition 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TopCharacter {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNtopCharacter, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNtopCharacter, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNvalue XmCValue String "" CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Value {
            get {
                return XSports.GetAnsiString(
                    Native.Motif.ResourceId.XmNvalue, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetAnsiString(
                    Native.Motif.ResourceId.XmNvalue, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNverifyBell XmCVerifyBell Boolean dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool VerifyBell {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNverifyBell, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNverifyBell, value, Data.Resource.Access.CSG);
            }
        }

        /*
         ** XmText Input Resource Set
        */

        /// XmNpendingDelete XmCPendingDelete Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool PendingDelete {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNpendingDelete, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNpendingDelete, value, Data.Resource.Access.CSG);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNselectionArray XmCSelectionArray XtPointer default array CSG

        /// XmNselectionArrayCount XmCSelectionArrayCount int 4 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SelectionArrayCount {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNselectionArrayCount, 4, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNselectionArrayCount, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNselectThreshold XmCSelectThreshold int 5 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SelectThreshold {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNselectThreshold, 5, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNselectThreshold, value, Data.Resource.Access.CSG);
            }
        }


        /*
        **XmText Output Resource Set
        */

        /// XmNblinkRate XmCBlinkRate int 500 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BlinkRate {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNblinkRate, 500, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNblinkRate, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNcolumns XmCColumns short dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Columns {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNcolumns, 1, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNcolumns, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNcursorPositionVisible XmCCursorPositionVisible Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool CursorPositionVisible {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNcursorPositionVisible, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNcursorPositionVisible, value, Data.Resource.Access.CSG);
            }
        }

        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Coreで定義

        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
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

        /// XmNresizeHeight XmCResizeHeight Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ResizeHeight {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNresizeHeight, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNresizeHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNresizeWidth XmCResizeWidth Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ResizeWidth {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNresizeWidth, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNresizeWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNrows XmCRows short dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Rows {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNrows, 1, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNrows, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNwordWrap XmCWordWrap Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool WordWrap {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNwordWrap, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNwordWrap, value, Data.Resource.Access.CSG);
            }
        }


        /*
        ** XmText ScrolledText Resource Set
        */

        /// XmNscrollHorizontal XmCScroll Boolean True CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool ScrollHorizontal {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNscrollHorizontal, true, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNscrollHorizontal, value, Data.Resource.Access.CG);
            }
        }

        /// XmNscrollLeftSide XmCScrollSide Boolean False CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool ScrollLeftSide {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNscrollLeftSide, false, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNscrollLeftSide, value, Data.Resource.Access.CG);
            }
        }

        /// XmNscrollTopSide XmCScrollSide Boolean False CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool ScrollTopSide {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNscrollTopSide, false, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNscrollTopSide, value, Data.Resource.Access.CG);
            }
        }

        /// XmNscrollVertical XmCScroll Boolean True CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool ScrollVertical {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNscrollVertical, true, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNscrollVertical, value, Data.Resource.Access.CG);
            }
        }
		#endregion

        #region ｴﾍﾞﾝﾄ
        internal TnkXtEvents<Events.TextVerifyEventArgs> TextVerifyEventTable {
            get;
        }

        /**
        *** XmText Resource Set
        Name	Class	Type	Default	Access
        XmNmodifyVerifyCallbackWcs	XmCCallback	XtCallbackList	NULL	C
        */

		/// <summary>
		/// ﾏｳｽﾎﾞﾀﾝｸﾘｯｸ時
		/// </summary>
		public virtual event EventHandler<Events.AnyEventArgs> ActivateEvent
		{
			add
			{
				MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNactivateCallback , value);
			}
			remove
			{
				MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNactivateCallback ,  value );
			}
		}

		/// <summary>
		/// ﾌｫーｶｽ
		/// </summary>
		public virtual event EventHandler<Events.AnyEventArgs> FocusEvent
		{
			add
			{
				MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNfocusCallback ,  value );
			}
			remove
			{
				MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNfocusCallback ,  value );
			}
		}


		public virtual event EventHandler<Events.AnyEventArgs> GainPrimaryEvent
		{
			add
			{
				MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNgainPrimaryCallback ,  value );
			}
			remove
			{
				MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNgainPrimaryCallback ,  value );
			}
		}

		public virtual event EventHandler<Events.AnyEventArgs> LosePrimaryEvent
		{
			add
			{
				MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNlosePrimaryCallback ,  value );
			}
			remove
			{
				MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNlosePrimaryCallback ,  value );
			}
		}

		public virtual event EventHandler<Events.TextVerifyEventArgs> LosingFocusEvent
		{
			add {
				TextVerifyEventTable.AddHandler(this, Native.Motif.EventId.XmNlosingFocusCallback ,  value );
			}
			remove {
				TextVerifyEventTable.RemoveHandler(Native.Motif.EventId.XmNlosingFocusCallback ,  value );
			}
		}

        //
		public virtual event EventHandler<Events.TextVerifyEventArgs> ModifyVerifyEvent
		{
			add {
				TextVerifyEventTable.AddHandler(this, Native.Motif.EventId.XmNmodifyVerifyCallback ,  value );
			}
			remove {
				TextVerifyEventTable.RemoveHandler(Native.Motif.EventId.XmNmodifyVerifyCallback ,  value );
			}
		}

        //        XmNmotionVerifyCallback	XmCCallback	XtCallbackList	NULL	C
		public virtual event EventHandler<Events.TextVerifyEventArgs> MotionVerifyEvent
		{
			add {
				TextVerifyEventTable.AddHandler(this, Native.Motif.EventId.XmNmotionVerifyCallback ,  value );
			}
			remove {
				TextVerifyEventTable.RemoveHandler(Native.Motif.EventId.XmNmotionVerifyCallback ,  value );
			}
		}

       //  XmNvalueChangedCallback	XmCCallback	XtCallbackList	NULL	C
		public virtual event EventHandler<Events.AnyEventArgs> ValueChangedEvent
		{
			add {
				MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNvalueChangedCallback ,  value );
			}
			remove {
				MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNvalueChangedCallback ,  value );
			}
		}
        #endregion
    }
}
