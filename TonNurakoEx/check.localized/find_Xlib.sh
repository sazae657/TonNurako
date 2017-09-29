#!/bin/sh

#RULES_OK="check.localized/rules.ok"
#RULES_INC="check.localized/rules.inc"
#RULES_LIB="check.localized/rules.lib"

# pkgconfig
LIBS=""
CFLAGS=""
XLIB_FOUND="NO"
XMU_FOUND="NO"
XT_LIBS=$(pkg-config --libs xt)
if [ "x" != "x${XT_LIBS}" ];then
   echo found X11 from pkgconfig
   LIBS=${XT_LIBS}
   CFLAGS=$(pkg-config --cflags xt)
   XLIB_FOUND="YES"
fi

XMU_LIBS=$(pkg-config --libs xmu)
if [ "x" != "x${XMU_LIBS}" ];then
   echo found Xmu from pkgconfig
   LIBS="${LIBS} ${XMU_LIBS}"
   CFLAGS="${CFLAGS} $(pkg-config --cflags xt)"
   XMU_FOUND="YES"
fi

if [ "xNO" = "x${XLIB_FOUND}" ];then
	TLIB="-lXt -lX11" TSRC=${KWD}/check.localized/check_xlib.c ${KWD}/check.localized/try_compile.sh
	if [ ! -f ${RULES_OK} ];then
		echo "libXtがないよう"	
		exit 9
	fi
	LIBS="${LIBS} $(cat ${RULES_LIB})"
	CFLAGS="${CFLAGS} $(cat ${RULES_INC})"
fi

if [ "xNO" = "x${XMU_FOUND}" ];then
	TLIB="-lXmu -lXt -lX11" TSRC=${KWD}/check.localized/check_xmu.c ${KWD}/check.localized/try_compile.sh
	if [ ! -f ${RULES_OK} ];then
		echo "libXmuがないよう"	
		exit 9
	fi
	LIBS="${LIBS} $(cat ${RULES_LIB})"
	CFLAGS="${CFLAGS} $(cat ${RULES_INC})"
fi

#echo "LIBS=$LIBS"
#echo "CFLAGS=$CFLAGS"
cc ${CFLAGS} ${LIBS} ${KWD}/check.localized/check_xlib.c -o ${KWD}/a.out 2>&1 || echo "XLIB!!"
cc ${CFLAGS} ${LIBS} ${KWD}/check.localized/check_xmu.c -o ${KWD}/a.out 2>&1 || echo "XLIB!!"

echo "X11_HEADER_ARGS := ${CFLAGS}" >>${SITE_MP3}
echo "X11_LIBS := ${LIBS}" >>${SITE_MP3}

