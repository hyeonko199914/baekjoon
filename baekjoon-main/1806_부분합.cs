using System;
using System.Linq;

namespace MyCompiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            // 입력 처리
            int[] condi = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int B = condi[1];
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int len = data.Length;
            int mincount = int.MaxValue;
            int sum = 0;
            int start = 0;

            // 슬라이딩 윈도우 사용
            for (int end = 0; end < len; end++)
            {
                sum += data[end]; // 오른쪽으로 윈도우 확장

                // 부분합이 B 이상일 경우, 윈도우를 축소
                while (sum >= B)
                {
                    mincount = Math.Min(mincount, end - start + 1); // 최소 길이 갱신
                    sum -= data[start]; // 왼쪽으로 윈도우 축소
                    start++;
                }
            }

            // 결과 출력
            Console.WriteLine(mincount == int.MaxValue ? 0 : mincount);
        }
    }
}
