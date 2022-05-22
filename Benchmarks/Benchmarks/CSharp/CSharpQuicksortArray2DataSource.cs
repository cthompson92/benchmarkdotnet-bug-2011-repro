using Benchmarks.Abstract;

namespace Benchmarks.Benchmarks.CSharp;

public class CSharpQuicksortArray2DataSource : ICSharpQuicksortDataSource
{
    public string Category => "Array2";

    public int[] Data { get; } = BenchmarksData.A2;

    public override string ToString() => Category;
}