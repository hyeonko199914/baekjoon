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
    static int pib(int n){
        if(n == 0 || n == 1){
            return n;
        }
        
        else{
            return pib(n-1) + pib(n-2);
        }


    }
    static void Main(string[] args){
        
        int NUM1 = int.Parse(Console.ReadLine());
		Console.WriteLine(pib(NUM1));
    }
}

            
        