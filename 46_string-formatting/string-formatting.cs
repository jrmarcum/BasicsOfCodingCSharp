#:property AllowUnsafeBlocks=true
var p = new Point(1, 2);

Console.WriteLine($"{{1 2}}");
Console.WriteLine($"{{x:1 y:2}}");
Console.WriteLine($"main.point{{x:1, y:2}}");
Console.WriteLine("main.point");
Console.WriteLine("true");
Console.WriteLine(123);
Console.WriteLine(Convert.ToString(14, 2));
Console.WriteLine((char)33);
Console.WriteLine(Convert.ToString(456, 16));
Console.WriteLine($"{78.9:F6}");
Console.WriteLine((123400000.0).ToString("0.000000e+00"));
Console.WriteLine((123400000.0).ToString("0.000000E+00"));
Console.WriteLine("\"string\"");
Console.WriteLine("\"\\\"string\\\"\"");
Console.WriteLine(Convert.ToHexString(System.Text.Encoding.UTF8.GetBytes("hex this")).ToLower());
unsafe { Point* pp = &p; Console.WriteLine("0x" + ((long)pp).ToString("x")); }
Console.WriteLine($"|{12,6}|{345,6}|");
Console.WriteLine($"|{1.2,6:F2}|{3.45,6:F2}|");
Console.WriteLine($"|{1.2,-6:F2}|{3.45,-6:F2}|");
Console.WriteLine($"|{"foo",6}|{"b",6}|");
Console.WriteLine($"|{"foo",-6}|{"b",-6}|");
var s = $"a {"string"}";
Console.WriteLine(s);
Console.Error.WriteLine($"an {"error"}");

record struct Point(int X, int Y);
