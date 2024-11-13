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
        List<(int, int)> data = new List<(int, int)>();
        
        int a = int.Parse(rd.ReadLine());
        for(int i = 0 ; i<a ; i++){
            string [] s = new string [2];
            s = rd.ReadLine().Split(' ');
            data.Add((int.Parse(s[0]),int.Parse(s[1])));
        }
        var sort = data.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
        
        for(int j = 0 ; j<a ; j++){
            wr.WriteLine($"{sort[j].Item1} {sort[j].Item2}");
        }
        wr.Close();
        rd.Close();      
    }
}