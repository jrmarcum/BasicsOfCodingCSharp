int[] a = new int[5];
Console.WriteLine("emp: [" + string.Join(" ", a) + "]");

a[4] = 100;
Console.WriteLine("set: [" + string.Join(" ", a) + "]");
Console.WriteLine("get: " + a[4]);

Console.WriteLine("len: " + a.Length);

int[] b = { 1, 2, 3, 4, 5 };
Console.WriteLine("dcl: [" + string.Join(" ", b) + "]");

int[,] twoD = new int[2, 3];
for (int i = 0; i < 2; i++)
    for (int j = 0; j < 3; j++)
        twoD[i, j] = i + j;

var rows = new List<string>();
for (int i = 0; i < 2; i++)
{
    var cols = new List<int>();
    for (int j = 0; j < 3; j++)
        cols.Add(twoD[i, j]);
    rows.Add("[" + string.Join(" ", cols) + "]");
}
Console.WriteLine("2d:  [" + string.Join(" ", rows) + "]");
