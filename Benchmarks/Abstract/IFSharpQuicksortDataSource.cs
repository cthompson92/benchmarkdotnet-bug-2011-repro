using Microsoft.FSharp.Collections;

namespace Benchmarks.Abstract;

public interface IFSharpQuicksortDataSource : IQuicksortDataSourceCategory
{
    FSharpList<int> Data { get; }
}