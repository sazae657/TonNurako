﻿//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// ScrolledWindow
	/// </summary>
	public class ScrolledWindow : Manager
	{
		public ScrolledWindow()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		/// <summary>
		/// ScrolledWindow作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create( IWidget parent )
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateScrolledWindow, parent, ToolkitResources);
			}
			return base.Create (parent);
		}


        /// XmNautoDragModel XmCAutoDragModel XtEnum XmAUTO_DRAG_ENABLED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual DragModel AutoDragModel {
            get {
                return XSports.GetValue<DragModel>(Native.Motif.ResourceId.XmNautoDragModel, DragModel.Enabled);
            }
            set {
                XSports.SetValue<DragModel>(Native.Motif.ResourceId.XmNautoDragModel, value);
            }
        }


        /// XmNclipWindow XmCClipWindow Widget dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget ClipWindow {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNclipWindow, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNclipWindow, value, Data.Resource.Access.CSG);
            }
        }


        /// XmNhorizontalScrollBar XmCHorizontalScrollBar Widget dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget HorizontalScrollBar {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNhorizontalScrollBar);
            }
            set {
            XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNhorizontalScrollBar, value);
            }
        }


        /// XmNscrollBarDisplayPolicy XmCScrollBarDisplayPolicy unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrollBarDisplayPolicy ScrollBarDisplayPolicy {
            get {
                return XSports.GetValue<ScrollBarDisplayPolicy>(
                    Native.Motif.ResourceId.XmNscrollBarDisplayPolicy, ScrollBarDisplayPolicy.AsNeeded);
            }
            set {
                XSports.GetValue<ScrollBarDisplayPolicy>(Native.Motif.ResourceId.XmNscrollBarDisplayPolicy, value);
            }
        }


        /// XmNscrollBarPlacement XmCScrollBarPlacement unsigned char XmBOTTOM_RIGHT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrollBarPlacement ScrollBarPlacement {
            get {
                return XSports.GetValue<ScrollBarPlacement>(Native.Motif.ResourceId.XmNscrollBarPlacement, ScrollBarPlacement.BottomRight);
            }
            set {
            XSports.SetValue<ScrollBarPlacement>(Native.Motif.ResourceId.XmNscrollBarPlacement, value);
            }
        }


        /// XmNscrolledWindowMarginHeight XmCScrolledWindowMarginHeight Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScrolledWindowMarginHeight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNscrolledWindowMarginHeight, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNscrolledWindowMarginHeight, value);
            }
        }


        /// XmNscrolledWindowMarginWidth XmCScrolledWindowMarginWidth Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScrolledWindowMarginWidth {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNscrolledWindowMarginWidth, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNscrolledWindowMarginWidth, value);
            }
        }


        /// XmNscrollingPolicy XmCScrollingPolicy unsigned char XmAPPLICATION_DEFINED CG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrollingPolicy ScrollingPolicy {
            get {
                return XSports.GetValue<ScrollingPolicy>(
                    Native.Motif.ResourceId.XmNscrollingPolicy, ScrollingPolicy.ApplicationDefined, Data.Resource.Access.CG);
            }
            set {
            XSports.SetValue<ScrollingPolicy>(Native.Motif.ResourceId.XmNscrollingPolicy, value, Data.Resource.Access.CG);
            }
        }


        /// XmNspacing XmCSpacing Dimension 4 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNspacing, 4);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNspacing, value);
            }
        }


        /// XmNverticalScrollBar XmCVerticalScrollBar Widget dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget VerticalScrollBar {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNverticalScrollBar);
            }
            set {
            XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNverticalScrollBar, value);
            }
        }


        /// XmNvisualPolicy XmCVisualPolicy unsigned char dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual VisualPolicy VisualPolicy {
            get {
                return XSports.GetValue<VisualPolicy>(
                    Native.Motif.ResourceId.XmNvisualPolicy, VisualPolicy.Static, Data.Resource.Access.G);
            }
        }


        /// XmNworkWindow XmCWorkWindow Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget WorkWindow {
            get {
                return XSports.GetWidget<IWidget>(Native.Motif.ResourceId.XmNworkWindow);
            }
            set {
            XSports.SetWidget<IWidget>(Native.Motif.ResourceId.XmNworkWindow, value);
            }
        }


        /// XmNscrolledWindowChildType XmCScrolledWindowChildType unsigned char RESOURCE_DEFAULT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrolledWindowChildType ScrolledWindowChildType {
            get {
                return XSports.GetValue<ScrolledWindowChildType>(
                    Native.Motif.ResourceId.XmNscrolledWindowChildType, ScrolledWindowChildType.GenericChild);
            }
            set {
                XSports.GetValue<ScrolledWindowChildType>(Native.Motif.ResourceId.XmNscrolledWindowChildType, value);
            }
        }


        /// XmNtraverseObscuredCallback XmCCallback XtCallbackList NULL CSG
        public virtual event EventHandler<Events.AnyEventArgs> TraverseObscuredEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNtraverseObscuredCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNtraverseObscuredCallback ,  value );
            }
        }


	}
}
