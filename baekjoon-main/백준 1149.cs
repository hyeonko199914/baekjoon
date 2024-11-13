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
    static int [,] colorcost;
    static int [,] totalcost;

    static void cost(int count){
        if(count == 0){
            totalcost[count,0] = colorcost[count,0];
            totalcost[count,1] = colorcost[count,1];
            totalcost[count,2] = colorcost[count,2];
        }
        else{
            totalcost[count,0] = Math.Min(totalcost[count-1,1],totalcost[count-1,2]) + colorcost[count,0];
            totalcost[count,1] = Math.Min(totalcost[count-1,0],totalcost[count-1,2]) + colorcost[count,1];
            totalcost[count,2] = Math.Min(totalcost[count-1,0],totalcost[count-1,1]) + colorcost[count,2];
        }

    }
    static void Main(string[] args){
        
        int NUM1 = int.Parse(Console.ReadLine());

        colorcost = new int[NUM1,3];
        totalcost = new int[NUM1,3];

        for(int i = 0 ; i<NUM1; i++){
          string[] A = new string[3];
          A = Console.ReadLine().Split(' ');
          colorcost[i,0] = int.Parse(A[0]);
          colorcost[i,1] = int.Parse(A[1]);
          colorcost[i,2] = int.Parse(A[2]);
          cost(i);
        }
        Console.WriteLine(Math.Min(totalcost[NUM1-1,0],Math.Min(totalcost[NUM1-1,1],totalcost[NUM1-1,2])));
		
        
        
    }
}