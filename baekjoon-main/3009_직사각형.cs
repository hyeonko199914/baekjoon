using System;

namespace MyCompiler {
    class Program {
        public static void Main(string[] args) {
            int[,] points = new int[3, 2]; // 세 점의 좌표 저장

            // 입력 받기
            for (int i = 0; i < 3; i++) {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                points[i, 0] = input[0]; // x 좌표
                points[i, 1] = input[1]; // y 좌표
            }

            // 네 번째 점 계산
            int fourthX = FindUnique(points[0, 0], points[1, 0], points[2, 0]);
            int fourthY = FindUnique(points[0, 1], points[1, 1], points[2, 1]);

            Console.WriteLine($"{fourthX} {fourthY}");
        }

        // 고유한 값을 찾는 함수 (3개의 값 중 2개가 같고 1개가 다른 경우)
        static int FindUnique(int a, int b, int c) {
            if (a == b) return c; // a와 b가 같다면 c가 고유값
            if (a == c) return b; // a와 c가 같다면 b가 고유값
            return a;             // 그렇지 않다면 a가 고유값
        }
    }
}
