using System;
using System.Linq;

namespace MyCompiler {
    class Program {
        static int[] SieveOfEratosthenes(int n) {
            bool[] primes = new bool[n + 1];
            int count = 0;

            for (int i = 2; i <= n; i++)
                primes[i] = true;

            for (int p = 2; p * p <= n; p++) {
                if (primes[p] == true) {
                    for (int i = p * p; i <= n; i += p)
                        primes[i] = false;
                }
            }

            for (int i = 2; i <= n; i++) {
                if (primes[i] == true)
                    count++;
            }

            int[] primeNumbers = new int[count];
            int index = 0;

            for (int i = 2; i <= n; i++) {
                if (primes[i] == true)
                    primeNumbers[index++] = i;
            }

            return primeNumbers;
        }
        public static void Main(string[] args) {
            int B = int.Parse(Console.ReadLine());
            int NEND = 4000000; // 종료 범위
            int[] primeNumbers = SieveOfEratosthenes(NEND);
            int len = primeNumbers.Length;
            int count = 0;
            for(int start = 0; start<len; start++){
                int sum = 0;
                int end = start;
                while(sum < B){
                    sum += primeNumbers[end];
                    end++;
                    if(end >= len) break;
                }
                if(sum ==B){
                    count++;
                }
            }
           
            Console.WriteLine(count);

            
        }
    }
}