using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Xml.Schema;
using System.ComponentModel;

static class Program{
    static void Main(string[] args){
        
        int NUM1 = int.Parse(Console.ReadLine());
		string[] A = new string[NUM1];
        int [] arr = new int[NUM1];
        int [] MAX = new int[NUM1];
        A = sr.ReadLine().Split(' ');
        
        MAX[0] = int.Parse(A[0]);
        int max22 = MAX[0];
        
        
        for(int i = 1 ; i<NUM1 ; i++){
            arr[i] = int.Parse(A[i]);
            MAX[i] = Math.Max(Max[i-1]+arr[i],arr[i]);
            max22 = Math.Max(max22,Max[i]);
             
        }
        Console.WriteLine(max22);
        }
    }