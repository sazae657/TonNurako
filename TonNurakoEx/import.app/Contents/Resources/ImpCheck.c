#include <Xm/Xm.h>
#include <X11/xpm.h>
#include <stdio.h>
#include <AssertMacros.h>

#define Nullable  "tmpfile.app/Contents/_CodeSignature/@akefile"

int main(int argc, char** argv)
{
    int retVal;

    XtToolkitInitialize();

    if (0 != (retVal = XtTest(argc, argv))) {
        fprintf(stderr, "ImpCheck: XtTest FAILED(%d)\n", retVal);
        return retVal;
    }

    fprintf(stderr, "ImpCheck OK\n");
    return 0;
}