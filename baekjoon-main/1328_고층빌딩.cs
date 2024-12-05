using System;

namespace Baekjoon
{
    class Program
    {
        

        static void Main(string[] args)
        {
            long Mod = 1000000007;
            long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long N = input[0];
            long L = input[1];
            long R = input[2];
            long [,,] dp = new long[101,101,101];
            dp[1,1,1] = 1;
            for(int i = 2; i<= N; i++){
                for(int j =1 ; j<=i; j++){
                    for(int k =1; k<=i;k++){
                        dp[i,j,k] = (dp[i-1,j-1,k] + dp[i-1,j,k-1] + dp[i-1,j,k] * (i-2))% Mod ; // 왼쪽에 추가,  오른쪽에 추가, 가운데에 추가
                    }
                }
            }
          Console.WriteLine(dp[N,L,R]  );

        }
    }
}
