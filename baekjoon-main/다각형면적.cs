using System;

namespace MyCompiler {
    class Program {
        static double calc(double[,] point, int a) {
            double sum = 0;

            // 다각형 면적 계산 (Shoelace 공식)
            for (int i = 0; i < a; i++) {
                double x1 = point[i, 0];
                double y1 = point[i, 1];
                double x2 = point[(i + 1) % a, 0]; 
                double y2 = point[(i + 1) % a, 1];

                sum += (x1 * y2) - (y1 * x2);
            }

            return Math.Abs(sum) / 2.0; // 면적의 절댓값 반환
        }

        public static void Main(string[] args) {
            
            int a = int.Parse(Console.ReadLine());
            double[,] point = new double[a, 2];

            
            for (int i = 0; i < a; i++) {
                double[] input = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
                point[i, 0] = input[0];
                point[i, 1] = input[1];
            }

            // 면적 계산 및 출력 (소수점 첫째 자리까지)
            Console.WriteLine(calc(point, a).ToString("F1"));
        }
    }
}
