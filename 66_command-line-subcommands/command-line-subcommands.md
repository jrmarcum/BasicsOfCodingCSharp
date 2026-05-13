
___

##### Run Command:
`dotnet run command-line-subcommands.cs -- foo -enable -name=joe a1 a2`

##### Results:
`subcommand 'foo'`
`  enable: true`
`  name: joe`
`  tail: [a1 a2]`

##### Run Command:
`dotnet run command-line-subcommands.cs -- bar -level 8 a1`

##### Results:
`subcommand 'bar'`
`  level: 8`
`  tail: [a1]`
