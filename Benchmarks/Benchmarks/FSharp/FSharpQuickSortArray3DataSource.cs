using Benchmarks.Abstract;
using Microsoft.FSharp.Collections;

namespace Benchmarks.Benchmarks.FSharp;

public class FSharpQuickSortArray3DataSource : IFSharpQuicksortDataSource
{
    public string Category => "Array3";

    public FSharpList<int> Data { get; } = ListModule.OfSeq(BenchmarksData.A3);

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => Category;
}