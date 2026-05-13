var s = new string[3];
Console.WriteLine("emp: [" + string.Join(" ", s) + "]");

s[0] = "a";
s[1] = "b";
s[2] = "c";
Console.WriteLine("set: [" + string.Join(" ", s) + "]");
Console.WriteLine("get: " + s[2]);

Console.WriteLine("len: " + s.Length);

var sl = new List<string>(s) { "d", "e", "f" };
Console.WriteLine("apd: [" + string.Join(" ", sl) + "]");

var c = new List<string>(sl);
Console.WriteLine("cpy: [" + string.Join(" ", c) + "]");

var l = sl.GetRange(2, 3);
Console.WriteLine("sl1: [" + string.Join(" ", l) + "]");

l = sl.GetRange(0, 5);
Console.WriteLine("sl2: [" + string.Join(" ", l) + "]");

l = sl.GetRange(2, sl.Count - 2);
Console.WriteLine("sl3: [" + string.Join(" ", l) + "]");

var t = new List<string> { "g", "h", "i" };
Console.WriteLine("dcl: [" + string.Join(" ", t) + "]");

var twoD = new List<List<int>>();
for (int i = 0; i < 3; i++)
{
    int innerLen = i + 1;
    var inner = new List<int>();
    for (int j = 0; j < innerLen; j++)
        inner.Add(i + j);
    twoD.Add(inner);
}
Console.WriteLine("2d:  [" + string.Join(" ", twoD.Select(row => "[" + string.Join(" ", row) + "]")) + "]");
