Measure(new Rect(3, 4));
Measure(new Circle(5));

static void Measure(IGeometry g)
{
    Console.WriteLine(g);
    Console.WriteLine(g.Area());
    Console.WriteLine(g.Perim());
}

interface IGeometry
{
    double Area();
    double Perim();
}

record struct Rect(double Width, double Height) : IGeometry
{
    public double Area() => Width * Height;
    public double Perim() => 2 * Width + 2 * Height;
    public override string ToString() => "{" + Width + " " + Height + "}";
}

record struct Circle(double Radius) : IGeometry
{
    public double Area() => Math.PI * Radius * Radius;
    public double Perim() => 2 * Math.PI * Radius;
    public override string ToString() => "{" + Radius + "}";
}
