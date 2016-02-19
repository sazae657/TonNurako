//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Manager
	/// </summary>
	public abstract class Manager : Constraint, Widgets.IManagerWidget
	{

		internal Manager() : base()
		{
            PopupHandlerEventTable = new TnkXtEvents<Events.PopupHandlerEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        internal TnkXtEvents<Events.PopupHandlerEventArgs> PopupHandlerEventTable {
            get;
        }

		public override int Create( IWidget parent )
		{
			return base.Create( parent );
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Managerﾌﾟﾛﾊﾟﾃｨ

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
		public virtual int ShadowThickness
		{
			get {
				return XSports.GetInt(Native.Motif.ResourceId.XmNshadowThickness, 0);
			}
			set{
				XSports.SetInt( Native.Motif.ResourceId.XmNshadowThickness, value );
			}
		}

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color BottomShadowColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNbottomShadowColor);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNbottomShadowColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color ForegroundColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNforeground);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNforeground, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color HighlightColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNhighlightColor);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNhighlightColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color TopShadowColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNtopShadowColor);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNtopShadowColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
		public NavigationType NavigationType
		{
			get {
                return XSports.GetValue<NavigationType>(Native.Motif.ResourceId.XmNnavigationType, NavigationType.TabGroup);
			}
			set {
                XSports.SetValue<NavigationType>(Native.Motif.ResourceId.XmNnavigationType, value );
			}
		}

        /// XmNbottomShadowPixmap XmCBottomShadowPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap BottomShadowPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNbottomShadowPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNbottomShadowPixmap, value);
            }
        }


        /// XmNhighlightPixmap XmCHighlightPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap HighlightPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNhighlightPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNhighlightPixmap, value);
            }
        }


        /// XmNinitialFocus XmCInitialFocus Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget InitialFocus {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNinitialFocus);
            }
            set {
                XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNinitialFocus, value);
            }
        }


        /// XmNlayoutDirection XmCLayoutDirection XmDirection dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual Direction LayoutDirection {
            get {
                return XSports.GetValue<Direction>(
                    Native.Motif.ResourceId.XmNlayoutDirection, Direction.DefaultDirection, Data.Resource.Access.CG);
            }
            set {
            XSports.SetValue<Direction>(Native.Motif.ResourceId.XmNlayoutDirection, value, Data.Resource.Access.CG);
            }
        }


        /// XmNstringDirection XmCStringDirection XmStringDirection dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual StringDirection StringDirection {
            get {
                return XSports.GetValue<StringDirection>(
                    Native.Motif.ResourceId.XmNstringDirection, StringDirection.LtoR, Data.Resource.Access.CG);
            }
            set {
            XSports.SetValue<StringDirection>(Native.Motif.ResourceId.XmNstringDirection, value, Data.Resource.Access.CG);
            }
        }


        /// XmNtopShadowPixmap XmCTopShadowPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap TopShadowPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNtopShadowPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNtopShadowPixmap, value);
            }
        }


        /// XmNtraversalOn XmCTraversalOn Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool TraversalOn {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNtraversalOn, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNtraversalOn, value);
            }
        }


        /// XmNunitType XmCUnitType unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType UnitType {
            get {
                return XSports.GetValue<UnitType>(Native.Motif.ResourceId.XmNunitType, UnitType.Pixels);
            }
            set {
                XSports.SetValue<UnitType>(Native.Motif.ResourceId.XmNunitType, value);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNuserData XmCUserData XtPointer NULL CSG

        /// XmNhelpCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> HelpEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNhelpCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNhelpCallback ,  value );
            }
        }


        /// XmNpopupHandlerCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PopupHandlerEventArgs> PopupHandlerEvent
        {
            add {
                PopupHandlerEventTable.AddHandler(this, Native.Motif.EventId.XmNpopupHandlerCallback ,  value );
            }
            remove {
                PopupHandlerEventTable.RemoveHandler(Native.Motif.EventId.XmNpopupHandlerCallback ,  value );
            }
        }


		#endregion

	}
}

