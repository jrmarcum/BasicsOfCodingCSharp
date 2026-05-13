var nums = new[] { 2, 3, 4 };
int sum = 0;
foreach (var num in nums)
    sum += num;
Console.WriteLine("sum: " + sum);

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] == 3)
        Console.WriteLine("index: " + i);
}

var kvs = new Dictionary<string, string> { ["a"] = "apple", ["b"] = "banana" };
foreach (var kv in kvs)
    Console.WriteLine(kv.Key + " -> " + kv.Value);

foreach (var k in kvs.Keys)
    Console.WriteLine("key: " + k);

foreach (var (i, c) in "go".Select((ch, idx) => (idx, (int)ch)))
    Console.WriteLine(i + " " + c);
