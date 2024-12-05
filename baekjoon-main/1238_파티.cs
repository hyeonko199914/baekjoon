using System;

namespace Baekjoon
{
    class Program
    {
        const int INF = int.MaxValue;

        static int MinDistance(int[] dist, bool[] visit)
        {
            int min = INF, minIndex = -1;

            for (int v = 1; v < dist.Length; v++) // 1부터 N까지
            {
                if (!visit[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        static int[] Dijkstra(int[,] map, int N, int start)
        {
            int[] dist = new int[N + 1];
            bool[] visit = new bool[N + 1];

            for (int i = 1; i <= N; i++) dist[i] = INF; // 초기화
            dist[start] = 0;

            for (int i = 1; i <= N; i++)
            {
                int u = MinDistance(dist, visit);
                if (u == -1) break;

                visit[u] = true;

                for (int v = 1; v <= N; v++)
                {
                    if (!visit[v] && map[u, v] != INF && dist[u] != INF && dist[u] + map[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + map[u, v];
                    }
                }
            }
            return dist;
        }

        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = input[0];
            int M = input[1];
            int X = input[2];

            int[,] map = new int[N + 1, N + 1];

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    map[i, j] = INF; // 초기값 설정
                }
                map[i, i] = 0; // 자기 자신으로 가는 비용은 0
            }

            for (int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int a = input[0];
                int b = input[1];
                int c = input[2];
                map[a, b] = c; // 단방향 간선
            }

            // 목적지 X에서 다른 모든 노드로의 최단 거리
            int[] distFromX = Dijkstra(map, N, X);

            int maxRoundTrip = 0;

            // 각 노드에서 X까지의 거리 + X에서 다시 해당 노드로의 거리
            for (int i = 1; i <= N; i++)
            {
                int[] distToX = Dijkstra(map, N, i);
                maxRoundTrip = Math.Max(maxRoundTrip, distToX[X] + distFromX[i]);
            }

            Console.WriteLine(maxRoundTrip);
        }
    }
}
