using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            if(a>=3 && a % 2 != 0){
                Console.WriteLine("Goose");
            }
            else Console.WriteLine("Duck");
        }
    }
}