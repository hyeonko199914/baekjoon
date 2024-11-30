using System;
using System.Text;

namespace BitmaskSet
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine()); // 연산 수
            int bitSet = 0; // 비트마스킹으로 집합 표현
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < M; i++)
            {
                string[] command = Console.ReadLine().Split();
                string operation = command[0];
                int x = (command.Length > 1) ? int.Parse(command[1]) : 0;

                switch (operation)
                {
                    case "add":
                        bitSet |= (1 << (x - 1)); // x를 추가
                        break;

                    case "remove":
                        bitSet &= ~(1 << (x - 1)); // x를 제거
                        break;

                    case "check":
                        output.AppendLine(((bitSet & (1 << (x - 1))) != 0) ? "1" : "0"); // x가 있으면 1, 없으면 0
                        break;

                    case "toggle":
                        bitSet ^= (1 << (x - 1)); // x가 있으면 제거, 없으면 추가
                        break;

                    case "all":
                        bitSet = (1 << 20) - 1; // {1, 2, ..., 20}을 모두 추가
                        break;

                    case "empty":
                        bitSet = 0; // 공집합으로 설정
                        break;
                }
            }

            Console.Write(output); // 결과 출력
        }
    }
}
