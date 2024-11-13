using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int[,] dp = new int[1001, 1001];
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = data[0]; 
            int k = data[1]; 
            int max = 0;

            for (int i = 0; i < n; i++) {
                string input = Console.ReadLine();
                for (int j = 0; j < k; j++) {
                    dp[i, j] = input[j] - '0'; 
                }
            }
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < k; j++) {
                    if (i > 0 && j > 0 && dp[i, j] == 1) {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                    }
                    max = Math.Max(max, dp[i, j]);
                }
            }
            Console.WriteLine(max*max);
        }
    }
}
