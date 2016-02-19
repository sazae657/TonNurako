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
    /// Gadget
    /// </summary>
    public abstract class Gadget : Widget
    {
		public Gadget()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		public override int Create(IWidget parent)
		{
			return base.Create (parent);
		}


        protected void CreateMotifGadget(
            Native.Motif.CreateSymbol sym, IWidget parent, XResource res)
        {
            if (0 == this.Name.Length) {
                // 名無しは作れないので強制命名
                this.Name = AppContext.CreateTempName(this.GetType().Name);
            }

            IntPtr w = Native.Motif.XmSports.CallCreate2P(sym,
                                    parent,
                                    this.Name,
                                    (null != res) ? res.ToXtArg() : null);

            if (IntPtr.Zero == w) {
                throw new Exception($"{sym.ToString()} failed");
            }
            NativeHandle = new Native.WidgetHandle(w);
            if (null != res) {
                res.Clear();
            }
        }


        #region resource
        /// XmNbackground XmCBackground Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color Background {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNbackground);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNbackground, value);
            }
        }


        /// XmNbackgroundPixmap XmCPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap BackgroundPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNbackgroundPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNbackgroundPixmap, value);
            }
        }


        /// XmNbottomShadowColor XmCBottomShadowColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color BottomShadowColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNbottomShadowColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNbottomShadowColor, value);
            }
        }


        /// XmNbottomShadowPixmap XmCBottomShadowPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap BottomShadowPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNbottomShadowPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNbottomShadowPixmap, value);
            }
        }


        /// XmNforeground XmCForeground Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color Foreground {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNforeground);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNforeground, value);
            }
        }


        /// XmNhighlightColor XmCHighlightColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color HighlightColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNhighlightColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNhighlightColor, value);
            }
        }


        /// XmNhighlightOnEnter XmCHighlightOnEnter Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool HighlightOnEnter {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNhighlightOnEnter, false);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNhighlightOnEnter, value);
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


        /// XmNlayoutDirection XmNCLayoutDirection XmDirection dynamic CG
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


        /// XmNnavigationType XmCNavigationType XmNavigationType XmNONE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual NavigationType NavigationType {
            get {
                return XSports.GetValue<NavigationType>(Native.Motif.ResourceId.XmNnavigationType, NavigationType.None);
            }
            set {
            XSports.SetValue<NavigationType>(Native.Motif.ResourceId.XmNnavigationType, value);
            }
        }


        /// XmNshadowThickness XmCShadowThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ShadowThickness {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNshadowThickness, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNshadowThickness, value);
            }
        }


        /// XmNtopShadowColor XmCTopShadowColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color TopShadowColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNtopShadowColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNtopShadowColor, value);
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

        /// XmNtoolTipString XmCToolTipString XmString NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string ToolTipString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNtoolTipString, "");
            }
            set {
            XSports.SetString(Native.Motif.ResourceId.XmNtoolTipString, value);
            }
        }


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


        #endregion
    }

}
