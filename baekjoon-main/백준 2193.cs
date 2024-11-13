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
        
        int NUM1 = int.Parse(Console.ReadLine());
        long [,] dp = new long[NUM1+1,2];
        dp[0,0] = 1;
        dp[1,0] = 1;
        for(int i = 2; i<NUM1; i++){
            if(dp[i-1,0] >= 1){
                dp[i,0] += dp[i-1,0];
                dp[i,1] += dp[i-1,0];
            }
            if(dp[i-1,1] >= 1){
                dp[i,0] += dp[i-1,1];
            }
        }
        Console.WriteLine(dp[NUM1,0]+ dp[NUM1,1]);
       
        
    }
}