using System.Threading.Channels;

var c1 = Channel.CreateUnbounded<string>();
var c2 = Channel.CreateUnbounded<string>();

_ = Task.Run(async () => { await Task.Delay(1000); await c1.Writer.WriteAsync("one"); });
_ = Task.Run(async () => { await Task.Delay(2000); await c2.Writer.WriteAsync("two"); });

var t1 = c1.Reader.ReadAsync().AsTask();
var t2 = c2.Reader.ReadAsync().AsTask();

for (int i = 0; i < 2; i++)
{
    var done = await Task.WhenAny(t1, t2);
    if (done == t1)
    {
        Console.WriteLine("received " + await t1);
        t1 = c1.Reader.ReadAsync().AsTask();
    }
    else
    {
        Console.WriteLine("received " + await t2);
        t2 = c2.Reader.ReadAsync().AsTask();
    }
}
