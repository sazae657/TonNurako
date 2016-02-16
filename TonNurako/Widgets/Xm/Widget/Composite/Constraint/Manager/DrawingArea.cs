using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// DrawingArea
	/// </summary>
	public class DrawingArea : Manager, IDefectiveWidget
	{

		#region 生成

		public DrawingArea() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }



		/// <summary>
		/// DrawingArea生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateDrawingArea, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// <summary>
        /// XmNmarginHeight
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmarginHeight, 10, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmarginWidth
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNmarginWidth, 10, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNresizePolicy
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ResizePolicy ResizePolicy {
            get {
                return XSports.GetValue<ResizePolicy>(
                Native.Motif.ResourceId.XmNresizePolicy, ResizePolicy.Any, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<ResizePolicy>(
                Native.Motif.ResourceId.XmNresizePolicy, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

        /// <summary>
        /// XmNconvertCallback
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> ConvertEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNconvertCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNconvertCallback ,  value );
            }
        }

        /// <summary>
        /// XmNdestinationCallback
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> DestinationEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNdestinationCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNdestinationCallback ,  value );
            }
        }

        /// <summary>
        /// XmNexposeCallback
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> ExposeEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNexposeCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNexposeCallback ,  value );
            }
        }

        /// <summary>
        /// XmNinputCallback
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> InputEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNinputCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNinputCallback ,  value );
            }
        }

        /// <summary>
        /// XmNresizeCallback
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> ResizeEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNresizeCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNresizeCallback ,  value );
            }
        }

		#endregion

	}
}
