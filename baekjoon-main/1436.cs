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
        
        int s = int.Parse(rd.ReadLine());
        int cnt = 1;
        int num = 666;
        

        while(cnt != s){
            num++;
            if(Convert.ToString(num).Contains("666")){
                cnt++;
            }
            
        }
    
            wr.WriteLine(num);

       
        
        
        wr.Close();
        rd.Close();  
        }
    }