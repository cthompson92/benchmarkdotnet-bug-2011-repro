using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.Abstract;
using Benchmarks.Benchmarks.CSharp;
using Benchmarks.Benchmarks.FSharp;
using csharp.console1;
using fsharp.console1;
using Microsoft.FSharp.Core;

namespace Benchmarks.Benchmarks;

public class MedianBenchmarks
{
	public static IEnumerable<ICSharpQuicksortDataSource> CSharpDataSources()
		=> InjectedCSharpQuicksortBenchmarks.CSharpDataSources();

	[ParamsSource(nameof(CSharpDataSources))]
	public ICSharpQuicksortDataSource CSharpData { get; set; }

	[Benchmark(Baseline = true)]
	[BenchmarkCategory("CSharp")]
	public int CSharpMedian()
	{
		return CSharpData.Data.Median((x, y) => x + y / 2);
	}

	public static IEnumerable<IFSharpQuicksortDataSource> FSharpDataSources()
		=> InjectedFSharpQuicksortBenchmarks.FSharpDataSources();

	[ParamsSource(nameof(FSharpDataSources))]
	public IFSharpQuicksortDataSource FSharpData { get; set; }

	[Benchmark()]
	[BenchmarkCategory("FSharp")]
	public int FSharpMedian()
	{
		return Utils.median(FSharpData.Data, FuncConvert.FromFunc((Tuple<int, int> t) => t.Item1 + t.Item2 / 2));
	}
}
