using System.Collections;
using System.Text.RegularExpressions;

Execute("Value: {{.}}\n", "some text");
Execute("Value: {{.}}\n", 5);
Execute("Value: {{.}}\n", new[] { "Go", "Rust", "C++", "C#" });

Execute("Name: {{.Name}}\n", new { Name = "Jane Doe" });
Execute("Name: {{.Name}}\n", new Dictionary<string, string> { ["Name"] = "Mickey Mouse" });

Execute("{{if . -}} yes {{else -}} no {{end}}\n", "not empty");
Execute("{{if . -}} yes {{else -}} no {{end}}\n", "");

Execute("Range: {{range .}}{{.}} {{end}}\n", new[] { "Go", "Rust", "C++", "C#" });

static void Execute(string tmpl, object? data)
{
    // Handle trim markers: -}} removes whitespace after, {{- removes whitespace before
    tmpl = Regex.Replace(tmpl, @"-\}\}\s*", "}}");
    tmpl = Regex.Replace(tmpl, @"\s*\{\{-", "{{");

    // range
    var rangeM = Regex.Match(tmpl, @"^([\s\S]*?)\{\{\s*range\s+\.\s*\}\}([\s\S]*?)\{\{\s*end\s*\}\}([\s\S]*)$");
    if (rangeM.Success)
    {
        Console.Write(rangeM.Groups[1].Value);
        if (data is IEnumerable<string> seq)
            foreach (var x in seq)
                Console.Write(rangeM.Groups[2].Value.Replace("{{.}}", x));
        Console.Write(rangeM.Groups[3].Value);
        return;
    }

    // if/else
    var ifM = Regex.Match(tmpl, @"^([\s\S]*?)\{\{\s*if\s+\.\s*\}\}([\s\S]*?)\{\{\s*else\s*\}\}([\s\S]*?)\{\{\s*end\s*\}\}([\s\S]*)$");
    if (ifM.Success)
    {
        bool truthy = data is string s ? !string.IsNullOrEmpty(s) : data != null;
        Console.Write(ifM.Groups[1].Value);
        Console.Write(truthy ? ifM.Groups[2].Value : ifM.Groups[3].Value);
        Console.Write(ifM.Groups[4].Value);
        return;
    }

    // field access {{.FieldName}}
    var result = Regex.Replace(tmpl, @"\{\{\.(\w+)\}\}", m =>
    {
        var f = m.Groups[1].Value;
        if (data is IDictionary dict) return dict.Contains(f) ? dict[f]?.ToString() ?? "" : "";
        return data?.GetType().GetProperty(f)?.GetValue(data)?.ToString() ?? "";
    });

    // simple value {{.}}
    var fmtd = data switch
    {
        string[] arr => "[" + string.Join(" ", arr) + "]",
        _ => data?.ToString() ?? ""
    };
    Console.Write(result.Replace("{{.}}", fmtd));
}
