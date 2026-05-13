C# uses `ref` parameters instead of raw pointers; `unsafe` blocks are used here to print the memory address, which varies each run. Requires `#:property AllowUnsafeBlocks=true`.

___

##### Run Command:
`dotnet run pointers.cs`

##### Results:
`initial: 1`
`zeroval: 1`
`zeroptr: 0`
`pointer: 0x654ff7e6e8`
