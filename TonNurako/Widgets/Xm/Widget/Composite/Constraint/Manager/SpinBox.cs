//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SpinBox
	/// </summary>
	public class SpinBox : Manager, IDefectiveWidget
	{

		public SpinBox() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }


		/// <summary>
		/// SpinBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateSpinBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNarrowLayout XmCArrowLayout unsigned char XmARROWS_BEGINNING CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowLayout ArrowLayout {
            get {
                return XSports.GetValue<ArrowLayout>(Native.Motif.ResourceId.XmNarrowLayout, ArrowLayout.Beginning);
            }
            set {
                XSports.SetValue<ArrowLayout>(Native.Motif.ResourceId.XmNarrowLayout, value);
            }
        }

        /// XmNarrowOrientation XmCArrowOrientation unsigned char XmARROWS_VERTICAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowOrientation ArrowOrientation {
            get {
                return XSports.GetValue<ArrowOrientation>(Native.Motif.ResourceId.XmNarrowOrientation, ArrowOrientation.Vertical);
            }
            set {
                XSports.SetValue<ArrowOrientation>(Native.Motif.ResourceId.XmNarrowOrientation, value);
            }
        }

        /// XmNarrowSize XmCArrowSize Dimension 16 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ArrowSize {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNarrowSize, 16);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNarrowSize, value);
            }
        }

        /// XmNdefaultArrowSensitivity XmCDefaultArrowSensitivity unsigned char XmARROWS_SENSITIVE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowSensitivity DefaultArrowSensitivity {
            get {
                return XSports.GetValue<ArrowSensitivity>(
                    Native.Motif.ResourceId.XmNdefaultArrowSensitivity, ArrowSensitivity.Sensitive);
            }
            set {
                XSports.SetValue<ArrowSensitivity>(Native.Motif.ResourceId.XmNdefaultArrowSensitivity, value);
            }
        }

        /// XmNdetailShadowThickness XmCDetailShadowThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailShadowThickness {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNdetailShadowThickness, 2);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNdetailShadowThickness, value);
            }
        }

        /// XmNinitialDelay XmCInitialDelay unsigned int 250 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual uint InitialDelay {
            get {
                return XSports.GetUInt(Native.Motif.ResourceId.XmNinitialDelay, 250);
            }
            set {
                XSports.SetUInt(Native.Motif.ResourceId.XmNinitialDelay, value);
            }
        }

        /// XmNmarginHeight XmCMarginHeight Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginHeight, 1);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginHeight, value);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginWidth, 1);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginWidth, value);
            }
        }

        /// XmNrepeatDelay XmCRepeatDelay unsigned int 200 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual uint RepeatDelay {
            get {
                return XSports.GetUInt(Native.Motif.ResourceId.XmNrepeatDelay, 200);
            }
            set {
                XSports.SetUInt(Native.Motif.ResourceId.XmNrepeatDelay, value);
            }
        }

        /// XmNspacing XmCSpacing Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNspacing, 1);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNspacing, value);
            }
        }

        /// XmNarrowSensitivity XmCArrowSensitivity unsigned char XmARROWS_DEFAULT_SENSITIVITY CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowSensitivity ArrowSensitivity {
            get {
                return XSports.GetValue<ArrowSensitivity>(
                    Native.Motif.ResourceId.XmNarrowSensitivity, ArrowSensitivity.Default);
            }
            set {
            XSports.SetValue<ArrowSensitivity>(Native.Motif.ResourceId.XmNarrowSensitivity, value);
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

        /// XmNvalues XmCValues XmStringTable NULL CSG
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

        /// XmNpositionType XmCPositionType char XmPOSITION_VALUE CG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpinBoxPositionType PositionType {
            get {
                return XSports.GetValue<SpinBoxPositionType>(
                    Native.Motif.ResourceId.XmNspinBoxChildType, SpinBoxPositionType.Value);
            }
            set {
            XSports.SetValue<SpinBoxPositionType>(Native.Motif.ResourceId.XmNspinBoxChildType, value);
            }
        }

        /// XmNspinBoxChildType XmSpinBoxChildType unsigned char XmSTRING CG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpinBoxChildType SpinBoxChildType {
            get {
                return XSports.GetValue<SpinBoxChildType>(Native.Motif.ResourceId.XmNspinBoxChildType, SpinBoxChildType.String);
            }
            set {
                XSports.SetValue<SpinBoxChildType>(Native.Motif.ResourceId.XmNspinBoxChildType, value);
            }
        }


        #endregion

        #region ｲﾍﾞﾝﾄ

        /// XmNmodifyVerifyCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ModifyVerifyEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ValueChangedEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
