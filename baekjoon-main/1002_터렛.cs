using System;

namespace MyCompiler {
    class Program {

        public static int Intersection(int x1, int y1, int r1, int x2, int y2, int r2) {
            int distSquared = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            int rSum = r1 + r2;
            int rDiff = Math.Abs(r1 - r2);

            // 충돌 x
            if (distSquared > rSum * rSum) {
                return 0;
            }

            // 원안에 다른 원이 있을때
            if (distSquared < rDiff * rDiff) {
                return 0;
            }
            // 교점이 무한일때 -> 원이 완전히 겹쳤을때
            if (distSquared == 0 && r1 == r2) {
                return -1;
            }

            // 힌잠에서 만날떄
            if (distSquared == rSum * rSum || distSquared == rDiff * rDiff) {
                return 1;
            }

            // 두점에서 만날때
            return 2;
        }

        public static void Main(string[] args) {
            int testcase = int.Parse(Console.ReadLine());
            for (int p = 1; p <= testcase; p++) {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int x1 = input[0];
                int y1 = input[1];
                int r1 = input[2];
                int x2 = input[3];
                int y2 = input[4];
                int r2 = input[5];

                int result = Intersection(x1, y1, r1, x2, y2, r2);
                Console.WriteLine(result);
            }
        }
    }
}
