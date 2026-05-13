try
{
    MayPanic();
    Console.WriteLine("After mayPanic()");
}
catch (Exception e)
{
    Console.WriteLine("Recovered. Error:\n " + e.Message);
}

static void MayPanic() => throw new Exception("a problem");
