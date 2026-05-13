Console.WriteLine("Contains:   " + "test".Contains("es").ToString().ToLower());
Console.WriteLine("Count:      " + "test".Count(c => c == 't'));
Console.WriteLine("HasPrefix:  " + "test".StartsWith("te").ToString().ToLower());
Console.WriteLine("HasSuffix:  " + "test".EndsWith("st").ToString().ToLower());
Console.WriteLine("Index:      " + "test".IndexOf('e'));
Console.WriteLine("Join:       " + string.Join("-", new[] { "a", "b" }));
Console.WriteLine("Repeat:     " + string.Concat(Enumerable.Repeat("a", 5)));
Console.WriteLine("Replace:    " + "foo".Replace("o", "0"));
Console.WriteLine("Replace:    " + ReplaceFirst("foo", "o", "0"));
Console.WriteLine("Split:      [" + string.Join(" ", "a-b-c-d-e".Split('-')) + "]");
Console.WriteLine("ToLower:    " + "TEST".ToLower());
Console.WriteLine("ToUpper:    " + "test".ToUpper());
Console.WriteLine("Len:  " + "hello".Length);
Console.WriteLine("Char: " + (int)"hello"[1]);

static string ReplaceFirst(string s, string old, string rep)
{
    int i = s.IndexOf(old);
    if (i < 0) return s;
    return s[..i] + rep + s[(i + old.Length)..];
}
