#!/bin/bash
CONSOLE_EXE="packages/xunit.runner.console.2.3.1/tools/net452/xunit.console.exe"

export LD_LIBRARY_PATH=$(pwd)/bin/Debug 
export LANG="ja_JP.UTF-8" 
export DISPLAY=:9
XPID=""

function kill_server {
    kill ${XPID}
}

function run_server {
    Xvfb ${DISPLAY} -screen 0 320x240x24 &
    XPID=$!
}

function bailout {
   kill_server
   exit 9
}

run_server

#mono ${CONSOLE_EXE}  \
#  bin/Debug/TonNurakoTest.dll -verbose -maxthreads 1 -parallel none $@ || bailout

dotnet test -f netcoreapp2.1 TonNurakoTest/TonNurakoTest.csproj

kill_server

ur=$(uname -s | grep Microsoft)
if [ "x" = "x${ur}" ];then
	exit	
fi

run_server

mono ${CONSOLE_EXE}  \
  bin/Debug/TonNurakoTest.dll -verbose -maxthreads 1 -parallel none $@ || bailout

kill_server

kill_server
