C# `Dictionary<K,V>` preserves insertion order; Go map iteration is non-deterministic, so the `a -> apple` / `b -> banana` and `key: a` / `key: b` pairs may appear in either order in Go.

___

##### Run Command:
`dotnet run range.cs`

##### Results:
`sum: 9`
`index: 1`
`a -> apple`
`b -> banana`
`key: a`
`key: b`
`0 103`
`1 111`
