//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{

	/// <summary>
	/// ButtonBox
	/// </summary>
	public class ButtonBox : Manager, IDefectiveWidget
	{
		public ButtonBox() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// ButtonBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateButtonBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNequalSize XmCEqualSize Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool EqualSize {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNequalSize, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNequalSize, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNfillOption XmCFillOption unsigned char XmFillNone CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual FillOption FillOption {
            get {
                return XSports.GetValue<FillOption>(
                Native.Motif.ResourceId.XmNfillOption, FillOption.None, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<FillOption>(
                Native.Motif.ResourceId.XmNfillOption, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginHeight XmCMargin VerticalDimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmarginHeight, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginWidth XmCMargin HorizontalDimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmarginWidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNorientation XmCOrientation unsigned char XmHORIZONTAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(
                    Native.Motif.ResourceId.XmNorientation, Orientation.Horizontal, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<Orientation>(
                    Native.Motif.ResourceId.XmNorientation, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdefaultButton XmCWidget Widget NULL SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual IWidget DefaultButton {
            get {
                return XSports.GetWidget<IWidget>(
                    Native.Motif.ResourceId.XmNdefaultButton, Data.Resource.Access.SG);
            }
            set {
                XSports.SetWidget<IWidget>(
                    Native.Motif.ResourceId.XmNdefaultButton, value, Data.Resource.Access.SG);
            }
        }

		#endregion


	}
}
