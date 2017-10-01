#!/bin/sh

LIBS=""
CFLAGS=""

TLIB="-lXm" TSRC=${KWD}/check.localized/check_motif.c ${KWD}/check.localized/try_compile.sh
if [ ! -f ${RULES_OK} ];then
	echo "Motifがないよう"	
	exit 9
fi
LIBS="${LIBS} $(cat ${RULES_LIB})"
CFLAGS="${CFLAGS} $(cat ${RULES_INC})"


cc ${CFLAGS} ${KWD}/check.localized/check_motif.c -o ${KWD}/a.out ${LIBS} || exit 9

echo "Xm:LIBS=$LIBS"
echo "Xm:CFLAGS=$CFLAGS"
echo "MOTF_HEADER_ARGS := ${CFLAGS}" >>${SITE_MP3}
echo "MOTIF_LIBS := ${LIBS}" >>${SITE_MP3}

