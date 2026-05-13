using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

var opts = new JsonSerializerOptions { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };

Console.WriteLine(JsonSerializer.Serialize(true, opts));
Console.WriteLine(JsonSerializer.Serialize(1, opts));
Console.WriteLine(JsonSerializer.Serialize(2.34, opts));
Console.WriteLine(JsonSerializer.Serialize("vector", opts));

Console.WriteLine(JsonSerializer.Serialize(new[] { "apple", "peach", "pear" }, opts));

var mapD = new SortedDictionary<string, int> { ["apple"] = 5, ["lettuce"] = 7 };
Console.WriteLine(JsonSerializer.Serialize(mapD, opts));

var res1 = new Response1 { Page = 1, Fruits = ["apple", "peach", "pear"] };
Console.WriteLine(JsonSerializer.Serialize(res1, opts));

var res2 = new Response2 { Page = 1, Fruits = ["apple", "peach", "pear"] };
Console.WriteLine(JsonSerializer.Serialize(res2, opts));

var byt = """{"num":6.13,"strs":["a","b"]}""";
var dat = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(byt, opts)!;
Console.WriteLine("map[" + string.Join(" ", dat.OrderBy(kv => kv.Key).Select(kv =>
    kv.Key + ":" + (kv.Value.ValueKind == JsonValueKind.Array
        ? "[" + string.Join(" ", kv.Value.EnumerateArray().Select(e => e.GetString()!)) + "]"
        : kv.Value.ToString()))) + "]");

double num = dat["num"].GetDouble();
Console.WriteLine(num);

var strs2 = dat["strs"].EnumerateArray().Select(e => e.GetString()!).ToArray();
Console.WriteLine(strs2[0]);

var str = """{"page": 1, "fruits": ["apple", "peach"]}""";
var res = JsonSerializer.Deserialize<Response2>(str, opts)!;
Console.WriteLine("{" + res.Page + " [" + string.Join(" ", res.Fruits) + "]}");
Console.WriteLine(res.Fruits[0]);

var d = new SortedDictionary<string, int> { ["apple"] = 5, ["lettuce"] = 7 };
Console.WriteLine(JsonSerializer.Serialize(d, opts));

class Response1 { public int Page { get; set; } public string[] Fruits { get; set; } = []; }
class Response2
{
    [System.Text.Json.Serialization.JsonPropertyName("page")]   public int Page { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("fruits")] public string[] Fruits { get; set; } = [];
}
