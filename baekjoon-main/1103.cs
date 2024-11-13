using System;

namespace MyCompiler {
    class Program {
        static int[,] dp;
        static int N, M;
        static string[,] map;
        static bool[,] inStack;
        static int maxCount = -1;

        static int DFS(int n, int m) {
            if (n < 0 || n >= N || m < 0 || m >= M || map[n, m] == "H") {
                return 0; // 종료 조건: 경계 밖이거나 "H"에 도달한 경우
            }

            if (inStack[n, m]) {
                Console.WriteLine("-1"); // 무한 루프 발생
                Environment.Exit(0);
            }

            if (dp[n, m] != -1) {
                return dp[n, m]; // 이미 계산된 값이 있으면 반환
            }

            inStack[n, m] = true; // 현재 노드를 스택에 추가
            int steps = int.TryParse(map[n, m], out int A) ? A : 0;
            int result = 0;

            // 4방향 탐색
            if (steps > 0) {
                result = Math.Max(result, DFS(n + steps, m) + 1); // 아래로 이동
                result = Math.Max(result, DFS(n - steps, m) + 1); // 위로 이동
                result = Math.Max(result, DFS(n, m + steps) + 1); // 오른쪽으로 이동
                result = Math.Max(result, DFS(n, m - steps) + 1); // 왼쪽으로 이동
            }

            inStack[n, m] = false; // 탐색 종료 후 스택에서 제거
            dp[n, m] = result; // 결과를 메모이제이션
            return result;
        }

        public static void Main(string[] args) {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            N = data[0];
            M = data[1];
            map = new string[N, M];
            dp = new int[N, M];
            inStack = new bool[N, M];

            for (int i = 0; i < N; i++) {
                string input = Console.ReadLine();
                for (int j = 0; j < M; j++) {
                    map[i, j] = input[j].ToString();
                    dp[i, j] = -1; // DP 배열 초기화
                }
            }

            maxCount = DFS(0, 0);
            Console.WriteLine(maxCount);
        }
    }
}
