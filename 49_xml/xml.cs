using System.Xml.Linq;

var coffee = new Plant(27, "Coffee", ["Ethiopia", "Brazil"]);
var tomato = new Plant(81, "Tomato", ["Mexico", "California"]);

PrintIndented(PlantXml(coffee));
Console.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
PrintIndented(PlantXml(coffee));
Console.WriteLine(Plant.FromXml(PlantXml(coffee)));

var nesting = new XElement("nesting",
    new XElement("parent",
        new XElement("child",
            PlantXml(coffee),
            PlantXml(tomato))));
PrintIndented(nesting);

static XElement PlantXml(Plant p) =>
    new XElement("plant",
        new XAttribute("id", p.Id),
        new XElement("name", p.Name),
        p.Origin.Select(o => new XElement("origin", o)));

static void PrintIndented(XElement el)
{
    var sw = new System.IO.StringWriter();
    using (var w = System.Xml.XmlWriter.Create(sw, new System.Xml.XmlWriterSettings
           { Indent = true, IndentChars = "  ", OmitXmlDeclaration = true }))
        el.Save(w);
    foreach (var line in sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None))
        Console.WriteLine(" " + line);
}

record Plant(int Id, string Name, string[] Origin)
{
    public static Plant FromXml(XElement e) => new(
        (int)e.Attribute("id")!,
        (string)e.Element("name")!,
        e.Elements("origin").Select(o => (string)o!).ToArray());
    public override string ToString() =>
        $"Plant id={Id}, name={Name}, origin=[{string.Join(" ", Origin)}]";
}
