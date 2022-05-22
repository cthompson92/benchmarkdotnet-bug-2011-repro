using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks.CSharp;
using Benchmarks.Benchmarks.FSharp;

BenchmarkSwitcher
   .FromTypes(new []
    {
        typeof(InjectedCSharpQuicksortBenchmarks),
        typeof(InjectedFSharpQuicksortBenchmarks),
        //typeof(InjectedQuicksortBenchmarks),

        //typeof(QuicksortBenchmarks),
        //typeof(QuicksortBenchmarks_Array1),
        //typeof(QuicksortBenchmarks_Array2),
        //typeof(QuicksortBenchmarks_Array3),
    })
   .Run(args,
#if DEBUG
    new DebugInProcessConfig()
#else
    DefaultConfig.Instance
#endif
       .WithOptions(ConfigOptions.JoinSummary)
    );