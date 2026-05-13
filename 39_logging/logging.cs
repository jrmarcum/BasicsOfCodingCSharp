using System.Text;
using System.Text.Json;

static string Ts()      => DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
static string TsMicro() => DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffffff");

Console.Error.WriteLine(Ts() + " standard logger");

Console.Error.WriteLine(TsMicro() + " with micro");

Console.Error.WriteLine(Ts() + " logging.cs:12: with file/line");

Console.Error.WriteLine("my:" + Ts() + " from mylog");

Console.Error.WriteLine("ohmy:" + Ts() + " from mylog");

var buf = new StringBuilder();
buf.AppendLine("buf:" + Ts() + " hello");
Console.Write("from buflog:" + buf);

var t1 = DateTime.UtcNow.ToString("o");
Console.Error.WriteLine($"{{\"time\":\"{t1}\",\"level\":\"INFO\",\"msg\":\"hi there\"}}");

var t2 = DateTime.UtcNow.ToString("o");
Console.Error.WriteLine($"{{\"time\":\"{t2}\",\"level\":\"INFO\",\"msg\":\"hello again\",\"key\":\"val\",\"age\":25}}");
