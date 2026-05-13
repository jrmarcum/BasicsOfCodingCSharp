using System.Threading.Channels;

var c1 = Channel.CreateBounded<string>(1);
_ = Task.Run(async () => { await Task.Delay(2000); await c1.Writer.WriteAsync("result 1"); });

using var cts1 = new CancellationTokenSource(1000);
try
{
    Console.WriteLine(await c1.Reader.ReadAsync(cts1.Token));
}
catch (OperationCanceledException)
{
    Console.WriteLine("timeout 1");
}

var c2 = Channel.CreateBounded<string>(1);
_ = Task.Run(async () => { await Task.Delay(2000); await c2.Writer.WriteAsync("result 2"); });

using var cts2 = new CancellationTokenSource(3000);
try
{
    Console.WriteLine(await c2.Reader.ReadAsync(cts2.Token));
}
catch (OperationCanceledException)
{
    Console.WriteLine("timeout 2");
}
