using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.ComponentModel;

static class Program{

    static void Main(string[] args){
        
        string[] A = new string[3];
        A = Console.ReadLine().Split(' ');
        int count = int.Parse(A[0]);
        int test = int.Parse(A[1]);
        string[] B = new string[count];
        B = Console.ReadLine().Split(' ');
        long [] list = new long[count];
        for(int j =0;j<count;j++){
            if(j==0){
                list[0] = int.Parse(B[0]);
            }
            else{
                list[j] = list [j-1] + int.Parse(B[j]);
            }
        }
        for(int i =0; i<test; i++){
            string[] C = new string[3];
            C = Console.ReadLine().Split(' ');
            int NUM1 = int.Parse(C[0]);
            int NUM2 = int.Parse(C[1]);
            long sum = 0;
            if(NUM1 == 1){
                sum = list[NUM2-1];
            }
            sum = list[NUM2-1] -list[NUM1-2];

            Console.WriteLine(sum);
            
        }
        
    }
}