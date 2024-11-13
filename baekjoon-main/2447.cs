using System;
using System.Text;

namespace MyCompiler {
    class Program {
        static char[,] map = new char[3000, 3000];

        static void star(int n,int a){
            int c = n;
            for(int i = 0; i<a; i++){
                for(int j = 0 ; j<a; j++){
                    if((i/c) % 3 == 1 && (j/c) % 3 ==1){
                        map[i,j] = ' ';
                    }
                }
            }
           if(c>1){

             star(c/3,a);
            }


            
        }
        
       
            
            
        public static void Main(string[] args) {
            StringBuilder bd = new StringBuilder();
            
            int a = int.Parse(Console.ReadLine());
            
            for(int i = 0; i< a ; i++){
                for(int j = 0; j<a ; j++){
                    map[i,j] = '*';
                }
            }
            star(a,a);
            
            for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < a; j++)
            {
                bd.Append(map[i, j]);
            }
            bd.Append("\n");
        }
 
        Console.WriteLine(bd.ToString());
            

            
        
        }
    }
}