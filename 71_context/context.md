Run the server in the background, then use curl to connect to `/hello`. Hit Ctrl+C on the curl to cancel.

___

##### Run Command:
`dotnet run context.cs`
`curl localhost:8090/hello`

##### Results:
`server: hello handler started`
`^C`
`server: context canceled`
`server: hello handler ended`
