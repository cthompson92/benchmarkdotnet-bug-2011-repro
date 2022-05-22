namespace Benchmarks.Abstract;

public interface ICSharpToFSharpQuicksortDataSourceConverter
{
    IFSharpQuicksortDataSource Convert(ICSharpQuicksortDataSource data);
}