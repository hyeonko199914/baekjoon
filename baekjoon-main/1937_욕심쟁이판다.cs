using System;

namespace MyCompiler {
    class Program {
        static void dfs(int x, int y, int[,] map, int[,] dp, bool[,] pass, int size) {
            if (pass[x, y]) return;

            pass[x, y] = true; 
            dp[x, y] = 1; 

            
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int i = 0; i < 4; i++) {
                int nx = x + dx[i];
                int ny = y + dy[i];

                
                if (nx >= 0 && nx < size && ny >= 0 && ny < size && map[x, y] < map[nx, ny]) {
                    if (!pass[nx, ny]) {
                        dfs(nx, ny, map, dp, pass, size);
                    }
                    dp[x, y] = Math.Max(dp[x, y], dp[nx, ny] + 1);
                }
            }
        }

        public static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            int[,] map = new int[a, a];
            bool[,] pass = new bool[a, a];
            int[,] dp = new int[a, a];
            int maxdp = 0;

            for (int i = 0; i < a; i++) {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < a; j++) {
                    map[i, j] = data[j];
                }
            }

            for (int i = 0; i < a; i++) {
                for (int j = 0; j < a; j++) {
                    if (!pass[i, j]) {
                        dfs(i, j, map, dp, pass, a);
                    }
                    maxdp = Math.Max(maxdp, dp[i, j]); 
                }
            }

            Console.WriteLine(maxdp);
        }
    }
}
