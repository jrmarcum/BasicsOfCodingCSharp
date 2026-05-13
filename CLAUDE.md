# BasicsOfCodingCsharp — Session Context

## What This Project Is

A multi-language comparative study of programming syntax, simplicity, lines
of code, and performance. Each language implements the same 78 example
programs so they can be compared side-by-side.

The source of truth for program logic and expected output is **Basics of
Coding Go** by Jon Marcum (https://github.com/jrmarcum/BasicsOfCodingGo),
which lives as a git submodule at `upstream/basicsofcodinggo`. For every
lesson, read the upstream `.go` source and `.md` to understand what the
program does and what output it produces, then translate to idiomatic
[LANGUAGE].

The structural reference is **BasicsOfCodingC**
(https://github.com/jrmarcum/BasicsOfCodingC). Match its repo layout,
CLAUDE.md shape, NOTICE/LICENSE structure, and lesson `.md` format exactly.

## Project Structure

```
BasicsOfCoding[LANGUAGE]/
├── CLAUDE.md
├── LICENSE            — CC0 (Jon Marcum original contributions)
├── NOTICE             — CC BY 3.0 attribution for derived lesson content
├── README.md
├── upstream/
│   └── basicsofcodinggo/  — git submodule
└── ##_topic-name/
    ├── topic-name.[ext]
    └── topic-name.md
```

All 78 lessons: `01_hello-world` through `78_sha256-hashes`.
Numbers match BasicsOfCodingGo exactly — do not renumber.

## Lesson .md Format (exact, no deviations)

```
[Optional one-line description]

___

##### Run Command:
`[run command]`

##### Results:
`[output line 1]`
`[output line 2]`
```

No per-file attribution footers. Time-dependent or nondeterministic
lessons note this in the description line.

## Licensing Rule

Do NOT add per-file attribution footers. Attribution is handled centrally
in README and NOTICE. This is intentional and differs from some other repos.

## Output Matching

Match upstream Go output line-for-line. Where the language produces
structurally different output (e.g., map ordering, array formatting),
document the difference in the lesson `.md` description line.

## Special Lessons

- **58–60** (reading/writing files, line-filters): require a `tmp/`
  directory at runtime (gitignored, create manually). Lesson 58 also needs
  `tmp/dat.txt` containing `hello\n[lang]\n`.
- **50–52, 32, 37**: time-dependent output — note in `.md` that results vary.
- **27–37** (concurrency): nondeterministic per-thread ordering — note in `.md`.
- **64–66** (command-line args/flags/subcommands): must be compiled to a
  binary before running; args passed after `--` separator or equivalent.
- **68** (testing-and-benchmarking): use the language's native test framework.

---

### C# (target: .NET 10, file-based programs)

**Toolchain:** .NET SDK 10+
```
$ dotnet run topic-name.cs        # from within the lesson directory
$ dotnet run topic-name.cs -- a b # pass args with -- separator (lessons 64–66)
$ dotnet test                     # lesson 68 only (MSTest .csproj project)
```

Each lesson is a **single `.cs` file** using .NET 10 top-level statements and
file-based program support — no `.csproj` needed. The one exception is lesson
68 (testing-and-benchmarking), which uses a `.csproj` MSTest project and runs
with `dotnet test`.

**Top-level statement rule:** All executable code and local function
definitions must appear **before** any type declarations (`class`, `record`,
`struct`, `interface`). This is enforced by the compiler.

**File-level build directives (before any code):**
```
#:property AllowUnsafeBlocks=true   // lessons 17, 46 (pointer address)
```

**Key translations:**
| Go | C# |
|---|---|
| `fmt.Println` | `Console.WriteLine()` |
| `fmt.Printf` | `Console.Write($"...")` |
| Slices | `List<T>` / `T[]` |
| Maps | `Dictionary<K,V>` |
| Multiple return | `(T1, T2)` tuple / `out` / `record` |
| Closures | `x => x * 2` / `Func<T,R>` |
| `interface` | `interface` |
| `defer` | `try-finally` (prints side-effects); `using var` for `IDisposable` |
| goroutines | `Task` / `async-await` |
| channels | `Channel<T>` (System.Threading.Channels) |
| `select` | `Task.WhenAny` |
| `sync.WaitGroup` | `CountdownEvent` / `Task.WhenAll` |
| `sync.Mutex` | `lock` / `SemaphoreSlim` |
| `sync/atomic` | `Interlocked.Add` / `Interlocked.Increment` |
| `error` | `Exception` |
| `panic/recover` | `throw` / `try-catch` |
| `regexp` | `Regex` (System.Text.RegularExpressions) |
| `net/http` client | `HttpClient` (async top-level, `await` supported) |
| `net/http` server | `HttpListener` (no ASP.NET Core needed) |
| TCP server | `TcpListener` / `TcpClient` |
| SHA1 | `SHA1.HashData(bytes)` |
| SHA256 | `SHA256.HashData(bytes)` |
| Base64 std | `Convert.ToBase64String(bytes)` |
| Base64 URL | `Convert.ToBase64String(bytes).Replace('+','-').Replace('/','_')` |
| `time.Now()` | `DateTimeOffset.UtcNow` |
| `time.Unix(s,0)` | `DateTimeOffset.FromUnixTimeSeconds(s)` |
| `os.Args` | top-level `args` (excludes program name) |
| `os.Getenv` | `Environment.GetEnvironmentVariable` |
| `os.Exit(n)` | `Environment.Exit(n)` (bypasses `try-finally`, like Go `defer`) |
| `syscall.Exec` | `Process.Start` + exit (Unix exec unavailable on Windows) |
| `exec.Command` | `Process.Start(ProcessStartInfo{...})` |
| signals | `Console.CancelKeyPress` + `CancellationTokenSource` |

**Output-matching patterns — required to match Go's fmt output:**

```csharp
// Booleans: Go prints "true"/"false", C# prints "True"/"False"
Console.WriteLine(b.ToString().ToLower());

// Arrays/slices: Go fmt prints "[a b c]"
"[" + string.Join(" ", arr) + "]"

// Maps: Go fmt prints "map[k1:v1 k2:v2]"
"map[" + string.Join(" ", dict.Select(kv => kv.Key + ":" + kv.Value)) + "]"

// Scientific notation: Go %e gives "1.234000e+08" (2-digit exponent)
(123400000.0).ToString("0.000000e+00")   // NOT {:e6} which gives 3-digit

// Time string (Go time.String() format): "2006-01-02 15:04:05.fffffff +0000 UTC"
// trim trailing fractional zeros; omit fractional part if zero
static string GoFormatTime(DateTimeOffset t) {
    long sub = t.Ticks % 10_000_000L;
    if (sub == 0) return t.ToString("yyyy-MM-dd HH:mm:ss +0000 UTC");
    return t.ToString("yyyy-MM-dd HH:mm:ss") + "."
           + sub.ToString("0000000").TrimEnd('0') + " +0000 UTC";
}

// Go duration format: "144504h54m3.592848s" (no trailing zeros in seconds)
static string GoFormatDuration(TimeSpan ts) {
    long ns = ts.Ticks * 100L;
    long h = ns / 3_600_000_000_000L; ns %= 3_600_000_000_000L;
    long m = ns / 60_000_000_000L;    ns %= 60_000_000_000L;
    double s = ns / 1_000_000_000.0;
    string sFmt = s.ToString("F9", CultureInfo.InvariantCulture)
                   .TrimEnd('0').TrimEnd('.');
    return $"{h}h{m}m{(sFmt == "" ? "0" : sFmt)}s";
}

// File path normalization (Windows \ → / and resolve .. like Go filepath.Join)
static string N(string? path) {
    path = (path ?? "").Replace('\\', '/');
    var parts = new List<string>();
    foreach (var p in path.Split('/')) {
        if (p == "" || p == ".") continue;
        if (p == ".." && parts.Count > 0) parts.RemoveAt(parts.Count - 1);
        else parts.Add(p);
    }
    return string.Join("/", parts);
}
```

**JSON reflection (lesson 48):** .NET 10 file-based programs disable
reflection-based JSON serialization by default. Fix:

```csharp
var opts = new JsonSerializerOptions {
    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
};
```

**XML indentation (lesson 49):** Use `XElement` (LINQ to XML) with
`XmlWriter` + `IndentChars = "  "` + `OmitXmlDeclaration = true`. Flush the
`StringWriter` inside a `using` block before reading it.

**Lesson 52 (time-formatting-parsing):** C#'s `DateTime.ParseExact` with an
incomplete format fills in the **current date** (not a zero date). Use
`TimeOnly.ParseExact` and reconstruct with year 0001. Go's zero time is year
0000, C#'s minimum is 0001 — document this difference in the `.md`.

**Lesson 58 (reading-files):** `tmp/dat.txt` contains `hello\ncsharp\n`
(13 bytes). Byte offset 6 is the start of `"csharp"`, so the 2-byte read
at position 6 yields `"cs"`.

**Lesson 68 (testing-and-benchmarking):** The only lesson with a `.csproj`.
Uses MSTest. `IntMin` is a static method inside `[TestClass]` — it cannot
be a top-level local function because type declarations cannot access
top-level locals.

**Lessons 74–75 (exec/spawn):** `syscall.Exec` is Unix-only. Windows
replacements: `cmd /c dir` for `ls`, `cmd /c date /t` for `date`,
`findstr` for `grep`, `cmd /c dir /b` for `ls` output. Document in `.md`.

**.gitignore:** `bin/`, `obj/`, `.vs/`, `*.user`, `tmp/`

---