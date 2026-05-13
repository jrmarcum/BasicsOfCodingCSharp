F("direct");

var t1 = Task.Run(() => F("goroutine"));
var t2 = Task.Run(() => Console.WriteLine("going"));

await Task.Delay(1000);
Console.WriteLine("done");

static void F(string from)
{
    for (int i = 0; i < 3; i++)
        Console.WriteLine(from + " : " + i);
}
