using System.Threading.Channels;

var requests = Channel.CreateBounded<int>(5);
for (int i = 1; i <= 5; i++) await requests.Writer.WriteAsync(i);
requests.Writer.Complete();

using var limiterTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(200));

await foreach (var req in requests.Reader.ReadAllAsync())
{
    await limiterTimer.WaitForNextTickAsync();
    Console.WriteLine("request " + req + " " + DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zzz"));
}

var burstyLimiter = Channel.CreateBounded<DateTimeOffset>(3);
for (int i = 0; i < 3; i++) await burstyLimiter.Writer.WriteAsync(DateTimeOffset.Now);

_ = Task.Run(async () =>
{
    using var t = new PeriodicTimer(TimeSpan.FromMilliseconds(200));
    while (await t.WaitForNextTickAsync())
        await burstyLimiter.Writer.WriteAsync(DateTimeOffset.Now);
});

var burstyRequests = Channel.CreateBounded<int>(5);
for (int i = 1; i <= 5; i++) await burstyRequests.Writer.WriteAsync(i);
burstyRequests.Writer.Complete();

await foreach (var req in burstyRequests.Reader.ReadAllAsync())
{
    await burstyLimiter.Reader.ReadAsync();
    Console.WriteLine("request " + req + " " + DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zzz"));
}
