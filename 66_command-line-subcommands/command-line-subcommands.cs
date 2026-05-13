if (args.Length < 1)
{
    Console.Error.WriteLine("expected 'foo' or 'bar' subcommands");
    Environment.Exit(1);
}

switch (args[0])
{
    case "foo":
    {
        bool enable = false;
        string name = "";
        int i = 1;
        while (i < args.Length && args[i].StartsWith('-'))
        {
            var kv = args[i].TrimStart('-').Split('=', 2);
            switch (kv[0])
            {
                case "enable": enable = kv.Length > 1 ? bool.Parse(kv[1]) : true; break;
                case "name":   name   = kv.Length > 1 ? kv[1] : args[++i]; break;
            }
            i++;
        }
        Console.WriteLine("subcommand 'foo'");
        Console.WriteLine("  enable: " + enable.ToString().ToLower());
        Console.WriteLine("  name: " + name);
        Console.WriteLine("  tail: [" + string.Join(" ", args[i..]) + "]");
        break;
    }
    case "bar":
    {
        int level = 0;
        int i = 1;
        while (i < args.Length && args[i].StartsWith('-'))
        {
            var kv = args[i].TrimStart('-').Split('=', 2);
            if (kv[0] == "level") level = int.Parse(kv.Length > 1 ? kv[1] : args[++i]);
            i++;
        }
        Console.WriteLine("subcommand 'bar'");
        Console.WriteLine("  level: " + level);
        Console.WriteLine("  tail: [" + string.Join(" ", args[i..]) + "]");
        break;
    }
    default:
        Console.Error.WriteLine("expected 'foo' or 'bar' subcommands");
        Environment.Exit(1);
        break;
}
