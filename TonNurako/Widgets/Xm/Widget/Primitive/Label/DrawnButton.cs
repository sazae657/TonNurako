﻿//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// DrawnButton
	/// </summary>
	public class DrawnButton : LabelBase, IDefectiveWidget
	{

		public DrawnButton() : base() {
            PushButtonEventTable = new TnkXtEvents<Events.PushButtonEventArgs>();
		}

        internal TnkXtEvents<Events.PushButtonEventArgs> PushButtonEventTable {
            get;
        }

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// DrawnButton生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateDrawnButton, parent, ToolkitResources);
			}
			return base.Create (parent);
		}


		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNmultiClick XmCMultiClick unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MultiClick MultiClick {
            get {
                return XSports.GetValue<MultiClick>(
                    Native.Motif.ResourceId.XmNmultiClick, MultiClick.Discard, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<MultiClick>(
                    Native.Motif.ResourceId.XmNmultiClick, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNpushButtonEnabled XmCPushButtonEnabled Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool PushButtonEnabled {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNpushButtonEnabled, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNpushButtonEnabled, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNshadowType XmCShadowType unsigned char XmSHADOW_ETCHED_IN CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShadowType ShadowType {
            get {
                return XSports.GetValue<ShadowType>(
                Native.Motif.ResourceId.XmNshadowType, ShadowType.EtchedIn, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ShadowType>(
                    Native.Motif.ResourceId.XmNshadowType, value, Data.Resource.Access.CSG);
            }
        }
        #endregion

		#region ｲﾍﾞﾝﾄ

        /// XmNactivateCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> ActivateEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNactivateCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNactivateCallback ,  value );
            }
        }

        /// XmNarmCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> ArmEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNarmCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNarmCallback ,  value );
            }
        }

        /// XmNdisarmCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> DisarmEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNdisarmCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNdisarmCallback ,  value );
            }
        }

        /// XmNexposeCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> ExposeEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNexposeCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNexposeCallback ,  value );
            }
        }

        /// XmNresizeCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> ResizeEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNresizeCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNresizeCallback ,  value );
            }
        }

		#endregion
	}
}

