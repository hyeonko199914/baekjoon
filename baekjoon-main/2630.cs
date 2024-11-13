using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace a{
    class dadas{
        static StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static StringBuilder std = new StringBuilder();
        static int bc = 0;
        static int wc = 0;
        

        
        static void divide(int size,int row, int col,int [,] paper){
            int now = paper[row,col];
            int ns = size/2;
            bool color = true;
            for(int i = row ; i<row + size; i++){
                for(int j = col ; j<col + size; j++){
                    if(now != paper[i,j]){
                        color = false;
                        break;
                    }
                    if(color != true) break;
                }
                
            }
            if(color == true){
                    if(now == 1 ) bc++;
                    else wc++;
                    return;
                }                
                else{
                    divide(ns,row,col,paper);
                    divide(ns,row,col+ns,paper);
                    divide(ns,row+ns,col,paper);
                    divide(ns,row+ns,col+ns,paper);
                }
        }
        
        static void Main(){
            int N = int.Parse(rd.ReadLine());
            int [,] paper = new int [N,N];
            for(int i = 0; i<N ;i++){
                int[] data = Array.ConvertAll(rd.ReadLine().Split(), int.Parse);
                for(int j = 0 ; j<N ; j++){
                    paper[i,j] = data[j];
                }
            }
            divide(N,0,0,paper);
            Console.WriteLine(wc);
            Console.WriteLine(bc);
            
            
           
            
        }
    }
}