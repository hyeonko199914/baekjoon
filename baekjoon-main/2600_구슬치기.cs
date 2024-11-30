using System;

namespace MyCompiler
{
    class Program
    {
        static bool[,] dp = new bool[501, 501];
        static int[] moves;

        static void Solve(int maxX, int maxY)
        {
            // DP 배열 초기화
            for (int i = 0; i <= maxX; i++)
            {
                for (int j = 0; j <= maxY; j++)
                {
                    foreach (int move in moves)
                    {
                        // 첫 번째 통에서 move만큼 구슬을 꺼낼 경우
                        if (i >= move && !dp[i - move, j])
                            dp[i, j] = true;

                        // 두 번째 통에서 move만큼 구슬을 꺼낼 경우
                        if (j >= move && !dp[i, j - move])
                            dp[i, j] = true;

                        // 이미 승리 상태가 결정되었다면 중단
                        if (dp[i, j]) break;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            moves = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // DP 배열 계산
            Solve(500, 500);

            // 다섯 개 테스트 케이스 처리
            for (int t = 0; t < 5; t++)
            {
                // 각 테스트 케이스의 초기 상태 입력
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int k1 = data[0], k2 = data[1];

                // 결과 출력
                Console.WriteLine(dp[k1, k2] ? "A" : "B");
            }
        }
    }
}
