using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
                int testcase = int.Parse(Console.ReadLine());
               for(int i = 0; i<testcase ; i++){
                   int [] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                   int a = input[0];
                   int b = input[1];
                   int m = Math.Min(a,b);
                   bool check = false;
                   int result = 0;
                   while (check == false){
                      if(m % a == m % b){
                        result = m;
                        check = true;
                           
                       }
                       m++;
                   }
                   Console.WriteLine(result);
                   
                   }
        }
    }
}