using System;
using System.Linq;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int A = int.Parse(Console.ReadLine());
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(data); // 배열을 정렬합니다.
            int len = data.Length;
            int left = 0;
            int right = len - 1;
            int min = Math.Abs(data[left] + data[right]); // 최솟값을 합의 절댓값으로 초기화
            int leftanswer = data[left];
            int rightanswer = data[right];

            while (left < right) {
                int sum = data[left] + data[right];
                int absSum = Math.Abs(sum); // 합의 절댓값을 계산

                if (min > absSum) {
                    min = absSum;
                    leftanswer = data[left];
                    rightanswer = data[right];
                }

                if (sum < 0) // 합이 음수일 때 left 포인터를 오른쪽으로 이동
                    left++;
                else // 합이 양수일 때 right 포인터를 왼쪽으로 이동
                    right--;
            }

            Console.Write(leftanswer + " " + rightanswer + "\n");
        }
    }
}