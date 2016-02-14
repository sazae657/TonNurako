//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// PanedWindow
	/// </summary>
	public class PanedWindow : Manager, IDefectiveWidget
	{

		public PanedWindow() : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// PanedWindow生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreatePanedWindow, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー
        
        /// XmNmarginHeight XmCMarginHeight Dimension 3 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginHeight, 3);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginHeight, value);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 3 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNmarginWidth, 3);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNmarginWidth, value);
            }
        }

        /// XmNorientation XmCOrientation unsigned char XmVERTICAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(Native.Motif.ResourceId.XmNorientation, Orientation.Vertical);
            }
            set {
                XSports.SetValue<Orientation>(Native.Motif.ResourceId.XmNorientation, value);
            }
        }

        /// XmNrefigureMode XmCBoolean Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RefigureMode {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNrefigureMode, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNrefigureMode, value);
            }
        }

        /// XmNsashHeight XmCSashHeight Dimension 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashHeight {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNsashHeight, 10);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNsashHeight, value);
            }
        }

        //  XmNsashIndent XmCSashIndent Position -10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashIndent {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNsashIndent, -10);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNsashIndent, value);
            }
        }

        /// XmNsashShadowThickness XmCShadowThickness Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashShadowThickness {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNsashShadowThickness, 0);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNsashShadowThickness, value);
            }
        }

        /// XmNsashWidth XmCSashWidth Dimension 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashWidth {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNsashWidth, 10);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNsashWidth, value);
            }
        }

        /// XmNseparatorOn XmCSeparatorOn Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool SeparatorOn {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNseparatorOn, true);
            }
            set {
            XSports.SetBool(Native.Motif.ResourceId.XmNseparatorOn, value);
            }
        }

        /// XmNspacing XmCSpacing Dimension 8 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNspacing, 8);
            }
            set {
            XSports.SetInt(Native.Motif.ResourceId.XmNspacing, value);
            }
        }


		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
