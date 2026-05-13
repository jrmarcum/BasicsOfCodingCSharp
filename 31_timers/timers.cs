await Task.Delay(2000);
Console.WriteLine("Timer 1 fired");

using var cts2 = new CancellationTokenSource();
_ = Task.Run(async () =>
{
    try
    {
        await Task.Delay(1000, cts2.Token);
        Console.WriteLine("Timer 2 fired");
    }
    catch (OperationCanceledException) { }
});

cts2.Cancel();
Console.WriteLine("Timer 2 stopped");

await Task.Delay(2000);
