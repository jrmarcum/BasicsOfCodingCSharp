using System.Threading;

long ops = 0;

var tasks = Enumerable.Range(0, 50).Select(_ => Task.Run(() =>
{
    for (int k = 0; k < 1000; k++)
        Interlocked.Increment(ref ops);
})).ToArray();

await Task.WhenAll(tasks);
Console.WriteLine("ops: " + Interlocked.Read(ref ops));
