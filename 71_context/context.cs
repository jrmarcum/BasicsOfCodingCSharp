using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8090/");
listener.Start();

while (true)
{
    var ctx = listener.GetContext();
    _ = Task.Run(() => HandleHello(ctx));
}

static async Task HandleHello(HttpListenerContext listenerCtx)
{
    Console.WriteLine("server: hello handler started");
    using var cts = new CancellationTokenSource();
    var resp = listenerCtx.Response;

    // Detect client disconnect by watching request stream close
    _ = Task.Run(async () =>
    {
        try { await listenerCtx.Request.InputStream.CopyToAsync(Stream.Null); }
        catch { }
        cts.Cancel();
    });

    try
    {
        await Task.Delay(10_000, cts.Token);
        var body = Encoding.UTF8.GetBytes("hello\n");
        resp.ContentLength64 = body.Length;
        await resp.OutputStream.WriteAsync(body);
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("server: context canceled");
        try
        {
            resp.StatusCode = 500;
            var body = Encoding.UTF8.GetBytes("context canceled\n");
            resp.ContentLength64 = body.Length;
            await resp.OutputStream.WriteAsync(body);
        }
        catch { }
    }
    finally
    {
        resp.Close();
        Console.WriteLine("server: hello handler ended");
    }
}
