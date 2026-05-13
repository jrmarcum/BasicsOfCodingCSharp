var r = new Rect(10, 5);
Console.WriteLine("area:  " + r.Area());
Console.WriteLine("perim: " + r.Perim());

var rp = r;
Console.WriteLine("area:  " + rp.Area());
Console.WriteLine("perim: " + rp.Perim());

record struct Rect(int Width, int Height)
{
    public int Area() => Width * Height;
    public int Perim() => 2 * Width + 2 * Height;
}
