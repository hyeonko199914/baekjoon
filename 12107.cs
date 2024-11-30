using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            if(a == 1) Console.WriteLine("B");
            else Console.WriteLine("A");
            // 1빼고 A가 다 승리 
        }
    }
}