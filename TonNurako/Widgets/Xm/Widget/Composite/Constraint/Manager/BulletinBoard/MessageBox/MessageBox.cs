//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// MessageBox
	/// </summary>
	public class MessageBox : BulletinBoard
	{

        /// <summary>
        /// 子のID
        /// </summary>
        internal enum ChildId {
            XmDIALOG_CANCEL_BUTTON = Native.Motif.Constant.XmDIALOG_CANCEL_BUTTON,

            XmDIALOG_DEFAULT_BUTTON = Native.Motif.Constant.XmDIALOG_DEFAULT_BUTTON,

            XmDIALOG_HELP_BUTTON = Native.Motif.Constant.XmDIALOG_HELP_BUTTON,

            XmDIALOG_MESSAGE_LABEL = Native.Motif.Constant.XmDIALOG_MESSAGE_LABEL,

            XmDIALOG_OK_BUTTON = Native.Motif.Constant.XmDIALOG_OK_BUTTON,

            XmDIALOG_SEPARATOR = Native.Motif.Constant.XmDIALOG_SEPARATOR,

            XmDIALOG_SYMBOL_LABEL = Native.Motif.Constant.XmDIALOG_SYMBOL_LABEL
        }

		#region 固有

		public MessageBox()  : base()
		{
            Items = new DlgItems();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        public override void Destroy() {
            Items.Clear();
            base.Destroy();
        }

        internal static class NativeMethods {
            //XmMessageBoxGetChild
            [DllImport(Native.ExtremeSports.Lib, EntryPoint = "XmMessageBoxGetChild_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XmMessageBoxGetChild(IntPtr widget, byte id);
        }
        internal IntPtr GetChild(ChildId id) {
            return NativeMethods.XmMessageBoxGetChild(this.NativeHandle.Widget, (byte)id);
        }


		#endregion

        public class DlgItems {
            public DlgItems() {
                Children = new List<Widget>();

                OK = new PushButtonGadget();
                Children.Add(OK);

                Cancel = new PushButtonGadget();
                Children.Add(Cancel);

                Help = new PushButtonGadget();
                Children.Add(Help);

                Message = new LabelGadget();
                Children.Add(Message);

                Symbol = new LabelGadget();
                Children.Add(Symbol);

                Separator = new SeparatorGadget();
                Children.Add(Separator);
            }

            internal void Clear() {
                Children.Clear();
                OK =null;
                Cancel = null;
                Help = null;
                Message = null;
                Symbol = null;
                Separator = null;
            }

            internal List<Widget> Children;

            public PushButtonGadget OK {
                get; internal set;
            }
            public PushButtonGadget Cancel {
                get; internal set;
            }

            public PushButtonGadget Help {
                get; internal set;
            }

            public LabelGadget Message {
                get; internal set;
            }

            public LabelGadget Symbol {
                get; internal set;
            }

            public SeparatorGadget Separator {
                get; internal set;
            }
        }

        public DlgItems Items {
            get;
        }

		#region ｳｲｼﾞｪｯﾄ作成

		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateMessageBox, parent, ToolkitResources);
			}
            RegisterChildren();

			return base.Create (parent);
		}

        /// <summary>
        /// 子をTNKに登録する
        /// </summary>
        internal virtual void RegisterChildren() {
            IntPtr w;
            w = GetChild(ChildId.XmDIALOG_OK_BUTTON);
            if (IntPtr.Zero != w) {
                Items.OK.WrapExistingWidget(w);
                this.Children.Add(Items.OK);
            }

            w = GetChild(ChildId.XmDIALOG_CANCEL_BUTTON);
            if (IntPtr.Zero != w) {
                Items.Cancel.WrapExistingWidget(w);
                this.Children.Add(Items.Cancel);
            }
            w = GetChild(ChildId.XmDIALOG_HELP_BUTTON);
            if (IntPtr.Zero != w) {
                Items.Help.WrapExistingWidget(w);
                this.Children.Add(Items.Help);
            }

            w = GetChild(ChildId.XmDIALOG_MESSAGE_LABEL);
            if (IntPtr.Zero != w) {
                Items.Message.WrapExistingWidget(w);
                this.Children.Add(Items.Message);
            }

            w = GetChild(ChildId.XmDIALOG_SYMBOL_LABEL);
            if (IntPtr.Zero != w) {
                Items.Symbol.WrapExistingWidget(w);
                this.Children.Add(Items.Symbol);
            }

            w = GetChild(ChildId.XmDIALOG_SEPARATOR);
            if (IntPtr.Zero != w) {
                Items.Separator.WrapExistingWidget(w);
                this.Children.Add(Items.Separator);
            }

            // Unmapだけ
            //this.UnmapEvent += (s, e ) => {
            //   Destroy();
            //};
        }

		#endregion

        #region ﾘｿーｽ
        /*
            XmMessageBox Resource Set
            Name	Class	Type	Default	Access

        */

        /// XmNsymbolPixmap	XmCPixmap	Pixmap	dynamic	CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap SymbolPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNsymbolPixmap);
            }
            set {
                XSports.SetPixmap(Native.Motif.ResourceId.XmNsymbolPixmap, value);
            }
        }

        /// XmNcancelLabelString XmCCancelLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string CancelLabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNcancelLabelString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNcancelLabelString, value);
            }
        }


        /// XmNdefaultButtonType XmCDefaultButtonType unsigned char XmDIALOG_OK_BUTTON CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual DefaultButtonType DefaultButtonType {
            get {
                return XSports.GetValue(Native.Motif.ResourceId.XmNdefaultButtonType, DefaultButtonType.Ok);
            }
            set {
                XSports.SetValue(Native.Motif.ResourceId.XmNdefaultButtonType, value);
            }
        }


        /// XmNdialogType XmCDialogType unsigned char XmDIALOG_MESSAGE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MessageDialogType DialogType {
            get {
                return XSports.GetValue(Native.Motif.ResourceId.XmNdialogType, MessageDialogType.Message);
            }
            set {
                XSports.SetValue(Native.Motif.ResourceId.XmNdialogType, value);
            }
        }


        /// XmNhelpLabelString XmCHelpLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string HelpLabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNhelpLabelString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNhelpLabelString, value);
            }
        }


        /// XmNmessageAlignment XmCAlignment unsigned char XmALIGNMENT_BEGINNING CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment MessageAlignment {
            get {
                return XSports.GetValue(Native.Motif.ResourceId.XmNmessageAlignment, Alignment.Beginning);
            }
            set {
                XSports.SetValue(Native.Motif.ResourceId.XmNmessageAlignment, value);
            }
        }


        /// XmNmessageString XmCMessageString XmString "" CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string MessageString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNmessageString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNmessageString, value);
            }
        }


        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string LabelString {
            get {
                return MessageString;
            }
            set {
                 MessageString = value;
            }
        }


        /// XmNminimizeButtons XmCMinimizeButtons Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool MinimizeButtons {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNminimizeButtons, false);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNminimizeButtons, value);
            }
        }


        /// XmNokLabelString XmCOkLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string OkLabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNokLabelString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNokLabelString, value);
            }
        }

        #endregion

        /// XmNcancelCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> CancelEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNcancelCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNcancelCallback ,  value );
            }
        }


        /// XmNokCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> OkEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNokCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNokCallback ,  value );
            }
        }
	}
}
