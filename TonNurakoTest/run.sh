#!/bin/bash
CONSOLE_EXE="packages/xunit.runner.console.2.3.1/tools/net452/xunit.console.exe"
LD_LIBRARY_PATH=$(pwd)/bin/Debug \
LANG="ja_JP.UTF-8" \
mono ${CONSOLE_EXE}  \
  bin/Debug/TonNurakoTest.dll -verbose -parallel none $@ || exit 9

LD_LIBRARY_PATH=$(pwd)/bin/Debug \
LANG="ja_JP.UTF-8" \
mono ${CONSOLE_EXE}  \
  bin/Debug/TonNurakoTestEx.dll -verbose -parallel none $@ || exit 9

