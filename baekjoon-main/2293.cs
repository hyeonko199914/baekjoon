using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = data[0];
            int k = data[1];
            int[] coin = new int[n];
            
            for(int i = 0; i < n; i++){
                coin[i] = int.Parse(Console.ReadLine());
            }
            
            Array.Sort(coin);
            Array.Reverse(coin);

            
            int[] dp = new int[k + 1];
            dp[0] = 1;
            
            foreach(int c in coin){
                for(int i = c; i <= k; i++){
                    dp[i] += dp[i - c];
                }
            }

            Console.WriteLine(dp[k]);
        }
    }
}