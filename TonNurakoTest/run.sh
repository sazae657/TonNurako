 #!/bin/bash
 CONSOLE_EXE="packages/xunit.runner.console.2.3.1/tools/net452/xunit.console.exe"
LD_LIBRARY_PATH=$(pwd)/bin/Debug \
 mono ${CONSOLE_EXE}  \
  bin/Debug/TonNurakoTest.dll -verbose $@
