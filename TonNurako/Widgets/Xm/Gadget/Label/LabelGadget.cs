//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// LabelGadget
    /// </summary>
    public class LabelGadget : Gadget
    {
        public LabelGadget()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifGadget(Native.Motif.CreateSymbol.XmCreateLabelGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}


        /// XmNaccelerator XmCAccelerator String NULL CSG
        public virtual string Accelerator {
            get {
                return XSports.GetAnsiString(Native.Motif.ResourceId.XmNaccelerator, "");
            }
            set {
            XSports.SetAnsiString(Native.Motif.ResourceId.XmNaccelerator, value);
            }
        }


        /// XmNacceleratorText XmCAcceleratorText XmString NULL CSG
        public virtual string AcceleratorText {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNacceleratorText, "");
            }
            set {
            XSports.SetString(Native.Motif.ResourceId.XmNacceleratorText, value);
            }
        }


        /// XmNalignment XmCAlignment unsigned char dynamic CSG
        public virtual Alignment Alignment {
            get {
                return XSports.GetValue<Alignment>(Native.Motif.ResourceId.XmNalignment, Alignment.Beginning);
            }
            set {
                XSports.SetValue<Alignment>(Native.Motif.ResourceId.XmNalignment, value);
            }
        }


        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Coreで定義


        /// XmNlabelInsensitivePixmap XmCLabelInsensitivePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        public virtual GC.Pixmap LabelInsensitivePixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNlabelInsensitivePixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNlabelInsensitivePixmap, value);
            }
        }


        /// XmNlabelPixmap XmCLabelPixmap Pixmap dynamic CSG
        public virtual GC.Pixmap LabelPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNlabelPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNlabelPixmap, value);
            }
        }


        /// XmNlabelString XmCXmString XmString dynamic CSG
        public virtual string LabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNlabelString, "");
            }
            set {
            XSports.SetString(Native.Motif.ResourceId.XmNlabelString, value);
            }
        }


        /// XmNlabelType XmCLabelType unsigned char XmSTRING CSG
        public virtual LabelType LabelType {
            get {
                return XSports.GetValue<LabelType>(Native.Motif.ResourceId.XmNlabelType, LabelType.String);
            }
            set {
            XSports.SetValue<LabelType>(Native.Motif.ResourceId.XmNlabelType, value);
            }
        }


        /// XmNmarginBottom XmCMarginBottom Dimension dynamic CSG
        public virtual int MarginBottom {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginBottom, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginBottom, value);
            }
        }


        /// XmNmarginHeight XmCMarginHeight Dimension 2 CSG
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginHeight, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginHeight, value);
            }
        }


        /// XmNmarginLeft XmCMarginLeft Dimension dynamic CSG
        public virtual int MarginLeft {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginLeft, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginLeft, value);
            }
        }


        /// XmNmarginRight XmCMarginRight Dimension dynamic CSG
        public virtual int MarginRight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginRight, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginRight, value);
            }
        }


        /// XmNmarginTop XmCMarginTop Dimension dynamic CSG
        public virtual int MarginTop {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginTop, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginTop, value);
            }
        }


        /// XmNmarginWidth XmCMarginWidth Dimension 2 CSG
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginWidth, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginWidth, value);
            }
        }


        /// XmNmnemonic XmCMnemonic KeySym NULL CSG
        public virtual Data.KeySym Mnemonic {
            get {
                return XSports.GetKeySym(Native.Motif.ResourceId.XmNmnemonic);
            }
            set {
            XSports.SetKeySym(Native.Motif.ResourceId.XmNmnemonic, value);
            }
        }


        // ### XmNpixmapPlacement XmCPixmapPlacement unsigned int XmPIXMAP_LEFT CSG
        /*public virtual uint PixmapPlacement {
            get {
                return XSports.GetUInt(Native.Motif.ResourceId.XmNpixmapPlacement, XmPIXMAP_LEFT);
            }
            set {
            XSports.SetUInt(Native.Motif.ResourceId.XmNpixmapPlacement, value);
            }
        }*/


        /// XmNpixmapTextPadding XmCSpace Dimension 2 CSG
        public virtual int PixmapTextPadding {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNpixmapTextPadding, 2);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNpixmapTextPadding, value);
            }
        }


        /// XmNmnemonicCharSet XmCMnemonicCharSet String dynamic CSG
        public virtual string MnemonicCharSet {
            get {
                return XSports.GetAnsiString(Native.Motif.ResourceId.XmNmnemonicCharSet, "");
            }
            set {
            XSports.SetAnsiString(Native.Motif.ResourceId.XmNmnemonicCharSet, value);
            }
        }


        /// XmNrecomputeSize XmCRecomputeSize Boolean True CSG
        public virtual bool RecomputeSize {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNrecomputeSize, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNrecomputeSize, value);
            }
        }

        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
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

        /// XmNstringDirection XmCStringDirection XmStringDirection dynamic CSG
        public virtual StringDirection StringDirection {
            get {
                return XSports.GetValue<StringDirection>(Native.Motif.ResourceId.XmNstringDirection, StringDirection.LtoR);
            }
            set {
                XSports.SetValue<StringDirection>(Native.Motif.ResourceId.XmNstringDirection, value);
            }
        }


    }

}
