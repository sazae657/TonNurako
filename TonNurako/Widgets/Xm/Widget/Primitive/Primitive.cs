//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    ///　Primitive
    /// </summary>
    abstract public class Primitive : Core
    {
        public Primitive() : base() {
        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
            InitProperties();
        }

        private PrimitiveProperties prop = null;

		#region Primitiveﾌﾟﾛﾊﾟﾃｨ

		/// <summary>
		/// ﾌﾟﾛﾊﾟﾃｨー
		/// </summary>
		internal class PrimitiveProperties
		{
            public int hilightThickness = 2;
			public int shadowThickness = 2;
			public bool highlightOnEnter = false;
			public NavigationType navigationType = NavigationType.TabGroup;
			public bool traversalOn = true;
		}

		/// <summary>
		/// ﾌﾟﾛﾊﾟﾃｨ初期化
		/// </summary>
		protected override void InitProperties()
		{
            prop = new PrimitiveProperties();
			base.InitProperties();
		}

        /*
        ** XmPrimitive Resource Set
        Name	Class	Type	Default	Access

        XmNuserData	XmCUserData	XtPointer	NULL	CSG
        */

        /// XmNbottomShadowPixmap XmCBottomShadowPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap BottomShadowPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNbottomShadowPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNbottomShadowPixmap, value);
            }
        }


        /// XmNhighlightPixmap XmCHighlightPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap HighlightPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNhighlightPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNhighlightPixmap, value);
            }
        }


        /// XmNtopShadowPixmap XmCTopShadowPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap TopShadowPixmap {
            get {
                return XSports.GetPixmap(Native.Motif.ResourceId.XmNtopShadowPixmap);
            }
            set {
            XSports.SetPixmap(Native.Motif.ResourceId.XmNtopShadowPixmap, value);
            }
        }


        /// XmNunitType XmCUnitType unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType UnitType {
            get {
                return XSports.GetValue<UnitType>(Native.Motif.ResourceId.XmNunitType, UnitType.Pixels);
            }
            set {
                XSports.SetValue<UnitType>(Native.Motif.ResourceId.XmNunitType, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color BottomShadowColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNbottomShadowColor);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNbottomShadowColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color ForegroundColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNforeground);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNforeground, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color HighlightColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNhighlightColor);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNhighlightColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Color TopShadowColor {
            get {
                return XSports.GetColor(Native.Motif.ResourceId.XmNtopShadowColor);
            }
            set {
                XSports.SetColor(Native.Motif.ResourceId.XmNtopShadowColor, value);
            }
        }

		/// <summary>
		/// ﾊｲﾗｲﾄを表す枠の厚みを設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public int HighlightThickness
		{
			get
			{

				prop.hilightThickness =
                    XSports.GetInt(Native.Motif.ResourceId.XmNhighlightThickness, (ushort)prop.hilightThickness);
                return prop.hilightThickness;
			}
			set
			{
				XSports.SetInt( Native.Motif.ResourceId.XmNhighlightThickness, (ushort)value );
				//値を保持
				prop.hilightThickness = value;
			}
		}

		/// <summary>
		/// ﾊｲﾗｲﾄを表す枠の厚みを設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public int ShadowThickness
		{
			get
			{
				prop.shadowThickness =
                    XSports.GetInt(Native.Motif.ResourceId.XmNshadowThickness, (ushort)prop.shadowThickness);
				return prop.shadowThickness;
			}
			set
			{
				XSports.SetInt(Native.Motif.ResourceId.XmNshadowThickness, (ushort)value );
				//値を保持
				prop.shadowThickness = value;
			}
		}

		/// <summary>
		/// ﾏｳｽﾎﾟｲﾝﾀ通過時に強調表示するか否かを設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public bool HighlightOnEnter
		{
			get
			{
                prop.highlightOnEnter =
                    XSports.GetBool(Native.Motif.ResourceId.XmNhighlightOnEnter, prop.highlightOnEnter);
                return prop.highlightOnEnter;
			}
			set
			{
				XSports.SetBool( Native.Motif.ResourceId.XmNhighlightOnEnter, value );
				//値を保持
				prop.highlightOnEnter = value;

			}
		}


		/// <summary>
		/// ﾀﾌﾞｸﾞﾙーﾌﾟ構成の設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public NavigationType NavigationType
		{
			get {
				prop.navigationType =
                    XSports.GetValue<NavigationType>(Native.Motif.ResourceId.XmNnavigationType, NavigationType.TabGroup);
                return prop.navigationType;
			}
			set {
				prop.navigationType = value;

                XSports.SetValue<NavigationType>(Native.Motif.ResourceId.XmNnavigationType, value );
			}
		}

		/// <summary>
		/// ﾏｳｽ入力中のｷー入力を許可
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public bool TraversalOn
		{
			get {
				prop.traversalOn =
			         XSports.GetBool( Native.Motif.ResourceId.XmNtraversalOn, prop.traversalOn);
                return prop.traversalOn;
			}
			set {
				XSports.SetBool(Native.Motif.ResourceId.XmNtraversalOn, value );
				prop.traversalOn = value;
			}
		}

        /// XmNhelpCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> HelpEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNhelpCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNhelpCallback ,  value );
            }
        }

		#endregion
    }
}
