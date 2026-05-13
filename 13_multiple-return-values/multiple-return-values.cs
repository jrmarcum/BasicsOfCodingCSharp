static (int, int) Vals() => (3, 7);

var (a, b) = Vals();
Console.WriteLine(a);
Console.WriteLine(b);

var (_, c) = Vals();
Console.WriteLine(c);
