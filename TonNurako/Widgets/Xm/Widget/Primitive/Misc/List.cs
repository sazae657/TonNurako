//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Native;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// List
	/// </summary>
	public class List : Primitive, IDefectiveWidget
	{

		public List() : base()
		{
            ListEventTable = new TnkXtEvents<Events.ListEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// List生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateList, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

        internal static class NativeMethods {

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListAddItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListAddItem(IntPtr widget, IntPtr item, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListAddItems_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListAddItems(IntPtr widget,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] items, int item_count, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListAddItemsUnselected_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListAddItemsUnselected(IntPtr widget,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] items, int item_count, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListAddItemUnselected_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListAddItemUnselected(IntPtr widget, IntPtr item, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeleteAllItems_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeleteAllItems(IntPtr widget);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeleteItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeleteItem(IntPtr widget, IntPtr item);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeleteItems_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeleteItems(IntPtr widget,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] items, int item_count);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeleteItemsPos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeleteItemsPos(IntPtr widget, int item_count, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeletePos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeletePos(IntPtr widget, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeletePositions_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeletePositions(IntPtr widget,
                            [In][MarshalAs(UnmanagedType.LPArray)]int [] position_list, int position_count);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListGetSelectedPos_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmListGetSelectedPos(IntPtr widget, out IntPtr position_list, out int position_count);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeselectAllItems_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeselectAllItems(IntPtr widget);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeselectItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeselectItem(IntPtr widget, IntPtr item);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListDeselectPos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListDeselectPos(IntPtr widget, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListGetKbdItemPos_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmListGetKbdItemPos(IntPtr widget);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListGetMatchPos_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmListGetMatchPos(IntPtr widget, IntPtr item, out IntPtr position_list, out int position_count);


            [DllImport(ExtremeSports.Lib, EntryPoint="XmListItemExists_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmListItemExists(IntPtr widget, IntPtr item);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListItemPos_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmListItemPos(IntPtr widget, IntPtr item);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListPosSelected_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmListPosSelected(IntPtr widget, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListPosToBounds_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmListPosToBounds(IntPtr widget,
                    int position, [Out]out int x, [Out]out int y, [Out]out int width, [Out]out int height);


            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSelectItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSelectItem(IntPtr widget, IntPtr item, [MarshalAs(UnmanagedType.U1)] bool notify);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSelectPos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSelectPos(IntPtr widget, int position, [MarshalAs(UnmanagedType.U1)] bool notify);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSetAddMode_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSetAddMode(IntPtr widget, [MarshalAs(UnmanagedType.U1)] bool state);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSetBottomItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSetBottomItem(IntPtr widget, IntPtr item);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSetBottomPos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSetBottomPos(IntPtr widget, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSetHorizPos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSetHorizPos(IntPtr widget, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSetItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSetItem(IntPtr widget, IntPtr item);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSetKbdItemPos_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmListSetKbdItemPos(IntPtr widget, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListSetPos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListSetPos(IntPtr widget, int position);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmListUpdateSelectedList_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListUpdateSelectedList(IntPtr widget);

            //TODO: 怪しい
            // int: XmListYToPos [{'type': 'Widget', 'name': 'widget'}, {'type': 'Position', 'name': 'y'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XmListYToPos_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmListYToPos(IntPtr widget, Int16 y);

            // void: XmListReplaceItems [{'type': 'Widget', 'name': 'widget'}, {'type': 'XmString*', 'name': 'old_items'}, {'type': 'int', 'name': 'item_count'}, {'type': 'XmString*', 'name': 'new_items'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XmListReplaceItems_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListReplaceItems(IntPtr widget,
                    [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] old_items, int item_count,
                    [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] new_items);

            // void: XmListReplaceItemsPos [{'type': 'Widget', 'name': 'widget'}, {'type': 'XmString*', 'name': 'new_items'}, {'type': 'int', 'name': 'item_count'}, {'type': 'int', 'name': 'position'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XmListReplaceItemsPos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListReplaceItemsPos(IntPtr widget,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] new_items, int item_count, int position);

            // void: XmListReplaceItemsPosUnselected [{'type': 'Widget', 'name': 'widget'}, {'type': 'XmString*', 'name': 'new_items'}, {'type': 'int', 'name': 'item_count'}, {'type': 'int', 'name': 'position'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XmListReplaceItemsPosUnselected_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListReplaceItemsPosUnselected(IntPtr widget,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] new_items, int item_count, int position);

            // void: XmListReplaceItemsUnselected [{'type': 'Widget', 'name': 'widget'}, {'type': 'XmString*', 'name': 'old_items'}, {'type': 'int', 'name': 'item_count'}, {'type': 'XmString*', 'name': 'new_items'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XmListReplaceItemsUnselected_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListReplaceItemsUnselected(IntPtr widget,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] old_items, int item_count,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] new_items);

            // void: XmListReplacePositions [{'type': 'Widget', 'name': 'widget'}, {'type': 'int*', 'name': 'position_list'}, {'type': 'XmString*', 'name': 'item_list'}, {'type': 'int', 'name': 'item_count;'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XmListReplacePositions_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmListReplacePositions(IntPtr widget, out IntPtr position_list,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]IntPtr [] item_list, int item_count);

        }

        public void AddItem(string item, int pos, bool autoSelect = false) {
            using(var cs = new CompoundString(item)) {
                if(true == autoSelect) {
                    NativeMethods.XmListAddItem(this.NativeHandle.Widget, cs.Handle, pos);
                }
                else {
                    NativeMethods.XmListAddItemUnselected(this.NativeHandle.Widget, cs.Handle, pos);
                }
            }
        }

        public void AddItems(string[] items, int pos, bool autoSelect = false) {
            using(var cs = new CompoundStringTable(items)) {
                if(true == autoSelect) {
                    NativeMethods.XmListAddItems(this.NativeHandle.Widget, cs.ToNativeArray(true), items.Length, pos);
                }
                else {
                    NativeMethods.XmListAddItemsUnselected(this.NativeHandle.Widget, cs.ToNativeArray(true), items.Length, pos);
                }
            }
        }

        public void DeleteAllItems() {
            NativeMethods.XmListDeleteAllItems(this.NativeHandle.Widget);
        }

        public void DeleteItem(string item) {
            using(var cs = new CompoundString(item)) {
                NativeMethods.XmListDeleteItem(this.NativeHandle.Widget, cs.Handle);
            }
        }
        public void DeleteItem(int pos) {
            NativeMethods.XmListDeletePos(this.NativeHandle.Widget, pos);
        }

        public void DeleteItems(string[] items) {
            using(var cs = new CompoundStringTable(items)) {
                NativeMethods.XmListDeleteItems(this.NativeHandle.Widget, cs.ToNativeArray(true), items.Length);
            }
        }
        public void DeleteItems(int offset, int count) {
            NativeMethods.XmListDeleteItemsPos(this.NativeHandle.Widget, offset, count);
        }

        public void DeleteItems(int[] pos) {
            NativeMethods.XmListDeletePositions(this.NativeHandle.Widget, pos, pos.Length);
        }

        public int[] GetSelectedIndex() {
            IntPtr listRef;
            int count;
            bool r = NativeMethods.XmListGetSelectedPos(this.NativeHandle.Widget, out listRef, out count);
            if (true != r) {
                return new int[]{};
            }

            int [] ret = new int[count];
            Marshal.Copy(listRef, ret, 0, count);

            Native.Xt.XtSports.XtFree(listRef);
            return ret;
        }

        public void DeselectAllItems() {
            NativeMethods.XmListDeselectAllItems(this.NativeHandle.Widget);
        }

        public void DeselectItem(string item) {
            using(var cs = new CompoundString(item)) {
                NativeMethods.XmListDeselectItem(this.NativeHandle.Widget, cs.Handle);
            }
        }

        public void DeselectItem(int pos) {
            NativeMethods.XmListDeselectPos(this.NativeHandle.Widget, pos);
        }

        public int GetKbdItemPos() {
            return NativeMethods.XmListGetKbdItemPos(this.NativeHandle.Widget);
        }

        public int[] GetMatchPos(string pattern) {
            IntPtr listRef;
            int count;
            using (var cs = new CompoundString(pattern)) {
                bool r = NativeMethods.XmListGetMatchPos(this.NativeHandle.Widget, cs.Handle, out listRef, out count);
                if (true != r) {
                    return new int[]{};
                }
            }

            int [] ret = new int[count];
            Marshal.Copy(listRef, ret, 0, count);

            Native.Xt.XtSports.XtFree(listRef);
            return ret;
        }

        public bool ItemExists(string item) {
            using (var cs = new CompoundString(item)) {
                return NativeMethods.XmListItemExists(this.NativeHandle.Widget, cs.Handle);
            }
        }

        public int GetItemPos(string item) {
            using (var cs = new CompoundString(item)) {
                return NativeMethods.XmListItemPos(this.NativeHandle.Widget, cs.Handle);
            }
        }
        public bool IsSelected(int pos) {
            return NativeMethods.XmListPosSelected(this.NativeHandle.Widget, pos);
        }

        public bool PosToBounds(int position) {
            int x, y, w, h;
            bool r = NativeMethods.XmListPosToBounds(this.NativeHandle.Widget, position, out x, out y, out w, out h);
            return r;
        }

        public void SelectItem(string item, bool notify = false) {
            using(var cs = new CompoundString(item)) {
                NativeMethods.XmListSelectItem(this.NativeHandle.Widget, cs.Handle, notify);
            }
        }

        public void SelectItem(int position, bool notify = false) {
            NativeMethods.XmListSelectPos(this.NativeHandle.Widget, position, notify);
        }

        public void SetAddMode(bool state) {
            NativeMethods.XmListSetAddMode(this.NativeHandle.Widget, state);
        }

        public void SetBottomItem(string item) {
            using(var cs = new CompoundString(item)) {
                NativeMethods.XmListSetBottomItem(this.NativeHandle.Widget, cs.Handle);
            }
        }

        public void SetBottomItem(int position) {
            NativeMethods.XmListSetBottomPos(this.NativeHandle.Widget, position);
        }

        public void SetHorizontalScrollPosition(int position) {
            NativeMethods.XmListSetHorizPos(this.NativeHandle.Widget, position);
        }
        public void SetScrollPosition(int position) {
            NativeMethods.XmListSetPos(this.NativeHandle.Widget, position);
        }

        public void SetItem(string item) {
            using(var cs = new CompoundString(item)) {
                NativeMethods.XmListSetItem(this.NativeHandle.Widget, cs.Handle);
            }
        }

        public void XmListSetKbdItemPos(int position) {
            NativeMethods.XmListSetKbdItemPos(this.NativeHandle.Widget, position);
        }


        public void Update() {
            NativeMethods.XmListUpdateSelectedList(this.NativeHandle.Widget);
        }

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNautomaticSelection XmCAutomaticSelection XtEnum False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual AutomaticSelection AutomaticSelection {
            get {
                return XSports.GetValue<AutomaticSelection>(
                    Native.Motif.ResourceId.XmNautomaticSelection, AutomaticSelection.No);
            }
            set {
            XSports.SetValue<AutomaticSelection>(Native.Motif.ResourceId.XmNautomaticSelection, value);
            }
        }

        /// XmNdoubleClickInterval XmCDoubleClickInterval int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DoubleClickInterval {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNdoubleClickInterval, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNdoubleClickInterval, value);
            }
        }

        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Coreで定義

        /// XmNitemCount XmCItemCount int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ItemCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNitemCount, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNitemCount, value);
            }
        }

        /// XmNitems XmCItems XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public string[] Items {
            get {
                using(var cs = XSports.GetStringTable(Native.Motif.ResourceId.XmNitems, ItemCount, true)) {
                    return cs.ToStringArray();
                }
            }
            set {
                XSports.SetStringTable(Native.Motif.ResourceId.XmNitems, new CompoundStringTable(value));
            }
        }

        /// XmNlistMarginHeight XmCListMarginHeight Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ListMarginHeight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNlistMarginHeight, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNlistMarginHeight, value);
            }
        }

        /// XmNlistMarginWidth XmCListMarginWidth Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ListMarginWidth {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNlistMarginWidth, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNlistMarginWidth, value);
            }
        }

        /// XmNlistSizePolicy XmCListSizePolicy unsigned char XmVARIABLE CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual ListSizePolicy ListSizePolicy {
            get {
                return XSports.GetValue<ListSizePolicy>(
                    Native.Motif.ResourceId.XmNlistSizePolicy, ListSizePolicy.Variable, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<ListSizePolicy>(
                    Native.Motif.ResourceId.XmNlistSizePolicy, value, Data.Resource.Access.CG);
            }
        }

        /// XmNlistSpacing XmCListSpacing Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ListSpacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNlistSpacing, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNlistSpacing, value);
            }
        }

        /// XmNmatchBehavior XmCMatchBehavior unsigned char XmQUICK_NAVIGATE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MatchBehavior MatchBehavior {
            get {
                return XSports.GetValue<MatchBehavior>(Native.Motif.ResourceId.XmNmatchBehavior, MatchBehavior.QuickNavigate);
            }
            set {
            XSports.SetValue<MatchBehavior>(Native.Motif.ResourceId.XmNmatchBehavior, value);
            }
        }

        /// XmNprimaryOwnership XmCPrimaryOwnership unsigned char XmOWN_NEVER CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual PrimaryOwnership PrimaryOwnership {
            get {
                return XSports.GetValue<PrimaryOwnership>(Native.Motif.ResourceId.XmNprimaryOwnership, PrimaryOwnership.Never);
            }
            set {
            XSports.SetValue<PrimaryOwnership>(Native.Motif.ResourceId.XmNprimaryOwnership, value);
            }
        }

        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable RenderTable {
            get {
                return XSports.GetRenderTable(
                    Native.Motif.ResourceId.XmNrenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    Native.Motif.ResourceId.XmNrenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNscrollBarDisplayPolicy XmCScrollBarDisplayPolicy unsigned char XmAS_NEEDED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrollBarDisplayPolicy ScrollBarDisplayPolicy {
            get {
                return XSports.GetValue<ScrollBarDisplayPolicy>(
                       Native.Motif.ResourceId.XmNscrollBarDisplayPolicy, ScrollBarDisplayPolicy.AsNeeded);
            }
            set {
                XSports.SetValue<ScrollBarDisplayPolicy>(Native.Motif.ResourceId.XmNscrollBarDisplayPolicy, value);
            }
        }

        /// XmNselectColor XmCSelectColor XmRSelectColor XmREVERSED_GROUND_COLORS CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectColor SelectColor {
            get {
                return XSports.GetValue<SelectColor>(Native.Motif.ResourceId.XmNselectColor, SelectColor.ReversedGroundColors);
            }
            set {
                XSports.GetValue<SelectColor>(Native.Motif.ResourceId.XmNselectColor, value);
            }
        }

        /// XmNselectedItemCount XmCSelectedItemCount int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SelectedItemCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNselectedItemCount, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNselectedItemCount, value);
            }
        }

        /// XmNselectedItems XmCSelectedItems XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string[] SelectedItems {

            get {
                var t = XSports.GetStringTable(
                    Native.Motif.ResourceId.XmNselectedItems, SelectedItemCount, true, Data.Resource.Access.CSG);
                return t.ToStringArray();
            }
            set {
                SelectedItemCount = value.Length;
                XSports.SetStringTable(
                        Native.Motif.ResourceId.XmNselectedItems, new CompoundStringTable(value), Data.Resource.Access.CSG);
            }
        }

        /// XmNselectedPositionCount XmCSelectedPositionCount int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SelectedPositionCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNselectedPositionCount, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNselectedPositionCount, value);
            }
        }

        /// XmNselectedPositions XmCSelectedPositions unsigned int * NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int[] SelectedPositions {
            get {
                int count = 0;
                if (0 == (count = SelectedPositionCount)) {
                    return new int[]{};
                }
                IntPtr listRef = XSports.GetPtr(Native.Motif.ResourceId.XmNselectedPositions);
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
                    SelectedPositionCount = count;
                    if (0 != count) {
                        ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * value.Length);
                        Marshal.Copy(value, 0, ptr, value.Length);
                        XSports.SetPtr(Native.Motif.ResourceId.XmNselectedPositions, ptr, Data.Resource.Access.CSG);
                    }
                }finally {
                    ToolkitResources.Commit(true);
                    if(IntPtr.Zero != ptr) {
                        Marshal.FreeCoTaskMem(ptr);
                    }
                }
            }
        }

        /// XmNselectionMode XmCSelectionMode unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectionMode SelectionMode {
            get {
                return XSports.GetValue<SelectionMode>(Native.Motif.ResourceId.XmNselectionMode, SelectionMode.Normal);
            }
            set {
                XSports.SetValue<SelectionMode>(Native.Motif.ResourceId.XmNselectionMode, value);
            }
        }

        /// XmNselectionPolicy XmCSelectionPolicy unsigned char XmBROWSE_SELECT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectionPolicy SelectionPolicy {
            get {
                return XSports.GetValue<SelectionPolicy>(
                    Native.Motif.ResourceId.XmNselectionPolicy, SelectionPolicy.Browse);
            }
            set {
            XSports.SetValue<SelectionPolicy>(Native.Motif.ResourceId.XmNselectionPolicy, value);
            }
        }

        /// XmNstringDirection XmCStringDirection XmStringDirection dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual StringDirection StringDirection {
            get {
                return XSports.GetValue<StringDirection>(Native.Motif.ResourceId.XmNstringDirection, StringDirection.Default);
            }
            set {
            XSports.SetValue<StringDirection>(Native.Motif.ResourceId.XmNstringDirection, value);
            }
        }

        /// XmNtopItemPosition XmCTopItemPosition int 1 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int TopItemPosition {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNtopItemPosition, 1);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNtopItemPosition, value);
            }
        }

        /// XmNvisibleItemCount XmCVisibleItemCount int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VisibleItemCount {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNvisibleItemCount, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNvisibleItemCount, value);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

        internal TnkXtEvents<Events.ListEventArgs> ListEventTable {
            get;
        }

        /// XmNbrowseSelectionCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ListEventArgs> BrowseSelectionEvent
        {
            add {
                ListEventTable.AddHandler(this, Native.Motif.EventId.XmNbrowseSelectionCallback ,  value );
            }
            remove {
                ListEventTable.RemoveHandler(Native.Motif.EventId.XmNbrowseSelectionCallback ,  value );
            }
        }

        /// XmNdefaultActionCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ListEventArgs> DefaultActionEvent
        {
            add {
                ListEventTable.AddHandler(this, Native.Motif.EventId.XmNdefaultActionCallback ,  value );
            }
            remove {
                ListEventTable.RemoveHandler(Native.Motif.EventId.XmNdefaultActionCallback ,  value );
            }
        }

        /// XmNdestinationCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ListEventArgs> DestinationEvent
        {
            add {
                ListEventTable.AddHandler(this, Native.Motif.EventId.XmNdestinationCallback ,  value );
            }
            remove {
                ListEventTable.RemoveHandler(Native.Motif.EventId.XmNdestinationCallback ,  value );
            }
        }

        /// XmNextendedSelectionCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ListEventArgs> ExtendedSelectionEvent
        {
            add {
                ListEventTable.AddHandler(this, Native.Motif.EventId.XmNextendedSelectionCallback ,  value );
            }
            remove {
                ListEventTable.RemoveHandler(Native.Motif.EventId.XmNextendedSelectionCallback ,  value );
            }
        }

        /// XmNmultipleSelectionCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ListEventArgs> MultipleSelectionEvent
        {
            add {
                ListEventTable.AddHandler(this, Native.Motif.EventId.XmNmultipleSelectionCallback ,  value );
            }
            remove {
                ListEventTable.RemoveHandler(Native.Motif.EventId.XmNmultipleSelectionCallback ,  value );
            }
        }

        /// XmNsingleSelectionCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ListEventArgs> SingleSelectionEvent
        {
            add {
                ListEventTable.AddHandler(this, Native.Motif.EventId.XmNsingleSelectionCallback ,  value );
            }
            remove {
                ListEventTable.RemoveHandler(Native.Motif.EventId.XmNsingleSelectionCallback ,  value );
            }
        }

		#endregion

	}

	/// <summary>
	/// ScrolledList (XmScrolledList.txt)
	/// </summary>
	public class ScrolledList : List, IDefectiveWidget
	{

		#region ｺﾝｽﾄﾗｸﾀー

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public ScrolledList() : base() {
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		#endregion

		#region 生成

		/// <summary>
		/// ScrolledList生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateScrolledList, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

	}
}
