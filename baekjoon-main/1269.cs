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
        
        
        HashSet<int> k = new HashSet<int>();
        HashSet<int> t = new HashSet<int>();
       
        
        string [] s = new string[2];
        s = rd.ReadLine().Split();
        int num1 = int.Parse(s[0]);
        int num2 = int.Parse(s[1]);

        string [] l = new string[2];
        l = rd.ReadLine().Split();
        string [] p = new string[2];
        p = rd.ReadLine().Split();
    

        for(int i = 0 ; i<num1 ; i++){
            k.Add(int.Parse(l[i]));
            
        }
        for(int j = 0 ; j<num2 ; j++){
            t.Add(int.Parse(p[j]));
        }
        
        int ans1 = k.Count;
        int ans2 = t.Count;
        List<int> list1 = new List<int>(k);
        List<int> list2 = new List<int>(t);
        
        for(int i = 0; i<num2 ; i++){
            if(k.Contains(list2[i])) ans1--;
        }
        for(int i = 0; i<num1 ; i++){
            if(t.Contains(list1[i])) ans2--;
        }

        
        wr.WriteLine(ans1+ans2);
        
       
        
        
        
        wr.Close();
        rd.Close();  
        }
    }