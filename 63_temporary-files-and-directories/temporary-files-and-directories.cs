var tmpPath = Path.Combine(Path.GetTempPath(), "sample" + Path.GetRandomFileName().Replace(".", ""));
using (var f = File.Create(tmpPath))
{
    Console.WriteLine("Temp file name: " + tmpPath);
    f.Write(new byte[] { 1, 2, 3, 4 });
}
File.Delete(tmpPath);

var tmpDir = Directory.CreateTempSubdirectory("sampledir");
Console.WriteLine("Temp dir name: " + tmpDir.FullName);

File.WriteAllBytes(Path.Combine(tmpDir.FullName, "file1"), new byte[] { 1, 2 });
tmpDir.Delete(recursive: true);
