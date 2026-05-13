`Environment.Exit` bypasses `try-finally` cleanup, analogous to Go's `os.Exit` bypassing `defer`. The program produces no output; the exit code is 3.

___

##### Run Command:
`dotnet run exit.cs; echo "Exit code: $?"`

##### Results:
`Exit code: 3`
