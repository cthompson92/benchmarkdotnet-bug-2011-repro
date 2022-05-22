namespace Benchmarks.Abstract;

public interface ICSharpQuicksortDataSource : IQuicksortDataSourceCategory
{
    int[] Data { get; }
}