using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int [] dp = new int [1001];
            int a = int.Parse(Console.ReadLine());
            
            dp[1] = 1;
            dp[2] = 0;
            dp[3] = 1;
            for(int i = 4; i<= a ; i++){
                dp[i] = 1;
                if(dp[i -1] == 1 || dp[i-3] ==1 ) dp[i] = 0;
            }
            if(dp[a] == 0) Console.WriteLine("CY");
            if(dp[a] == 1) Console.WriteLine("SK");
        }
    }
}