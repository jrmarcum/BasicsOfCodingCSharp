using System.Text;

// Requires ./tmp/dat.txt containing "hello\ncsharp\n"
var dat = File.ReadAllBytes("./tmp/dat.txt");
Console.Write(Encoding.UTF8.GetString(dat));

var f = File.OpenRead("./tmp/dat.txt");

var b1 = new byte[5];
var n1 = f.Read(b1, 0, 5);
Console.WriteLine($"{n1} bytes: {Encoding.UTF8.GetString(b1, 0, n1)}");

var o2 = f.Seek(6, SeekOrigin.Begin);
var b2 = new byte[2];
var n2 = f.Read(b2, 0, 2);
Console.Write($"{n2} bytes @ {o2}: ");
Console.WriteLine(Encoding.UTF8.GetString(b2, 0, n2));

f.Seek(6, SeekOrigin.Begin);
var b3 = new byte[2];
int n3 = 0;
while (n3 < 2) n3 += f.Read(b3, n3, 2 - n3);
Console.WriteLine($"{n3} bytes @ 6: {Encoding.UTF8.GetString(b3)}");

f.Seek(0, SeekOrigin.Begin);
var b4 = new byte[5];
f.Read(b4, 0, 5);
Console.WriteLine($"5 bytes: {Encoding.UTF8.GetString(b4)}");

f.Close();
