string word = "foo", svar = "bar";
int numb = 42;
bool fork = false;
int i = 0;

while (i < args.Length && args[i].StartsWith('-'))
{
    var kv = args[i].TrimStart('-').Split('=', 2);
    var key = kv[0];
    switch (key)
    {
        case "word":  word  = kv.Length > 1 ? kv[1] : args[++i]; break;
        case "numb":  numb  = int.Parse(kv.Length > 1 ? kv[1] : args[++i]); break;
        case "fork":  fork  = kv.Length > 1 ? bool.Parse(kv[1]) : true; break;
        case "svar":  svar  = kv.Length > 1 ? kv[1] : args[++i]; break;
    }
    i++;
}

var tail = args[i..];

Console.WriteLine("word: " + word);
Console.WriteLine("numb: " + numb);
Console.WriteLine("fork: " + fork.ToString().ToLower());
Console.WriteLine("svar: " + svar);
Console.WriteLine("tail: [" + string.Join(" ", tail) + "]");
