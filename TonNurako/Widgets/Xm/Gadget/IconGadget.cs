//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{

    /// <summary>
    /// IconGadget
    /// </summary>
    public class IconGadget : Gadget
    {
        #region 定数(どっかに追い出したい)
        public enum IconType {
            LargeIcon = Native.Motif.Constant.XmLARGE_ICON,
            SmallIcon = Native.Motif.Constant.XmSMALL_ICON,
        }
        public enum SelectState {
            Selected = Native.Motif.Constant.XmSELECTED,
            NotSelected = Native.Motif.Constant.XmNOT_SELECTED,
        }
        #endregion

		#region 生成

		public IconGadget()  : base()
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
				this.CreateMotifGadget(Native.Motif.CreateSymbol.XmCreateIconGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
		#endregion

        ///  XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
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

        /// Xmalignment XmCAlignment unsigned char XmALIGNMENT_CENTER CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment Lignment {
            get {
                return XSports.GetValue<Alignment>(
                    Native.Motif.ResourceId.XmNalignment, Alignment.Center, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<Alignment>(
                Native.Motif.ResourceId.XmNalignment, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdetail XmCDetail XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual CompoundStringTable Detail {
            get {
                return XSports.GetStringTable(
                    Native.Motif.ResourceId.XmNdetail, DetailCount, true, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetStringTable(
                    Native.Motif.ResourceId.XmNdetail, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdetailCount XmCDetailCount Cardinal 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailCount {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNdetailCount, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNdetailCount, value, Data.Resource.Access.CSG);
            }
        }

        // XmNfontList XmCFontList XmFontList NULL CSG
        // -> Core

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

        /// XmNlargeIconMask XmCIconMask Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap LargeIconMask {
            get {
                return XSports.GetPixmap(
                Native.Motif.ResourceId.XmNlargeIconMask, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    Native.Motif.ResourceId.XmNlargeIconMask, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlargeIconPixmap XmCIconPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap LargeIconPixmap {
            get {
                return XSports.GetPixmap(
                    Native.Motif.ResourceId.XmNlargeIconPixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    Native.Motif.ResourceId.XmNlargeIconPixmap, value, Data.Resource.Access.CSG);
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

        /// XmNsmallIconMask XmCIconMask Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap SmallIconMask {
            get {
                return XSports.GetPixmap(
                Native.Motif.ResourceId.XmNsmallIconMask, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                Native.Motif.ResourceId.XmNsmallIconMask, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsmallIconPixmap XmCIconPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap SmallIconPixmap {
            get {
                return XSports.GetPixmap(
                    Native.Motif.ResourceId.XmNsmallIconPixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    Native.Motif.ResourceId.XmNsmallIconPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNviewType XmCViewType unsigned char XmLARGE_ICON CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IconType ViewType {
            get {
                return XSports.GetValue<IconType>(
                Native.Motif.ResourceId.XmNviewType, IconType.LargeIcon, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<IconType>(
                Native.Motif.ResourceId.XmNviewType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNvisualEmphasis XmCVisualEmphasis unsigned char XmNOT_SELECTED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectState VisualEmphasis {
            get {
                return XSports.GetValue<SelectState>(
                Native.Motif.ResourceId.XmNvisualEmphasis, SelectState.NotSelected, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<SelectState>(
                    Native.Motif.ResourceId.XmNvisualEmphasis, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNspacing XmCSpacing Dimension 4 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNspacing, 4, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNspacing, value, Data.Resource.Access.CSG);
            }
        }
    }
}
