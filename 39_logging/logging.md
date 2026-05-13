Timestamps reflect actual run time. C# timestamp format uses `yyyy/MM/dd HH:mm:ss` vs Go's same format; JSON timestamps use ISO 8601.

___

##### Run Command:
`dotnet run logging.cs`

##### Results:
`2026/05/13 17:21:45 standard logger`
`2026/05/13 17:21:45.907683 with micro`
`2026/05/13 17:21:45 logging.cs:12: with file/line`
`my:2026/05/13 17:21:45 from mylog`
`ohmy:2026/05/13 17:21:45 from mylog`
`from buflog:buf:2026/05/13 17:21:45 hello`
`{"time":"2026-05-13T21:21:45.9079368Z","level":"INFO","msg":"hi there"}`
`{"time":"2026-05-13T21:21:45.9079950Z","level":"INFO","msg":"hello again","key":"val","age":25}`
