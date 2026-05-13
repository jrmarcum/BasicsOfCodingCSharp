Dates and times vary with each run. C# minimum year is 0001 vs Go's 0000 for zero-date parses. Error message wording differs from Go.

___

##### Run Command:
`dotnet run time-formatting-parsing.cs`

##### Results:
`2026-05-13T21:38:51Z`
`2012-11-01 22:08:41 +0000 UTC`
`9:38PM`
`Wed May 13 21:38:51 2026`
`2026-05-13T21:38:51.331678Z`
`0001-01-01 20:41:00 +0000 UTC`
`2026-05-13T21:38:51-00:00`
`String '8:41PM' was not recognized as a valid DateTime.`
