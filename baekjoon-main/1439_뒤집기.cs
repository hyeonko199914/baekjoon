using System;

namespace MyCompiler {
    class Program {
        static void Main(string[] args) {
            string inputnum = Console.ReadLine();
            char[] input = inputnum.ToCharArray();
            int zerocnt =0;
            int onecnt = 0;
            if(input[0] == '0') {
                zerocnt++;
            } else {
                onecnt++;
            }
            for(int i = 1; i < input.Length; i++) {
                if(input[i] != input[i-1]) {
                    if(input[i] == '0') {
                        zerocnt++;
                    } else {
                        onecnt++;
                    }
                }
            }
            Console.WriteLine(Math.Min(zerocnt, onecnt));
        }
    }
}