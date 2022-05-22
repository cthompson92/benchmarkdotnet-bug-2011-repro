using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.Abstract;

namespace Benchmarks.Benchmarks.CSharp;

public class InjectedCSharpQuicksortBenchmarks
{
    private readonly Consumer consumer = new Consumer();

    public static IEnumerable<ICSharpQuicksortDataSource> CSharpDataSources()
    {
        yield return new CSharpQuicksortArray1DataSource();
        yield return new CSharpQuicksortArray2DataSource();
        yield return new CSharpQuicksortArray3DataSource();
    }

    [ParamsSource(nameof(CSharpDataSources))]
    public ICSharpQuicksortDataSource CSharpData { get; set; }

    public static IEnumerable<ICSharpQuicksortBenchmark> CSharpBenchmarks()
    {
        yield return new ReadableCSharpQuicksortBenchmark();
        yield return new OptimizedCSharpQuicksortBenchmark();
    }

    [ParamsSource(nameof(CSharpBenchmarks))]
    public ICSharpQuicksortBenchmark CSharpBenchmark { get; set; }

    [Benchmark]
    public void CSharpQuicksorts()
    {
        CSharpBenchmark.Run(CSharpData.Data).Consume(consumer);
    }
}