using System.Text.RegularExpressions;

Console.WriteLine(Regex.IsMatch("peach", @"p([a-z]+)ch").ToString().ToLower());

var r = new Regex(@"p([a-z]+)ch");

Console.WriteLine(r.IsMatch("peach").ToString().ToLower());

Console.WriteLine(r.Match("peach punch").Value);

var m = r.Match("peach punch");
Console.WriteLine("[" + m.Index + " " + (m.Index + m.Length) + "]");

var sm = r.Match("peach punch");
Console.WriteLine("[" + string.Join(" ", new[] { sm.Value }.Concat(sm.Groups.Cast<Group>().Skip(1).Select(g => g.Value))) + "]");

Console.WriteLine("[" + string.Join(" ", r.Match("peach punch").Groups.Cast<Group>().SelectMany(g => new[] { g.Index, g.Index + g.Length })) + "]");

var all = r.Matches("peach punch pinch").Select(x => x.Value);
Console.WriteLine("[" + string.Join(" ", all) + "]");

var allIdx = r.Matches("peach punch pinch").Select(x =>
    "[" + string.Join(" ", x.Groups.Cast<Group>().SelectMany(g => new[] { g.Index, g.Index + g.Length })) + "]");
Console.WriteLine("[" + string.Join(" ", allIdx) + "]");

var twoMatches = r.Matches("peach punch pinch").Take(2).Select(x => x.Value);
Console.WriteLine("[" + string.Join(" ", twoMatches) + "]");

Console.WriteLine(r.IsMatch("peach").ToString().ToLower());

Console.WriteLine(r.ToString());

Console.WriteLine(r.Replace("a peach", "<fruit>"));

var inStr = "a peach";
var outStr = r.Replace(inStr, m2 => m2.Value.ToUpper());
Console.WriteLine(outStr);
