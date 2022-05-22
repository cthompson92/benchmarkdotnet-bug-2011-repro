using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using csharp.console1;
using fsharp.console1;
using Microsoft.FSharp.Collections;

namespace Benchmarks.Benchmarks;

public class QuicksortBenchmarks_Array3
{
    private readonly Consumer consumer = new Consumer();

    private static readonly int[] CSharpData = BenchmarksData.A3;

    private static readonly FSharpList<int> FSharpData = ListModule.OfSeq(CSharpData);

    [Benchmark]
    public void CSharp() => CSharpUtils.Quicksort(CSharpData).Consume(consumer);

    [Benchmark]
    public void CSharp_optimized() => CSharpUtils.Quicksort_optimized(CSharpData, 0, CSharpData.Length - 1).Consume(consumer);

    [Benchmark(Baseline = true)]
    public void FSharp() => Utils.quicksort(FSharpData).Consume(consumer);
}