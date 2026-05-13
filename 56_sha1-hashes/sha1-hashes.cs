using System.Security.Cryptography;
using System.Text;

var s = "sha1 this string";
var hash = SHA1.HashData(Encoding.UTF8.GetBytes(s));
Console.WriteLine(s);
Console.WriteLine(Convert.ToHexString(hash).ToLower());
