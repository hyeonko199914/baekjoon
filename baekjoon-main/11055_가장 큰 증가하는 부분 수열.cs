using System;

namespace MyCompiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            // 입력 처리
            int n = int.Parse(Console.ReadLine());
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // DP 배열 초기화
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = data[i]; 
            }

            // 동적 프로그래밍으로 LIS 계산
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (data[i] > data[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + data[i]);
                    }
                }
            }

            // 가장 긴 증가 부분 수열 길이 계산
            int max= 0;
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, dp[i]);
            }

            // 결과 출력
            Console.WriteLine(max);
        }
    }
}
