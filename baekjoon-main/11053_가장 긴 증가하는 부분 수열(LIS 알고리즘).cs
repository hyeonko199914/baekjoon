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
                dp[i] = 1; // 기본값: 모든 숫자는 최소 길이 1의 증가 부분 수열을 가짐
            }

            // 동적 프로그래밍으로 LIS 계산
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (data[i] > data[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            // 가장 긴 증가 부분 수열 길이 계산
            int maxLength = 0;
            for (int i = 0; i < n; i++)
            {
                maxLength = Math.Max(maxLength, dp[i]);
            }

            // 결과 출력
            Console.WriteLine(maxLength);
        }
    }
}
