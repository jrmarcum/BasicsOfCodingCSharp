using System.Globalization;

var now = DateTimeOffset.UtcNow;

// RFC3339
Console.WriteLine(now.ToString("yyyy-MM-ddTHH:mm:sszzz").Replace("+00:00", "Z"));

// Parse RFC3339
var t1 = DateTimeOffset.Parse("2012-11-01T22:08:41+00:00",
    CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
Console.WriteLine(GoFormatTime(t1));

// Custom formats
Console.WriteLine(now.ToString("h:mmtt", CultureInfo.InvariantCulture));

var dayPad = now.Day < 10 ? " " + now.Day : now.Day.ToString();
Console.WriteLine(now.ToString("ddd MMM", CultureInfo.InvariantCulture)
    + " " + dayPad + " " + now.ToString("HH:mm:ss yyyy", CultureInfo.InvariantCulture));

// ISO with microseconds, trailing zeros removed
long subSec6 = now.Ticks % 10_000_000L / 10;
string fracMicro = subSec6 == 0 ? "" : "." + subSec6.ToString("000000").TrimEnd('0');
Console.WriteLine(now.ToString("yyyy-MM-ddTHH:mm:ss") + fracMicro
    + now.ToString("zzz").Replace("+00:00", "Z"));

// Parse "8 41 PM" with incomplete format — Go zero time is 0000-01-01; C# minimum is 0001-01-01
var tOnly = TimeOnly.ParseExact("8 41 PM", "h mm tt", CultureInfo.InvariantCulture);
Console.WriteLine($"0001-01-01 {tOnly:HH:mm:ss} +0000 UTC");

// Printf-style manual format
Console.WriteLine($"{now.Year:D4}-{now.Month:D2}-{now.Day:D2}"
    + $"T{now.Hour:D2}:{now.Minute:D2}:{now.Second:D2}-00:00");

// Parse error
try
{
    DateTime.ParseExact("8:41PM", "ddd MMM  d HH:mm:ss yyyy", CultureInfo.InvariantCulture);
}
catch (FormatException e)
{
    Console.WriteLine(e.Message);
}

static string GoFormatTime(DateTimeOffset t)
{
    long sub = t.Ticks % 10_000_000L;
    if (sub == 0)
        return t.ToString("yyyy-MM-dd HH:mm:ss +0000 UTC");
    string frac = sub.ToString("0000000").TrimEnd('0');
    return t.ToString("yyyy-MM-dd HH:mm:ss") + "." + frac + " +0000 UTC";
}
