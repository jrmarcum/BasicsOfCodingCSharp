foreach (var i in new[] { 7, 42 })
{
    var (r1, e1) = F1(i);
    if (e1 != null) Console.WriteLine("f1 failed: " + e1.Message);
    else            Console.WriteLine("f1 worked: " + r1);
}

foreach (var i in new[] { 7, 42 })
{
    var (r2, e2) = F2(i);
    if (e2 != null) Console.WriteLine("f2 failed: " + e2.Message);
    else            Console.WriteLine("f2 worked: " + r2);
}

var (_, err) = F2(42);
if (err is ArgException ae)
{
    Console.WriteLine(ae.Arg);
    Console.WriteLine(ae.Prob);
}

static (int, Exception?) F1(int arg)
{
    if (arg == 42) return (-1, new Exception("can't work with 42"));
    return (arg + 3, null);
}

static (int, Exception?) F2(int arg)
{
    if (arg == 42) return (-1, new ArgException(arg, "can't work with it"));
    return (arg + 3, null);
}

class ArgException(int arg, string prob) : Exception($"{arg} - {prob}")
{
    public int    Arg  => arg;
    public string Prob => prob;
}
