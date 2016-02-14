//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Hierarchy (XmHierarchy.txt)
	/// </summary>
	public abstract class Hierarchy : Manager
	{
        public enum NodeState : byte {
            AlwaysOpen = Native.Motif.Constant.XmAlwaysOpen,
            Open   = Native.Motif.Constant.XmOpen,
            Closed  = Native.Motif.Constant.XmClosed,
            Hidden = Native.Motif.Constant.XmHidden,
        }

		public Hierarchy() : base() {
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNautoClose XmCAutoClose Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AutoClose {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNautoClose, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNautoClose, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNcloseFolderPixmap XmCPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap CloseFolderPixmap {
            get {
                return XSports.GetPixmap(
                Native.Motif.ResourceId.XmNcloseFolderPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                Native.Motif.ResourceId.XmNcloseFolderPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNhorizontalMargin XmCDimension Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HorizontalMargin {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNhorizontalMargin, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNhorizontalMargin, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNopenFolderPixmap XmCPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Pixmap OpenFolderPixmap {
            get {
                return XSports.GetPixmap(
                Native.Motif.ResourceId.XmNopenFolderPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                Native.Motif.ResourceId.XmNopenFolderPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNrefigureMode XmCBoolean Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RefigureMode {
            get {
                return XSports.GetBool(
                Native.Motif.ResourceId.XmNrefigureMode, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                Native.Motif.ResourceId.XmNrefigureMode, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNverticalMargin XmCDimension Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VerticalMargin {
            get {
                return XSports.GetInt(
                Native.Motif.ResourceId.XmNverticalMargin, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                Native.Motif.ResourceId.XmNverticalMargin, value, Data.Resource.Access.CSG);
            }
        }


		#endregion

		#region ｲﾍﾞﾝﾄ

        /// XmNnodeStateCallback XmCNodeStateCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> NodeStateEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, Native.Motif.EventId.XmNnodeStateCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(Native.Motif.EventId.XmNnodeStateCallback ,  value );
            }
        }

		#endregion

	}
}
