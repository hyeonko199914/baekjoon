using System;
using System.Collections.Generic;
using System.Linq;

class CSharpTest
{
    static int[,] map;
    static bool[,] isVisited;
    static int m, n, q;
    static Queue<int[]> myQueue = new Queue<int[]>();
    static int[] dirX = new int[] { 1, 0, -1, 0 };
    static int[] dirY = new int[] { 0, 1, 0, -1 };
    static int cnt;

    static void Bfs()
    {
        while (myQueue.Count != 0)
        {
            int[] target = myQueue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int newX = target[0] + dirX[i];
                int newY = target[1] + dirY[i];

                if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                {
                    if (map[newX, newY] == 1 && isVisited[newX, newY] == false)
                    {
                        myQueue.Enqueue(new int[] { newX, newY });
                        isVisited[newX, newY] = true;
                    }
                }
            }
        }
        if(myQueue.Count == 0) cnt++;
        
    }

    static void Main()
    {
        int A = int.Parse(Console.ReadLine());
        
        for(int t = 0 ; t<A ; t++){
            cnt = 0;
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        m = input[0];
        n = input[1];
        q = input[2];
        map = new int[m, n];
        isVisited = new bool[m, n];

        for (int i = 0; i < m; i++)
        {

            for (int j = 0; j < n; j++)
            {
                map[i, j] = 0;
            }
        }
        for(int i = 0; i<q ;i++){
            int[] ve = Console.ReadLine().Split().Select(int.Parse).ToArray();
            map[ve[0],ve[1]] = 1;
                      
        }
        for(int i = 0; i<m ;i++){
                for(int j = 0; j<n; j++){
                    if(map[i,j] == 1 && isVisited[i,j] != true){
                       myQueue.Enqueue(new int[] { i, j});
                       isVisited[i, j] = true;
                       Bfs(); 
                }           
            }
        }
        Console.WriteLine(cnt);
        
    }
}
}