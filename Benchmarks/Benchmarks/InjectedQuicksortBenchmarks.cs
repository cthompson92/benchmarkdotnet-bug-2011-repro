using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using Benchmarks.Abstract;
using Benchmarks.Benchmarks.CSharp;
using Benchmarks.Benchmarks.FSharp;

namespace Benchmarks.Benchmarks;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class InjectedQuicksortBenchmarks
{
    private readonly Consumer consumer = new Consumer();

    public static IEnumerable<ICSharpQuicksortDataSource> CSharpDataSources()
    {
        return InjectedCSharpQuicksortBenchmarks.CSharpDataSources();
    }

    [ParamsSource(nameof(CSharpDataSources))]
    public ICSharpQuicksortDataSource CSharpData { get; set; }

    public static IEnumerable<IFSharpQuicksortDataSource> FSharpDataSources()
    {
        return InjectedFSharpQuicksortBenchmarks.FSharpDataSources();
    }

    [ParamsSource(nameof(FSharpDataSources))]
    public IFSharpQuicksortDataSource FSharpData { get; set; }

    public static IEnumerable<ICSharpQuicksortBenchmark> CSharpBenchmarks()
    {
        return InjectedCSharpQuicksortBenchmarks.CSharpBenchmarks();
    }

    [ParamsSource(nameof(CSharpBenchmarks))]
    public ICSharpQuicksortBenchmark CSharpBenchmark { get; set; }

    public static IEnumerable<IFSharpQuicksortBenchmark> FSharpBenchmarks()
    {
        return InjectedFSharpQuicksortBenchmarks.FSharpBenchmarks();
    }

    [ParamsSource(nameof(FSharpBenchmarks))]
    public IFSharpQuicksortBenchmark FSharpBenchmark { get; set; }

    [Benchmark]
    [BenchmarkCategory("CSharp")]
    public void CSharpQuicksorts()
    {
        CSharpBenchmark.Run(CSharpData.Data).Consume(consumer);
    }

    [Benchmark]
    [BenchmarkCategory("FSharp")]
    public void FSharpQuicksorts()
    {
        FSharpBenchmark.Run(FSharpData.Data).Consume(consumer);
    }
}