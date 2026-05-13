using var cts = new CancellationTokenSource();

var tickerTask = Task.Run(async () =>
{
    try
    {
        while (!cts.Token.IsCancellationRequested)
        {
            await Task.Delay(500, cts.Token);
            Console.WriteLine("Tick at " + DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zzz"));
        }
    }
    catch (OperationCanceledException) { }
});

await Task.Delay(1600);
cts.Cancel();
await tickerTask;
Console.WriteLine("Ticker stopped");
