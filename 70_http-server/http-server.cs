using System.Net;
using System.Text;

var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8090/");
listener.Start();

while (true)
{
    var ctx = listener.GetContext();
    var req = ctx.Request;
    var resp = ctx.Response;

    byte[] body;
    if (req.Url?.LocalPath == "/hello")
    {
        body = Encoding.UTF8.GetBytes("hello\n");
    }
    else if (req.Url?.LocalPath == "/headers")
    {
        var sb = new StringBuilder();
        foreach (string key in req.Headers)
            sb.AppendLine($"{key}: {req.Headers[key]}");
        body = Encoding.UTF8.GetBytes(sb.ToString());
    }
    else
    {
        resp.StatusCode = 404;
        body = Array.Empty<byte>();
    }

    resp.ContentLength64 = body.Length;
    resp.OutputStream.Write(body);
    resp.Close();
}
