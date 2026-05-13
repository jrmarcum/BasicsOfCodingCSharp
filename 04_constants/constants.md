C# prints `600000000000` where Go prints `6e+11`; both represent the same value — C#'s default `G` format uses fixed notation for exponents below 15.

___

##### Run Command:
`dotnet run constants.cs`

##### Results:
`constant`
`600000000000`
`600000000000`
`-0.28470407323754404`
