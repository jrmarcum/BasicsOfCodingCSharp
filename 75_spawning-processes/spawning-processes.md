Uses Windows-specific commands (`date /t`, `findstr`, `dir /b`) instead of Unix `date`, `grep`, `bash`.

___

##### Run Command:
`dotnet run spawning-processes.cs`

##### Results:
`> date`
`Wed 05/13/2026`
``
`command exit rc = 1`
`> grep hello`
`hello grep`
``
`> ls -a -l -h`
`spawning-processes.cs`
