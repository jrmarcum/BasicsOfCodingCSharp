Console.WriteLine(new Person("Bob", 20));
Console.WriteLine(new Person("Alice", 30));
Console.WriteLine(new Person("Fred", 0));
Console.WriteLine("&" + new Person("Ann", 40));
Console.WriteLine("&" + NewPerson("Jon"));

var s = new Person("Sean", 50);
Console.WriteLine(s.Name);
Console.WriteLine(s.Age);
s = s with { Age = 51 };
Console.WriteLine(s.Age);

static Person NewPerson(string name) => new Person(name, 42);

record struct Person(string Name, int Age)
{
    public override string ToString() => "{" + Name + " " + Age + "}";
}
