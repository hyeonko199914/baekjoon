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
        StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
        StreamReader rd = new StreamReader(Console.OpenStandardInput());
        
        
        HashSet<string> k = new HashSet<string>();
        
        string [] s = new string[4];
        s = rd.ReadLine().Split();
        int num1 = int.Parse(s[0]);
        int num2 = int.Parse(s[1]);
        
        for(int i = 0 ; i<num1 ; i++){
            k.Add(rd.ReadLine());
        }
        
        int cnt = 0;
        for(int j = 0; j<num2 ; j++){
            if (k.Contains(rd.ReadLine()))
                {
                    cnt = cnt+1;
                }
        }
        wr.WriteLine(cnt);
        
        
        
        wr.Close();
        rd.Close();  
        }
    }
