# -*- coding: utf-8 -*-
import sys
import re

print '''
#include <stdio.h>
#include <Xm/XmAll.h>
int main() {
printf("namespace TonNurako.Native.Motif {\\n");
printf("    public enum ResourceId {\\n");
'''

for arg in sys.argv[1:]:
    for line in open(arg, 'r'):
        p = line.strip()
        if not p:
            continue
        print 'printf("        [ToolkitOption(\\"%%s\\")]\\n        %s,\\n\\n",%s);' % (p, p)

print '''
printf("    }\\n");
printf("}\\n");
return 0;
}
'''

