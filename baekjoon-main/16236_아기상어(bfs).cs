using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int size;
    static int[,] map;
    static int startX, startY;
    static int totalTime = 0;

    static int BFS(int x, int y, ref int growth, ref int eatCount)
    {
        int[] dx = { -1, 0, 0, 1 }; // 상좌우하 (문제 조건에 따라 탐색 우선순위 지정)
        int[] dy = { 0, -1, 1, 0 };

        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((x, y, 0)); // (현재 X, 현재 Y, 이동 시간)
        bool[,] visited = new bool[size, size];
        visited[x, y] = true;

        List<(int, int, int)> eatableFish = new List<(int, int, int)>(); // (X, Y, 거리)

        while (queue.Count > 0)
        {
            var (curX, curY, dist) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int nx = curX + dx[i];
                int ny = curY + dy[i];

                if (nx >= 0 && ny >= 0 && nx < size && ny < size && !visited[nx, ny])
                {
                    if (map[nx, ny] <= growth) // 지나갈 수 있는 칸 (상어 크기 이하)
                    {
                        visited[nx, ny] = true;
                        queue.Enqueue((nx, ny, dist + 1));

                        if (map[nx, ny] > 0 && map[nx, ny] < growth) // 먹을 수 있는 물고기
                        {
                            eatableFish.Add((nx, ny, dist + 1));
                        }
                    }
                }
            }
        }

        if (eatableFish.Count > 0)
        {
            // 먹을 수 있는 물고기 중 우선순위 결정
            eatableFish = eatableFish.OrderBy(f => f.Item3).ThenBy(f => f.Item1).ThenBy(f => f.Item2).ToList();
            var (fishX, fishY, fishDist) = eatableFish[0];

            // 물고기를 먹으러 이동
            map[x, y] = 0; // 현재 위치 초기화
            map[fishX, fishY] = 0; // 물고기 먹음
            startX = fishX;
            startY = fishY;
            totalTime += fishDist;

            eatCount++;
            if (eatCount == growth) // 상어 크기 증가
            {
                growth++;
                eatCount = 0;
            }

            return 1; // 물고기를 먹었음
        }

        return 0; // 더 이상 먹을 물고기 없음
    }

    static void Main(string[] args)
    {
        size = int.Parse(Console.ReadLine());
        map = new int[size, size];
        int growth = 2; // 초기 상어 크기
        int eatCount = 0; // 먹은 물고기 수

        for (int i = 0; i < size; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < size; j++)
            {
                map[i, j] = int.Parse(input[j]);
                if (map[i, j] == 9)
                {
                    startX = i;
                    startY = j;
                    
                }
            }
        }

        while (true)
        {
            if (BFS(startX, startY, ref growth, ref eatCount) == 0) break; // 더 이상 먹을 물고기 없으면 종료
        }

        Console.WriteLine(totalTime);
    }
}
