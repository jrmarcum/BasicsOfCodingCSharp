static void Sum(params int[] nums)
{
    Console.Write("[" + string.Join(" ", nums) + "] ");
    int total = 0;
    foreach (var n in nums)
        total += n;
    Console.WriteLine(total);
}

Sum(1, 2);
Sum(1, 2, 3);

int[] nums = { 1, 2, 3, 4 };
Sum(nums);
