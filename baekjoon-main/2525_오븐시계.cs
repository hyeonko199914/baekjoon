using System;

namespace MyCompiler {
    class Program {

        public static void Main(string[] args) {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int hour = data[0];
            int minute = data[1];

            int plus = int.Parse(Console.ReadLine());
            int ph = (minute+plus) / 60;
            int pm = (minute + plus) %60;

            int newhour = (hour + ph) %24;


            Console.WriteLine(newhour + " " + pm);
        }
    }
}
