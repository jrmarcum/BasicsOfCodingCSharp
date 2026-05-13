using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new TcpListener(IPAddress.Any, 8090);
listener.Start();

while (true)
{
    var client = await listener.AcceptTcpClientAsync();
    _ = Task.Run(() => HandleConnection(client));
}

static async Task HandleConnection(TcpClient client)
{
    using var _ = client;
    using var stream = client.GetStream();
    using var reader = new StreamReader(stream, Encoding.UTF8);
    using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

    var message = await reader.ReadLineAsync();
    if (message == null) return;

    var ack = "ACK: " + message.Trim().ToUpper();
    await writer.WriteLineAsync(ack);
}
