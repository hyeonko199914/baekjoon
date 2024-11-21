using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int N = int.Parse(Console.ReadLine());
            int [] dp = new int [31];
            dp[0] = 1;
            dp[1] = 0;
            dp[2] = 3;
            dp[3] = 0;
            dp[4] = 11;
            dp[5] = 0;
            for(int i = 6; i<=N ; i++){
               if(i%2 == 0){
                   dp[i] = 3 *dp[i-2]; 
                   for(int j = 4 ;j <= i; j = j+2){
                       dp[i] = dp[i] + 2*dp[i-j];
                   }
               } 
            }
            

            Console.WriteLine(dp[N]);
        }
    }
}
