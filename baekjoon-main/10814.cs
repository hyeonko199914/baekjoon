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
        List<(int, string)> data = new List<(int, string)>();
        
        int a = int.Parse(Console.ReadLine());
        for(int i = 0 ; i<a ; i++){
            string [] s = new string [2];
            s = Console.ReadLine().Split(' ');
            data.Add((int.Parse(s[0]),s[1]));
        }
        var sort = data.OrderBy(x => x.Item1).ToList();
        
        for(int j = 0 ; j<a ; j++){
            Console.WriteLine($"{sort[j].Item1} {sort[j].Item2}");
        }
               
    }
}