//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimplePopupMenu
	/// </summary>
	public class SimplePopupMenu : SimpleMenuBase
	{

		#region 生成
		public SimplePopupMenu()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

        public override bool AllowAutoManage {
            get {return false;}
        }


		public override int Create( IWidget parent )
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateSimplePopupMenu, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion

        #region 固有
        public void  SetPopupPosition(Native.Xt.XEventStruct.XButtonEvent ev) {
            TonNurako.Native.Motif.XmSports.XmMenuPosition(this, ev);
        }

        public void  Popup(int x, int y) {
            Native.Xt.XEventStruct.XButtonEvent ev =new Native.Xt.XEventStruct.XButtonEvent();
            ev.x_root = x;
            ev.y_root = y;
            Popup(ev);
        }

        public void  Popup(Native.Xt.XEventStruct.XButtonEvent ev) {
            SetPopupPosition(ev);
            Popup();
        }

        public void  Popup() {
            this.Visible = true;
        }

        #endregion
	}
}
