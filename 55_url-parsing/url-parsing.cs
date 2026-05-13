var s = "postgres://user:pass@host.com:5432/path?k=v#f";
var u = new Uri(s);

Console.WriteLine(u.Scheme);
Console.WriteLine(u.UserInfo);
Console.WriteLine(u.UserInfo.Split(':')[0]);
Console.WriteLine(u.UserInfo.Split(':')[1]);

Console.WriteLine(u.Host + ":" + u.Port);
Console.WriteLine(u.Host);
Console.WriteLine(u.Port);

Console.WriteLine(u.AbsolutePath);
Console.WriteLine(u.Fragment.TrimStart('#'));

var rawQuery = u.Query.TrimStart('?');
Console.WriteLine(rawQuery);

var qmap = rawQuery.Split('&', StringSplitOptions.RemoveEmptyEntries)
    .Select(p => p.Split('=', 2))
    .ToDictionary(p => p[0], p => new List<string> { p.Length > 1 ? p[1] : "" });

Console.WriteLine("map[" + string.Join(" ", qmap.Select(kv =>
    kv.Key + ":[" + string.Join(" ", kv.Value) + "]")) + "]");

Console.WriteLine(qmap["k"][0]);
