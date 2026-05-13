using System.Text;

// Requires ./tmp/ directory to exist
File.WriteAllBytes("./tmp/dat1.txt", Encoding.UTF8.GetBytes("hello\ncsharp\n"));

var f = new FileStream("./tmp/dat2.txt", FileMode.Create);

var d2 = new byte[] { 115, 111, 109, 101, 10 }; // "some\n"
f.Write(d2);
Console.WriteLine($"wrote {d2.Length} bytes");

var d3 = Encoding.UTF8.GetBytes("writes\n");
f.Write(d3);
Console.WriteLine($"wrote {d3.Length} bytes");

f.Flush();

var bw = new StreamWriter(f, leaveOpen: true);
var d4 = "buffered\n";
bw.Write(d4);
Console.WriteLine($"wrote {Encoding.UTF8.GetByteCount(d4)} bytes");
bw.Flush();

f.Close();
