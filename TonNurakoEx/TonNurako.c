#include "TonNurako.h"

TNK_DECLARE_BEGIN

#define TNK_INTERNAL_EVENT "_TNK_INTERNAL_EVENT"

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

typedef int(*Arg1ReturnInt)(void*);
TNK_EXPORT
int TNK_CallPtrArg1ReturnInt(Arg1ReturnInt fn, void* p) {
    return fn(p);
}

TNK_EXPORT char *setlocale_TNK(int category, const char *locale) {
    return setlocale(category, locale);
}

// ﾄﾝﾇﾗﾌﾟﾗｲﾍﾞーﾄﾊﾝﾄﾞﾗー
typedef void(*TonnuraCB)(void);
void TonnuaInternalHandler(Widget w, XtPointer client_data, XEvent *ev, Boolean* bo)
{
    Atom atm = XInternAtom(XtDisplay(w), TNK_INTERNAL_EVENT, False);

    if ((ev->type != ClientMessage) ||
      (ev->xclient.message_type != atm)) {
           return;
    }
    ((TonnuraCB)(client_data))();
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
        sessionShellWidgetClass
        , pContext->display,
		arglist, argcount);

    // EditRes
	XtAddEventHandler(w, 0, True, _XEditResCheckMessages, NULL);

    // ﾄﾝﾇﾗﾊﾝﾄﾞﾗー
    XtAddEventHandler(w, NoEventMask, True, TonnuaInternalHandler, (XtPointer)pContext->comm);

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

    XInitThreads();

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
        copyArgv = (String*)XtMalloc((1+argc) * sizeof(String));
        if (NULL == copyArgv) {
            return TNK_ALLOC_FAILED;
        }

        for( i = 0; i < argc; i++ ) {
            len = strlen(argv[i]);
            if (len == 0) {
                copyArgv[i] = NULL;
                continue;
            }
            copyArgv[i] = (String)XtCalloc(len+1, sizeof(char));
            memcpy((void*)copyArgv[i], (const void*)argv[i], len);
            #ifdef _DEBUG
            CONS25W( stderr, "TNK_XtInitialize[%d] %s\n", i, copyArgv[i]);
            #endif
        }
        copyArgv[argc] = NULL;
    }

    copyArgc = argc;
	//ﾃﾞｨｽﾌﾟﾚｲのOpen
	pContext->display = XtOpenDisplay( pContext->context, pContext->display_string,
		NULL, strAppTitle, NULL, 0, &copyArgc, copyArgv);

    if (NULL != copyArgv) {
        for( i = 0; i < argc; i++ ) {
            #ifdef _DEBUG
            CONS25W( stderr, "TNK_XtInitialize[%d] F: %s\n", i, copyArgv[i]);
            #endif
            XtFree(copyArgv[i]);
        }
        XtFree((String)copyArgv);
    }
    if (NULL == pContext->display) {
        return TNK_ERR_CANNOT_OPEN_DISPLAY;
    }

    XmRepTypeInstallTearOffModelConverter();

	return 0;
}

void TNK_IMP_TriggerPrivateEvent(LPTNK_APP_CONTEXT app, Widget widget) {
    XtAppLock(app->context);
    XFlush(XtDisplay(widget));

    XClientMessageEvent ev;
    memset(&ev, 0, sizeof(XClientMessageEvent));

    ev.display = XtDisplay(widget);
    ev.window = XtWindow(widget);
    ev.type = ClientMessage;
    ev.message_type = XInternAtom(ev.display, TNK_INTERNAL_EVENT, False);
    ev.format = 32;
    XSendEvent(ev.display, ev.window, False, NoEventMask, (XEvent *)&ev);
    XFlush(XtDisplay(widget));
    XtAppUnlock(app->context);
}


void TNK_IMP_Flush(LPTNK_APP_CONTEXT app, Widget widget) {
    XFlush(XtDisplay(widget));
}

#define ARRAY_LENGTH(array) (sizeof(array) / sizeof(array[0]))

void TNK_IMP_SplitXClientMessageEventData(
    const XClientMessageEvent* src, TNK_XClientMessageEventData* ev, TNK_XClientMessageEventStudio* studio)
{
    memset(ev, 0xcc, sizeof(TNK_XClientMessageEventData));

    memcpy(&ev->event, src, sizeof(XClientMessageEvent));
    memcpy(ev->data.b, src->data.b, sizeof(src->data.b));
    memcpy(ev->data.s, src->data.s, sizeof(src->data.s));
    memcpy(ev->data.l, src->data.l, sizeof(src->data.l));
}


void
dumpbin(const void* p, size_t len, const char* fs)
{
    FILE* fp = fopen(fs, "wb");
    fwrite(p, len, 1, fp);
    fclose(fp);
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
