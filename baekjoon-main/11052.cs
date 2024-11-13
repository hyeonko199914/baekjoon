using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int [] dp = new int [1001];
            int a = int.Parse(Console.ReadLine());
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            dp[1] = data[0];
            for(int i = 1 ; i<= a ; i++ ){
                dp[i] = data[i-1];
                for(int j = i; j>=1 ; j--){
                    dp[i] = Math.Max(dp[i], dp[i-j] +data[j-1]);
                }
                
            }
            Console.WriteLine(dp[a]);
        }
    }
}