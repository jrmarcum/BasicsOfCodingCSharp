static string N(string? path)
{
    path = (path ?? "").Replace('\\', '/');
    var parts = new List<string>();
    foreach (var p in path.Split('/'))
    {
        if (p == "" || p == ".") continue;
        if (p == ".." && parts.Count > 0) parts.RemoveAt(parts.Count - 1);
        else parts.Add(p);
    }
    return string.Join("/", parts);
}

var p = N(Path.Combine("dir1", "dir2", "filename"));
Console.WriteLine("p: " + p);

Console.WriteLine(N(Path.Combine("dir1//", "filename")));
Console.WriteLine(N(Path.Combine("dir1/../dir1", "filename")));

Console.WriteLine("Dir(p): " + N(Path.GetDirectoryName(p)));
Console.WriteLine("Base(p): " + Path.GetFileName(p));

Console.WriteLine(Path.IsPathRooted("dir/file").ToString().ToLower());
Console.WriteLine(Path.IsPathRooted("/dir/file").ToString().ToLower());

var filename = "config.json";
var ext = Path.GetExtension(filename);
Console.WriteLine(ext);
Console.WriteLine(Path.GetFileNameWithoutExtension(filename));

Console.WriteLine(N(Path.GetRelativePath("a/b", "a/b/t/file")));
Console.WriteLine(N(Path.GetRelativePath("a/b", "a/c/t/file")));
