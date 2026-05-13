using System.Text;

const string s = "สวัสดี";

var utf8 = Encoding.UTF8.GetBytes(s);
Console.WriteLine("Len: " + utf8.Length);

foreach (var b in utf8)
    Console.Write(b.ToString("x2") + " ");
Console.WriteLine();

Console.WriteLine("Rune count: " + s.EnumerateRunes().Count());

int byteOffset = 0;
foreach (var rune in s.EnumerateRunes())
{
    Console.WriteLine($"U+{rune.Value:X4} '{rune}' starts at {byteOffset}");
    byteOffset += rune.Utf8SequenceLength;
}

Console.WriteLine();
Console.WriteLine("Using DecodeRuneInString");
byteOffset = 0;
foreach (var rune in s.EnumerateRunes())
{
    Console.WriteLine($"U+{rune.Value:X4} '{rune}' starts at {byteOffset}");
    ExamineRune(rune);
    byteOffset += rune.Utf8SequenceLength;
}

static void ExamineRune(Rune r)
{
    if (r == new Rune('t'))       Console.WriteLine("found tee");
    else if (r == new Rune('ส')) Console.WriteLine("found so sua");
}
