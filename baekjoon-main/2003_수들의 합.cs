using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int [] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = data[0];
            int M = data[1];
            
            int [] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int len = input.Length;
            int mincount = int.MaxValue;
            int sum = 0;
            int start = 0;
            int cnt = 0;

            
            for (int end = 0; end < N; end++)
            {
                
                sum += input[end]; 
                

                // 부분합이 B 이상일 경우, 윈도우를 축소
                while (sum >= M)
                {
                    if(sum == M) cnt++;
                    mincount = Math.Min(mincount, end - start + 1); // 최소 길이 갱신
                    sum -= input[start]; // 왼쪽으로 윈도우 축소
                    start++;
                    
                }
            }

            // 결과 출력
            Console.WriteLine(cnt);
                
            
        }
    }
}