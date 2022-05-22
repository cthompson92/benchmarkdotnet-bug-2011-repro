using Microsoft.FSharp.Collections;

namespace Benchmarks.Abstract;

public interface IFSharpQuicksortBenchmark
{
    IEnumerable<int> Run(FSharpList<int> data);
}