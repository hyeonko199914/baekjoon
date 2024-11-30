using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int area = int.Parse(Console.ReadLine());
            int[,] map = new int[area, area];
            int[,,] dp = new int[area, area, 3]; // DP 배열: 0 - 가로, 1 - 세로, 2 - 대각선

            for (int i = 0; i < area; i++) {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < area; j++) {
                    map[i, j] = input[j];
                }
            }

            dp[0, 1, 0] = 1;

            // DP 계산
            for (int x = 0; x < area; x++) {
                for (int y = 0; y < area; y++) {
                    if (map[x, y] == 1) continue; 

                    // 가로 방향 (→)
                    if (y - 1 >= 0) {
                        dp[x, y, 0] += dp[x, y - 1, 0]; 
                        dp[x, y, 0] += dp[x, y - 1, 2]; 
                    }

                    // 세로 방향 (↓)
                    if (x - 1 >= 0) {
                        dp[x, y, 1] += dp[x - 1, y, 1]; 
                        dp[x, y, 1] += dp[x - 1, y, 2]; 
                    }

                    // 대각선 방향 (↘)
                    if (x - 1 >= 0 && y - 1 >= 0 &&
                        map[x - 1, y] == 0 && map[x, y - 1] == 0) {
                        dp[x, y, 2] += dp[x - 1, y - 1, 0];
                        dp[x, y, 2] += dp[x - 1, y - 1, 1]; 
                        dp[x, y, 2] += dp[x - 1, y - 1, 2]; 
                    }
                }
            }

            int result = dp[area - 1, area - 1, 0] + dp[area - 1, area - 1, 1] + dp[area - 1, area - 1, 2];
            Console.WriteLine(result);
        }
    }
}
