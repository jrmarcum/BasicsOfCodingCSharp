string[] fruits = { "peach", "banana", "kiwi" };
Array.Sort(fruits, (a, b) => a.Length.CompareTo(b.Length));
Console.WriteLine("[" + string.Join(" ", fruits) + "]");
