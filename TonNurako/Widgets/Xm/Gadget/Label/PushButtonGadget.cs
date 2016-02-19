//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// PushButtonGadget
    /// </summary>
    public class PushButtonGadget : LabelGadget
    {
		#region ｳｲｼﾞｪｯﾄ作成
		public PushButtonGadget()  : base()
		{
            PushButtonEventTable = new TnkXtEvents<Events.PushButtonEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


        TnkXtEvents<Events.PushButtonEventArgs> PushButtonEventTable {
            get;
        }

		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifGadget(Native.Motif.CreateSymbol.XmCreatePushButtonGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
		#endregion


        /// XmNarmColor XmCArmColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color ArmColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNarmColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNarmColor, value);
            }
        }


        /// XmNarmPixmap XmCArmPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap ArmPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNarmPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNarmPixmap, value);
            }
        }


        /// XmNdefaultButtonShadowThickness XmCdefaultButtonShadowThickness Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DefaultButtonShadowThickness {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNdefaultButtonShadowThickness, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNdefaultButtonShadowThickness, value);
            }
        }


        /// XmNfillOnArm XmCFillOnArm Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool FillOnArm {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNfillOnArm, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNfillOnArm, value);
            }
        }


        /// XmNmultiClick XmCMultiClick unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MultiClick MultiClick {
            get {
                return XSports.GetValue<MultiClick>(Native.Motif.ResourceId.XmNmultiClick, MultiClick.Discard);
            }
            set {
                XSports.SetValue<MultiClick>(Native.Motif.ResourceId.XmNmultiClick, value);
            }
        }


        /// XmNshowAsDefault XmCShowAsDefault Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ShowAsDefault {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNshowAsDefault, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNshowAsDefault, value);
            }
        }


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

    }
}
