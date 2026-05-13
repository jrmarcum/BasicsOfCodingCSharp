var argsWithProg = new[] { "command-line-arguments" }.Concat(args).ToArray();
var argsWithoutProg = args;
var arg = args[2];

Console.WriteLine("[" + string.Join(" ", argsWithProg) + "]");
Console.WriteLine("[" + string.Join(" ", argsWithoutProg) + "]");
Console.WriteLine(arg);
