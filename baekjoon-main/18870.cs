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
        
        List<int> data = new List<int>();
        Dictionary<int, int> dic = new Dictionary<int, int>();
        
        int a = int.Parse(rd.ReadLine());
        string [] s = new string[a];
        s = rd.ReadLine().Split();
        
        for(int i = 0 ; i<a ; i++){
            data.Add(int.Parse(s[i]));
        }
        
        var sort = data.Distinct().OrderBy(x => x).ToList();
        int bb = sort.Count;
        
        for(int i = 0 ; i<bb; i++){
            dic.Add(sort[i], i);
        }


        foreach (int ans in data)
            {
                wr.WriteLine(dic[ans]);

            }
        wr.Close();
        rd.Close();  
        }
    }
