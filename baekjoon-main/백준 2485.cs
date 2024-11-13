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

    static int gcd1= 0;
    static int gcd(int a, int b){
     int R;
     while(b != 0){
        R = a % b;
        a = b;
        b = R;
     }
     gcd1 = a;
       return gcd1;
   }

    static void Main(string[] args){
        
        int NUM1 = int.Parse(Console.ReadLine());
        

        int [] cost = new int[NUM1];
        int [] interval = new int[NUM1-1];

        for(int i = 0 ; i<NUM1; i++){
          cost[i] = int.Parse(Console.ReadLine());
        }
        for(int j=0 ; j<NUM1-1;j++){
            interval[j] = cost[j+1] - cost[j]; 
        }
        int Inter = interval[0];
        for(int k=0; k<NUM1-2;k++){
            gcd(Inter,interval[k+1]);
            Inter = gcd1;
        }
        int answer = 0;
        for (int p = 0; p<NUM1-1;p++){
            answer += (interval[p]-Inter)/Inter;
        }
        Console.WriteLine(answer);
       
        
    }
}