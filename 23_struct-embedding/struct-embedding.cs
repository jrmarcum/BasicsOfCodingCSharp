var co = new Container(new Base(1), "some name");
Console.WriteLine($"co={{num: {co.Num}, str: {co.Str}}}");
Console.WriteLine("also num: " + co.Base.Num);
Console.WriteLine("describe: " + co.Describe());

IDescriber d = co;
Console.WriteLine("describer: " + d.Describe());

interface IDescriber { string Describe(); }

record struct Base(int Num)
{
    public string Describe() => $"base with num={Num}";
}

record struct Container(Base Base, string Str) : IDescriber
{
    public int    Num      => Base.Num;
    public string Describe() => Base.Describe();
}
