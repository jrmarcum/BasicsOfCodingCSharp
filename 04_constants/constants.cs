const string s = "constant";
Console.WriteLine(s);

const long n = 500000000;

const double d = 3e20 / n;
Console.WriteLine(d.ToString("G").ToLower());

Console.WriteLine((long)d);

Console.WriteLine(Math.Sin(n));
