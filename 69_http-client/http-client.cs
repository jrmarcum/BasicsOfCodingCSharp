using var client = new HttpClient();
var resp = await client.GetAsync("https://gobyexample.com");
Console.WriteLine($"Response status: {(int)resp.StatusCode} {resp.ReasonPhrase}");

using var reader = new StreamReader(await resp.Content.ReadAsStreamAsync());
for (int i = 0; i < 5; i++)
{
    var line = await reader.ReadLineAsync();
    if (line == null) break;
    Console.WriteLine(line);
}
