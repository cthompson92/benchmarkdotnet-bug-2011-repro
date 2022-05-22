using Benchmarks.Abstract;
using csharp.console1;

namespace Benchmarks.Benchmarks.CSharp;

public class ReadableCSharpQuicksortBenchmark : ICSharpQuicksortBenchmark
{
    public IEnumerable<int> Run(int[] data)
    {
        return CSharpUtils.Quicksort(data);
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => "Readable";
}