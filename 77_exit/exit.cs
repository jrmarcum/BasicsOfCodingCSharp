// try-finally cleanup (like Go's defer) will NOT run when Environment.Exit is called.
try
{
    Environment.Exit(3);
}
finally
{
    Console.WriteLine("!"); // This line is never reached
}
