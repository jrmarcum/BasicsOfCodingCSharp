using System.Threading.Channels;

var messages = Channel.CreateUnbounded<string>();

_ = Task.Run(async () => await messages.Writer.WriteAsync("ping"));

var msg = await messages.Reader.ReadAsync();
Console.WriteLine(msg);
