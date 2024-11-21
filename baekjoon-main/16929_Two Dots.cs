using System;

namespace MyCompiler
{
    class Program
    {
        static int M;
        static int N;
        static char[,] map;
        static bool[,] visited;

        static void Solve(int x, int y, char color, int startX, int startY, int count)
        {
            // 경계 조건: 배열 범위를 초과하거나 이미 방문한 경우
            if (x < 0 || y < 0 || x >= M || y >= N || visited[x, y] || map[x, y] != color)
                return;

            // 방문 처리
            visited[x, y] = true;
            count++;

            // 방향 배열
            int[] dirX = { 0, 1, 0, -1 };
            int[] dirY = { 1, 0, -1, 0 };

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dirX[i];
                int ny = y + dirY[i];

                // 경로를 완성한 경우
                if (nx == startX && ny == startY && count >= 4)
                {
                    Console.WriteLine("Yes");
                    Environment.Exit(0); // 프로그램 종료
                }

                Solve(nx, ny, color, startX, startY, count);
            }

            // 백트래킹: 방문 취소
            visited[x, y] = false;
        }

        public static void Main(string[] args)
        {
            // 입력 처리
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            M = input[0];
            N = input[1];
            map = new char[M, N];
            visited = new bool[M, N];

            for (int i = 0; i < M; i++)
            {
                char[] temp = Console.ReadLine().ToCharArray();
                for (int j = 0; j < N; j++)
                {
                    map[i, j] = temp[j];
                }
            }

            // 모든 좌표에서 탐색 시작
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Array.Clear(visited, 0, visited.Length); // 방문 배열 초기화
                    Solve(i, j, map[i, j], i, j, 0);
                }
            }

            // 경로가 없는 경우
            Console.WriteLine("No");
        }
    }
}
