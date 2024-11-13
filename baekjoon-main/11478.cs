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
       
        
        string s = rd.ReadLine();
        int t = s.Length;
        for(int i = 1; i <= t ; i++){
            for(int j = 0 ; j <= t-i; j++) {
                
                k.Add(s.Substring(j,i));
            }
        }
       

        
        
        wr.WriteLine(k.Count);
        
       
        
        
        
        wr.Close();
        rd.Close();  
        }
    }