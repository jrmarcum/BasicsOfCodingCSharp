string[] strs = { "c", "a", "b" };
Array.Sort(strs);
Console.WriteLine("Strings: [" + string.Join(" ", strs) + "]");

int[] ints = { 7, 2, 4 };
Array.Sort(ints);
Console.WriteLine("Ints:    [" + string.Join(" ", ints) + "]");

bool sorted = ints.SequenceEqual(ints.OrderBy(x => x));
Console.WriteLine("Sorted:  " + sorted.ToString().ToLower());
