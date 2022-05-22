using static csharp.console1.CSharpUtils;

var list = new[] { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
var sorted = Quicksort(list).ToArray();
Console.WriteLine(string.Join(",", sorted));
