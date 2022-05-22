using Benchmarks.Abstract;
using fsharp.console1;
using Microsoft.FSharp.Collections;

namespace Benchmarks.Benchmarks.FSharp;

public class FSharpQuicksort1Benchmark : IFSharpQuicksortBenchmark
{
    public IEnumerable<int> Run(FSharpList<int> data)
    {
        return Utils.quicksort(data);
    }

    public override string ToString() => "Quicksort1";
}