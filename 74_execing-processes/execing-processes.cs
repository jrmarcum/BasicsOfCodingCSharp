using System.Diagnostics;

// Go uses syscall.Exec (Unix-only). C# equivalent: spawn subprocess and exit.
// On Windows, uses 'cmd /c dir' instead of Unix 'ls'.
var psi = new ProcessStartInfo("cmd.exe", "/c dir")
{
    UseShellExecute = false,
    RedirectStandardOutput = true
};

var p = Process.Start(psi)!;
Console.Write(p.StandardOutput.ReadToEnd());
p.WaitForExit();
