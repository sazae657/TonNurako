//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Form
	/// </summary>
	public class Form : BulletinBoard
	{

		#region 生成

		public Form()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create( IWidget parent )
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(Native.Motif.CreateSymbol.XmCreateForm, parent, ToolkitResources);
			}

			return base.Create (parent);
		}


		#endregion

        #region XmForm Resource Set
        /// XmNfractionBase XmCMaxValue int 100 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int FractionBase {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNfractionBase, 100);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNfractionBase, value);
            }
        }


        /// XmNhorizontalSpacing XmCSpacing Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HorizontalSpacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNhorizontalSpacing, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNhorizontalSpacing, value);
            }
        }


        /// XmNrubberPositioning XmCRubberPositioning Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RubberPositioning {
            get {
                return XSports.GetBool(Native.Motif.ResourceId.XmNrubberPositioning, false);
            }
            set {
                XSports.SetBool(Native.Motif.ResourceId.XmNrubberPositioning, value);
            }
        }


        /// XmNverticalSpacing XmCSpacing Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VerticalSpacing {
            get {
                return XSports.GetInt(Native.Motif.ResourceId.XmNverticalSpacing, 0);
            }
            set {
                XSports.SetInt(Native.Motif.ResourceId.XmNverticalSpacing, value);
            }
        }
        #endregion

	}
}
