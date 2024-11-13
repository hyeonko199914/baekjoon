using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Schema;
static class Program
{
    public static void Main(string[] args){
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        
        int A = int.Parse(sr.ReadLine());
         for(int i = 0; i < A ; i++)
        {
			string[] B = new string[10];
            B = sr.ReadLine().Split(' ');
            int NUM1 = int.Parse(B[0]);
            int NUM2 = int.Parse(B[1]);
            
            int num3 = 1;

              for (int k= 2; k<= Math.Min(NUM1,NUM2); k++){
                while(NUM1 % k == 0 && NUM2 % k ==0){
                        NUM1 = NUM1/k ;
                        NUM2 = NUM2/k ;
                        num3 = num3 * k ;
                }
                
                }
                Console.WriteLine(num3 * NUM1 * NUM2);
            }
        }
    }
