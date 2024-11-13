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
        HashSet<string> t = new HashSet<string>();
        
        string [] s = new string[2];
        s = rd.ReadLine().Split();
        int num1 = int.Parse(s[0]);
        int num2 = int.Parse(s[1]);
        int cnt = 0;
        for(int i = 0 ; i<num1 ; i++){
            k.Add(rd.ReadLine());
            
        }
        for(int j = 0 ; j<num2 ; j++){
            string name1 = rd.ReadLine();
            if(k.Contains(name1)){
                cnt++;
                t.Add(name1);
            }
        }

        
         var sort = t.OrderBy(x => x).ToList();
        wr.WriteLine(cnt);
        foreach(string ans in sort){
             wr.WriteLine(ans);
        }
       
        
        
        
        wr.Close();
        rd.Close();  
        }
    }
