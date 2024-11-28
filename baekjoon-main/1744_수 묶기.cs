using System;

namespace MyCompiler {
    class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            int[] list = new int[n];
            for (int k = 0; k < n; k++) {
                list[k] = int.Parse(Console.ReadLine());
            }

            // 배열을 오름차순으로 정렬
            Array.Sort(list);

            int sum = 0;
            int i = 0;

            // 음수와 0 처리
            while (i < n - 1 && list[i] <= 0 && list[i + 1] <= 0) {
                sum += list[i] * list[i + 1];
                i += 2;
            }

            // 양수 처리
            int j = n - 1;
            while (j > 0 && list[j] > 1 && list[j - 1] > 1) {
                sum += list[j] * list[j - 1];
                j -= 2;
            }

            // 남은 숫자들 더하기
            while (i <= j) {
                sum += list[i];
                i++;
            }

            Console.WriteLine(sum);
        }
    }
}
