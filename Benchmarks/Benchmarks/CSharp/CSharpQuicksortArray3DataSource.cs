using Benchmarks.Abstract;

namespace Benchmarks.Benchmarks.CSharp;

public class CSharpQuicksortArray3DataSource : ICSharpQuicksortDataSource
{
    public string Category => "Array3";

    public int[] Data { get; } = BenchmarksData.A3;
    
    public override string ToString() => Category;
}