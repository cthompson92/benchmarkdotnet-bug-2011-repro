using Benchmarks.Abstract;
using Microsoft.FSharp.Collections;

namespace Benchmarks.Benchmarks.FSharp;

public class CSharpToFSharpQuicksortDataSourceConverter : ICSharpToFSharpQuicksortDataSourceConverter
{
    public IFSharpQuicksortDataSource Convert(ICSharpQuicksortDataSource data)
    {
        return new FSharpQuickSortDataSource(data.Data, data.Category);
    }

    public class FSharpQuickSortDataSource : IFSharpQuicksortDataSource
    {
        public FSharpList<int> Data { get; }
        public string Category { get; }
        
        public FSharpQuickSortDataSource(IEnumerable<int> data, string category)
        {
            Data = ListModule.OfSeq(data);
            Category = category;
        }
        
        public override string ToString()
        {
            return $"FSharp - {Category}";
        }
    }
}
