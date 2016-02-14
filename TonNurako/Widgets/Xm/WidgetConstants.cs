//
// ﾄﾝﾇﾗｺ
//
// ｳｲｼﾞｪｯﾄ定数
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// 編集ﾓーﾄﾞ
    /// </summary>
    public enum  EditMode: byte {
        Single = Native.Motif.Constant.XmSINGLE_LINE_EDIT,
        Multi = Native.Motif.Constant.XmMULTI_LINE_EDIT
    }

    /// <summary>
    /// ﾗﾍﾞﾙの中身
    /// </summary>
    public enum LabelType : byte {
        String = Native.Motif.Constant.XmSTRING,
        Pixmap = Native.Motif.Constant.XmPIXMAP,
        PixmapAndString = Native.Motif.Constant.XmPIXMAP_AND_STRING
    }

    /// <summary>
    /// 方向
    /// </summary>
    public enum StringDirection : byte {
        LtoR = Native.Motif.Constant.XmSTRING_DIRECTION_L_TO_R,
        RtoL = Native.Motif.Constant.XmSTRING_DIRECTION_R_TO_L,
        Default = Native.Motif.Constant.XmSTRING_DIRECTION_DEFAULT
    }

    /// <summary>
    /// 複数ｸﾘｯｸ許容する？
    /// </summary>
    public enum MultiClick : byte{
        Keep = Native.Motif.Constant.XmMULTICLICK_KEEP,
        Discard = Native.Motif.Constant.XmMULTICLICK_DISCARD
    }

    /// <summary>
    /// ﾀﾞｲｱﾛｸﾞの表示ｽﾀｲﾙ(SYSTEM_MODAL危険)
    /// </summary>
    public enum DialogStyle : byte{
        SystemModal = Native.Motif.Constant.XmDIALOG_SYSTEM_MODAL,
        PrimaryApplicationModal = Native.Motif.Constant.XmDIALOG_PRIMARY_APPLICATION_MODAL,
        ApplicationModal = Native.Motif.Constant.XmDIALOG_APPLICATION_MODAL,
        FullApplicationModal =  Native.Motif.Constant.XmDIALOG_FULL_APPLICATION_MODAL,
        Modeless = Native.Motif.Constant.XmDIALOG_MODELESS,
        WorkArea = Native.Motif.Constant.XmDIALOG_WORK_AREA
    }

    /// <summary>
    /// ﾘｻｲｽﾞﾎﾟﾘｼー
    /// </summary>
    public enum ResizePolicy : byte{
        None = Native.Motif.Constant.XmRESIZE_NONE,
        Any = Native.Motif.Constant.XmRESIZE_ANY,
        Grow = Native.Motif.Constant.XmRESIZE_GROW,
    }

	/// <summary>
	/// ArrowButtonの向き
	/// </summary>
    public enum ArrowDirection : byte{
        Up      = Native.Motif.Constant.XmARROW_UP,
        Down    = Native.Motif.Constant.XmARROW_DOWN,
        Left    = Native.Motif.Constant.XmARROW_LEFT,
        Right   = Native.Motif.Constant.XmARROW_RIGHT,
    }

    /// <summary>
    /// 影の形
    /// </summary>
    public enum ShadowType : byte{
        In = Native.Motif.Constant.XmSHADOW_IN,
        Out = Native.Motif.Constant.XmSHADOW_OUT,
        EtchedIn = Native.Motif.Constant.XmSHADOW_ETCHED_IN,
        EtchedOut = Native.Motif.Constant.XmSHADOW_ETCHED_OUT
    }

    /// <summary>
    /// ﾀﾞｲｱﾛｸﾞのﾃﾞﾌｫﾙﾄﾎﾞﾀﾝ
    /// </summary>
    public enum DefaultButtonType : byte
    {
        Cancel= Native.Motif.Constant.XmDIALOG_CANCEL_BUTTON,
        Ok  = Native.Motif.Constant.XmDIALOG_OK_BUTTON,
        Help = Native.Motif.Constant.XmDIALOG_HELP_BUTTON,
        None = Native.Motif.Constant.XmDIALOG_NONE
    }

    /// <summary>
    /// ﾒｯｾーｼﾞﾀﾞｲｱﾛｸﾞのｲﾝｼﾞｹーﾀー
    /// </summary>
    public enum MessageDialogType : byte {
        Error = Native.Motif.Constant.XmDIALOG_ERROR,
        Information = Native.Motif.Constant.XmDIALOG_INFORMATION,
        Message = Native.Motif.Constant.XmDIALOG_MESSAGE,
        Question = Native.Motif.Constant.XmDIALOG_QUESTION,
        Template = Native.Motif.Constant.XmDIALOG_TEMPLATE,
        Warning = Native.Motif.Constant.XmDIALOG_WARNING,
    }

    /// <summary>
    /// ﾀﾞｲｱﾛｸﾞの種類
    /// </summary>
    public enum DialogType : byte{
        Working = Native.Motif.Constant.XmDIALOG_WORKING,
        Prompt = Native.Motif.Constant.XmDIALOG_PROMPT,
        Command = Native.Motif.Constant.XmDIALOG_COMMAND,
        Selection = Native.Motif.Constant.XmDIALOG_SELECTION,
        FileSelection = Native.Motif.Constant.XmDIALOG_FILE_SELECTION,
        WorkArea = Native.Motif.Constant.XmDIALOG_WORK_AREA,
    }

    /// <summary>
    /// ﾜーｸｴﾘｱの配置
    /// </summary>
    public enum Placement : byte{
        AboveSelection = Native.Motif.Constant.XmPLACE_ABOVE_SELECTION,
        BelowSelection = Native.Motif.Constant.XmPLACE_BELOW_SELECTION,
        Top = Native.Motif.Constant.XmPLACE_TOP
    }

    /// <summary>
    /// 中身の位置
    /// </summary>
    public enum ContentsAlignment : byte{
        BaselineBottom = Native.Motif.Constant.XmALIGNMENT_BASELINE_BOTTOM,
        BaselineTop = Native.Motif.Constant.XmALIGNMENT_BASELINE_TOP,
        ContentsBottom = Native.Motif.Constant.XmALIGNMENT_CONTENTS_BOTTOM,
        Center = Native.Motif.Constant.XmALIGNMENT_CENTER,
        ContentsTop  = Native.Motif.Constant.XmALIGNMENT_CONTENTS_TOP,
    }

    /// <summary>
    /// RowColumnのﾊﾟｯｷﾝｸﾞ
    /// </summary>
    public enum Packing : byte{
        None	= Native.Motif.Constant.XmPACK_NONE,
        Column	= Native.Motif.Constant.XmPACK_COLUMN,
        Tight	= Native.Motif.Constant.XmPACK_TIGHT
    }

    /// <summary>
    /// ﾎﾟｯﾌﾟｱｯﾌﾟの挙動
    /// </summary>
    public enum PopupType : byte { // TODO 名前がわかりにくい
        Keyboard = Native.Motif.Constant.XmPOPUP_KEYBOARD,
        Disabled = Native.Motif.Constant.XmPOPUP_DISABLED,
        Automatic = Native.Motif.Constant.XmPOPUP_AUTOMATIC,
        AutomaticRecursive = Native.Motif.Constant.XmPOPUP_AUTOMATIC_RECURSIVE,
    }

    /// <summary>
    /// RwColumnの種類
    /// </summary>
    public enum RowColumnType : byte{
        WorkArea = Native.Motif.Constant.XmWORK_AREA,
        MenuBar = Native.Motif.Constant.XmMENU_BAR,
        MenuPulldown = Native.Motif.Constant.XmMENU_PULLDOWN,
        MenuPopup = Native.Motif.Constant.XmMENU_POPUP
    }

    /// <summary>
    /// ﾒﾆｭーの切り離し設定
    /// </summary>
    public enum TearOffModel : byte{
        Enabled = Native.Motif.Constant.XmTEAR_OFF_ENABLED,
        Disabled = Native.Motif.Constant.XmTEAR_OFF_DISABLED,
    }

    /// <summary>
    /// 区切り線のｽﾀｲﾙ
    /// </summary>
    public enum SeparatorType : byte{
        SingleLine = Native.Motif.Constant.XmSINGLE_LINE,
        DoubleLine = Native.Motif.Constant.XmDOUBLE_LINE,
        SingleDashedLine = Native.Motif.Constant.XmSINGLE_DASHED_LINE,
        DoubleDashedLine = Native.Motif.Constant.XmDOUBLE_DASHED_LINE,
        NoLine = Native.Motif.Constant.XmNO_LINE,
        ShadowEtchedIn = Native.Motif.Constant.XmSHADOW_ETCHED_IN,
        ShadowEtchedOut = Native.Motif.Constant.XmSHADOW_ETCHED_OUT,
        ShadowEtchedInDash = Native.Motif.Constant.XmSHADOW_ETCHED_IN_DASH,
        ShadowEtchedOutDash = Native.Motif.Constant.XmSHADOW_ETCHED_OUT_DASH,
    }

    //
    // LIST
    //

    /// <summary>
    /// 自動選択ﾓーﾄﾞ
    /// </summary>
    public enum AutomaticSelection : byte{
        Auto  = Native.Motif.Constant.XmAUTO_SELECT,
        No = Native.Motif.Constant.XmNO_AUTO_SELECT,
        Single = Native.Motif.Constant.XmSINGLE_SELECT,
        Multiple = Native.Motif.Constant.XmMULTIPLE_SELECT,
        Extended = Native.Motif.Constant.XmEXTENDED_SELECT,
        Browse = Native.Motif.Constant.XmBROWSE_SELECT,
    }

    /// <summary>
    /// 項目の選択方式
    /// </summary>
    public enum SelectionPolicy : byte{
        Single  = Native.Motif.Constant.XmSINGLE_SELECT,
        Multiple = Native.Motif.Constant.XmMULTIPLE_SELECT,
        Extended = Native.Motif.Constant.XmEXTENDED_SELECT,
        Browse = Native.Motif.Constant.XmBROWSE_SELECT,
    }

    /// <summary>
    /// ｷーﾎﾞーﾄﾞﾅﾋﾞｹﾞーｼｮﾝ
    /// </summary>
    public enum MatchBehavior : byte{
        None = Native.Motif.Constant.XmNONE,
        QuickNavigate = Native.Motif.Constant.XmQUICK_NAVIGATE,
    }

    /// <summary>
    /// 選択項目の所有権
    /// </summary>
    public enum PrimaryOwnership : byte{
        Never = Native.Motif.Constant.XmOWN_NEVER,
        Always = Native.Motif.Constant.XmOWN_ALWAYS,
        Multiple = Native.Motif.Constant.XmOWN_MULTIPLE,
        PossibleMultiple = Native.Motif.Constant.XmOWN_POSSIBLE_MULTIPLE,
    };

    /// <summary>
    /// ﾘｽﾄのｻｲｽﾞ変更ﾎﾟﾘｼー
    /// </summary>
    public enum ListSizePolicy : byte{
        Variable = Native.Motif.Constant.XmVARIABLE,
        Constant = Native.Motif.Constant.XmCONSTANT,
        ResizeIfPossible = Native.Motif.Constant.XmRESIZE_IF_POSSIBLE,
    }

    /// <summary>
    /// 選択ﾓーﾄﾞ
    /// </summary>
    public enum SelectionMode : byte{
        Normal = Native.Motif.Constant.XmNORMAL_MODE,
        Add = Native.Motif.Constant.XmADD_MODE,
    }

    /// <summary>
    /// 選択項目の色
    /// </summary>
    public enum SelectColor {
        DefaultSelectColor = Native.Motif.Constant.XmDEFAULT_SELECT_COLOR,
        ReversedGroundColors = Native.Motif.Constant.XmREVERSED_GROUND_COLORS,
        HighlightColor = Native.Motif.Constant.XmHIGHLIGHT_COLOR,
    }

    /// <summary>
    /// ｲﾝｼﾞｹーﾀーのｽﾀｲﾙ
    /// </summary>
    public enum Indicator {
        None  = Native.Motif.Constant.XmINDICATOR_NONE,
        Fill  = Native.Motif.Constant.XmINDICATOR_FILL,
        Box   = Native.Motif.Constant.XmINDICATOR_BOX,
        Check     = Native.Motif.Constant.XmINDICATOR_CHECK,
        CheckBox = Native.Motif.Constant.XmINDICATOR_CHECK_BOX,
        Cross     = Native.Motif.Constant.XmINDICATOR_CROSS,
        CrossBox = Native.Motif.Constant.XmINDICATOR_CROSS_BOX,
    }

    /// <summary>
    /// ｲﾝｼﾞｹーﾀーの形
    /// </summary>
    public enum IndicatorType : byte{
        Many = Native.Motif.Constant.XmN_OF_MANY,
        OneOfMany = Native.Motif.Constant.XmONE_OF_MANY,
        Round = Native.Motif.Constant.XmONE_OF_MANY_ROUND,
        Diamond = Native.Motif.Constant.XmONE_OF_MANY_DIAMOND,
    }

    /// <summary>
    /// ﾄｸﾞﾙﾎﾞﾀﾝのｽﾃーﾄ
    /// </summary>
    public enum ToggleButtonState : byte{
        Unset  = Native.Motif.Constant.XmUNSET,
        Set  = Native.Motif.Constant.XmSET,
        Indeterminate  = Native.Motif.Constant.XmINDETERMINATE,
    }

    /// <summary>
    /// ﾄｸﾞﾙﾎﾞﾀﾝのﾓーﾄﾞ
    /// </summary>
    public enum ToggleMode : byte{
        Boolean = Native.Motif.Constant.XmTOGGLE_BOOLEAN,
        Indeterminate = Native.Motif.Constant.XmTOGGLE_INDETERMINATE,
    }


    /// <summary>
    /// 方向ﾌﾗｸﾞ
    /// </summary>
    [Flags]
    public enum Direction : byte{
        Ignored     = Native.Motif.Constant.XmDIRECTION_IGNORED,
        RightToLeftMask    = Native.Motif.Constant.XmRIGHT_TO_LEFT_MASK,
        LeftToRightMask    = Native.Motif.Constant.XmLEFT_TO_RIGHT_MASK,
        HorizontalMask       = Native.Motif.Constant.XmHORIZONTAL_MASK,
        TopToBottomMask    = Native.Motif.Constant.XmTOP_TO_BOTTOM_MASK,
        BottomToTopMask    = Native.Motif.Constant.XmBOTTOM_TO_TOP_MASK,
        VerticalMask         = Native.Motif.Constant.XmVERTICAL_MASK,
        PrecedenceHorizMask = Native.Motif.Constant.XmPRECEDENCE_HORIZ_MASK,
        PrecedenceVertMask  = Native.Motif.Constant.XmPRECEDENCE_VERT_MASK,
        PrecedenceMask       = Native.Motif.Constant.XmPRECEDENCE_MASK,
        RightToLeftTopToBottom =
            RightToLeftMask | TopToBottomMask | PrecedenceHorizMask,
        LeftToRightTopToBottom =
            LeftToRightMask | TopToBottomMask | PrecedenceHorizMask,
        RightToLeftBottomToTop =
            RightToLeftMask | BottomToTopMask | PrecedenceHorizMask,
        LeftToRightBottomToTop =
            LeftToRightMask | BottomToTopMask | PrecedenceHorizMask,
        TopToBottomRightToLeft =
            RightToLeftMask | TopToBottomMask | PrecedenceVertMask,
        TopToBottomLeftToRight =
            LeftToRightMask | TopToBottomMask | PrecedenceVertMask,
        BottomToTopRightToLeft =
            RightToLeftMask | BottomToTopMask | PrecedenceVertMask,
        BottomToTopLeftToRight =
            LeftToRightMask | BottomToTopMask | PrecedenceVertMask,
        TopToBottom =
            TopToBottomMask | HorizontalMask | PrecedenceMask,
        BottomToTop =
            BottomToTopMask | HorizontalMask | PrecedenceMask,
        RightToLeft =
            RightToLeftMask | VerticalMask | PrecedenceMask,
        LeftToRight =
            LeftToRightMask | VerticalMask | PrecedenceMask,
        DefaultDirection = 0xff

    }

    /// <summary>
    /// 単位
    /// </summary>
    public enum UnitType : byte{
        Pixels            = Native.Motif.Constant.XmPIXELS,
        Millimeters       = Native.Motif.Constant.XmMILLIMETERS,
        X100thMillimeters = Native.Motif.Constant.Xm100TH_MILLIMETERS,
        Centimeters       = Native.Motif.Constant.XmCENTIMETERS,
        Inches            = Native.Motif.Constant.XmINCHES,
        X1000thInches     = Native.Motif.Constant.Xm1000TH_INCHES,
        Points            = Native.Motif.Constant.XmPOINTS,
        X100thPoints      = Native.Motif.Constant.Xm100TH_POINTS,
        FontUnits        = Native.Motif.Constant.XmFONT_UNITS,
        X100thFontUnits  = Native.Motif.Constant.Xm100TH_FONT_UNITS,
    }

    /// <summary>
    /// ﾄﾞﾗｯｸﾞ許容
    /// </summary>
    public enum DragModel : byte{
        Enabled = Native.Motif.Constant.XmAUTO_DRAG_ENABLED,
        Disabled = Native.Motif.Constant.XmAUTO_DRAG_DISABLED,
    }

    /// <summary>
    /// ｽｸﾛーﾙﾊﾞーの表示条件
    /// </summary>
    public enum ScrollBarDisplayPolicy : byte{
        AsNeeded =  Native.Motif.Constant.XmAS_NEEDED,
        Static = Native.Motif.Constant.XmSTATIC,
    }

    /// <summary>
    /// ｽｸﾛーﾙ方法
    /// </summary>
    public enum ScrollingPolicy : byte{
        Automatic = Native.Motif.Constant.XmAUTOMATIC,
        Constant  = Native.Motif.Constant.XmCONSTANT,
        ApplicationDefined = Native.Motif.Constant.XmAPPLICATION_DEFINED,
    }

    /// <summary>
    /// ｽｸﾛーﾙｳｲﾝﾄﾞｳの中身
    /// </summary>
    public enum VisualPolicy : byte{
        Variable = Native.Motif.Constant.XmVARIABLE,
        Static    = Native.Motif.Constant.XmSTATIC,
        Constant = Native.Motif.Constant.XmCONSTANT,

    }

    /// <summary>
    /// ｽｸﾛーﾙﾊﾞーの位置
    /// </summary>
    public enum ScrollBarPlacement : byte{
        TopLeft  = Native.Motif.Constant.XmTOP_LEFT,
        BottomLeft = Native.Motif.Constant.XmBOTTOM_LEFT,
        TopRight = Native.Motif.Constant.XmTOP_RIGHT,
        BottomRight = Native.Motif.Constant.XmBOTTOM_RIGHT,
    }

    /// <summary>
    /// ｽｸﾛーﾙｳｲﾝﾄﾞｳの子供達
    /// </summary>
    public enum ScrolledWindowChildType : byte{
        WorkArea = Native.Motif.Constant.XmWORK_AREA,
        HorScrollbar = Native.Motif.Constant.XmHOR_SCROLLBAR,
        VertScrollbar = Native.Motif.Constant.XmVERT_SCROLLBAR,
        CommandWindow = Native.Motif.Constant.XmCOMMAND_WINDOW,
        MessageWindow = Native.Motif.Constant.XmMESSAGE_WINDOW,
        ScrollHor = Native.Motif.Constant.XmSCROLL_HOR,
        ScrollVert = Native.Motif.Constant.XmSCROLL_VERT,
        NoScroll = Native.Motif.Constant.XmNO_SCROLL,
        ClipWindow = Native.Motif.Constant.XmCLIP_WINDOW,
        GenericChild =  Native.Motif.Constant.XmGENERIC_CHILD,
    }

    /// <summary>
    /// ｺﾏﾝﾄﾞｳｲﾝﾄﾞｳの配置
    /// </summary>
    public enum CommandWindowLocation {
        AboveWorkspace =  Native.Motif.Constant.XmCOMMAND_ABOVE_WORKSPACE,
        BelowWorkspace =  Native.Motif.Constant.XmCOMMAND_BELOW_WORKSPACE,
    }

    /// <summary>
    /// Frameに束縛される際の処遇
    /// </summary>
    public enum FrameChildType : byte {
        TitleChild     =  Native.Motif.Constant.XmFRAME_TITLE_CHILD,
        WorkareaChild  =  Native.Motif.Constant.XmFRAME_WORKAREA_CHILD,
        GenericChild   =  Native.Motif.Constant.XmFRAME_GENERIC_CHILD,
    }

	/// <summary>
	/// ﾚｲｱｳﾄ条件
	/// </summary>
	public enum AttachmentType : byte
	{
        None = Native.Motif.Constant.XmATTACH_NONE,
        Form = Native.Motif.Constant.XmATTACH_FORM,

        OppositeForm = Native.Motif.Constant.XmATTACH_OPPOSITE_FORM,
		Widget = Native.Motif.Constant.XmATTACH_WIDGET,

        OppositeWidget = Native.Motif.Constant.XmATTACH_OPPOSITE_WIDGET,
        Position = Native.Motif.Constant.XmATTACH_POSITION,
		Self = Native.Motif.Constant.XmATTACH_SELF
	}


	/// <summary>
	/// 表示方向
	/// </summary>
	public enum Orientation : byte
	{
        Horizontal = Native.Motif.Constant.XmHORIZONTAL,
		Vertical = Native.Motif.Constant.XmVERTICAL
	}


	/// <summary>
	/// ﾀﾌﾞｸﾞﾙーﾌﾟでの動作を指定する
	/// </summary>
	public enum NavigationType : byte
	{
		None = Native.Motif.Constant.XmNONE,
		TabGroup = Native.Motif.Constant.XmTAB_GROUP,
		StickyTabGroup = Native.Motif.Constant.XmSTICKY_TAB_GROUP,
		ExclusiveTabGroup = Native.Motif.Constant.XmEXCLUSIVE_TAB_GROUP,
	}


	/// <summary>
	/// 配置
	/// </summary>
	public enum Alignment : byte
	{
        Beginning = Native.Motif.Constant.XmALIGNMENT_BEGINNING,
		Center = Native.Motif.Constant.XmALIGNMENT_CENTER,
		End = Native.Motif.Constant.XmALIGNMENT_END,
	}

    /// <summary>
    /// 子ｳｲｼﾞｪｯﾄの配置
    /// </summary>
    public enum ChildAlignment : byte {
        BaselineBottom = Native.Motif.Constant.XmALIGNMENT_BASELINE_BOTTOM,
        BaselineTop    = Native.Motif.Constant.XmALIGNMENT_BASELINE_TOP,
        ChildTop       = Native.Motif.Constant.XmALIGNMENT_CHILD_TOP,
        Center          = Native.Motif.Constant.XmALIGNMENT_CENTER,
        ChildBottom    = Native.Motif.Constant.XmALIGNMENT_CHILD_BOTTOM,
    }


	/// <summary>
	/// SpinBox の矢印ﾎﾞﾀﾝ配置
	/// </summary>
	public enum ArrowLayout : byte
	{
        Beginning = Native.Motif.Constant.XmARROWS_BEGINNING,
        End = Native.Motif.Constant.XmARROWS_END,
		FlatBeginning = Native.Motif.Constant.XmARROWS_FLAT_BEGINNING,
		FlatEnd = Native.Motif.Constant.XmARROWS_FLAT_END,
		Split = Native.Motif.Constant.XmARROWS_SPLIT,
	}

    /// <summary>
    /// SpinBoxの矢印ﾎﾞﾀﾝの挙動
    /// </summary>
    public enum ArrowSensitivity : byte{
        Sensitive = Native.Motif.Constant.XmARROWS_SENSITIVE,
        DecrementSensitive = Native.Motif.Constant.XmARROWS_DECREMENT_SENSITIVE,
        IncrementSensitive = Native.Motif.Constant.XmARROWS_INCREMENT_SENSITIVE,
        Insensitive = Native.Motif.Constant.XmARROWS_INSENSITIVE,
        Default = Native.Motif.Constant.XmARROWS_DEFAULT_SENSITIVITY
    }

    /// <summary>
    /// SpinBoxの表示項目の種類
    /// </summary>
    public enum SpinBoxChildType : byte{
        String = Native.Motif.Constant.XmSTRING,
        Numeric = Native.Motif.Constant.XmNUMERIC,
    }

    /// <summary>
    /// SpinBoxの値の
    /// </summary>
    public enum SpinBoxPositionType : byte{
        Index = Native.Motif.Constant.XmPOSITION_INDEX,
        Value = Native.Motif.Constant.XmPOSITION_VALUE,
    }



	/// <summary>
	/// 矢印ﾎﾞﾀﾝの方向
	/// </summary>
	public enum ArrowOrientation : byte
	{
		Vertical = Native.Motif.Constant.XmARROWS_VERTICAL,
		Horizontal = Native.Motif.Constant.XmARROWS_HORIZONTAL,
	}

    /// <summary>
    ///　FileSelectionBoxのﾊﾟｽﾓーﾄﾞ
    /// </summary>
    public enum PathMode {
       Full = Native.Motif.Constant.XmPATH_MODE_FULL,
       Relative  = Native.Motif.Constant.XmPATH_MODE_RELATIVE
    }

    /// <summary>
    /// FileSelectionBoxのﾌｧｲﾙﾀｲﾌﾟ
    /// </summary>
    [Flags]
    public enum FileTypeMask :byte{
        Directory = Native.Motif.Constant.XmFILE_DIRECTORY,
        Regular = Native.Motif.Constant.XmFILE_REGULAR,
        Any = Native.Motif.Constant.XmFILE_ANY_TYPE,
    }

    /// <summary>
    /// SelectionBoxのﾌｨﾙﾀーのｽﾀｲﾙ
    /// </summary>
    public enum FileFilterStyle {
        HiddenFiles	= Native.Motif.Constant.XmFILTER_HIDDEN_FILES,
        None	= Native.Motif.Constant.XmFILTER_NONE,
    }

	/// <summary>
	/// TabStackのﾓーﾄﾞ
	/// </summary>
    public enum TabMode {
        Basic = Native.Motif.Constant.XmTABS_BASIC,
        Stacked =  Native.Motif.Constant.XmTABS_STACKED,
        StackedStatic = Native.Motif.Constant.XmTABS_STACKED_STATIC,
    }

	/// <summary>
	/// TabStackの方向
	/// </summary>
    public enum TabOrientation {
        Dynamic = Native.Motif.Constant.XmTAB_ORIENTATION_DYNAMIC,
        LeftToRight = Native.Motif.Constant.XmTABS_LEFT_TO_RIGHT,
        RightToLeft = Native.Motif.Constant.XmTABS_RIGHT_TO_LEFT,
        TopToBottom = Native.Motif.Constant.XmTABS_TOP_TO_BOTTOM,
        BottomToTop = Native.Motif.Constant.XmTABS_BOTTOM_TO_TOP,
    }

	/// <summary>
	/// TabStackのﾀﾌﾞ位置
	/// </summary>
    public enum TabSide {
        Top = Native.Motif.Constant.XmTABS_ON_TOP,
        Bottom = Native.Motif.Constant.XmTABS_ON_BOTTOM,
        Right = Native.Motif.Constant.XmTABS_ON_RIGHT,
        Left = Native.Motif.Constant.XmTABS_ON_LEFT,

    }

    /// <summary>
	/// TabStackのｽﾀｲﾙ
	/// </summary>
    public enum TabStyle {
        Beveled = Native.Motif.Constant.XmTABS_BEVELED,
        Rounded = Native.Motif.Constant.XmTABS_ROUNDED,
        Squared = Native.Motif.Constant.XmTABS_SQUARED,
    }

	/// <summary>
	/// ﾒﾆｭーのﾎﾞﾀﾝの種類
	/// </summary>
    public enum MenuButtonType : byte {
        Pushbutton = Native.Motif.Constant.XmPUSHBUTTON,
        Togglebutton = Native.Motif.Constant.XmTOGGLEBUTTON,
        Radiobutton = Native.Motif.Constant.XmRADIOBUTTON,
        Cascadebutton = Native.Motif.Constant.XmCASCADEBUTTON,
        Separator = Native.Motif.Constant.XmSEPARATOR,
        DoubleSeparator = Native.Motif.Constant.XmDOUBLE_SEPARATOR,
        Title = Native.Motif.Constant.XmTITLE,
        Checkbutton = Native.Motif.Constant.XmCHECKBUTTON,
    }

	/// <summary>
	/// FillOption
	/// </summary>
    public enum FillOption : byte{
        None = Native.Motif.Constant.XmFillNone,
        Major = Native.Motif.Constant.XmFillMajor,
        Minor = Native.Motif.Constant.XmFillMinor,
        All = Native.Motif.Constant.XmFillAll,
    }

    /// <summary>
	/// ComboBoxの種類
	/// </summary>
    public enum ComboBoxType {
        ComboBox = Native.Motif.Constant.XmCOMBO_BOX,
        DropDownComboBox = Native.Motif.Constant.XmDROP_DOWN_COMBO_BOX,
        DropDownList = Native.Motif.Constant.XmDROP_DOWN_LIST,
    }

    /// <summary>
	/// ComboBoxの基準
	/// </summary>
    public enum PositionMode {
        ZeroBased = Native.Motif.Constant.XmZERO_BASED,
        OneBased = Native.Motif.Constant.XmONE_BASED,
    }

    /// <summary>
    /// Scaleのﾗﾍﾞﾙ位置
    /// </summary>
    public enum ShowValuePosition {
        None          = Native.Motif.Constant.XmNONE,
        NearSlider   = Native.Motif.Constant.XmNEAR_SLIDER,
        NearBorder   = Native.Motif.Constant.XmNEAR_BORDER,
    }

    /// <summary>
	/// ｳｲﾝﾄﾞーの状態
	/// </summary>
    public enum WindowState {
        Normal = 1,
        Iconic = 3
    }
}
