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
}