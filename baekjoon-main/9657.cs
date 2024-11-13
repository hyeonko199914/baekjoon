using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int [] dp = new int [1001];
            int a = int.Parse(Console.ReadLine());
            
            dp[1] = 1;
            dp[2] = 0;
            dp[3] = 1;
            dp[4] = 1;
            dp[5] = 1;
            for(int i = 6; i<= a ; i++){
                dp[i] = 0;
                if(dp[i -1] == 0 || dp[i-3] ==0 || dp[i-4] == 0 ) dp[i] = 1;
            }
            if(dp[a] == 0) Console.WriteLine("CY");
            if(dp[a] == 1) Console.WriteLine("SK");
        }
    }
}