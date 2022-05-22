using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.Abstract;
using Benchmarks.Benchmarks.CSharp;

namespace Benchmarks.Benchmarks.FSharp;

public class InjectedFSharpQuicksortBenchmarks
{
    private readonly Consumer consumer = new Consumer();

    public static IEnumerable<IFSharpQuicksortDataSource> FSharpDataSources()
    {
        // works fine
        //yield return new FSharpQuickSortArray1DataSource();
        //yield return new FSharpQuickSortArray2DataSource();
        //yield return new FSharpQuickSortArray3DataSource();

        // throws build error in RELEASE, but works in DEBUG compilation
        var converter = new CSharpToFSharpQuicksortDataSourceConverter();

        return InjectedCSharpQuicksortBenchmarks.CSharpDataSources().Select(x => converter.Convert(x));
    }

    [ParamsSource(nameof(FSharpDataSources))]
    public IFSharpQuicksortDataSource FSharpData { get; set; }

    public static IEnumerable<IFSharpQuicksortBenchmark> FSharpBenchmarks()
    {
        yield return new FSharpQuicksort1Benchmark();
        yield return new FSharpQuicksort2Benchmark();
        yield return new FSharpQuicksortb1Benchmark();
        yield return new FSharpQuicksortb2Benchmark();
        yield return new FSharpQuicksortb3Benchmark();
        yield return new FSharpQuicksortb4Benchmark();
        yield return new FSharpQuicksortb5Benchmark();
        yield return new FSharpQuicksortb6Benchmark();
        yield return new FSharpQuicksortb7Benchmark();
    }

    [ParamsSource(nameof(FSharpBenchmarks))]
    public IFSharpQuicksortBenchmark FSharpBenchmark { get; set; }

    [Benchmark]
    public void FSharpQuicksorts()
    {
        FSharpBenchmark.Run(FSharpData.Data).Consume(consumer);
    }
}