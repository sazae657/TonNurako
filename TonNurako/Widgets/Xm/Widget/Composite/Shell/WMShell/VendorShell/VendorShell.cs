//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    public enum AudibleWarning {
        Bell = Native.Motif.Constant.XmBELL,
        None = Native.Motif.Constant.XmNONE
    }
    public enum DeleteResponse {
        Destroy = Native.Motif.Constant.XmDESTROY,
        Unmap = Native.Motif.Constant.XmUNMAP,
        DoNothing = Native.Motif.Constant.XmDO_NOTHING,

    }

    public enum InputPolicy {
        PerShell = Native.Motif.Constant.XmPER_SHELL,
        PerWidget = Native.Motif.Constant.XmPER_WIDGET,
    }

    public enum KeyboardFocusPolicy {
        Explicit = Native.Motif.Constant.XmEXPLICIT,
        Pointer = Native.Motif.Constant.XmPOINTER,
    }

    [Flags]
    public enum MwmDecorations {
        All       = (1 << 0),
        Border    = (1 << 1),
        Resizeh   = (1 << 2),
        Title     = (1 << 3),
        Menu      = (1 << 4),
        Minimize  = (1 << 5),
        Maximize  = (1 << 6),
    }

    public enum MwmFunctions  {
        All      =  (1 << 0),
        Resize   = (1 << 1),
        Move     = (1 << 2),
        Minimize  = (1 << 3),
        Maximize  = (1 << 4),
        Close     = (1 << 5),
    }

	/// <summary>
	/// VendorShell
	/// </summary>
	public abstract class VendorShell : WMShell, IDefectiveWidget
	{

		public VendorShell() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー
        /// XmNaudibleWarning XmCAudibleWarning unsigned char XmBELL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual AudibleWarning AudibleWarning {
            get {
                return XSports.GetValue<AudibleWarning>(
                    Native.Motif.ResourceId.XmNaudibleWarning, AudibleWarning.Bell, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<AudibleWarning>(
                    Native.Motif.ResourceId.XmNaudibleWarning, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNbuttonFontList XmCButtonFontList XmFontList dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList ButtonFontList {
            get {
                return XSports.GetFontList(
                    Native.Motif.ResourceId.XmNbuttonFontList,  Data.Resource.Access.CSG);
            }
            set {
                XSports.SetFontList(
                    Native.Motif.ResourceId.XmNbuttonFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNbuttonRenderTable XmCButtonRenderTable XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable ButtonRenderTable  {
            get {
                return XSports.GetRenderTable(
                    Native.Motif.ResourceId.XmNbuttonRenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    Native.Motif.ResourceId.XmNbuttonRenderTable, value, Data.Resource.Access.CSG);
            }
        }


        /// XmNdefaultFontList XmCDefaultFontList XmFontList dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual SportyFontList DefaultFontList {
            get {
                return XSports.GetFontList(
                    Native.Motif.ResourceId.XmNdefaultFontList, Data.Resource.Access.CG);
            }
            set {
                XSports.SetFontList(
                    Native.Motif.ResourceId.XmNdefaultFontList, value, Data.Resource.Access.CG);
            }
        }

        /// XmNdeleteResponse XmCDeleteResponse unsigned char XmDESTROY CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual DeleteResponse DeleteResponse {
            get {
                return XSports.GetValue<DeleteResponse>(
                    Native.Motif.ResourceId.XmNdeleteResponse, DeleteResponse.Destroy, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<DeleteResponse>(
                    Native.Motif.ResourceId.XmNdeleteResponse, value, Data.Resource.Access.CSG);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNinputMethod XmCInputMethod string NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string InputMethod {
            get {
                return XSports.GetAnsiString(
                    Native.Motif.ResourceId.XmNinputMethod, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetAnsiString(
                    Native.Motif.ResourceId.XmNinputMethod, value, Data.Resource.Access.CSG);
            }
        }

        // ### XmNinputPolicy XmCInputPolicy XmInputPolicy XmPER_SHELL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual InputPolicy InputPolicy {
            get {
                return XSports.GetValue<InputPolicy>(
                    Native.Motif.ResourceId.XmNinputPolicy, InputPolicy.PerShell, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<InputPolicy>(
                    Native.Motif.ResourceId.XmNinputPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNkeyboardFocusPolicy XmCKeyboardFocusPolicy unsigned char XmEXPLICIT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual KeyboardFocusPolicy KeyboardFocusPolicy {
            get {
                return XSports.GetValue<KeyboardFocusPolicy>(
                Native.Motif.ResourceId.XmNkeyboardFocusPolicy, KeyboardFocusPolicy.Explicit, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<KeyboardFocusPolicy>(
                    Native.Motif.ResourceId.XmNkeyboardFocusPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelFontList XmCLabelFontList XmFontList dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList LabelFontList {
            get {
                return XSports.GetFontList(
                    Native.Motif.ResourceId.XmNlabelFontList, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetFontList(
                    Native.Motif.ResourceId.XmNlabelFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelRenderTable XmCLabelRenderTabel XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable LabelRenderTable  {
            get {
                return XSports.GetRenderTable(
                    Native.Motif.ResourceId.XmNlabelRenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    Native.Motif.ResourceId.XmNlabelRenderTable, value, Data.Resource.Access.CSG);
            }
        }


        /// XmNlayoutDirection XmCLayoutDirection XmDirection XmLEFT_TO_RIGHT CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual Direction LayoutDirection {
            get {
                return XSports.GetValue<Direction>(
                Native.Motif.ResourceId.XmNlayoutDirection, Direction.LeftToRight, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<Direction>(
                    Native.Motif.ResourceId.XmNlayoutDirection, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmDecorations XmCMwmDecorations int -1 CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual MwmDecorations MwmDecorations {
            get {
                return XSports.GetValue<MwmDecorations>(
                    Native.Motif.ResourceId.XmNmwmDecorations, MwmDecorations.All, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<MwmDecorations>(
                    Native.Motif.ResourceId.XmNmwmDecorations, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmFunctions XmCMwmFunctions int -1 CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual MwmFunctions MwmFunctions {
            get {
                return XSports.GetValue(
                Native.Motif.ResourceId.XmNmwmFunctions, MwmFunctions.All, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue(
                    Native.Motif.ResourceId.XmNmwmFunctions, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmInputMode XmCMwmInputMode int -1 CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int MwmInputMode {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmwmInputMode, -1, Data.Resource.Access.CG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmwmInputMode, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmMenu XmCMwmMenu String NULL CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual string MwmMenu {
            get {
                return XSports.GetAnsiString(
                Native.Motif.ResourceId.XmNmwmMenu, "", Data.Resource.Access.CG);
            }
            set {
            XSports.SetAnsiString(
                Native.Motif.ResourceId.XmNmwmMenu, value, Data.Resource.Access.CG);
            }
        }

        /// XmNpreeditType XmCPreeditType String dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string PreeditType {
            get {
                return XSports.GetAnsiString(
                Native.Motif.ResourceId.XmNpreeditType, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetAnsiString(
                Native.Motif.ResourceId.XmNpreeditType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNverifyPreedit XmCVerifyPreedit Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool VerifyPreedit {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNverifyPreedit, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNverifyPreedit, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNshellUnitType XmCShellUnitType unsigned char XmPIXELS CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType ShellUnitType {
            get {
                return XSports.GetValue<UnitType>(
                Native.Motif.ResourceId.XmNshellUnitType, UnitType.Pixels , Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<UnitType>(
                    Native.Motif.ResourceId.XmNshellUnitType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtextFontList XmCTextFontList XmFontList dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList TextFontList {
            get {
                return XSports.GetFontList(
                Native.Motif.ResourceId.XmNtextFontList, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetFontList(
                Native.Motif.ResourceId.XmNtextFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtextRenderTable XmCTextRenderTable XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable TextRenderTable  {
            get {
                return XSports.GetRenderTable(
                    Native.Motif.ResourceId.XmNtextRenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    Native.Motif.ResourceId.XmNtextRenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtoolTipPostDelay XmCToolTipPostDelay int 5000 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ToolTipPostDelay {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNtoolTipPostDelay, 5000, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNtoolTipPostDelay, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtoolTipPostDuration XmCToolTipPostDuration int 5000 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ToolTipPostDuration {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNtoolTipPostDuration, 5000, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNtoolTipPostDuration, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtoolTipEnable XmCToolTipEnable Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ToolTipEnable {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNtoolTipEnable, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNtoolTipEnable, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNunitType XmCUnitType unsigned char XmPIXELS CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType UnitType {
            get {
                return XSports.GetValue<UnitType>(
                Native.Motif.ResourceId.XmNunitType, UnitType.Pixels, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<UnitType>(
                    Native.Motif.ResourceId.XmNunitType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNuseAsyncGeometry XmCUseAsyncGeometry Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool UseAsyncGeometry {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNuseAsyncGeometry, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNuseAsyncGeometry, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
