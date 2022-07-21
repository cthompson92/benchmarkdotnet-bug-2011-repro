using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using Benchmarks.Benchmarks.CSharp;
using Benchmarks.Benchmarks.FSharp;

var config =
#if DEBUG
    new DebugInProcessConfig();
#else
	DefaultConfig.Instance;
#endif

BenchmarkSwitcher
.FromTypes(
		new[]
		{
			typeof(InjectedCSharpQuicksortBenchmarks),
			typeof(InjectedFSharpQuicksortBenchmarks),
			typeof(MedianBenchmarks),

			//typeof(InjectedQuicksortBenchmarks),

			//typeof(QuicksortBenchmarks),
			//typeof(QuicksortBenchmarks_Array1),
			//typeof(QuicksortBenchmarks_Array2),
			//typeof(QuicksortBenchmarks_Array3),
		})
.Run(args,
	config
		.WithOptions(ConfigOptions.JoinSummary)
		.WithSummaryStyle(SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend))
	);
