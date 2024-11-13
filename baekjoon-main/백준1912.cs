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
		string[] A = new string[NUM1];
        int [] arr = new int[NUM1];
        int [] DP = new int[NUM1];
        A = Console.ReadLine().Split(' ');
        
        DP[0] = int.Parse(A[0]);
        int max22 = DP[0];
        
        
        for(int i = 1 ; i<NUM1 ; i++){
            arr[i] = int.Parse(A[i]);
            DP[i] = Math.Max(DP[i-1]+arr[i],arr[i]);
            max22 = Math.Max(max22,DP[i]);
             
        }
        Console.WriteLine(max22);
        }
    }

            
        