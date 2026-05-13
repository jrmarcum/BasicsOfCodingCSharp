Environment.SetEnvironmentVariable("FOO", "1");
Console.WriteLine("FOO: " + Environment.GetEnvironmentVariable("FOO"));
Console.WriteLine("BAR: " + Environment.GetEnvironmentVariable("BAR"));

Console.WriteLine();
foreach (System.Collections.DictionaryEntry entry in Environment.GetEnvironmentVariables())
    Console.WriteLine(entry.Key);
