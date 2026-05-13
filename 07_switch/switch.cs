int i = 2;
Console.Write("Write " + i + " as ");
switch (i)
{
    case 1: Console.WriteLine("one"); break;
    case 2: Console.WriteLine("two"); break;
    case 3: Console.WriteLine("three"); break;
}

switch (DateTime.Now.DayOfWeek)
{
    case DayOfWeek.Saturday:
    case DayOfWeek.Sunday:
        Console.WriteLine("It's the weekend");
        break;
    default:
        Console.WriteLine("It's a weekday");
        break;
}

var t = DateTime.Now;
if (t.Hour < 12)
    Console.WriteLine("It's before noon");
else
    Console.WriteLine("It's after noon");

Action<object> whatAmI = (obj) =>
{
    switch (obj)
    {
        case bool: Console.WriteLine("I'm a bool"); break;
        case int:  Console.WriteLine("I'm an int"); break;
        default:   Console.WriteLine("Don't know type " + obj.GetType().Name.ToLower()); break;
    }
};
whatAmI(true);
whatAmI(1);
whatAmI("hey");
