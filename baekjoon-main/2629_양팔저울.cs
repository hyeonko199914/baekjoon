using System;

namespace MyCompiler
{
    class Program
    {
        // 문제를 해결하기 위한 재귀 함수
        static void Solve(int x, int y, int a, bool[,] dp, int[] weight)
        {
            if (x > a || dp[x, y]) return; // 경계 조건: 범위를 넘거나 이미 처리된 경우 종료
            dp[x, y] = true; // 현재 상태 기록

            if (x < a) // 조건에 맞게 상태 탐색
            {
                Solve(x + 1, y + weight[x], a, dp, weight); // 현재 무게 추가
                Solve(x + 1, y, a, dp, weight);             // 무게 추가하지 않음
                Solve(x + 1, Math.Abs(y - weight[x]), a, dp, weight); // 무게 차이 계산
            }
        }

        public static void Main(string[] args)
        {
            // 입력 처리
            int a = int.Parse(Console.ReadLine());
            int[] weight = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int b = int.Parse(Console.ReadLine());
            int[] queries = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // DP 배열 초기화: 최대 무게는 문제에 따라 조정 가능 (예: 40000)
            bool[,] dp = new bool[a + 1, 40001];
            
            // 무게 조합 계산 시작
            Solve(0, 0, a, dp, weight);

            // 질의 처리 및 출력
            for (int i = 0; i < b; i++)
            {
                if (queries[i] >= 0 && queries[i] <= 40000 && dp[a, queries[i]])
                {
                    Console.Write("Y");
                }
                else
                {
                    Console.Write("N");
                }

                // 각 출력 뒤 공백 추가 (마지막 요소 제외)
                if (i < queries.Length - 1)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
