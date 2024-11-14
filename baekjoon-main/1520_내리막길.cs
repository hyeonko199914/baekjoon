using System;

namespace MyCompiler {
    class Program {
        public static int dpdps(int x, int y, int m, int n, int[,] dp, int[,] map) {
            // Base case: If we reach the bottom-right corner, there's one path.
            if (x == m - 1 && y == n - 1) {
                return 1;
            }

            // If already calculated, return the stored result.
            if (dp[x, y] != -1) {
                return dp[x, y];
            }

            dp[x, y] = 0; // Initialize paths from this cell.

            // Check all possible directions and accumulate paths.
            if (x + 1 < m && map[x, y] > map[x + 1, y]) {
                dp[x, y] += dpdps(x + 1, y, m, n, dp, map);
            }
            if (x - 1 >= 0 && map[x, y] > map[x - 1, y]) {
                dp[x, y] += dpdps(x - 1, y, m, n, dp, map);
            }
            if (y + 1 < n && map[x, y] > map[x, y + 1]) {
                dp[x, y] += dpdps(x, y + 1, m, n, dp, map);
            }
            if (y - 1 >= 0 && map[x, y] > map[x, y - 1]) {
                dp[x, y] += dpdps(x, y - 1, m, n, dp, map);
            }

            return dp[x, y];
        }

        public static void Main(string[] args) {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int m = data[0];
            int n = data[1];

            int[,] map = new int[m, n];
            int[,] dp = new int[m, n];

            // Initialize dp array with -1 (unvisited state).
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    dp[i, j] = -1;
                }
            }

            for (int i = 0; i < m; i++) {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < n; j++) {
                    map[i, j] = input[j];
                }
            }

            Console.WriteLine(dpdps(0, 0, m, n, dp, map));
        }
    }
}
