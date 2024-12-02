using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int[] homex = new int[2500]; // 최대 크기 50*50
    static int[] homey = new int[2500];
    static int[] chickenx = new int[13]; // 최대 치킨집 13
    static int[] chickeny = new int[13];
    static int homecnt = 0;
    static int chickencnt = 0;
    static int mapsize;
    static int minCityDistance = int.MaxValue;

    static void Solve(int nextchicken, List<int> selected)
    {
        // 치킨집 M개를 선택했을 때 도시 치킨 거리 계산
        if (selected.Count == nextchicken)
        {
            minCityDistance = Math.Min(minCityDistance, CalculateCityDistance(selected));
            return;
        }

        // 백트래킹으로 치킨집 조합 생성
        int start = selected.Count == 0 ? 0 : selected.Last() + 1;
        for (int i = start; i < chickencnt; i++)
        {
            selected.Add(i);
            Solve(nextchicken, selected);
            selected.RemoveAt(selected.Count - 1);
        }
    }

    static int CalculateCityDistance(List<int> selected)
    {
        int totalDistance = 0;

        for (int i = 0; i < homecnt; i++)
        {
            int minDistance = int.MaxValue;
            foreach (int idx in selected)
            {
                int distance = Math.Abs(homex[i] - chickenx[idx]) + Math.Abs(homey[i] - chickeny[idx]);
                minDistance = Math.Min(minDistance, distance);
            }
            totalDistance += minDistance;
        }

        return totalDistance;
    }

    static void Main(string[] args)
    {
        // 입력 처리
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        mapsize = input[0];
        int b = input[1];
        int[,] map = new int[mapsize, mapsize];

        for (int i = 0; i < mapsize; i++)
        {
            int[] mapinput = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int j = 0; j < mapsize; j++)
            {
                map[i, j] = mapinput[j];
                if (map[i, j] == 1)
                {
                    homex[homecnt] = i;
                    homey[homecnt] = j;
                    homecnt++;
                }
                else if (map[i, j] == 2)
                {
                    chickenx[chickencnt] = i;
                    chickeny[chickencnt] = j;
                    chickencnt++;
                }
            }
        }

        // M개의 치킨집 선택 및 도시 치킨 거리 계산
        Solve(b, new List<int>());
        Console.WriteLine(minCityDistance);
    }
}