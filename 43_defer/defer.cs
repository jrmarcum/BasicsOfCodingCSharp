var f = CreateFile("./tmp/defer.txt");
try
{
    WriteFile(f);
}
finally
{
    CloseFile(f);
}

static System.IO.StreamWriter CreateFile(string path)
{
    Console.WriteLine("creating");
    return new System.IO.StreamWriter(path);
}

static void WriteFile(System.IO.StreamWriter f)
{
    Console.WriteLine("writing");
    f.WriteLine("data");
}

static void CloseFile(System.IO.StreamWriter f)
{
    Console.WriteLine("closing");
    f.Close();
}
