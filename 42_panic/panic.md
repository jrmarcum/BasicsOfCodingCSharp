C# unhandled exceptions print a different format than Go panics; the program exits with a non-zero status in both cases.

___

##### Run Command:
`dotnet run panic.cs`

##### Results:
`Unhandled exception. System.Exception: a problem`
`   at Program.<Main>$(String[] args) in .../panic.cs:line 1`
