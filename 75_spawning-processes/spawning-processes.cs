using System.Diagnostics;

// Windows equivalents: 'date /t' for date, 'findstr' for grep, 'dir' for ls.

// date
var dateProc = Process.Start(new ProcessStartInfo("cmd.exe", "/c date /t")
    { UseShellExecute = false, RedirectStandardOutput = true })!;
var dateOut = dateProc.StandardOutput.ReadToEnd().Trim();
dateProc.WaitForExit();
Console.WriteLine("> date");
Console.WriteLine(dateOut);
Console.WriteLine();

// invalid command to show exit code
var badProc = Process.Start(new ProcessStartInfo("cmd.exe", "/c exit 1")
    { UseShellExecute = false })!;
badProc.WaitForExit();
if (badProc.ExitCode != 0)
    Console.WriteLine("command exit rc = " + badProc.ExitCode);

// grep equivalent: findstr with piped input
var grepPsi = new ProcessStartInfo("findstr", "hello")
{
    UseShellExecute = false,
    RedirectStandardInput = true,
    RedirectStandardOutput = true
};
var grepProc = Process.Start(grepPsi)!;
grepProc.StandardInput.Write("hello grep\ngoodbye grep");
grepProc.StandardInput.Close();
var grepOut = grepProc.StandardOutput.ReadToEnd();
grepProc.WaitForExit();
Console.WriteLine("> grep hello");
Console.WriteLine(grepOut);

// dir listing
var lsProc = Process.Start(new ProcessStartInfo("cmd.exe", "/c dir /b")
    { UseShellExecute = false, RedirectStandardOutput = true })!;
var lsOut = lsProc.StandardOutput.ReadToEnd();
lsProc.WaitForExit();
Console.WriteLine("> ls -a -l -h");
Console.WriteLine(lsOut);
