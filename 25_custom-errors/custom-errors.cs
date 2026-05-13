var (_, err) = F(42);
if (err is ArgError ae)
{
    Console.WriteLine(ae.Arg);
    Console.WriteLine(ae.Msg);
}
else
{
    Console.WriteLine("err doesn't match ArgError");
}

static (int, Exception?) F(int arg)
{
    if (arg == 42) return (-1, new ArgError(arg, "can't work with it"));
    return (arg + 3, null);
}

class ArgError(int arg, string msg) : Exception($"{arg} - {msg}")
{
    public int    Arg => arg;
    public string Msg => msg;
}
