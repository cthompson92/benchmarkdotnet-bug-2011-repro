using Benchmarks.Abstract;

namespace Benchmarks.Benchmarks.CSharp;

public class CSharpQuicksortArray1DataSource : ICSharpQuicksortDataSource
{
    public string Category => "Array1";

    public int[] Data { get; } = BenchmarksData.A1;

    public override string ToString() => Category;
}