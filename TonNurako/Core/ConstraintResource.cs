//
// ﾄﾝﾇﾗｺ
//
// 束縛ﾘｿーｽｱｸｾｯｻー
//

using TonNurako.Data;
using TonNurako.Widgets.Xm;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// 束縛ﾘｿーｽ
    /// </summary>
    /// <typeparam name="T">束縛付きｳｲｼﾞｪｯﾄ</typeparam>
    public class ConstraintResource<T> where T:Widgets.IWidget {
        public Widget Widget {
            get; internal set;
        }
        public Data.ExtremeResourceSports XSports {
            get {
                return Widget.XSports;
            }
        }

        public ConstraintResource(Widget widget) {
            Widget = widget;
        }
    }

    /// <summary>
    /// XmTabStack束縛ﾘｿーｽ
    /// </summary>
    public class TabStackConstraint : ConstraintResource<TabStack> {
        public TabStackConstraint(Widget widget) : base(widget) {
        }

        /// <summary>
        ///  XmNfreeTabPixmap
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool FreeTabPixmap {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNfreeTabPixmap, false);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNfreeTabPixmap, value);
            }
        }

        /// <summary>
        /// XmNtabAlignment
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment TabAlignment {
            get {
                return XSports.GetValue<Alignment>(Native.Motif.ResourceId.XmNtabAlignment, Alignment.Center);
            }
            set {
                XSports.SetValue<Alignment>(Native.Motif.ResourceId.XmNtabAlignment, value);
            }
        }

        /// <summary>
        /// XmNtabBackground
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color TabBackground {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNtabBackground);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNtabBackground, value);
            }
        }

        /// <summary>
        /// XmNtabBackgroundPixmap
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap TabBackgroundPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNtabBackgroundPixmap);
            }
            set {
                XSports.SetPixmap(Native.Motif.ResourceId.XmNtabBackgroundPixmap, value);
            }
        }

        /// <summary>
        /// XmNtabForeground
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color TabForeground {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNtabForeground);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNtabForeground, value);
            }
        }

        /// <summary>
        /// XmNtabLabelPixmap
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap TabLabelPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNtabLabelPixmap);
            }
            set {
                XSports.SetPixmap(Native.Motif.ResourceId.XmNtabLabelPixmap, value);
            }
        }

        /// <summary>
        /// XmNtabLabelString
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string TabLabelString {
            get {
                return XSports.GetString(Native.Motif.ResourceId.XmNtabLabelString, "");
            }
            set {
                XSports.SetString(Native.Motif.ResourceId.XmNtabLabelString, value);
            }
        }

        /// <summary>
        /// XmNtabStringDirection
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual StringDirection TabStringDirection {
            get {
                return XSports.GetValue<StringDirection>(Native.Motif.ResourceId.XmNtabStringDirection, StringDirection.Default);
            }
            set {
                XSports.SetValue<StringDirection>(Native.Motif.ResourceId.XmNtabStringDirection, value);
            }
        }

         // 以下未実装

        // ﾃｽﾄが出来ないくて困ってる
        // ### XmNtabPixmapPlacement XmCTabPixmapPlacement XmPixmapPlacement XmPIXMAP_RIGHT CSG

    }

    /// <summary>
    /// Frame束縛ﾘｿーｽ
    /// </summary>
    public class FrameConstraint : ConstraintResource<Frame> {
        public FrameConstraint(Widget widget) : base(widget) {
        }

        /// <summary>
        /// XmNchildType
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual FrameChildType ChildType {
            get {
                return XSports.GetValue<FrameChildType>(Native.Motif.ResourceId.XmNchildType, FrameChildType.WorkareaChild);
            }
            set {
            XSports.SetValue<FrameChildType>(Native.Motif.ResourceId.XmNchildType, value);
            }
        }

        /// <summary>
        /// XmNchildHorizontalAlignment
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment ChildHorizontalAlignment {
            get {
                return XSports.GetValue<Alignment>(Native.Motif.ResourceId.XmNchildHorizontalAlignment, Alignment.Beginning);
            }
            set {
            XSports.SetValue<Alignment>(Native.Motif.ResourceId.XmNchildHorizontalAlignment, value);
            }
        }

        /// <summary>
        /// XmNchildHorizontalSpacing
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ChildHorizontalSpacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNchildHorizontalSpacing, 2);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNchildHorizontalSpacing, value);
            }
        }

        /// <summary>
        /// XmNchildVerticalAlignment
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ChildAlignment ChildVerticalAlignment {
            get {
                return XSports.GetValue<ChildAlignment>(Native.Motif.ResourceId.XmNchildVerticalAlignment, ChildAlignment.Center);
            }
            set {
            XSports.SetValue<ChildAlignment>(Native.Motif.ResourceId.XmNchildVerticalAlignment, value);
            }
        }

        /// <summary>
        /// XmNframeChildType XmCFrameChildType unsigned char XmFRAME_WORKAREA_CHILD CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual FrameChildType FrameChildType {
            get {
                return XSports.GetValue<FrameChildType>(Native.Motif.ResourceId.XmNframeChildType, FrameChildType.WorkareaChild);
            }
            set {
                XSports.SetValue<FrameChildType>(Native.Motif.ResourceId.XmNframeChildType, value);
            }
        }
    }

    /// <summary>
    /// Paned (分割ｳｲﾝﾄﾞｳｽﾞXP)束縛
    /// </summary>
    public class PanedConstraint : ConstraintResource<Paned> {

        public PanedConstraint(Widget widget) : base(widget) {
        }

        /// <summary>
        /// XmNallowResize
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AllowResize
        {
            get
            {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNallowResize, false, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetBool(
                    Native.Motif.ResourceId.XmNallowResize, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNpaneMaximum
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PaneMaximum
        {
            get
            {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNpaneMaximum, 1000, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNpaneMaximum, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNpaneMinimum
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PaneMinimum
        {
            get
            {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNpaneMinimum, 1, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNpaneMinimum, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNskipAdjust
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool SkipAdjust
        {
            get
            {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNskipAdjust, false, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetBool(
                    Native.Motif.ResourceId.XmNskipAdjust, value, Data.Resource.Access.CSG);
            }
        }


        /// <summary>
        /// XmNpreferredPaneSize
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PreferredPaneSize
        {
            get
            {
                return XSports.GetInt(
                    Native.Motif.ResourceId.XmNpreferredPaneSize, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    Native.Motif.ResourceId.XmNpreferredPaneSize, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNresizeToPreferred
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ResizeToPreferred
        {
            get
            {
                return XSports.GetBool(
                    Native.Motif.ResourceId.XmNresizeToPreferred, false, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetBool(
                    Native.Motif.ResourceId.XmNresizeToPreferred, value, Data.Resource.Access.CSG);
            }
        }
        /// <summary>
        /// XmNshowSash
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ShowSash
        {
            get
            {
                return XSports.GetBool(
                    Native.Motif.ResourceId.XmNshowSash, true, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetBool(
                    Native.Motif.ResourceId.XmNshowSash, value, Data.Resource.Access.CSG);
            }
        }
    }

    /// <summary>
    /// みんな大好き RowColumn束縛ﾘｿーｽ
    /// </summary>
    public class RowColumnConstraint : ConstraintResource<RowColumn> {
        public RowColumnConstraint(Widget widget) : base(widget) {
        }

        /// <summary>
        /// XmNpositionIndex XmCPositionIndex short XmLAST_POSITION CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PositionIndex {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNpositionIndex, (int)Native.Motif.Constant.XmLAST_POSITION);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNpositionIndex, value);
            }
        }
    }

    /// <summary>
    /// PanedWindow(分割ｳｲﾝﾄﾞｳｽﾞXP)束縛ﾘｿーｽ
    /// </summary>
    public class PanedWindowConstraint : ConstraintResource<Paned> {

        public PanedWindowConstraint(Widget widget) : base(widget) {
        }

        /// <summary>
        /// XmNallowResize
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AllowResize {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNallowResize, false);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNallowResize, value);
            }
        }

        /// <summary>
        /// XmNpaneMaximum
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PaneMaximum {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNpaneMaximum, 1000);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNpaneMaximum, value);
            }
        }

        /// <summary>
        /// XmNpaneMinimum
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PaneMinimum {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNpaneMinimum, 1);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNpaneMinimum, value);
            }
        }

        /// <summary>
        /// XmNpositionIndex
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PositionIndex {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNpositionIndex, (int)Native.Motif.Constant.XmLAST_POSITION);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNpositionIndex, value);
            }
        }

        /// <summary>
        /// XmNskipAdjust
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool SkipAdjust {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNskipAdjust, false);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNskipAdjust, value);
            }
        }
    }

    /// <summary>
    /// Hierarchy束縛ﾘｿーｽ
    /// </summary>
    public class HierarchyConstraint : ConstraintResource<Hierarchy> {
        public HierarchyConstraint(Widget widget) : base(widget) {

        }

        /// <summary>
        /// XmNinsertBefore
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Widgets.IWidget InsertBefore {
            get {
                return XSports.GetWidget<Widgets.IWidget>(
                    Native.Motif.ResourceId.XmNinsertBefore, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetWidget<Widgets.IWidget>(
                    Native.Motif.ResourceId.XmNinsertBefore, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNnodeState
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Hierarchy.NodeState NodeState {
            get {
                return XSports.GetValue< Hierarchy.NodeState>(Native.Motif.ResourceId.XmNnodeState, Hierarchy.NodeState.Open);
            }
            set {
                XSports.SetValue< Hierarchy.NodeState>(Native.Motif.ResourceId.XmNnodeState, value);
            }
        }

        /// <summary>
        /// XmNparentNode
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Widgets.IWidget ParentNode {
            get {
                return XSports.GetWidget<Widgets.IWidget>(
                Native.Motif.ResourceId.XmNparentNode, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetWidget<Widgets.IWidget>(
                Native.Motif.ResourceId.XmNparentNode, value, Data.Resource.Access.CSG);
            }
        }

    }

}
