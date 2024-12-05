using System;

namespace MyCompiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[,,] dp = new int[10, 10, 1024];
            int mod = 1000000000;
            int ans = 0;

            // 초기화: 길이 1의 숫자
            for (int k = 1; k < 10; k++)
            {
                dp[0, k, 1 << k] = 1;
            }

            // DP 계산
            for (int i = 1; i < input; i++) // 길이 i
            {
                for (int j = 0; j < 10; j++) // 현재 숫자 j
                {
                    for (int k = 0; k < 1024; k++) // 비트마스크 k
                    {
                        if (j > 0) dp[i, j, k | (1 << j)] = (dp[i, j, k | (1 << j)] + dp[i - 1, j - 1, k]) % mod;
                        if (j < 9) dp[i, j, k | (1 << j)] = (dp[i, j, k | (1 << j)] + dp[i - 1, j + 1, k]) % mod;
                    }
                }
            }

            // 결과 계산
            for (int i = 0; i < 10; i++)
            {
                ans = (ans + dp[input - 1, i, 1023]) % mod;
            }

            Console.WriteLine(ans);
        }
    }
}
