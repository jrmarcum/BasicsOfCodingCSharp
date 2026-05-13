static int Fact(int n) => n == 0 ? 1 : n * Fact(n - 1);

Console.WriteLine(Fact(7));
