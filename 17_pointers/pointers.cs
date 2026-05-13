#:property AllowUnsafeBlocks=true

static void Zeroval(int ival) { ival = 0; }
static void Zeroptr(ref int iptr) { iptr = 0; }

int i = 1;
Console.WriteLine("initial: " + i);

Zeroval(i);
Console.WriteLine("zeroval: " + i);

Zeroptr(ref i);
Console.WriteLine("zeroptr: " + i);

unsafe
{
    int* ptr = &i;
    Console.WriteLine("pointer: 0x" + ((long)ptr).ToString("x"));
}
