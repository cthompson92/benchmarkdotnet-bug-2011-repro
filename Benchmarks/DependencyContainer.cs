//using Benchmarks.Abstract;
//using Benchmarks.Benchmarks.CSharp;
//using Benchmarks.Benchmarks.FSharp;
//using Microsoft.Extensions.DependencyInjection;

//namespace Benchmarks;

//internal class DependencyContainer
//{
//    private DependencyContainer()
//    {
//        var services = new ServiceCollection()
//           .AddSingleton<ICSharpQuicksortDataSource, CSharpQuicksortArray1DataSource>()
//           .AddSingleton<ICSharpQuicksortDataSource, CSharpQuicksortArray2DataSource>()
//           .AddSingleton<ICSharpQuicksortDataSource, CSharpQuicksortArray3DataSource>()
//           .AddSingleton<ICSharpToFSharpQuicksortDataSourceConverter, CSharpToFSharpQuicksortDataSourceConverter>()
//           .AddSingleton<ICSharpQuicksortBenchmark, ReadableCSharpQuicksortBenchmark>()
//           .AddSingleton<ICSharpQuicksortBenchmark, OptimizedCSharpQuicksortBenchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksort1Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksort2Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksortb1Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksortb2Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksortb3Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksortb4Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksortb5Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksortb6Benchmark>()
//           .AddSingleton<IFSharpQuicksortBenchmark, FSharpQuicksortb7Benchmark>();

//        ServiceProvider = services.BuildServiceProvider();
//    }

//    public IServiceProvider ServiceProvider { get; }

//    public static DependencyContainer Instance = new DependencyContainer();
//}