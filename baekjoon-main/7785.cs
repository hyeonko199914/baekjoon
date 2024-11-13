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
        
        int num1 = int.Parse(rd.ReadLine());
        HashSet<string> k = new HashSet<string>();
        
        string [] s = new string[2];
        
        for(int i = 0 ; i<num1 ; i++){
            s = rd.ReadLine().Split();
            string name = s[0];
            string ent = s[1];
            if(ent == "enter"){
                k.Add(name);
            }
            else if(ent == "leave"){
                k.Remove(name);
            }
        }
         var sort = k.OrderBy(x => x).Reverse().ToList();
        foreach(string ans in sort){
             wr.WriteLine(ans);
        }
       
        
        
        
        wr.Close();
        rd.Close();  
        }
    }
