var tasks = Enumerable.Range(1, 5).Select(i => Task.Run(() => Worker(i))).ToArray();
await Task.WhenAll(tasks);

static void Worker(int id)
{
    Console.WriteLine($"Worker {id} starting");
    Thread.Sleep(1000);
    Console.WriteLine($"Worker {id} done");
}
