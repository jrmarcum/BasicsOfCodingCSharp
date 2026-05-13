var c = new Container(new Dictionary<string, int> { ["a"] = 0, ["b"] = 0 });

var t1 = Task.Run(() => { for (int k = 0; k < 10000; k++) c.Inc("a"); });
var t2 = Task.Run(() => { for (int k = 0; k < 10000; k++) c.Inc("a"); });
var t3 = Task.Run(() => { for (int k = 0; k < 10000; k++) c.Inc("b"); });

await Task.WhenAll(t1, t2, t3);

var counters = c.Counters;
var sorted = counters.OrderBy(kv => kv.Key);
Console.WriteLine("map[" + string.Join(" ", sorted.Select(kv => $"{kv.Key}:{kv.Value}")) + "]");

class Container(Dictionary<string, int> counters)
{
    private readonly object _lock = new();
    public Dictionary<string, int> Counters => counters;

    public void Inc(string name)
    {
        lock (_lock) { counters[name]++; }
    }
}
