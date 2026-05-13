using System.Security.Cryptography;
using System.Text;

var s = "sha256 this string";
var hash = SHA256.HashData(Encoding.UTF8.GetBytes(s));
Console.WriteLine(s);
Console.WriteLine(Convert.ToHexString(hash).ToLower());
