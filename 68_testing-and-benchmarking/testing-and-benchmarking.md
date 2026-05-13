Uses MSTest via a `.csproj` project. Timing values vary per run.

___

##### Run Command:
`dotnet test --logger "console;verbosity=detailed"`

##### Results:
`Passed TestIntMinBasic [3 ms]`
`Passed 0,1 [< 1 ms]`
`Passed 1,0 [< 1 ms]`
`Passed 2,-2 [< 1 ms]`
`Passed 0,-1 [< 1 ms]`
`Passed -1,0 [< 1 ms]`
`Test Run Successful.`
`Total tests: 6`
`     Passed: 6`
