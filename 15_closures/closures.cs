static Func<int> IntSeq()
{
    int i = 0;
    return () => ++i;
}

var nextInt = IntSeq();
Console.WriteLine(nextInt());
Console.WriteLine(nextInt());
Console.WriteLine(nextInt());

var newInts = IntSeq();
Console.WriteLine(newInts());
