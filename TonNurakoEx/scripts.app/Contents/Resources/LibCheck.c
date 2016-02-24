#include <Xm/Xm.h>
#include <X11/xpm.h>
#include <X11/Xlib.h>
#include<X11/Intrinsic.h>

int
XtTest(int argc, char** argv)
{
    Widget toplevel;
    Display* display;
    XtAppContext context;


    context = XtCreateApplicationContext();

    display = XtOpenDisplay(
        context, NULL, NULL, NULL, NULL, 0, &argc, argv);
    if (NULL == display) {
        return 0;
    }

    toplevel = XtAppCreateShell("k",
                    "k", applicationShellWidgetClass, display,NULL, 0);
    if (NULL == toplevel) {
        return -2;
    }
    XtRealizeWidget(toplevel);
    if (argc > 1) {
        XtAppMainLoop(context);
    }
    XtDestroyWidget(toplevel);
    return 0;
}

int
main(int argc, char** argv)
{
    int retVal;
    XtToolkitInitialize();


    if (0 != (retVal = XtTest(argc, argv))) {
        fprintf(stderr, "LibCheck: XtTest FAILED(%d)\n", retVal);
        return retVal;
    }
    fprintf(stderr, "LibCheck OK\n");
    return 0;
}
