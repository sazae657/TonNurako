using System;
using System.Runtime.InteropServices;

namespace TonNurako.Widgets.Xm
{
    public enum EntryViewType : byte
    {
        Any = Native.Motif.Constant.XmANY_ICON,
        Large = Native.Motif.Constant.XmLARGE_ICON,
        Small = Native.Motif.Constant.XmSMALL_ICON,
    }

    public enum LayoutType : byte
    {
        Detail = Native.Motif.Constant.XmDETAIL,
        Outline = Native.Motif.Constant.XmOUTLINE,
        Spatial = Native.Motif.Constant.XmSPATIAL,
    }

    public enum OutlineButtonPolicy : byte
    {
        Absent = Native.Motif.Constant.XmOUTLINE_BUTTON_ABSENT,
        Present = Native.Motif.Constant.XmOUTLINE_BUTTON_PRESENT
    }

    public enum LineStyle : byte
    {
        NoLine = Native.Motif.Constant.XmNO_LINE,
        Single = Native.Motif.Constant.XmSINGLE
    }

    public enum SelectionTechnique : byte
    {
        Marquee = Native.Motif.Constant.XmMARQUEE,
        MarqueeExtendStart = Native.Motif.Constant.XmMARQUEE_EXTEND_START,
        MarqueeExtendBoth = Native.Motif.Constant.XmMARQUEE_EXTEND_BOTH,
        TouchOnly = Native.Motif.Constant.XmTOUCH_ONLY,
        TouchOver = Native.Motif.Constant.XmTOUCH_OVER

    }

    public enum SpatialIncludeModel : byte
    {
        Append = Native.Motif.Constant.XmAPPEND,
        Closest = Native.Motif.Constant.XmCLOSEST,
        FirstFit = Native.Motif.Constant.XmFIRST_FIT
    }

    public enum SpatialResizeModel : byte
    {
        GrowBalanced = Native.Motif.Constant.XmGROW_BALANCED,
        GrowMajor = Native.Motif.Constant.XmGROW_MAJOR,
        GrowMinor = Native.Motif.Constant.XmGROW_MINOR
    }
    public enum SpatialSnapModel : byte
    {
        Center = Native.Motif.Constant.XmCENTER,
        SnapToGrid = Native.Motif.Constant.XmSNAP_TO_GRID,
        None = Native.Motif.Constant.XmNONE
    }

    public enum SpatialStyle : byte
    {
        Cells = Native.Motif.Constant.XmCELLS,
        Grid = Native.Motif.Constant.XmGRID,
        None = Native.Motif.Constant.XmNONE
    }

    public enum OutlineState : byte {
        Collapsed = Native.Motif.Constant.XmCOLLAPSED,
        Expanded = Native.Motif.Constant.XmEXPANDED,
    }

    /// <summary>
    /// Container (XmContainer.txt)
    /// </summary>
    public class Container : Manager, IDefectiveWidget
    {

        #region 生成

        public Container() : base()
        {
        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }



        /// <summary>
        /// Container生成
        /// </summary>
        /// <param name="parent">親</param>
        /// <returns></returns>
        public override int Create(IWidget parent)
        {
            if (!IsAvailable)
            {
                this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateContainer, parent, ToolkitResources);
            }
            return base.Create(parent);
        }
        #endregion


        #region ﾌﾟﾛﾊﾟﾁー

        /// <summary>
        /// XmNautomaticSelection XmCAutomaticSelection unsigned char XmAUTO_SELECT CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual AutomaticSelection AutomaticSelection
        {
            get
            {
                return XSports.GetValue<AutomaticSelection>(
                   Native.Motif.ResourceId.XmNautomaticSelection, AutomaticSelection.Auto, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<AutomaticSelection>(
                    Native.Motif.ResourceId.XmNautomaticSelection, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNcollapsedStatePixmap XmCCollapsedStatePixmap Pixmap dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap CollapsedStatePixmap
        {
            get
            {
                return XSports.GetPixmap(
                   Native.Motif.ResourceId.XmNcollapsedStatePixmap, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetPixmap(
                    Native.Motif.ResourceId.XmNcollapsedStatePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNdetailColumnHeading XmCDetailColumnHeading XmStringTable NULL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.CompoundStringTable DetailColumnHeading
        {
            get
            {
                return XSports.GetStringTable(
                   Native.Motif.ResourceId.XmNdetailColumnHeading, DetailColumnHeadingCount, true, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetStringTable(
                    Native.Motif.ResourceId.XmNdetailColumnHeading, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNdetailColumnHeadingCount XmCDetailColumnHeadingCount Cardinal 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailColumnHeadingCount
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNdetailColumnHeadingCount, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNdetailColumnHeadingCount, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        // XmNdetailOrder XmCDetailOrder Cardinal * NULL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int [] DetailOrder {
            get {
                int count = 0;
                if (0 == (count = DetailOrderCount)) {
                    return new int[]{};
                }
                IntPtr listRef = XSports.GetPtr(Native.Motif.ResourceId.XmNdetailOrder);
                int [] ret = new int[count];
                Marshal.Copy(listRef, ret, 0, count);
                // listRefはfreeしちゃﾀﾞﾒ
                return ret;
            }
            set {
                IntPtr ptr = IntPtr.Zero;
                int count = value.Length;
                ToolkitResources.Begin();
                try {
                    DetailOrderCount = count;
                    if (0 != count) {
                        ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * value.Length);
                        Marshal.Copy(value, 0, ptr, value.Length);
                        XSports.SetPtr(Native.Motif.ResourceId.XmNdetailOrder, ptr, Data.Resource.Access.CSG);
                    }
                }finally {
                    ToolkitResources.Commit(true);
                    if(IntPtr.Zero != ptr) {
                        Marshal.FreeCoTaskMem(ptr);
                    }
                }
            }
        }

        /// <summary>
        /// XmNdetailOrderCount XmCDetailOrderCount Cardinal dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailOrderCount
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNdetailOrderCount, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNdetailOrderCount, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNdetailTabList XmCDetailTabList XmTabList NULL CSG
        /// </summary>
        public virtual Data.TabList DetailTabList
        {
            get
            {
                Data.TabList tab = new Data.TabList(
                    XSports.GetPtr(Native.Motif.ResourceId.XmNdetailTabList,  Data.Resource.Access.CSG));
                return tab;
            }
            set
            {
                XSports.SetPtr(
                    Native.Motif.ResourceId.XmNdetailTabList, value.Handle, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNentryViewType XmCEntryViewType unsigned char XmANY_ICON CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual EntryViewType EntryViewType
        {
            get
            {
                return XSports.GetValue<EntryViewType>(
                   Native.Motif.ResourceId.XmNentryViewType, EntryViewType.Any, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<EntryViewType>(
                    Native.Motif.ResourceId.XmNentryViewType, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNexpandedStatePixmap XmCExpandedStatePixmap Pixmap dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap ExpandedStatePixmap
        {
            get
            {
                return XSports.GetPixmap(
                   Native.Motif.ResourceId.XmNexpandedStatePixmap, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetPixmap(
                    Native.Motif.ResourceId.XmNexpandedStatePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlargeCellHeight XmCCellHeight Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int LargeCellHeight
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNlargeCellHeight, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNlargeCellHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlargeCellWidth XmCCellWidth Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int LargeCellWidth
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNlargeCellWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNlargeCellWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlayoutType XmCLayoutType unsigned char XmSPATIAL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual LayoutType LayoutType
        {
            get
            {
                return XSports.GetValue<LayoutType>(
                   Native.Motif.ResourceId.XmNlayoutType, LayoutType.Spatial, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<LayoutType>(
                    Native.Motif.ResourceId.XmNlayoutType, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmarginHeight XmCMarginHeight Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNmarginHeight, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmarginWidth XmCMarginWidth Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNmarginWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineButtonPolicy XmCOutlineButtonPolicy unsigned char XmOUTLINE_BUTTON_PRESENT CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual OutlineButtonPolicy OutlineButtonPolicy
        {
            get
            {
                return XSports.GetValue<OutlineButtonPolicy>(
                   Native.Motif.ResourceId.XmNoutlineButtonPolicy, OutlineButtonPolicy.Present, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<OutlineButtonPolicy>(
                    Native.Motif.ResourceId.XmNoutlineButtonPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineColumnWidth XmCOutlineColumnWidth Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int OutlineColumnWidth
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNoutlineColumnWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNoutlineColumnWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineIndentation XmCOutlineIndentation Dimension 40 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int OutlineIndentation
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNoutlineIndentation, 40, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNoutlineIndentation, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineLineStyle XmCLineStyle unsigned char XmSINGLE CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual LineStyle OutlineLineStyle
        {
            get
            {
                return XSports.GetValue<LineStyle>(
                   Native.Motif.ResourceId.XmNoutlineLineStyle, LineStyle.Single, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<LineStyle>(
                    Native.Motif.ResourceId.XmNoutlineLineStyle, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNprimaryOwnership XmCprimaryOwnership unsigned char XmOWN_POSSIBLE_MULTIPLE CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual PrimaryOwnership PrimaryOwnership
        {
            get
            {
                return XSports.GetValue<PrimaryOwnership>(
                   Native.Motif.ResourceId.XmNprimaryOwnership, PrimaryOwnership.Multiple, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<PrimaryOwnership>(
                    Native.Motif.ResourceId.XmNprimaryOwnership, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable RenderTable
        {
            get
            {
                return XSports.GetRenderTable(
                   Native.Motif.ResourceId.XmNrenderTable, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetRenderTable(
                    Native.Motif.ResourceId.XmNrenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNselectColor XmCSelectColor Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color SelectColor
        {
            get
            {
                return XSports.GetColor(
                   Native.Motif.ResourceId.XmNselectColor, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetColor(
                    Native.Motif.ResourceId.XmNselectColor, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// ### XmNselectedObjects XmCSelectedObjects WidgetList NULL SG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual Data.WidgetList SelectedObjects {
            get{
                IntPtr p = XSports.GetPtr(
                   Native.Motif.ResourceId.XmNselectedObjects, Data.Resource.Access.SG);

                int count = SelectedObjectCount;
                var w = new Data.WidgetList(this.AppContext, p, count);
                return w;
            }
            set {
                int count = value.Count;
                ToolkitResources.Begin();
                try {
                    SelectedObjectCount = count;
                    if (0 != count) {
                        XSports.SetPtr(Native.Motif.ResourceId.XmNselectedObjects, value.ToPointer(), Data.Resource.Access.CSG);
                    }
                }finally {
                    ToolkitResources.Commit(true);
                }
            }

        }

        /// <summary>
        /// XmNselectedObjectCount XmCSelectedObjectCount unsigned int 0 SG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual int SelectedObjectCount
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNselectedObjectCount, 0, Data.Resource.Access.SG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNselectedObjectCount, value, Data.Resource.Access.SG);
            }
        }

        /// <summary>
        /// XmNselectionPolicy XmCSelectionPolicy unsigned char XmEXTENDED_SELECT CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectionPolicy SelectionPolicy
        {
            get
            {
                return XSports.GetValue<SelectionPolicy>(
                   Native.Motif.ResourceId.XmNselectionPolicy, SelectionPolicy.Extended, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SelectionPolicy>(
                    Native.Motif.ResourceId.XmNselectionPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNselectionTechnique XmCSelectionTechnique unsigned char XmTOUCH_OVER CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectionTechnique SelectionTechnique
        {
            get
            {
                return XSports.GetValue<SelectionTechnique>(
                   Native.Motif.ResourceId.XmNselectionTechnique, SelectionTechnique.TouchOver, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SelectionTechnique>(
                    Native.Motif.ResourceId.XmNselectionTechnique, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsmallCellHeight XmCCellHeight Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SmallCellHeight
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNsmallCellHeight, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNsmallCellHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsmallCellWidth XmCCellWidth Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SmallCellWidth
        {
            get
            {
                return XSports.GetInt(
                   Native.Motif.ResourceId.XmNsmallCellWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNsmallCellWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialIncludeModel XmCSpatialIncludeModel unsigned char XmAPPEND CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialIncludeModel SpatialIncludeModel
        {
            get
            {
                return XSports.GetValue<SpatialIncludeModel>(
                   Native.Motif.ResourceId.XmNspatialIncludeModel, SpatialIncludeModel.Append, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialIncludeModel>(
                    Native.Motif.ResourceId.XmNspatialIncludeModel, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialResizeModel XmCSpatialResizeModel unsigned char XmGROW_MINOR CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialResizeModel SpatialResizeModel
        {
            get
            {
                return XSports.GetValue<SpatialResizeModel>(
                   Native.Motif.ResourceId.XmNspatialResizeModel, SpatialResizeModel.GrowMinor, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialResizeModel>(
                    Native.Motif.ResourceId.XmNspatialResizeModel, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialSnapModel XmCSpatialSnapModel unsigned char XmNONE CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialSnapModel SpatialSnapModel
        {
            get
            {
                return XSports.GetValue<SpatialSnapModel>(
                   Native.Motif.ResourceId.XmNspatialSnapModel, SpatialSnapModel.None, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialSnapModel>(
                    Native.Motif.ResourceId.XmNspatialSnapModel, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialStyle XmCSpatialStyle unsigned char XmGRID CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialStyle SpatialStyle
        {
            get
            {
                return XSports.GetValue<SpatialStyle>(
                   Native.Motif.ResourceId.XmNspatialStyle, SpatialStyle.Grid, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialStyle>(
                    Native.Motif.ResourceId.XmNspatialStyle, value, Data.Resource.Access.CSG);
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄ

        /// <summary>
        /// XmNconvertCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> ConvertEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNconvertCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNconvertCallback, value);
            }
        }

        /// <summary>
        /// XmNdefaultActionCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> DefaultActionEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNdefaultActionCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNdefaultActionCallback, value);
            }
        }

        /// <summary>
        /// XmNdestinationCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> DestinationEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNdestinationCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNdestinationCallback, value);
            }
        }

        /// <summary>
        /// XmNoutlineChangedCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> OutlineChangedEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNoutlineChangedCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNoutlineChangedCallback, value);
            }
        }

        /// <summary>
        /// XmNselectionCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> SelectionEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNselectionCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNselectionCallback, value);
            }
        }

        #endregion

    }
}
