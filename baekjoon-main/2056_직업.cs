using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // 작업 수
            List<int>[] dependencies = new List<int>[n + 1]; // 선행 관계 그래프
            int[] times = new int[n + 1]; // 각 작업의 소요 시간
            int[] indegree = new int[n + 1]; // 각 작업의 선행 작업 수
            int[] dp = new int[n + 1]; // 작업 완료 시간

            for (int i = 1; i <= n; i++)
            {
                dependencies[i] = new List<int>();
            }

            // 입력 처리
            for (int i = 1; i <= n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                times[i] = input[0]; // 작업 소요 시간
                int numDependencies = input[1]; // 선행 작업 개수

                for (int j = 0; j < numDependencies; j++)
                {
                    int dependency = input[2 + j];
                    dependencies[dependency].Add(i); // 선행 작업 추가
                    indegree[i]++; // i 작업의 선행 작업 수 증가
                }
            }

            // 위상 정렬 (Topological Sort)
            Queue<int> queue = new Queue<int>();

            // 선행 작업이 없는 작업들 초기화
            for (int i = 1; i <= n; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                    dp[i] = times[i];
                }
            }

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                foreach (int next in dependencies[current])
                {
                    // dp[next] = max(dp[next], dp[current] + 작업 시간)
                    dp[next] = Math.Max(dp[next], dp[current] + times[next]);

                    // 다음 작업의 indegree 감소
                    indegree[next]--;

                    // 선행 작업이 모두 처리되었으면 큐에 추가
                    if (indegree[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            // 결과 출력 (최대 작업 시간)
            Console.WriteLine(dp.Max());
        }
    }
}
