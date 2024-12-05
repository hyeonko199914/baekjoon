using System;

namespace MyCompiler
{
    class Program
    {
        static int[,] map;
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

        static int Dijkstra(int[,] map, int N, int start, int end)
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
            return dist[end];
        }

        public static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int mapsize = input[0];
            map = new int[mapsize + 1, mapsize + 1];
            
            for (int i = 1; i <= mapsize; i++)
            {
                for (int j = 1; j <= mapsize; j++)
                {
                    map[i, j] = INF;
                }
            }

            for (int i = 0; i < input[1]; i++)
            {
                int[] testinput = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int start = testinput[0];
                int end = testinput[1];
                int weight = testinput[2];
                map[start, end] = weight;
                map[end, start] = weight; // 필요에 따라 대칭 여부 조정
            }

            int[] ansinput = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int startNode = ansinput[0];
            int destinationNode = ansinput[1];

            int v1v2 = Dijkstra(map, mapsize, startNode, destinationNode);
            int starttov1 = Dijkstra(map, mapsize, 1, startNode);
            int v2toend = Dijkstra(map, mapsize, destinationNode, mapsize);
            int starttov2 = Dijkstra(map, mapsize, 1, destinationNode);
            int v1toend = Dijkstra(map, mapsize, startNode, mapsize);


            ans1 = starttov1 + v1v2 + v2toend;
            int ans2 = starttov2 + v1v2 + v1toend;
            int ans = Math.Min(ans1, ans2);

            if (v1v2 == INF)
            {
                Console.WriteLine("-1"); // 도달할 수 없는 경우
            }
            else
            {
                Console.WriteLine(ans); // 목적지까지의 최소 거리 출력
            }
        }
    }
}
