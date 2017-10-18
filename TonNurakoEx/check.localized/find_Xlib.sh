#!/bin/sh

#RULES_OK="check.localized/rules.ok"
#RULES_INC="check.localized/rules.inc"
#RULES_LIB="check.localized/rules.lib"

# pkgconfig
LIBS_Xt=""
CFLAGS_Xt=""

LIBS_Xmu=""
CFLAGS_Xmu=""

LIBS_Xext=""
CFLAGS_Xext=""

LIBS_Xr=""
CFLAGS_Xr=""

XLIB_FOUND="NO"
XMU_FOUND="NO"
XEXT_FOUND="NO"
XR_FOUND="NO"

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
   CFLAGS_Xmu=$(pkg-config --cflags xmu)
   XMU_FOUND="YES"
fi

XEXT_LIBS=$(pkg-config --libs xext)
if [ "x" != "x${XEXT_LIBS}" ];then
   echo found Xext from pkgconfig
   LIBS_Xext="${XEXT_LIBS}"
   CFLAGS_Xext=$(pkg-config --cflags xext)
   XEXT_FOUND="YES"
fi

XR_LIBS=$(pkg-config --libs xrender)
if [ "x" != "x${XR_LIBS}" ];then
   echo found Xrender from pkgconfig
   LIBS_Xr="${XR_LIBS}"
   CFLAGS_Xr=$(pkg-config --cflags xext)
   XEXT_FOUND="YES"
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

if [ "xNO" = "x${XEXT_FOUND}" ];then
	TLIB="-lXext -lX11" TSRC=${KWD}/check.localized/check_xext.c ${KWD}/check.localized/try_compile.sh
	if [ ! -f ${RULES_OK} ];then
		echo "libXextがないよう"
		exit 9
	fi
	LIBS_Xext=$(cat ${RULES_LIB})
	CFLAGS_Xext=$(cat ${RULES_INC})
fi

if [ "xNO" = "x${XR_FOUND}" ];then
	TLIB="-lXrender -lX11" TSRC=${KWD}/check.localized/check_xrender.c ${KWD}/check.localized/try_compile.sh
	if [ ! -f ${RULES_OK} ];then
		echo "libXrender がないよう"
		exit 9
	fi
	LIBS_Xr=$(cat ${RULES_LIB})
	CFLAGS_Xr=$(cat ${RULES_INC})
fi

echo "Xt:LIBS=$LIBS_Xt"
echo "Xt:CFLAGS=$CFLAGS_Xt"

cc ${CFLAGS_Xt} -o ${KWD}/a.out ${KWD}/check.localized/check_xlib.c ${LIBS_Xt}   || exit 9
echo "-- Xt Check OK --"

echo "Xmu:LIBS=$LIBS_Xmu"
echo "Xmu:CFLAGS=$CFLAGS_Xmu"
cc ${CFLAGS_Xmu} -o ${KWD}/a.out ${KWD}/check.localized/check_xmu.c ${LIBS_Xmu}  || exit 9
echo "-- Xmu Check OK --"

echo "Xext:CFLAGS=$CFLAGS_Xext"
echo "Xext:LIBS=$LIBS_Xext"
cc ${CFLAGS_Xext} -o ${KWD}/a.out ${KWD}/check.localized/check_xext.c ${LIBS_Xext}  || exit 9
echo "-- Xext Check OK --"

echo "Xrender:CFLAGS=$CFLAGS_Xr"
echo "Xrender:LIBS=$LIBS_Xr"
cc ${CFLAGS_Xr} -o ${KWD}/a.out ${KWD}/check.localized/check_xrender.c ${LIBS_Xr}  || exit 9
echo "-- Xrender Check OK --"


HA=$(echo ${CFLAGS_Xt} ${CFLAGS_Xmu} ${CFLAGS_Xr} ${CFLAGS_Xext} | perl -pe 's/\s/\n/g' | sort -u | xargs echo)
LA=$(echo ${LIBS_Xmu} ${LIBS_Xt} ${LIBS_Xr} ${LIBS_Xext} | perl -pe 's/\s/\n/g' | sort -u| xargs echo)

echo "X11_HEADER_ARGS := ${HA}" >>${SITE_MP3}
echo "X11_LIBS := ${LA}" >>${SITE_MP3}

