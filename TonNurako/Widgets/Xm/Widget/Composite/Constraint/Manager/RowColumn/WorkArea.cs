//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// WorkArea 
	/// </summary>
	public class WorkArea : RowColumn, IDefectiveWidget
	{

		public WorkArea() : base() {
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateWorkArea, parent, ToolkitResources);
			}
			return base.Create (parent);
		}


	}
}
