C# `Dictionary<K,V>` preserves insertion order; Go prints maps with sorted keys, so the final map prints `foo:1 bar:2` here vs Go's `bar:2 foo:1`.

___

##### Run Command:
`dotnet run maps.cs`

##### Results:
`map: map[k1:7 k2:13]`
`v1:  7`
`len: 2`
`map: map[k1:7]`
`prs: false`
`map: map[foo:1 bar:2]`
