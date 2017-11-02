#!/bin/bash
CONSOLE_EXE="packages/xunit.runner.console.2.3.1/tools/net452/xunit.console.exe"
LD_LIBRARY_PATH=$(pwd)/bin/Debug \
LANG="ja_JP.UTF-8" \
xvfb-run --server-args="-screen 0 320x240x24" \
mono ${CONSOLE_EXE}  \
  bin/Debug/TonNurakoTest.dll -verbose $@
exit $?
