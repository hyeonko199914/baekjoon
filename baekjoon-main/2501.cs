using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = data[0]; 
            int k = data[1];
            int [] div = new int [10001];
            int cnt = 0;

            for(int i =1 ; i<=n ; i++){
                if(n % i == 0){
                    cnt++;
                    div[cnt] = i;
                }    
            }
            Console.WriteLine(div[k]);
            
        }
    }
}
