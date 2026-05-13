var now = DateTimeOffset.UtcNow;
Console.WriteLine(GoFormatTime(now));

long secs  = now.ToUnixTimeSeconds();
long millis = now.ToUnixTimeMilliseconds();
long nanos  = millis * 1_000_000L + (now.Ticks % TimeSpan.TicksPerMillisecond) * 100L;

Console.WriteLine(secs);
Console.WriteLine(millis);
Console.WriteLine(nanos);

Console.WriteLine(GoFormatTime(DateTimeOffset.FromUnixTimeSeconds(secs)));
Console.WriteLine(GoFormatTime(DateTimeOffset.FromUnixTimeMilliseconds(nanos / 1_000_000L)
    .AddTicks((nanos % 1_000_000L) / 100L)));

static string GoFormatTime(DateTimeOffset t)
{
    long sub = t.Ticks % 10_000_000L;
    if (sub == 0)
        return t.ToString("yyyy-MM-dd HH:mm:ss +0000 UTC");
    string frac = sub.ToString("0000000").TrimEnd('0');
    return t.ToString("yyyy-MM-dd HH:mm:ss") + "." + frac + " +0000 UTC";
}
