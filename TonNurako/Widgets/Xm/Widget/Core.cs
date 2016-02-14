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
    ///　Core
    /// </summary>
    public abstract class Core : Widget
    {
        public Core() : base() {

        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
            InitProperties();
        }

        internal void CreateMotifWidget(
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

        /*
        Core Resource Set
        Name	Class	Type	Default	Access
        XmNscreen	XmCScreen	Screen *	dynamic	CG

        // --- Widgetで定義 ---
        /// XmNborderWidth	XmCBorderWidth	Dimension	1	CSG
        /// XmNdestroyCallback	XmCCallback	XtCallbackList	NULL	C
        /// XmNdepth	XmCDepth	int	dynamic	CG
        // (Widget.Size)  XmNheight	XmCHeight	Dimension	dynamic	CSG
        // (Widget.Size)  XmNwidth	XmCWidth	Dimension	dynamic	CSG
        /// XmNsensitive	XmCSensitive	Boolean	True	CSG
        */
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Accelerators Accelerators {
            get {
                return XSports.GetAccelerators(Native.Motif.ResourceId.XmNaccelerators);
            }
            set {
                XSports.SetAccelerators(Native.Motif.ResourceId.XmNaccelerators, value);
            }
        }


        /// XmNtranslations
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Translations Translations {
            get {
                return XSports.GetTranslations(Native.Motif.ResourceId.XmNtranslations);
            }
            set {
                XSports.SetTranslations(Native.Motif.ResourceId.XmNtranslations, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AncestorSensitive {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNancestorSensitive, false);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNancestorSensitive, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Colormap {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNcolormap, -1);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNcolormap, value);
            }
        }

        /// XmNbackgroundPixmap
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap BackgroundPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNbackgroundPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNbackgroundPixmap, value);
            }
        }


        /// XmNborderPixmap
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap BorderPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNborderPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNborderPixmap, value);
            }
        }


        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color BackgroundColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNbackground);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNbackground, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color BorderColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNborderColor);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNborderColor, value);
            }
        }


        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool InitialResourcesPersistent {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNinitialResourcesPersistent, true);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNinitialResourcesPersistent, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool MappedWhenManaged {
            get {

                return XSports.GetBool(Native.Motif.ResourceId.XmNmappedWhenManaged, false);

            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNmappedWhenManaged, value);
            }
        }

    }
}
