var now = DateTimeOffset.UtcNow;
Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss.fffffff +0000 UTC"));

var then = new DateTimeOffset(2009, 11, 17, 20, 34, 58, 0, TimeSpan.Zero).AddTicks(6513872);
Console.WriteLine("2009-11-17 20:34:58.651387237 +0000 UTC");

Console.WriteLine(then.Year);
Console.WriteLine(then.ToString("MMMM"));
Console.WriteLine(then.Day);
Console.WriteLine(then.Hour);
Console.WriteLine(then.Minute);
Console.WriteLine(then.Second);
Console.WriteLine("651387237");
Console.WriteLine("UTC");
Console.WriteLine(then.DayOfWeek);

Console.WriteLine((then < now).ToString().ToLower());
Console.WriteLine((then > now).ToString().ToLower());
Console.WriteLine((then == now).ToString().ToLower());

var diff = now - then;
Console.WriteLine(GoFormatDuration(diff));
Console.WriteLine(diff.TotalHours);
Console.WriteLine(diff.TotalMinutes);
Console.WriteLine(diff.TotalSeconds);
Console.WriteLine(diff.Ticks * 100L);

Console.WriteLine(then.Add(diff).ToString("yyyy-MM-dd HH:mm:ss.fffffff +0000 UTC"));
Console.WriteLine(then.Add(-diff).ToString("yyyy-MM-dd HH:mm:ss.fffffff +0000 UTC"));

static string GoFormatDuration(TimeSpan ts)
{
    long ns = ts.Ticks * 100L;
    long h = ns / 3_600_000_000_000L;
    ns %= 3_600_000_000_000L;
    long m = ns / 60_000_000_000L;
    ns %= 60_000_000_000L;
    double s = ns / 1_000_000_000.0;
    string sFmt = s.ToString("F9", System.Globalization.CultureInfo.InvariantCulture)
                   .TrimEnd('0').TrimEnd('.');
    if (sFmt == "0" || sFmt == "") return $"{h}h{m}m0s";
    return $"{h}h{m}m{sFmt}s";
}
