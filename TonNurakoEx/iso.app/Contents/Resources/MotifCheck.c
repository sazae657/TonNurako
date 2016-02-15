#include <Xm/Xm.h>
#include <stdio.h>
int main()
{
    if (xmUseVersion < 2000) {
        fprintf(stderr, "Motif TOO OLD!! %d\n", xmUseVersion);
        return -1;
    }
    fprintf(stderr, "Motif OK ver:%d\n", xmUseVersion);
    return 0;
}