using System;

namespace MyCompiler {
    class Program {

        public static void Main(string[] args) {
            int testcase = int.Parse(Console.ReadLine());
            for(int p=1 ; p<=testcase ; p++){
                int k = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());
                int [,] dp = new int [k+1,n+1];
                for(int i = 0; i<=k ; i++){
                    for(int j = 1; j<=n; j++){
                        if( i == 0) dp[i,j] = j;
                        else{
                            dp[i,j] = dp[i,j-1] + dp[i-1,j];
                        }
                    }
                }
                Console.WriteLine(dp[k,n]);
                
            }
        }
    }
}
