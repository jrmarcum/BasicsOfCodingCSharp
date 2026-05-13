static int Plus(int a, int b) => a + b;
static int PlusPlus(int a, int b, int c) => a + b + c;

int res = Plus(1, 2);
Console.WriteLine("1+2 = " + res);

res = PlusPlus(1, 2, 3);
Console.WriteLine("1+2+3 = " + res);
