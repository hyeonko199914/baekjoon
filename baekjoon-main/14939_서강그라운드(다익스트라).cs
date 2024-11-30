using System;
using System.Linq;

class Program
{
    const int INF = int.MaxValue;

    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int k = input[0]; // 정점 개수
        int search = input[1]; // 탐색 가능한 최대 거리
        int road = input[2]; // 도로 수
        int[] item = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 각 정점의 아이템 개수
        int[,] map = new int[k, k];
        int[] distmax = new int[k];

        // 맵 초기화
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                map[i, j] = INF;
            }
        }

        // 도로 입력
        for (int i = 0; i < road; i++)
        {
            int[] mapinp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int from = mapinp[0] - 1; // 1부터 시작하는 인덱스 변환
            int to = mapinp[1] - 1;
            int weight = mapinp[2];

            map[from, to] = weight;
            map[to, from] = weight; // 양방향 도로
        }

        // 각 정점을 시작점으로 다익스트라 수행
        for (int i = 0; i < k; i++)
        {
            int[] dist = new int[k];
            bool[] visit = new bool[k];

            // 초기화
            for (int j = 0; j < k; j++)
            {
                dist[j] = INF;
            }
            dist[i] = 0;

            // 다익스트라 알고리즘
            for (int j = 0; j < k; j++)
            {
                int u = MinDistance(dist, visit);
                if (u == -1) break; // 방문할 정점이 없으면 종료

                visit[u] = true;
                for (int t = 0; t < k; t++)
                {
                    if (!visit[t] && map[u, t] != INF && dist[u] != INF && dist[u] + map[u, t] < dist[t])
                    {
                        dist[t] = dist[u] + map[u, t];
                    }
                }
            }

            // 아이템 계산
            for (int j = 0; j < k; j++)
            {
                if (dist[j] != INF && dist[j] <= search)
                {
                    distmax[i] += item[j];
                }
            }
        }

        // 결과 출력
        Console.WriteLine(distmax.Max());
    }

    static int MinDistance(int[] dist, bool[] visit)
    {
        int min = INF, minIndex = -1;

        for (int v = 0; v < dist.Length; v++)
        {
            if (!visit[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}
