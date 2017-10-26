﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Widgets;

namespace TonNurako.Xt.Core {
    public delegate void XtProc();

    [StructLayout(LayoutKind.Sequential)]
    internal struct XtCallbackRec {
        [MarshalAs(UnmanagedType.FunctionPtr)] XtCallbackProc callback;
        IntPtr closure;
    }

    internal delegate void XtCallbackProc(
          IntPtr        widget,
          IntPtr         closure ,
          IntPtr         call_data
      );

    internal delegate void XtEventHandler(
        IntPtr        widget,
        IntPtr        closure,
        IntPtr       xevent,//XEvent*
         IntPtr      continue_to_dispatch //Boolean*
        );


    internal delegate void XtActionProc(
          IntPtr   widget,
          IntPtr   xevent , //XEvent*
          IntPtr   xparams, //String*
          IntPtr   num_params //Cardinal*
    );


    //
    // WidgetClass
    //

    internal delegate void XtWidgetClassProc(IntPtr widgetClass); //WidgetClass
    public delegate void XtWidgetClassDelegate(CoreWidgetClass widgetClass);

    //
    // Init
    //

    internal delegate void XtInitProc(
      IntPtr request, // Widget
      IntPtr xnew, // Widget
      IntPtr argList, //,
      IntPtr num_args //Cardinal*
    );

    public delegate void XtInitDelegate(
      IWidget request, // Widget
      IWidget xnew, // Widget
      XtArg[] argList
    );

    //
    // Args
    //

    internal delegate void XtArgsProc(
      IntPtr widget, // Widget
      IntPtr argList, // ArgList
      IntPtr num_args //Cardinal*
    );

    public delegate void XtArgsDelegate(
      IWidget widget, // Widget
      XtArg[] argList // ArgList
    );

    //
    // Realise
    //

    internal delegate void XtRealizeProc(
          IntPtr widget,
          IntPtr mask, //XtValueMask*
          IntPtr attributes //XSetWindowAttributes
      );
    public delegate void XtRealizeDelegate(
          IWidget widget,
          X11.ChangeWindowAttributes mask, //XtValueMask*
          X11.XSetWindowAttributes attributes //XSetWindowAttributes
      );


    //
    // Widget
    //

    internal delegate void XtWidgetProc(
          IntPtr widget
      );

    public delegate void XtWidgetDelegate(
          IWidget widget
      );

    //
    // Expose
    //
    internal delegate void XtExposeProc(
          IntPtr widget,
          IntPtr xevent, //XEvent
          IntPtr region // Region
      );

    public delegate void XtExposeDelegate(
          IWidget widget,
          X11.Event.XEventArg xevent, //XEvent
          X11.Region region // Region
      );

    //
    // SetValuesFunc
    //
    internal delegate bool XtSetValuesFunc(
        IntPtr old, // Widget
        IntPtr request,// Widget
        IntPtr xnew,// Widget
        IntPtr args, //ArgList
        IntPtr num_args // Cardinal*
    );

    public delegate bool XtSetValuesDelegate(
        IWidget old, // Widget
        IWidget request,// Widget
        IWidget xnew,// Widget
        XtArg[] args //ArgList
    );

    //
    // Almost
    //
    internal delegate void XtAlmostProc(
          IntPtr old, //Widget
          IntPtr xnew, //Widget
          IntPtr request, //XtWidgetGeometry*
          IntPtr reply //XtWidgetGeometry*
      );

    public delegate XtWidgetGeometry XtAlmostDelegate(
          IWidget old, //Widget
          IWidget xnew, //Widget
          XtWidgetGeometry request //XtWidgetGeometry*
    );

    //
    // AcceptFocus
    //

    internal delegate bool XtAcceptFocusProc(
       IntPtr widget, //Widget
       IntPtr time // Time*
    );

    public delegate bool XtAcceptFocusDelegate(
        IWidget widget, //Widget
        int time // Time*
    );

    //
    // Geometry
    //
    internal delegate void XtGeometryHandler(
          IntPtr widget, //Widget
          IntPtr request, //XtWidgetGeometry*
          IntPtr reply //XtWidgetGeometry*
      );
    public delegate XtWidgetGeometry XtGeometryHandlerDelegate(
          IWidget widget, //Widget
          XtWidgetGeometry request //XtWidgetGeometry*
      );

    //
    // String
    //
    internal delegate void XtStringProc(
          IntPtr widget,//Widget
          IntPtr str //String
    );

    public delegate void XtStringProcDelegate(
          IWidget widget,//Widget
          string str //String
    );

}
