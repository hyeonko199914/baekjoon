using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            bool k = true;
            while (k == true){
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int a = data[0];
                int b = data[1];
                int c = data[2];
                if(a == 0 && b == 0 && c == 0) break;
                

                if(a*a + b*b == c*c || a*a + c*c == b*b || b*b + c*c == a*a) Console.WriteLine("right");
                else{
                    Console.WriteLine("wrong");
                }

                
            }
        }
    }
}