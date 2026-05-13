Go's `syscall.Exec` is Unix-only. This C# equivalent uses `Process.Start` with `cmd /c dir` on Windows.

___

##### Run Command:
`dotnet run execing-processes.cs`

##### Results:
` Volume in drive D has no label.`
` Volume Serial Number is 3285-B831`
` Directory of D:\...\74_execing-processes`
`...`
