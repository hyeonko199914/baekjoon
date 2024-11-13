using System;
using System.Linq;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int A = int.Parse(Console.ReadLine());
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int B = int.Parse(Console.ReadLine());
            Array.Sort(data); // 배열을 정렬합니다.
            int len = data.Length;
            int count = 0;
            int left = 0;
            int right = len - 1;

            while (left < right) {
                int sum = data[left] + data[right];
                if (sum == B) {
                    count++;
                    left++;
                    right--;
                }
                else if (sum < B) {
                    left++;
                }
                else {
                    right--;
                }
            }

            Console.WriteLine(count);
        }
    }
}