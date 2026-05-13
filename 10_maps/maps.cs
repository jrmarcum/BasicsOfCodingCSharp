var m = new Dictionary<string, int>();

m["k1"] = 7;
m["k2"] = 13;

Console.WriteLine("map: map[" + string.Join(" ", m.Select(kv => $"{kv.Key}:{kv.Value}")) + "]");

int v1 = m["k1"];
Console.WriteLine("v1:  " + v1);

Console.WriteLine("len: " + m.Count);

m.Remove("k2");
Console.WriteLine("map: map[" + string.Join(" ", m.Select(kv => $"{kv.Key}:{kv.Value}")) + "]");

bool prs = m.ContainsKey("k2");
Console.WriteLine("prs: " + prs.ToString().ToLower());

var n = new Dictionary<string, int> { ["foo"] = 1, ["bar"] = 2 };
Console.WriteLine("map: map[" + string.Join(" ", n.Select(kv => $"{kv.Key}:{kv.Value}")) + "]");
