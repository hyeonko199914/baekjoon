using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int [] cardent = new int[100001];
    static int [] cardout = new int[100001];
    static bool [] exist = new bool[100001];
    static int [] cardnum = new int[100001];
    static int student;
    static int tcase;
    static void Main()
    {
        // 학생 수와 순서쌍 입력
        int[] test = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        student = test[0];
        tcase = test[1];
        

        // 순서쌍 리스트
        for (int i = 0; i < tcase; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            cardent[input[0]]++;
            cardout[input[1]]++;
        }
        for(int i = 1; i <= student;i++){
            int num = i + cardent[i] - cardout[i];
            if(exist[num] == true){
                Console.WriteLine("-1");
                return;
                
            }
            cardnum[i] = num;
            exist[num] = true;
            
        }
        for(int i = 1; i <= student;i++){
            Console.Write(cardnum[i] + " ");
            
        }
            
        }
        
}
