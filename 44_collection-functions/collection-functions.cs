static int Index(string[] vs, string t)
{
    for (int i = 0; i < vs.Length; i++)
        if (vs[i] == t) return i;
    return -1;
}

static bool Include(string[] vs, string t) => Index(vs, t) >= 0;

static bool Any(string[] vs, Func<string, bool> f)
{
    foreach (var v in vs) if (f(v)) return true;
    return false;
}

static bool All(string[] vs, Func<string, bool> f)
{
    foreach (var v in vs) if (!f(v)) return false;
    return true;
}

static string[] Filter(string[] vs, Func<string, bool> f)
    => vs.Where(f).ToArray();

static string[] Map(string[] vs, Func<string, string> f)
    => vs.Select(f).ToArray();

var strs = new[] { "peach", "apple", "pear", "plum" };

Console.WriteLine(Index(strs, "pear"));
Console.WriteLine(Include(strs, "grape").ToString().ToLower());
Console.WriteLine(Any(strs, v => v.StartsWith("p")).ToString().ToLower());
Console.WriteLine(All(strs, v => v.StartsWith("p")).ToString().ToLower());
Console.WriteLine("[" + string.Join(" ", Filter(strs, v => v.Contains('e'))) + "]");
Console.WriteLine("[" + string.Join(" ", Map(strs, v => v.ToUpper())) + "]");
