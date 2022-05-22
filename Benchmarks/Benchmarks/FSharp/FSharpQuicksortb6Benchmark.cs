using Benchmarks.Abstract;
using fsharp.console1;
using Microsoft.FSharp.Collections;

namespace Benchmarks.Benchmarks.FSharp;

public class FSharpQuicksortb6Benchmark : IFSharpQuicksortBenchmark
{
    public IEnumerable<int> Run(FSharpList<int> data)
    {
        return Utils.quicksortb6(data);
    }

    public override string ToString() => "Blog6";
}