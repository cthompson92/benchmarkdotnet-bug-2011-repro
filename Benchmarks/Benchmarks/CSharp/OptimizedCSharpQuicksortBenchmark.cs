using Benchmarks.Abstract;
using csharp.console1;

namespace Benchmarks.Benchmarks.CSharp;

public class OptimizedCSharpQuicksortBenchmark : ICSharpQuicksortBenchmark
{
    public IEnumerable<int> Run(int[] data)
    {
        return CSharpUtils.Quicksort_optimized(data, 0, data.Length - 1);
    }

    public override string ToString() => "Optimized";
}