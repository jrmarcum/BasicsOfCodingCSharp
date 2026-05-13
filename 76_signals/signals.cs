using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    Console.WriteLine();
    Console.WriteLine("interrupt signal received");
    cts.Cancel();
};

Console.WriteLine("awaiting signal");
try
{
    await Task.Delay(Timeout.Infinite, cts.Token);
}
catch (OperationCanceledException) { }
Console.WriteLine("exiting");
