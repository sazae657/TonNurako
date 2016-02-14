//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// ToggleButtonGadget
    /// </summary>
    public class ToggleButtonGadget : LabelGadget
    {
        #region ｳｲｼﾞｪｯﾄ作成
		public ToggleButtonGadget()  : base()
		{
            ToggleButtonEventTable = new TnkXtEvents<Events.ToggleButtonEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifGadget(Native.Motif.CreateSymbol.XmCreateToggleButtonGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
		#endregion


        #region 固有
        internal static class NativeMethods {
            // Boolean: XmToggleButtonGadgetGetState [{'type': 'Widget', 'name': 'widget'}]
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmToggleButtonGadgetGetState_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmToggleButtonGadgetGetState(IntPtr widget);

            // void: XmToggleButtonGadgetSetState [{'type': 'Widget', 'name': 'widget'}, {'type': 'Boolean', 'name': 'state'}, {'type': 'Boolean', 'name': 'notify'}]
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmToggleButtonGadgetSetState_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmToggleButtonGadgetSetState(IntPtr widget, [MarshalAs(UnmanagedType.U1)] bool state, [MarshalAs(UnmanagedType.U1)] bool notify);
        }

        public bool GetState() {
            return NativeMethods.XmToggleButtonGadgetGetState(this.NativeHandle.Widget);
        }

        public void SetState(bool state, bool notify) {
            NativeMethods.XmToggleButtonGadgetSetState(this.NativeHandle.Widget, state, notify);
        }

        #endregion

        #region ﾘｿーｽ
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

        /// XmNfillOnSelect XmCFillOnSelect Boolean dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool FillOnSelect {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNfillOnSelect, false);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNfillOnSelect, value);
            }
        }

        /// XmNindeterminatePixmap XmCIndeterminatePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap IndeterminatePixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNindeterminatePixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNindeterminatePixmap, value);
            }
        }

        /// XmNindicatorOn XmCIndicatorOn unsigned char XmINDICATOR_FILL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Indicator IndicatorOn {
            get {
                return XSports.GetValue<Indicator>(Native.Motif.ResourceId.XmNindicatorOn, Indicator.Fill);
            }
            set {
                XSports.SetValue<Indicator>(Native.Motif.ResourceId.XmNindicatorOn, value);
            }
        }

        /// XmNindicatorSize XmCIndicatorSize Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IndicatorSize {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNindicatorSize, 1);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNindicatorSize, value);
            }
        }

        /// XmNindicatorType XmCIndicatorType unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IndicatorType IndicatorType {
            get {
                return XSports.GetValue<IndicatorType>(Native.Motif.ResourceId.XmNindicatorType, IndicatorType.Many);
            }
            set {
                XSports.SetValue<IndicatorType>(Native.Motif.ResourceId.XmNindicatorType, value);
            }
        }

        /// XmNselectColor XmCSelectColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color SelectColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNselectColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNselectColor, value);
            }
        }

        /// XmNselectInsensitivePixmap XmCSelectInsensitivePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap SelectInsensitivePixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNselectInsensitivePixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNselectInsensitivePixmap, value);
            }
        }

        /// XmNselectPixmap XmCSelectPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap SelectPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNselectPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNselectPixmap, value);
            }
        }

        /// XmNset XmCSet unsigned char XmUNSET CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ToggleButtonState Set {
            get {
                return XSports.GetValue<ToggleButtonState>(Native.Motif.ResourceId.XmNset, ToggleButtonState.Unset);
            }
            set {
                XSports.SetValue<ToggleButtonState>(Native.Motif.ResourceId.XmNset, value);
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

        /// XmNtoggleMode XmCToggleMode unsigned char XmTOGGLE_BOOLEAN CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ToggleMode ToggleMode {
            get {
                return XSports.GetValue<ToggleMode>(Native.Motif.ResourceId.XmNtoggleMode, ToggleMode.Boolean);
            }
            set {
            XSports.SetValue<ToggleMode>(Native.Motif.ResourceId.XmNtoggleMode, value);
            }
        }

        /// XmNunselectColor XmCUnselectColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color UnselectColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNunselectColor);
            }
            set {
            XSports.SetColor(Native.Motif.ResourceId.XmNunselectColor, value);
            }
        }

        /// XmNvisibleWhenOff XmCVisibleWhenOff Boolean dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool VisibleWhenOff {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNvisibleWhenOff, false);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNvisibleWhenOff, value);
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄー

        TnkXtEvents<Events.ToggleButtonEventArgs> ToggleButtonEventTable {
            get;
        }

        /// XmNarmCallback XmCArmCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ToggleButtonEventArgs> ArmEvent
        {
            add {
                ToggleButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNarmCallback ,  value );
            }
            remove {
                ToggleButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNarmCallback ,  value );
            }
        }

        /// XmNdisarmCallback XmCDisarmCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ToggleButtonEventArgs> DisarmEvent
        {
            add {
                ToggleButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNdisarmCallback ,  value );
            }
            remove {
                ToggleButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNdisarmCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCValueChangedCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ToggleButtonEventArgs> ValueChangedEvent
        {
            add {
                ToggleButtonEventTable.AddHandler(this, Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                ToggleButtonEventTable.RemoveHandler(Native.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }
        #endregion
    }
}
