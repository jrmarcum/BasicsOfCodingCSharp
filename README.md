# BasicsOfCodingC#

A C# implementation of 78 example programs that explore the syntax and
standard library of the language. Each program corresponds to an equivalent
program in [BasicsOfCodingGo](https://github.com/jrmarcum/BasicsOfCodingGo),
allowing side-by-side comparison of language features, lines of code, and
idioms.

This repository is part of a multi-language comparative study. The Go version
is the source of truth for program logic and expected output.

---

## Prerequisites

- [.NET SDK 10+](https://dotnet.microsoft.com/download)

---

## Running Examples

Each lesson lives in its own directory. Run from within the lesson directory:

```sh
cd 01_hello-world
dotnet run hello-world.cs
```

For lessons 64–66 (command-line args/flags/subcommands), pass arguments after
the `--` separator:

```sh
dotnet run command-line-arguments.cs -- a b c
```

Lesson 68 (testing-and-benchmarking) uses an MSTest `.csproj` project:

```sh
cd 68_testing-and-benchmarking
dotnet test
```

Lessons 58–60 (reading/writing files, line-filters) require a `tmp/`
directory to exist at runtime. Create it manually inside the lesson directory
before running.

---

## Lessons

| # | Topic |
| --- | ------- |
| 01 | hello-world |
| 02 | values |
| 03 | variables |
| 04 | constants |
| 05 | for |
| 06 | if-else |
| 07 | switch |
| 08 | arrays |
| 09 | slices |
| 10 | maps |
| 11 | range |
| 12 | functions |
| 13 | multiple-return-values |
| 14 | variadic-functions |
| 15 | closures |
| 16 | recursion |
| 17 | pointers |
| 18 | structs |
| 19 | methods |
| 20 | interfaces |
| 21 | errors |
| 22 | strings-and-runes |
| 23 | struct-embedding |
| 24 | enums |
| 25 | custom-errors |
| 26 | generics |
| 27 | goroutines |
| 28 | channels |
| 29 | select |
| 30 | timeouts |
| 31 | timers |
| 32 | tickers |
| 33 | mutexes |
| 34 | atomic-counters |
| 35 | waitgroups |
| 36 | worker-pools |
| 37 | rate-limiting |
| 38 | recover |
| 39 | logging |
| 40 | sorting |
| 41 | sorting-by-functions |
| 42 | panic |
| 43 | defer |
| 44 | collection-functions |
| 45 | string-functions |
| 46 | string-formatting |
| 47 | regular-expressions |
| 48 | json |
| 49 | xml |
| 50 | time |
| 51 | epoch |
| 52 | time-formatting-parsing |
| 53 | random-numbers |
| 54 | number-parsing |
| 55 | url-parsing |
| 56 | sha1-hashes |
| 57 | base64-encoding |
| 58 | reading-files |
| 59 | writing-files |
| 60 | line-filters |
| 61 | file-paths |
| 62 | directories |
| 63 | temporary-files-and-directories |
| 64 | command-line-arguments |
| 65 | command-line-flags |
| 66 | command-line-subcommands |
| 67 | environment-variables |
| 68 | testing-and-benchmarking |
| 69 | http-client |
| 70 | http-server |
| 71 | context |
| 72 | tcp-server |
| 73 | text-templates |
| 74 | execing-processes |
| 75 | spawning-processes |
| 76 | signals |
| 77 | exit |
| 78 | sha256-hashes |

---

## License

Jon Marcum's original C# contributions are released under the
[CC0 1.0 Universal Public Domain Dedication](LICENSE).

Lesson structure and content derived from
[BasicsOfCodingGo](https://github.com/jrmarcum/BasicsOfCodingGo) by Jon Marcum
is licensed under
[Creative Commons Attribution 3.0 Unported (CC BY 3.0)](https://creativecommons.org/licenses/by/3.0/).
See [NOTICE](NOTICE) for full attribution details.
