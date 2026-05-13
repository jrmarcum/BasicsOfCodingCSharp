Timestamps reflect actual run time; the first 5 requests are spaced ~200ms apart and the bursty batch fires the first 3 immediately.

___

##### Run Command:
`dotnet run rate-limiting.cs`

##### Results:
`request 1 2026-05-13 17:21:51.258820 -04:00`
`request 2 2026-05-13 17:21:51.456200 -04:00`
`request 3 2026-05-13 17:21:51.673926 -04:00`
`request 4 2026-05-13 17:21:51.857253 -04:00`
`request 5 2026-05-13 17:21:52.057863 -04:00`
`request 1 2026-05-13 17:21:52.061686 -04:00`
`request 2 2026-05-13 17:21:52.061733 -04:00`
`request 3 2026-05-13 17:21:52.061740 -04:00`
`request 4 2026-05-13 17:21:52.273700 -04:00`
`request 5 2026-05-13 17:21:52.460242 -04:00`
