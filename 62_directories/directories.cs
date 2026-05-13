static string N(string p) => p.Replace('\\', '/');

Directory.CreateDirectory("subdir");
try
{
    File.WriteAllBytes("subdir/file1", Array.Empty<byte>());
    Directory.CreateDirectory("subdir/parent/child");
    File.WriteAllBytes("subdir/parent/file2", Array.Empty<byte>());
    File.WriteAllBytes("subdir/parent/file3", Array.Empty<byte>());
    File.WriteAllBytes("subdir/parent/child/file4", Array.Empty<byte>());

    Console.WriteLine("Listing subdir/parent");
    foreach (var e in Directory.GetFileSystemEntries("subdir/parent").OrderBy(x => x))
    {
        var name = Path.GetFileName(e);
        var isDir = Directory.Exists(e);
        Console.WriteLine("  " + name + " " + isDir.ToString().ToLower());
    }

    Environment.CurrentDirectory = Path.Combine(Environment.CurrentDirectory, "subdir/parent/child");

    Console.WriteLine("Listing subdir/parent/child");
    foreach (var e in Directory.GetFileSystemEntries(".").OrderBy(x => x))
    {
        var name = Path.GetFileName(e);
        var isDir = Directory.Exists(e);
        Console.WriteLine("  " + name + " " + isDir.ToString().ToLower());
    }

    Environment.CurrentDirectory = Path.Combine(Environment.CurrentDirectory, "../../..");

    Console.WriteLine("Visiting subdir");
    WalkDir("subdir");
}
finally
{
    Directory.Delete("subdir", recursive: true);
}

static void WalkDir(string root)
{
    Console.WriteLine("  " + N(root) + " " + Directory.Exists(root).ToString().ToLower());
    var entries = Directory.GetFileSystemEntries(root).OrderBy(x => x).ToList();
    foreach (var e in entries)
    {
        if (Directory.Exists(e))
            WalkDir(e);
        else
            Console.WriteLine("  " + N(e) + " false");
    }
}
