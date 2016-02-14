//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// MenuShell
	/// </summary>
	public class MenuShell : Shell, IDefectiveWidget
	{
		public MenuShell() : base() {
            throw new System.NotImplementedException();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateMenuShell, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNbuttonFontList XmCButtonFontList XmFontList dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList ButtonFontList {
            get {
                return XSports.GetFontList(
                    Native.Motif.ResourceId.XmNbuttonFontList, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetFontList(
                    Native.Motif.ResourceId.XmNbuttonFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNbuttonRenderTable	XmCButtonRenderTable	XmRenderTable	dynamic	CSG
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

        /// XmNlabelRenderTable XmCLabelRenderTable XmRenderTable NULL CSG
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

        /// XmNanimate XmCAnimate Boolean False CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool Animate {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNanimate, false, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNanimate, value, Data.Resource.Access.CG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
