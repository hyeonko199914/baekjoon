using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int [,] dp = new int [1001,1001];
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = data[0];
            int k = data[1];
            dp[0,0] = 1;
            for(int i = 1 ; i<= n ; i++ ){
                dp[i,0] = 1;
                for(int j = 0; j<=k ; j++){
                    if(j == 0) dp[i,j] = 1;
                    else{
                        dp[i,j] = dp[i-1,j] + dp[i-1,j-1];
                        dp[i,j] %= 10007;
                    }
                }
                
            }
            Console.WriteLine(dp[n,k]);
        }
    }
}