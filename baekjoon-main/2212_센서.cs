using System;
using System.Linq;

namespace MyCompiler {
    class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());  
            int k = int.Parse(Console.ReadLine());
            int [] list = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(list);
            int [] diff = new int[n-1];
            for(int i = 0; i < n-1; i++) {
                diff[i] = list[i+1] - list[i];
            }
            Array.Sort(diff);
            int result = 0;
            for(int i = 0; i < n-k; i++) {
                result += diff[i];
            }
            Console.WriteLine(result);
    }
}