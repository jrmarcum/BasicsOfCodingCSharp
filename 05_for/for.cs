int i = 1;
while (i <= 3)
{
    Console.WriteLine(i);
    i++;
}

for (int j = 7; j <= 9; j++)
{
    Console.WriteLine(j);
}

while (true)
{
    Console.WriteLine("loop");
    break;
}

for (int n = 0; n <= 5; n++)
{
    if (n % 2 == 0)
        continue;
    Console.WriteLine(n);
}
