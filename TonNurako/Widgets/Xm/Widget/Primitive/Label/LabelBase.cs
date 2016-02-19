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
	/// LabelBase
	/// </summary>
	public abstract class LabelBase : Primitive
	{

		public LabelBase()  : base()
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


		#region Labelﾌﾟﾛﾊﾟﾃｨ

        /// XmNaccelerator XmCAccelerator String NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Accelerator {
            get {
                return XSports.GetAnsiString(
                Native.Motif.ResourceId.XmNaccelerator, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetAnsiString(
                Native.Motif.ResourceId.XmNaccelerator, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNacceleratorText XmCAcceleratorText XmString NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string AcceleratorText {
            get {
                return XSports.GetString(
                Native.Motif.ResourceId.XmNacceleratorText, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                Native.Motif.ResourceId.XmNacceleratorText, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNalignment XmCAlignment unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment Alignment {
            get {
                return XSports.GetValue<Alignment>(
                Native.Motif.ResourceId.XmNalignment, Alignment.Beginning, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<Alignment>(
                    Native.Motif.ResourceId.XmNalignment, value, Data.Resource.Access.CSG);
            }
        }

        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Coreで定義

        /// XmNlabelInsensitivePixmap XmCLabelInsensitivePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap LabelInsensitivePixmap {
            get {
                return XSports.GetPixmap(
                    Native.Motif.ResourceId.XmNlabelInsensitivePixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    Native.Motif.ResourceId.XmNlabelInsensitivePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelPixmap XmCLabelPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap LabelPixmap {
            get {
                return XSports.GetPixmap(
                    Native.Motif.ResourceId.XmNlabelPixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    Native.Motif.ResourceId.XmNlabelPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelString XmCXmString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string LabelString {
            get {
                return XSports.GetString(
                Native.Motif.ResourceId.XmNlabelString, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetString(
                    Native.Motif.ResourceId.XmNlabelString, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelType XmCLabelType unsigned char XmSTRING CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual LabelType LabelType {
            get {
                return XSports.GetValue<LabelType>(
                Native.Motif.ResourceId.XmNlabelType, LabelType.String, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<LabelType>(
                    Native.Motif.ResourceId.XmNlabelType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginBottom XmCMarginBottom Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginBottom {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmarginBottom, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmarginBottom, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginHeight XmCMarginHeight Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmarginHeight, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginLeft XmCMarginLeft Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginLeft {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNmarginLeft, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmarginLeft, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginRight XmCMarginRight Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginRight {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNmarginRight, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmarginRight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginTop XmCMarginTop Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginTop {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNmarginTop, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmarginTop, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNmarginWidth, 2, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmnemonic XmCMnemonic KeySym NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.KeySym Mnemonic {
            get {
                return XSports.GetKeySym(
                    Native.Motif.ResourceId.XmNmnemonic, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetKeySym(
                    Native.Motif.ResourceId.XmNmnemonic, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmnemonicCharSet XmCMnemonicCharSet String XmFONTLIST_DEFAULT_TAG CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string MnemonicCharSet {
            get {
                return XSports.GetAnsiString(
                    Native.Motif.ResourceId.XmNmnemonicCharSet, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetAnsiString(
                    Native.Motif.ResourceId.XmNmnemonicCharSet, value, Data.Resource.Access.CSG);
            }
        }
        /*
        /// XmNpixmapPlacement XmCPixmapPlacement unsigned int XmPIXMAP_LEFT CSG
        public virtual uint PixmapPlacement {
            get {
                return XSports.GetUInt(
                Native.Motif.ResourceId.XmNpixmapPlacement, XmPIXMAP_LEFT, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetUInt(
                Native.Motif.ResourceId.XmNpixmapPlacement, value, Data.Resource.Access.CSG);
            }
        }*/

        /// XmNpixmapTextPadding XmCSpace Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PixmapTextPadding {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNpixmapTextPadding, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNpixmapTextPadding, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNrecomputeSize XmCRecomputeSize Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RecomputeSize {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNrecomputeSize, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNrecomputeSize, value, Data.Resource.Access.CSG);
            }
        }

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

        /// XmNstringDirection XmCStringDirection XmStringDirection dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual StringDirection StringDirection {
            get {
                return XSports.GetValue<StringDirection>(
                    Native.Motif.ResourceId.XmNstringDirection, StringDirection.Default, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<StringDirection>(
                    Native.Motif.ResourceId.XmNstringDirection, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

	}
}
