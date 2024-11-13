using System;
using System.Text;
using System.Linq;
namespace Solution {
  class Program {
    static void Main(string[] args) {

      var input = Console.ReadLine().Split(' ');
      var n = int.Parse(input[0]);
      var m = int.Parse(input[1]);

      var trees = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

      int start = 0, end = trees.Max();
      while (start <= end) {
        int mid = (start + end) / 2;

        long wood = 0;
        foreach (var tree in trees)
          if (tree > mid)
            wood += tree - mid;

        if (wood >= m) start = mid + 1;
        else end = mid - 1;
      }

      Console.WriteLine(end);

    }
  }
}