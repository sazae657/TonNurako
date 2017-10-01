#!/bin/sh

#RULES_OK="check.localized/rules.ok"
#RULES_INC="check.localized/rules.inc"
#RULES_LIB="check.localized/rules.lib"

# pkgconfig
LIBS_Xt=""
CFLAGS_Xt=""

LIBS_Xmu=""
CFLAGS_Xmu=""



XLIB_FOUND="NO"
XMU_FOUND="NO"
XT_LIBS=$(pkg-config --libs xt)
if [ "x" != "x${XT_LIBS}" ];then
   echo found X11 from pkgconfig
   LIBS_Xt="${XT_LIBS}"
   CFLAGS_Xt=$(pkg-config --cflags xt)
   XLIB_FOUND="YES"
fi

XMU_LIBS=$(pkg-config --libs xmu)
if [ "x" != "x${XMU_LIBS}" ];then
   echo found Xmu from pkgconfig
   LIBS_Xmu="${XMU_LIBS}"
   CFLAGS_Xmu=$(pkg-config --cflags xt)
   XMU_FOUND="YES"
fi

if [ "xNO" = "x${XLIB_FOUND}" ];then
	TLIB="-lXt -lX11" TSRC=${KWD}/check.localized/check_xlib.c ${KWD}/check.localized/try_compile.sh
	if [ ! -f ${RULES_OK} ];then
		echo "libXtがないよう"	
		exit 9
	fi
	LIBS_Xt=$(cat ${RULES_LIB})
	CFLAGS_Xt=$(cat ${RULES_INC})
fi

if [ "xNO" = "x${XMU_FOUND}" ];then
	TLIB="-lXmu -lXt -lX11" TSRC=${KWD}/check.localized/check_xmu.c ${KWD}/check.localized/try_compile.sh
	if [ ! -f ${RULES_OK} ];then
		echo "libXmuがないよう"	
		exit 9
	fi
	LIBS_Xmu=$(cat ${RULES_LIB})
	CFLAGS_Xmu=$(cat ${RULES_INC})
fi

echo "Xt:LIBS=$LIBS_Xt"
echo "Xt:CFLAGS=$CFLAGS_Xt"
cc ${CFLAGS_Xt} -o ${KWD}/a.out ${KWD}/check.localized/check_xlib.c ${LIBS_Xt}   || exit 9
echo "-- Xt Check OK --"

echo "Xt:LIBS=$LIBS_Xmu"
echo "Xt:CFLAGS=$CFLAGS_Xmu"
cc ${CFLAGS_Xmu} -o ${KWD}/a.out ${KWD}/check.localized/check_xmu.c ${LIBS_Xmu}  || exit 9
echo "-- Xmu Check OK --"

echo "X11_HEADER_ARGS := ${CFLAGS_Xt} ${CFLAGS_Xmu}" >>${SITE_MP3}
echo "X11_LIBS := ${LIBS_Xmu} ${LIBS_Xt}" >>${SITE_MP3}

