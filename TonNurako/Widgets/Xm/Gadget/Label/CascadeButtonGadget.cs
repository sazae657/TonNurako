//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// CascadeButtonGadget
    /// </summary>
    public class CascadeButtonGadget : LabelGadget, IMenuWidget
    {
		public CascadeButtonGadget()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public IChild ExtremeMenuSports { get{return this;} }

		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifGadget(Native.Motif.CreateSymbol.XmCreateCascadeButtonGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

        /// XmNcascadePixmap XmCPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap CascadePixmap {
            get {
                return XSports.GetPixmap(
                    Native.Motif.ResourceId.XmNcascadePixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                 Native.Motif.ResourceId.XmNcascadePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmappingDelay XmCMappingDelay int 180 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MappingDelay {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmappingDelay, 180, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmappingDelay, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsubMenuId XmCMenuWidget Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IMenuWidget SubMenuId {
            get {
                return XSports.GetWidget<IMenuWidget>(
                    Native.Motif.ResourceId.XmNsubMenuId, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetWidget<IMenuWidget>(
                    Native.Motif.ResourceId.XmNsubMenuId, value, Data.Resource.Access.CSG);
            }
        }


        /// XmNactivateCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ActivateEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNactivateCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNactivateCallback ,  value );
            }
        }

        /// XmNcascadingCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> CascadingEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNcascadingCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNcascadingCallback ,  value );
            }
        }
    }
}
