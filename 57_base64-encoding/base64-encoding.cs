using System.Text;

var data = "abc123!?$*&()'-=@~";
var bytes = Encoding.UTF8.GetBytes(data);

var sEnc = Convert.ToBase64String(bytes);
Console.WriteLine(sEnc);
Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(sEnc)));
Console.WriteLine();

var uEnc = Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_');
Console.WriteLine(uEnc);
Console.WriteLine(Encoding.UTF8.GetString(
    Convert.FromBase64String(uEnc.Replace('-', '+').Replace('_', '/'))));
