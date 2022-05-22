namespace Benchmarks.Abstract;

public interface ICSharpQuicksortBenchmark
{
    IEnumerable<int> Run(int[] data);
}