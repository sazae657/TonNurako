//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// DropDown
	/// </summary>
	public class DropDown : Manager, IDefectiveWidget
	{
        // TODO
        // Widget XmDropDownGetChild(Widget widget,int child);
        // XmDROPDOWN_LABEL
        // XmDROPDOWN_TEXT
        // XmDROPDOWN_ARROW_BUTTON
        // XmDROPDOWN_LIST
        //

		public DropDown() : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// DropDown生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateDropDown, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

        #region 固有

        public void SetItem(string[] items) {
            this.ItemCount = items.Length;
            using(var cs = new Data.CompoundStringTable(items)) {
                this.Items = cs;
            }
        }

        #endregion

		#region ﾌﾟﾛﾊﾟﾁー
        /// XmNcustomizedCombinationBox XmCBoolean Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool CustomizedCombinationBox {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNcustomizedCombinationBox, false);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNcustomizedCombinationBox, value);
            }
        }

        /// XmNeditable XmCBoolean Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Editable {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNeditable, true);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNeditable, value);
            }
        }

        /// XmNhorizontalMargin XmCMargin Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HorizontalMargin {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNhorizontalMargin, 2);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNhorizontalMargin, value);
            }
        }

        /// XmNitemCount list int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ItemCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNitemCount, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNitemCount, value);
            }
        }

        /// XmNitems list XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public Data.CompoundStringTable Items {
            get {
                return XSports.GetStringTable(Native.Motif.ResourceId.XmNitems, ItemCount, true);
            }
            set {
                XSports.SetStringTable(Native.Motif.ResourceId.XmNitems, value);
            }
        }

        /// XmNlabelString label XmString "label" CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string LabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNlabelString, "");
            }
            set {
            XSports.SetString(Native.Motif.ResourceId.XmNlabelString, value);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNpopupCursor XmCCursor Cursor left_ptr CSG

        /// XmNpopupOffset MxCPopupOffset int 15 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PopupOffset {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNpopupOffset, 15);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNpopupOffset, value);
            }
        }

        /// XmNpopupShellWidget XmCWidget Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget PopupShellWidget {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNpopupShellWidget);
            }
            set {
                XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNpopupShellWidget, value);
            }
        }

        /// XmNshowLabel XmCBoolean Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ShowLabel {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNshowLabel, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNshowLabel, value);
            }
        }

        /// XmNuseTextField XmCUseTextField Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool UseTextField {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNuseTextField, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNuseTextField, value);
            }
        }

        /// XmNvalue text String "" CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Value {
            get {
                return XSports.GetAnsiString(Native.Motif.ResourceId.XmNvalue, "");
            }
            set {
            XSports.SetAnsiString(Native.Motif.ResourceId.XmNvalue, value);
            }
        }

        /// XmNverify XmCVerify Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Verify {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNverify, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNverify, value);
            }
        }

        /// XmNverticalMargin XmCMargin Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VerticalMargin {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNverticalMargin, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNverticalMargin, value);
            }
        }

        /// XmNvisibleItemCount XmCVisibleItemCount int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VisibleItemCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNvisibleItemCount, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNvisibleItemCount, value);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

        /// XmNupdateShellCallback XmCCallback XtCallbackList NULL CSG
        public virtual event EventHandler<Events.AnyEventArgs> UpdateShellEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNupdateShellCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNupdateShellCallback ,  value );
            }
        }

        /// XmNupdateTextCallback XmCCallback XtCallbackList NULL CSG
        public virtual event EventHandler<Events.AnyEventArgs> UpdateTextEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNupdateTextCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNupdateTextCallback ,  value );
            }
        }

        /// XmNverifyTextCallback XmCCallback XtCallbackList NULL CSG
        public virtual event EventHandler<Events.AnyEventArgs> VerifyTextEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNverifyTextCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNverifyTextCallback ,  value );
            }
        }

		#endregion

	}
}
