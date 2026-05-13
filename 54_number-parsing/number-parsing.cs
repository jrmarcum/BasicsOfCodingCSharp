using System.Globalization;

var f = double.Parse("1.234", CultureInfo.InvariantCulture);
Console.WriteLine(f);

var i = long.Parse("123");
Console.WriteLine(i);

var d = Convert.ToInt64("1c8", 16);
Console.WriteLine(d);

var u = ulong.Parse("789");
Console.WriteLine(u);

var k = int.Parse("135");
Console.WriteLine(k);

try { int.Parse("wat"); }
catch (Exception e) { Console.WriteLine(e.Message); }
