using System.Threading.Channels;

const int numJobs = 5;
var jobs    = Channel.CreateBounded<int>(numJobs);
var results = Channel.CreateBounded<int>(numJobs);

var workers = Enumerable.Range(1, 3).Select(id => Task.Run(async () =>
{
    await foreach (var j in jobs.Reader.ReadAllAsync())
    {
        Console.WriteLine($"worker {id} started  job {j}");
        await Task.Delay(1000);
        Console.WriteLine($"worker {id} finished job {j}");
        await results.Writer.WriteAsync(j * 2);
    }
})).ToArray();

for (int j = 1; j <= numJobs; j++)
    await jobs.Writer.WriteAsync(j);
jobs.Writer.Complete();

await Task.WhenAll(workers);
results.Writer.Complete();
