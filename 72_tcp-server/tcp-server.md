Run the TCP server in the background, then send data using netcat or similar.

___

##### Run Command:
`dotnet run tcp-server.cs`
`echo "Hello from netcat" | nc localhost 8090`

##### Results:
`ACK: HELLO FROM NETCAT`
