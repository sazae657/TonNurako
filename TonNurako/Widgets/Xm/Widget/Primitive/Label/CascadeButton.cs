//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// CascadeButton
    /// </summary>
    public class CascadeButton : LabelBase, IMenuWidget
    {

		public CascadeButton()  : base()
		{
		}
        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }


		/// <summary>
		/// Labelの作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateCascadeButton, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

        /// <summary>
        /// IMenuWidget用
        /// </summary>
        public IChild ExtremeMenuSports {
            get {
                return this;
            }
        }

        // ### UNKOWN TYPE
        // ### Name Class Type Default Access

        /// XmNcascadePixmap XmCPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap CascadePixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNcascadePixmap);
            }
            set {
                XSports.SetPixmap(Native.Motif.ResourceId.XmNcascadePixmap, value);
            }
        }


        /// XmNmappingDelay XmCMappingDelay int 180 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MappingDelay {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmappingDelay, 180);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNmappingDelay, value);
            }
        }

        // Widget XmNsubMenuId XmCMenuWidget Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IMenuWidget SubMenuId {
            get {
                return XSports.GetWidget<IMenuWidget>(Native.Motif.ResourceId.XmNsubMenuId);
            }
            set {
                XSports.SetChildWidget<IMenuWidget>(Native.Motif.ResourceId.XmNsubMenuId, value);
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
