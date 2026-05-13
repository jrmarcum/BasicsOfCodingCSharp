var rng = Random.Shared;

Console.Write(rng.Next(100) + ",");
Console.WriteLine(rng.Next(100));

Console.WriteLine(rng.NextDouble());

Console.Write((rng.NextDouble() * 5) + 5 + ",");
Console.WriteLine((rng.NextDouble() * 5) + 5);

// Seeded with time — varying
var r1 = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
Console.Write(r1.Next(100) + ",");
Console.WriteLine(r1.Next(100));

// Fixed seed 42 — deterministic
var r2 = new Random(42);
Console.Write(r2.Next(100) + ",");
Console.WriteLine(r2.Next(100));

var r3 = new Random(42);
Console.Write(r3.Next(100) + ",");
Console.Write(r3.Next(100));
