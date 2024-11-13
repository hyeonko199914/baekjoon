using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int [,] dp = new int [1001,1001];
            int [,] map = new int [1001,1001];
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = data[0];
            int k = data[1];
            for(int i = 0; i<n ; i++){
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for(int j = 0; j<k; j++){
                    map[i,j] = input[j];
                }
            }
            dp[0,0] = map[0,0];
            for(int i = 0 ; i < n ; i++ ){
                for(int j = 0; j < k ; j++){
                    dp[i+1,j] = Math.Max(dp[i+1,j], dp[i,j] + map[i+1,j]); 
                    dp[i,j+1] = Math.Max(dp[i,j+1], dp[i,j] + map[i,j+1]);
                    dp[i+1,j+1] = Math.Max(dp[i+1,j+1], dp[i,j] + map[i+1,j+1]);
                    }
                }
                
            
            Console.WriteLine(dp[n-1,k-1]);
        }
    }
}