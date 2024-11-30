using System;
using System.Collections.Generic;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = data[0];
            int M = data[1];

            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int sum = 0;
            int max = 0;
            Dictionary<int, int> countMap = new Dictionary<int, int>();

            // 초기 구간 합 계산
            for (int i = 0; i < M; i++) {
                sum += input[i];
            }

            // 초기 값 처리
            max = sum;
            countMap[sum] = 1;

            // 슬라이딩 윈도우로 구간 합 갱신
            for (int end = M; end < N; end++) {
                sum += input[end] - input[end - M]; 

                if (!countMap.ContainsKey(sum)) {
                    countMap[sum] = 0;
                }
                countMap[sum]++;
                max = Math.Max(max, sum);
            }
            if(max == 0){
                Console.WriteLine("SAD");
            }
            else{
                Console.WriteLine(max);
                Console.WriteLine(countMap[max]);
            }

            
            
        }
    }
}
