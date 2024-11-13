using System;
using System.Linq;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int[] condi = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int B = condi[1];
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int len = data.Length;
            int mincount = 99999;
            for(int start = 0; start<len; start++){
                int sum = 0;
                int count = 0;
                int end = start;
                while(sum < B){
                    sum += data[end];
                    count++;
                    end++;
                    if(end >= len) break;
                }
                if(sum >=B){
                    mincount = Math.Min(mincount,count);
                }
            }
            if(mincount == 99999){
                mincount = 0;
            }
            Console.WriteLine(mincount);

            
        }
    }
}