//
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
	/// SimpleSpinBox
	/// </summary>
	public class SimpleSpinBox : Manager, IDefectiveWidget
	{
		public SimpleSpinBox() : base() {
            widgets = new Widgets();
            SimpleSpinBoxEventTable = new TnkXtEvents<Events.SimpleSpinBoxEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            widgets.TextField = null;
            widgets = null;
            base.Dispose(disposing);
        }


		/// <summary>
		/// SimpleSpinBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateSimpleSpinBox, parent, ToolkitResources);
			}
            widgets.TextField.WrapExistingWidget(ToolkitResources.GetPointerValue(Native.Motif.ResourceId.XmNtextField));
            this.Children.Add(widgets.TextField);
			return base.Create (parent);
		}


        #region 固有ﾒｿｯﾄﾞー

        // ﾈｲﾃｨﾌﾞ参照
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint="XmSimpleSpinBoxAddItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmSimpleSpinBoxAddItem(IntPtr w, IntPtr item, int pos);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmSimpleSpinBoxDeletePos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmSimpleSpinBoxDeletePos(IntPtr w, int pos);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmSimpleSpinBoxSetItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmSimpleSpinBoxSetItem(IntPtr w, IntPtr item);
        }

        internal class Widgets {
            public Widgets() {
                TextField = new TextField();
            }
            public TextField TextField {
                get; internal set;
            }
        }
        internal Widgets widgets;

        public void AddItem(string item, int pos) {
            using (var s = new Data.CompoundString(item)) {
                NativeMethods.XmSimpleSpinBoxAddItem(this.NativeHandle.Widget , s.Handle, pos);
            }
        }


        public void DeletePos(int pos) {
            NativeMethods.XmSimpleSpinBoxDeletePos(this.NativeHandle.Widget, pos);
        }


        public void SetItem(string item) {
            using (var s = new Data.CompoundString(item)) {
                NativeMethods.XmSimpleSpinBoxSetItem(this.NativeHandle.Widget, s.Handle);
            }
        }


        #endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNarrowLayout XmCArrowLayout unsigned char XmARROWS_END CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowLayout ArrowLayout {
            get {
                return XSports.GetValue<ArrowLayout>(Native.Motif.ResourceId.XmNarrowLayout, ArrowLayout.End);
            }
            set {
                XSports.SetValue<ArrowLayout>(Native.Motif.ResourceId.XmNarrowLayout, value);
            }
        }

        /// XmNarrowSensitivity XmCArrowSensitivity unsigned char XmARROWS-_SENSITIVE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowSensitivity ArrowSensitivity {
            get {
                return XSports.GetValue<ArrowSensitivity>(Native.Motif.ResourceId.XmNarrowSensitivity, ArrowSensitivity.Sensitive);
            }
            set {
                XSports.SetValue<ArrowSensitivity>(Native.Motif.ResourceId.XmNarrowSensitivity, value);
            }
        }

        /// XmNcolumns XmCColumn short 20 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Columns {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNcolumns, 20);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNcolumns, value);
            }
        }

        /// XmNdecimalPoints XmCDecimalPoints short 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DecimalPoints {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNdecimalPoints, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNdecimalPoints, value);
            }
        }

        /// XmNeditable XmCEditable Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Editable {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNeditable, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNeditable, value);
            }
        }

        /// XmNincrementValue XmCIncrementValue int 1 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IncrementValue {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNincrementValue, 1);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNincrementValue, value);
            }
        }

        /// XmNinitialDelay XmCInitialDelay unsigned int 250 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual uint InitialDelay {
            get {
                return XSports.GetUInt(Native.Motif.ResourceId.XmNinitialDelay, 250);
            }
            set {
                XSports.SetUInt(Native.Motif.ResourceId.XmNinitialDelay, value);
            }
        }

        /// XmNmaximumValue XmCMaximumValue int 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaximumValue {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmaximumValue, 10);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmaximumValue, value);
            }
        }

        /// XmNminimumValue XmCMinimumValue int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinimumValue {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNminimumValue, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNminimumValue, value);
            }
        }

        /// XmNnumValues XmCNumValues int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int NumValues {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNnumValues, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNnumValues, value);
            }
        }

        //  XmNvalues XmCValues XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public Data.CompoundStringTable Values {
            get {
                return XSports.GetStringTable(Native.Motif.ResourceId.XmNvalues, NumValues, true);
            }
            set {
                NumValues = value.Count;
                XSports.SetStringTable(Native.Motif.ResourceId.XmNvalues, value);
            }
        }

        /// XmNposition XmCPosition int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Position {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNposition, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNposition, value);
            }
        }

        /// XmNrepeatDelay XmCRepeatDelay unsigned int 200 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual uint RepeatDelay {
            get {
                return XSports.GetUInt(Native.Motif.ResourceId.XmNrepeatDelay, 200);
            }
            set {
            XSports.SetUInt(Native.Motif.ResourceId.XmNrepeatDelay, value);
            }
        }

        /// XmNspinBoxChildType XmCSpinBoxChildType unsigned char XmSTRING CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual SpinBoxChildType SpinBoxChildType {
            get {
                return XSports.GetValue<SpinBoxChildType>(
                    Native.Motif.ResourceId.XmNspinBoxChildType, SpinBoxChildType.String, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<SpinBoxChildType>(
                    Native.Motif.ResourceId.XmNspinBoxChildType, value, Data.Resource.Access.CG);
            }
        }

        /// XmNtextField XmCTextField Widget dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual TextField TextField {
            get {
                return widgets.TextField;
                //return XSports.GetWidget<TextField>(Native.Motif.ResourceId.XmNtextField, Data.Resource.Access.G);
            }
        }


        #endregion

        #region ｲﾍﾞﾝﾄ
        TnkXtEvents<Events.SimpleSpinBoxEventArgs> SimpleSpinBoxEventTable {
            get;
        }

        /// XmNmodifyVerifyCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.SimpleSpinBoxEventArgs> ModifyVerifyEvent
        {
            add {
                SimpleSpinBoxEventTable.AddHandler(this, Native.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
            remove {
                SimpleSpinBoxEventTable.RemoveHandler(Native.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.SimpleSpinBoxEventArgs> ValueChangedEvent
        {
            add {
                SimpleSpinBoxEventTable.AddHandler(this, Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                SimpleSpinBoxEventTable.RemoveHandler(Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
