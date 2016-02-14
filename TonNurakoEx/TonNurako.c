#include "TonNurako.h"

TNK_DECLARE_BEGIN

TNK_EXPORT
unsigned int TNK_GetVersion()
{
    return (TONNURAKO_EX_MAJOR_VERSION * 1000 + TONNURAKO_EX_MINOR_VERSION);
}

TNK_EXPORT
unsigned int TNK_GetMotifVersion() {
    return xmUseVersion;
}

TNK_EXPORT
const char* TNK_GetMotifVersionString() {
    return XmVERSION_STRING;
}

TNK_EXPORT Widget
TNK_XtAppCreateShell(
	LPTNK_APP_CONTEXT pContext,
	const char *strAppTitle,  char *argv[], int argc, ArgList arglist,Cardinal argcount )
{
	Widget w;
    //XColor color;

	CONS25W( stderr, "XtAppCreateShell a=%p d=%p n=%s cm=%ld\n"
			, pContext->context, pContext->display
			, strAppTitle, pContext->colormap );

	//Shellｳｲｼﾞｪｯﾄの作成
	w = XtAppCreateShell( NULL, strAppTitle,
		applicationShellWidgetClass, pContext->display,
		arglist, argcount);

	XtAddEventHandler(w, 0, True, _XEditResCheckMessages, NULL);

	#ifdef _DEBUG
	CONS25W( stderr, "XtAppCreateShell a=%p d=%p w=%p n=%s cm=%ld\n"
			, pContext->context, pContext->display
			, w ,strAppTitle, pContext->colormap );
	#endif

	return w;
}


TNK_EXPORT int
TNK_XtInitialize(
	LPTNK_APP_CONTEXT pContext,
	const char *strAppTitle,
    char *argv[], int argc,
	char *resFallBack[] , int resc)
{
    String* copyArgv;
    int copyArgc;
	int i;
    size_t len;

    CONS25W(stderr, "TNK_XtInitialize call\n");

    copyArgv = NULL;
    copyArgc = 0;

    pContext->context = (XtAppContext)0x1;
    pContext->display = (Display*)0x2;

	//Xtの初期化
	XtToolkitInitialize();

	//ｱﾌﾟﾘｹーｼｮﾝｺﾝﾃｷｽﾄの作成
	pContext->context = XtCreateApplicationContext();
    if (NULL == pContext->context) {
        return TNK_ERR_CREATE_CONTEXT_FAILED;
    }

	//言語ﾌﾟﾛｼーｼﾞｬの初期化
	XtSetLanguageProc( NULL, NULL, NULL );

	//予備ﾘｿーｽの設定(あれば)
	if (resc > 0) {
        #ifdef _DEBUG
        for( i = 0; i < resc; i++ ) {
            CONS25W( stderr, "TNK_XtInitialize: fr[%d] %s\n", i, resFallBack[i]);
        }
        #endif
		XtAppSetFallbackResources( pContext->context, resFallBack );
    }
    CONS25W(stderr, "TNK_XtInitialize %d\n", __LINE__);
    if (argc > 0) {
        copyArgc = argc;
        copyArgv = (String*)malloc(sizeof(String) * (1 + argc));

        for( i = 0; i < argc; i++ ) {
            len = 1 + strlen(argv[i]);
            copyArgv[i] = (String)calloc(len, sizeof(char));
            memcpy((void*)copyArgv[i], (const void*)argv[i], len);
            #ifdef _DEBUG
            CONS25W( stderr, "TNK_XtInitialize[%d] %s\n", i, copyArgv[i]);
            #endif
        }
        copyArgv[argc] = NULL;
    }

    copyArgc = argc;
	//ﾃﾞｨｽﾌﾟﾚｲのOpen
	pContext->display = XtOpenDisplay( pContext->context, NULL,
		NULL, strAppTitle, NULL, 0, &copyArgc, copyArgv);
    if (NULL == pContext->display) {
        return TNK_ERR_CANNOT_OPEN_DISPLAY;
    }

    if (NULL != copyArgv) {
        for( i = 0; i < argc; i++ ) {
            #ifdef _DEBUG
            CONS25W( stderr, "TNK_XtInitialize[%d] F: %s\n", i, copyArgv[i]);
            #endif
            free(copyArgv[i]);
        }
        free(copyArgv);
    }

    XmRepTypeInstallTearOffModelConverter();

	return 0;
}

void
dumpbin(const void* p, size_t len, const char* fs)
{
    FILE* fp = fopen(fs, "wb");
    fwrite(p, len, 1, fp);
    fclose(fp);
}


//
// Pixmap
//
TNK_EXPORT int
TNK_LoadPixmapFromBuffer(Display* display, Widget widget, TNK_PIXMAX* pix, char* buffer) {
	int ret = 0;
    pix->dpy = display;
    pix->pix = 0L;
    pix->mask = 0L;
    pix->attr = NULL;

    dumpbin((const void*)buffer, strlen(buffer), "dump.xpm");

    if((ret = XpmCreatePixmapFromBuffer(display,
				  RootWindowOfScreen(XtScreen(widget)),
				  buffer, &pix->pix,
				  &pix->mask, NULL)) != XpmSuccess)
    {
        return ret;
    }
    return ret;

}

TNK_EXPORT void
TNK_FreePixmapBuffer(TNK_PIXMAX* pix) {
    if (0L != pix->pix) {
        CONS25W( stderr, "XFreePixmap<P>(pix->%p, pix->%ld)\n", pix->dpy, pix->pix);
        XFreePixmap(pix->dpy, pix->pix);
        pix->pix = 0L;
    }
    if (0L != pix->mask) {
        CONS25W( stderr, "XFreePixmap<M>(pix->%p, pix->%ld)\n", pix->dpy, pix->pix);
        XFreePixmap(pix->dpy, pix->mask);
        pix->mask = 0L;
    }
}

TNK_EXPORT int
TNK_CreateCompoundTextProperty(XTextProperty* tprop, Display* display, String text) {
    return XmbTextListToTextProperty(display, &text, 1, XCompoundTextStyle, tprop);
}

TNK_EXPORT void
TNK_FreeCompoundTextProperty(XTextProperty* tprop) {
    if (NULL != tprop->value) {
        XFree(tprop->value);
        tprop->value = NULL;
    }
}
TNK_DECLARE_END
