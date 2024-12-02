using System;

namespace Baekjoon
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int[,] map = new int[3, a];
            int[,] dp = new int[3, a];      // 최대값
            int[,] dpMin = new int[3, a];  // 최소값

            // 입력 처리
            for (int i = 0; i < a; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < 3; j++)
                {
                    map[j, i] = int.Parse(input[j]);
                }
            }

            // DP 초기값 설정
            for (int i = 0; i < 3; i++)
            {
                dp[i, 0] = map[i, 0];       // 최대값
                dpMin[i, 0] = map[i, 0];    // 최소값
            }

            // DP 테이블 채우기
            for (int y = 1; y < a; y++) // 열 기준으로 진행
            {
                for (int x = 0; x < 3; x++) // 각 행을 처리
                {
                    dp[x, y] = int.MinValue;     // 최대값 초기화
                    dpMin[x, y] = int.MaxValue; // 최소값 초기화

                    // 위에서 오는 경우 (x-1 → x)
                    if (x > 0)
                    {
                        dp[x, y] = Math.Max(dp[x, y], dp[x - 1, y - 1] + map[x, y]);
                        dpMin[x, y] = Math.Min(dpMin[x, y], dpMin[x - 1, y - 1] + map[x, y]);
                    }

                    // 바로 위에서 오는 경우 (x → x)
                    dp[x, y] = Math.Max(dp[x, y], dp[x, y - 1] + map[x, y]);
                    dpMin[x, y] = Math.Min(dpMin[x, y], dpMin[x, y - 1] + map[x, y]);

                    // 아래에서 오는 경우 (x+1 → x)
                    if (x < 2)
                    {
                        dp[x, y] = Math.Max(dp[x, y], dp[x + 1, y - 1] + map[x, y]);
                        dpMin[x, y] = Math.Min(dpMin[x, y], dpMin[x + 1, y - 1] + map[x, y]);
                    }
                }
            }

            // 최종 결과 계산
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                max = Math.Max(max, dp[i, a - 1]);
                min = Math.Min(min, dpMin[i, a - 1]);
            }

            Console.WriteLine(max + " " + min);
        }
    }
}
