//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{



	/// <summary>
	/// WMShell
	/// </summary>
	public abstract class WMShell : Shell, IDefectiveWidget
	{
		public WMShell() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			return base.Create (parent);
		}


		#region ﾌﾟﾛﾊﾟﾁー
        private static readonly int XtUnspecifiedShellInt = 0;

        /// XmNbaseHeight XmCBaseHeight int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BaseHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNbaseHeight, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNbaseHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNbaseWidth XmCBaseWidth int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BaseWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNbaseWidth, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNbaseWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNheightInc XmCHeightInc int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HeightInc {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNheightInc, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNheightInc, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNiconMask XmCIconMask Pixmap NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap IconMask {
            get {
                return XSports.GetPixmap(
                Native.Motif.ResourceId.XmNiconMask, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                Native.Motif.ResourceId.XmNiconMask, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNiconPixmap XmCIconPixmap Pixmap NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap IconPixmap {
            get {
                return XSports.GetPixmap(
                Native.Motif.ResourceId.XmNiconPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                Native.Motif.ResourceId.XmNiconPixmap, value, Data.Resource.Access.CSG);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNiconWindow XmCIconWindow Window NULL CSG

        /// XmNiconX XmCIconX int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IconX {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNiconX, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNiconX, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNiconY XmCIconY int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IconY {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNiconY, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNiconY, value, Data.Resource.Access.CSG);
            }
        }



        /// XmNinitialState XmCInitialState int NormalState CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual WindowState InitialState {
            get {
                return XSports.GetValue<WindowState>(
                    Native.Motif.ResourceId.XmNinitialState, WindowState.Normal, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<WindowState>(
                    Native.Motif.ResourceId.XmNinitialState, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNinput XmCInput Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Input {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNinput, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNinput, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmaxAspectX XmCMaxAspectX int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxAspectX {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmaxAspectX, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmaxAspectX, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmaxAspectY XmCMaxAspectY int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxAspectY {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmaxAspectY, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmaxAspectY, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmaxHeight XmCMaxHeight int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmaxHeight, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmaxHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmaxWidth XmCMaxWidth int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmaxWidth, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmaxWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNminAspectX XmCMinAspectX int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinAspectX {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNminAspectX, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNminAspectX, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNminAspectY XmCMinAspectY int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinAspectY {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNminAspectY, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNminAspectY, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNminHeight XmCMinHeight int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNminHeight, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNminHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNminWidth XmCMinWidth int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNminWidth, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNminWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtitle XmCTitle String dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Title {
            get {
                return XSports.GetAnsiString(
                    Native.Motif.ResourceId.XmNtitle, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetAnsiString(
                    Native.Motif.ResourceId.XmNtitle, value, Data.Resource.Access.CSG);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNtitleEncoding XmCTitleEncoding Atom dynamic CSG

        /// XmNtransient XmCTransient Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Transient {
            get {
                return XSports.GetBool(
                    Native.Motif.ResourceId.XmNtransient, false, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetBool(
                    Native.Motif.ResourceId.XmNtransient, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNwaitForWm XmCWaitForWm Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool WaitForWm {
            get {
                return XSports.GetBool(
                    Native.Motif.ResourceId.XmNwaitForWm, true, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetBool(
                    Native.Motif.ResourceId.XmNwaitForWm, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNwidthInc XmCWidthInc int XtUnspecifiedShellInt CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int WidthInc {
            get {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNwidthInc, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNwidthInc, value, Data.Resource.Access.CSG);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNwindowGroup XmCWindowGroup Window dynamic CSG

        /// XmNwinGravity XmCWinGravity int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int WinGravity {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNwinGravity, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNwinGravity, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNwmTimeout XmCWmTimeout int 5000 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int WmTimeout {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNwmTimeout, 5000, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNwmTimeout, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
