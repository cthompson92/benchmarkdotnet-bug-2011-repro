using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using csharp.console1;
using fsharp.console1;
using Microsoft.FSharp.Collections;

namespace Benchmarks.Benchmarks;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class QuicksortBenchmarks
{
    private readonly Consumer consumer = new Consumer();

    private static readonly int[] A1 = BenchmarksData.A1;

    private static readonly FSharpList<int> F1 = ListModule.OfSeq(A1);

    private static readonly int[] A2 = BenchmarksData.A2;

    private static readonly FSharpList<int> F2 = ListModule.OfSeq(A2);

    private static readonly int[] A3 = BenchmarksData.A3;

    private static readonly FSharpList<int> F3 = ListModule.OfSeq(A3);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void CSharp_1() => CSharpUtils.Quicksort(A1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void CSharp_optimized_1() => CSharpUtils.Quicksort_optimized(A1, 0, A1.Length - 1).Consume(consumer);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Array1")]
    public void FSharp_1() => Utils.quicksort(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharp2_1() => Utils.quicksort2(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharpb1_1() => Utils.quicksortb1(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharpb2_1() => Utils.quicksortb2(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharpb3_1() => Utils.quicksortb3(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharpb4_1() => Utils.quicksortb4(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharpb5_1() => Utils.quicksortb5(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharpb6_1() => Utils.quicksortb6(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array1")]
    public void FSharpb7_1() => Utils.quicksortb7(F1).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void CSharp_2() => CSharpUtils.Quicksort(A2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void CSharp_optimized_2() => CSharpUtils.Quicksort_optimized(A2, 0, A2.Length - 1).Consume(consumer);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Array2")]
    public void FSharp_2() => Utils.quicksort(F2).Consume(consumer);
    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharp2_2() => Utils.quicksort2(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharpb1_2() => Utils.quicksortb1(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharpb2_2() => Utils.quicksortb2(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharpb3_2() => Utils.quicksortb3(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharpb4_2() => Utils.quicksortb4(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharpb5_2() => Utils.quicksortb5(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharpb6_2() => Utils.quicksortb6(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array2")]
    public void FSharpb7_2() => Utils.quicksortb7(F2).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void CSharp_3() => CSharpUtils.Quicksort(A3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void CSharp_optimized_3() => CSharpUtils.Quicksort_optimized(A3, 0, A3.Length - 1).Consume(consumer);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Array3")]
    public void FSharp_3() => Utils.quicksort(F3).Consume(consumer);
    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharp2_3() => Utils.quicksort2(F3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharpb1_3() => Utils.quicksortb1(F3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharpb2_3() => Utils.quicksortb2(F3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharpb3_3() => Utils.quicksortb3(F3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharpb4_3() => Utils.quicksortb4(F3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharpb5_3() => Utils.quicksortb5(F3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharpb6_3() => Utils.quicksortb6(F3).Consume(consumer);

    [Benchmark]
    [BenchmarkCategory("Array3")]
    public void FSharpb7_3() => Utils.quicksortb7(F3).Consume(consumer);
}