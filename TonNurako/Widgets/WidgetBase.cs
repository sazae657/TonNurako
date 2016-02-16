﻿//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.CompilerServices;
using TonNurako.Data;
using TonNurako.Events;


namespace TonNurako.Widgets
{
    /// <summary>
    /// Widget基底ｸﾗｽ
    /// </summary>
    public abstract class WidgetBase : Widgets.IWidget, System.IDisposable
    {

        //自身のｳｲｼﾞｪｯﾄ
        internal Native.WidgetHandle selfWidget = null;

        //子ｳｲｼﾞｪｯﾄのﾘｽﾄ
        private WidgetCollection children = null;

        // base初期化されてるﾌﾗｸﾞ
        private bool baseInitialized = false;

        // ｽﾚｯﾄﾞID(たぶん使わない)
        public int ThreadId {
            get;
        }

        //ｲﾍﾞﾝﾄ
        internal TnkEvents<TonNuraEventId, TnkEventArgs> UIeventTable {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get;
        }

        internal TnkXtEvents<Events.AnyEventArgs> motifAnyEventTable;
        internal TnkXtEvents<Events.AnyEventArgs> MotifAnyEventTable {
            get{ return motifAnyEventTable;}
        }

        //ﾘｿーｽ管理
        XResource xresource;
        public XResource ToolkitResources {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return xresource; }
        }

        ExtremeResourceSports xSports;
        internal ExtremeResourceSports XSports {
            get {return xSports;}
        }

        //ｺーﾙﾊﾞｯｸ管理
        internal Native.CallbackQueue CallbackQueue {
            get;
        }

        public Native.XEventQueue XEventQueue {
            get;
        }

        public bool IsManaged {
            get; internal set;
        }

       public Events.ServerEvent XServerEvent {
            get;
        }


        public Guid UniqueId {
            get; internal set;
        }

        public bool IsDisposed { get; internal set;}

        public virtual ApplicationContext AppContext {
            get; set;
        }

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        public WidgetBase()
        {
            UIeventTable = new TnkEvents<TonNuraEventId, TnkEventArgs>();
            motifAnyEventTable = new TnkXtEvents<AnyEventArgs>();
            CallbackQueue = new Native.CallbackQueue(this);
            XEventQueue = new Native.XEventQueue(this);
            children = new WidgetCollection(this);
            UniqueId = Guid.NewGuid();
            xSports = new ExtremeResourceSports(this);
            XServerEvent = new Events.ServerEvent(this);

            xresource = new XResource(this);

            ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        }

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー(2)
        /// </summary>
        public WidgetBase(IntPtr native)
        {
            UIeventTable = new TnkEvents<TonNuraEventId, TnkEventArgs>();
            motifAnyEventTable = new TnkXtEvents<AnyEventArgs>();
            CallbackQueue = new Native.CallbackQueue(this);
            XEventQueue = new Native.XEventQueue(this);
            children = new WidgetCollection(this);
            UniqueId = Guid.NewGuid();
            xSports = new ExtremeResourceSports(this);
            XServerEvent = new Events.ServerEvent(this);

            xresource = new XResource(this);
            selfWidget = new Native.WidgetHandle(native);

            ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        }

        /// <summary>
        /// ﾗｯﾌﾟする(どうなっても知らん)
        /// </summary>
        internal void WrapExistingWidget(IntPtr widget) {
            if (widget == IntPtr.Zero) {
                throw new Exception("Null Widget Exception!!");
            }
            selfWidget = new Native.WidgetHandle(widget);
            if (IntPtr.Zero != widget) {
                this.Name = selfWidget.XtName;
            }
            IsManaged = true;
            AllowAutoManage = false;
        }

        internal void InitializeBase() {
            Name = "";

            baseInitialized = true;

            IsManaged = false;
            IsDisposed = false;
            AllowAutoManage = true;

            InitProperties();
            InitalizeLocals();
        }

        protected virtual void InitProperties() {
        }

        ///
        internal virtual void InitalizeLocals()
        {
        }

        #region IDisposable

        /// <summary>
        /// 消滅時の処理
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// override
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) {
                return;
            }
            IsDisposed = true;
            //全子ｳｲｼﾞｪｯﾄのDispose
            foreach (IChild w in this.Children) {
                w.Dispose();
            }
            xSports.Dispose();
            if (null != xresource) {
                xresource.Dispose();
                xresource = null;
            }
            System.Diagnostics.Debug.WriteLine("WidgetBase.Dispose: " + this.ToString());
        }

        #endregion

        /// <summary>
        /// 子を全員ﾏﾈーｼﾞする
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void ManageChildren()
        {
            System.Diagnostics.Debug.WriteLine( $"Manage<Begin> =>{this.Name }");

            if (! baseInitialized) {
                throw new Exception($"{this.ToString()}: IS NOT Initialized!!!");
            }

            foreach (IChild w in this.Children.GetCreationList())
            {
                System.Diagnostics.Debug.WriteLine($"ManageChildren:{w.GetType()}");
                if(! w.IsManaged) {
                    w.ManageChildren();
                }
            }

            System.Diagnostics.Debug.WriteLine( $"Manage<End> =>{this.Name }");
        }


        /// <summary>
        /// 子を全滅させる
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void DestroyChildren()
        {
            System.Diagnostics.Debug.WriteLine( $"DestroyChildren<Begin> =>{this.Name }");

            if (! baseInitialized) {
                throw new Exception($"{this.ToString()}: IS NOT Initialized!!!");
            }

            foreach (IChild w in this.Children.GetCreationList())
            {
                System.Diagnostics.Debug.WriteLine($"DestroyChildren:{w.GetType()}");
                w.DestroyChildren();
                w.Destroy();
            }
            Children.RemoveAll();

            System.Diagnostics.Debug.WriteLine( $"DestroyChildren<End> =>{this.Name }");
        }

        #region Motif
        public virtual SportyFontList FontList {
            get {
                return XSports.GetFontList(
                    Native.Motif.ResourceId.XmNfontList, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetFontList(
                    Native.Motif.ResourceId.XmNfontList, value, Data.Resource.Access.CSG);
            }
        }
        #endregion

        #region TNK独自実装

        /// <summary>
        /// お好きなﾃﾞーﾀをどうぞ
        /// </summary>
        public object UserData {
            get; set;
        }

        /// <summary>
        /// 自身のWidgetを返す
        /// </summary>
        public virtual Native.WidgetHandle NativeHandle
        {
            get
            {
                return selfWidget;
            }

            set {
                selfWidget = value;
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name {
            get; set;
        }

        /// <summary>
        /// Widgetが使用可能か問い合わせる
        /// </summary>
        public virtual bool IsAvailable
        {
            get
            {
                return (selfWidget != null);
            }
        }

        /// <summary>
        /// 子のﾘｽﾄを取得
        /// </summary>
        public virtual WidgetCollection Children
        {
            get
            {
                return children;
            }
        }

        public virtual bool AllowAutoManage
        {
            get; set;
        }

        #endregion

        #region Widgetｲﾍﾞﾝﾄ

        /// <summary>
        /// Create成功時に呼ばれる
        /// </summary>
        public event EventHandler<TnkWidgetEventArgs> WidgetNowAvailableEvent;

        /// <summary>
        /// Manageされたら呼ばれる
        /// </summary>
        public event EventHandler<TnkWidgetEventArgs> WidgetManagedEvent;

        internal virtual void OnWidgetNowAvailable(TnkWidgetEventArgs args) {
            EventHandler<TnkWidgetEventArgs> handler = WidgetNowAvailableEvent;
             if (handler != null) {
                handler(this, args);
             }
        }

        internal virtual void OnWidgetManaged(TnkWidgetEventArgs args) {
            EventHandler<TnkWidgetEventArgs> handler = WidgetManagedEvent;
             if (handler != null) {
                handler(this, args);
             }
        }

       /* /// <summary>
        /// 作成時に呼ばれる
        /// </summary>
        public virtual event EventHandler<TnkEventArgs> Load
        {
            add
            {
                UIeventTable.AddHandler(UIEventId.Load, value);
            }
            remove
            {
                UIeventTable.RemoveHandler(UIEventId.Load, value);
            }

        }*/

        /// <summary>
        /// 表示状態変更時
        /// </summary>
        public virtual event EventHandler<TnkEventArgs> VisibleChangedEvent
        {
            add
            {
                UIeventTable.AddHandler(TonNuraEventId.VisibleChanged, value);
            }
            remove
            {
                UIeventTable.RemoveHandler(TonNuraEventId.VisibleChanged, value);
            }
        }

        /// <summary>
        /// 破壊前に呼ばれる
        /// </summary>
        public virtual event EventHandler<TnkEventArgs> DestroyEvent
        {
            add
            {
                UIeventTable.AddHandler(TonNuraEventId.Destroy, value);
            }
            remove
            {
                UIeventTable.RemoveHandler(TonNuraEventId.Destroy, value);
            }
        }


        /// <summary>
        /// 破壊後に呼ばれる
        /// </summary>
        public virtual event EventHandler<TnkEventArgs> DestroyedEvent
        {
            add
            {
                UIeventTable.AddHandler(TonNuraEventId.Destroyed, value);
            }
            remove
            {
                UIeventTable.RemoveHandler(TonNuraEventId.Destroyed, value);
            }
        }

        /// <summary>
        /// Createされた
        /// </summary>
        public virtual event EventHandler<TnkEventArgs> WidgetCreatedEvent
        {
            add
            {
                UIeventTable.AddHandler(TonNuraEventId.WidgetCreated, value);
            }
            remove
            {
                UIeventTable.RemoveHandler(TonNuraEventId.WidgetCreated, value);
            }
        }

        #endregion

        /// <summary>
        /// ｳｲｼﾞｪｯﾄを破壊する
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void Destroy()
        {
            //ｳｲｼﾞｪｯﾄを破壊する
            if (IsAvailable)
            {
                // Destroyｲﾍﾞﾝﾄ通知
                UIeventTable.CallHandler(TonNuraEventId.Destroy, this);

                if(null != selfWidget) {
                    Native.Xt.XtSports.XtDestroyWidget(this);
                }
                XEventQueue.RemoveAll();
                CallbackQueue.RemoveAlll();
                selfWidget = null;
                System.Diagnostics.Debug.WriteLine("WidgetBase.XtDestroyWidget: " + this.ToString());
            }
            else {
                System.Diagnostics.Debug.WriteLine("IGNORE!! WidgetBase.XtDestroyWidget: " + this.ToString());
            }

            //Destroyedｲﾍﾞﾝﾄを通知する
            UIeventTable.CallHandler(TonNuraEventId.Destroyed, this);
        }
    }

}
