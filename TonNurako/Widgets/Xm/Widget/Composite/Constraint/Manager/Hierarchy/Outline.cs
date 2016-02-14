//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Outline
	/// </summary>
	public class Outline : Hierarchy, IDefectiveWidget
	{

		#region 生成

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public Outline() : base() {
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }


		/// <summary>
		/// Outline生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateOutline, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNconnectNodes Boolean Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ConnectNodes {
            get {
                return XSports.GetBool(
                	    Native.Motif.ResourceId.XmNconnectNodes, false, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetBool(
                    Native.Motif.ResourceId.XmNconnectNodes, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNindentSpace Dimension Dimension 30 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IndentSpace {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNindentSpace, 30, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNindentSpace, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
