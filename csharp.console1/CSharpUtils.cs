using System.Runtime.CompilerServices;

namespace csharp.console1;

public static class CSharpUtils
{
    public static IEnumerable<int> Quicksort(IEnumerable<int> elements)
    {
        if (!elements.Any())
        {
            return Enumerable.Empty<int>();
        }

        var x = elements.First();
        var xs = elements.Skip(1);

        var smaller = Quicksort(xs.Where(y => x > y));
        var larger = Quicksort(xs.Where(y => x <= y));

        return smaller.Concat(new[] { x }).Concat(larger);
    }

    public static int[] Quicksort_optimized(int[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            Quicksort_optimized(array, leftIndex, j);

        if (i < rightIndex)
            Quicksort_optimized(array, i, rightIndex);

        return array;
    }

	/// <summary>
	/// Partitions the given list around a pivot element such that all elements on left of pivot are <= pivot
	/// and the ones at thr right are > pivot. This method can be used for sorting, N-order statistics such as
	/// as median finding algorithms.
	/// Pivot is selected randomly if random number generator is supplied else its selected as last element in the list.
	/// Reference: Introduction to Algorithms 3rd Edition, Corman et al, pp 171
	/// </summary>
	private static int Partition<T>(this IList<T> list, int start, int end, Random? rnd = null) where T : IComparable<T>
	{
		if (rnd != null)
			list.Swap(end, rnd.Next(start, end + 1));

		var pivot = list[end];
		var lastLow = start - 1;
		for (var i = start; i < end; i++)
		{
			if (list[i].CompareTo(pivot) <= 0)
				list.Swap(i, ++lastLow);
		}
		list.Swap(end, ++lastLow);
		return lastLow;
	}

	/// <summary>
	/// Returns Nth smallest element from the list. Here n starts from 0 so that n=0 returns minimum, n=1 returns 2nd smallest element etc.
	/// Note: specified list would be mutated in the process.
	/// Reference: Introduction to Algorithms 3rd Edition, Corman et al, pp 216
	/// </summary>
	public static T NthOrderStatistic<T>(this IList<T> list, int n, Func<T, T, T> averager, Random? rnd = null) where T : IComparable<T>
	{
		return NthOrderStatistic(list, n, 0, list.Count - 1, averager, rnd);
	}

	private static T NthOrderStatistic<T>(this IList<T> list, int n, int start, int end, Func<T, T, T> averager, Random? rnd) where T : IComparable<T>
	{
		while (true)
		{
			var pivotIndex = list.Partition(start, end, rnd);
			if (pivotIndex == n)
			{
				return n % 2 == 0 
					? list[pivotIndex]
					: averager(list[pivotIndex], list[pivotIndex + 1]);
			}

			if (n < pivotIndex)
				end = pivotIndex - 1;
			else
				start = pivotIndex + 1;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Swap<T>(this IList<T> list, int i, int j)
	{
		if (i == j)   //This check is not required but Partition function may make many calls so its for perf reason
			return;
		(list[i], list[j]) = (list[j], list[i]);
	}

	/// <summary>
	/// Note: specified list would be mutated in the process.
	/// </summary>
	private static T Median_Impl<T>(this IList<T> list, Func<T, T, T> averager) where T : IComparable<T>
	{
		return list.NthOrderStatistic((list.Count - 1) / 2, averager);
	}
	
	public static T Median<T>(this IEnumerable<T> source, Func<T, T, T> averager) where T : IComparable<T>
	{
		var list = source.ToList();
		return list.ToList().NthOrderStatistic((list.Count - 1) / 2, averager);
	}

	public static double Median<T>(this IEnumerable<T> sequence, Func<T, double> getValue)
	{
		var list = sequence.Select(getValue).ToList();
		var mid = (list.Count - 1) / 2;
		return list.NthOrderStatistic(mid, (left, right) => (left + right) / 2);
	}
}
