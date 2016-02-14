﻿//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SelectionBox
	/// </summary>
	public class SelectionBox : BulletinBoard
	{
		public SelectionBox()  : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		/// <summary>
		/// 作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateSelectionBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

        internal enum ChildId :byte {
            XmDIALOG_APPLY_BUTTON = Native.Motif.Constant.XmDIALOG_APPLY_BUTTON,

            XmDIALOG_CANCEL_BUTTON = Native.Motif.Constant.XmDIALOG_CANCEL_BUTTON,

            XmDIALOG_DEFAULT_BUTTON = Native.Motif.Constant.XmDIALOG_DEFAULT_BUTTON,

            XmDIALOG_HELP_BUTTON = Native.Motif.Constant.XmDIALOG_HELP_BUTTON,

            XmDIALOG_LIST = Native.Motif.Constant.XmDIALOG_LIST,

            XmDIALOG_LIST_LABEL = Native.Motif.Constant.XmDIALOG_LIST_LABEL,

            XmDIALOG_OK_BUTTON = Native.Motif.Constant.XmDIALOG_OK_BUTTON,

            XmDIALOG_SELECTION_LABEL = Native.Motif.Constant.XmDIALOG_SELECTION_LABEL,

            XmDIALOG_SEPARATOR = Native.Motif.Constant.XmDIALOG_SEPARATOR,

            XmDIALOG_TEXT = Native.Motif.Constant.XmDIALOG_TEXT,
            XmDIALOG_WORK_AREA = Native.Motif.Constant.XmDIALOG_WORK_AREA
        }


        //XmSelectionBoxGetChild
        internal class NativeMethods {
            [DllImport(Native.ExtremeSports.Lib, EntryPoint = "XmMessageBoxGetChild_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XmSelectionBoxGetChild(IntPtr widget, byte id);
        }
        internal IntPtr GetChild(ChildId id) {
            return NativeMethods.XmSelectionBoxGetChild(this.NativeHandle.Widget, (byte)id);
        }

        #region ﾌﾟﾛﾊﾟﾁー
        /// XmNapplyLabelString XmCApplyLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string ApplyLabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNapplyLabelString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNapplyLabelString, value);
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


        /// XmNchildPlacement XmCChildPlacement unsigned char XmPLACE_ABOVE_SELECTION CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Placement ChildPlacement {
            get {
                return XSports.GetValue<Placement>(Native.Motif.ResourceId.XmNchildPlacement, Placement.AboveSelection);
            }
            set {
                XSports.SetValue<Placement>(Native.Motif.ResourceId.XmNchildPlacement, value);
            }
        }


        /// XmNdialogType XmCDialogType unsigned char dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual DialogType DialogType {
            get {
                return XSports.GetValue<DialogType>(
                    Native.Motif.ResourceId.XmNdialogType, DialogType.Command, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<DialogType>(Native.Motif.ResourceId.XmNdialogType, value, Data.Resource.Access.CG);
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


        /// XmNlistItemCount XmCItemCount int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ListItemCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNlistItemCount, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNlistItemCount, value);
            }
        }

        /// XmNlistItems XmCItems XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public Data.CompoundStringTable ListItems {
            get {
                return XSports.GetStringTable(Native.Motif.ResourceId.XmNlistItems, ListItemCount, true);
            }
            set {
                ListItemCount = value.Count;
                XSports.SetStringTable(Native.Motif.ResourceId.XmNlistItems, value);
            }
        }

        /// XmNlistLabelString XmCListLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string ListLabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNlistLabelString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNlistLabelString, value);
            }
        }


        /// XmNlistVisibleItemCount XmCVisibleItemCount int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ListVisibleItemCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNlistVisibleItemCount, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNlistVisibleItemCount, value);
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


        /// XmNmustMatch XmCMustMatch Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool MustMatch {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNmustMatch, false);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNmustMatch, value);
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


        /// XmNselectionLabelString XmCSelectionLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string SelectionLabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNselectionLabelString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNselectionLabelString, value);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNtextAccelerators XmCTextAccelerators XtAccelerators default C

        /// XmNtextColumns XmCColumns short dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TextColumns {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtextColumns, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNtextColumns, value);
            }
        }

        /// XmNtextString XmCTextString XmString "" CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string TextString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNtextString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNtextString, value);
            }
        }
        #endregion

        #region ｴﾍﾞﾝﾄ

        /// XmNapplyCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ApplyEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNapplyCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNapplyCallback ,  value );
            }
        }


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


        /// XmNnoMatchCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> NoMatchEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNnoMatchCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNnoMatchCallback ,  value );
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
        #endregion
    }
}
