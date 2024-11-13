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
    static StringBuilder sb = new StringBuilder();
    static int [,] a= new int[10,10];
    static bool [,] c= new bool[10,10];
    static bool [,] c2= new bool[10,10];
    static bool [,] c3= new bool[10,10];
    static int n = 9;
    static int square(int x, int y){
        return (x/3)*3+(y/3);
    }
    static bool go(int z){
    if (z == 81) {
        for (int i=0; i<n; i++) {
            for (int j=0; j<n; j++) {
                sb.Append(a[i,j]).Append(' ');
            }
            sb.AppendLine();
        }
        return true;
    }
    int x = z/n;
    int y = z%n;
    if (a[x,y] != 0) {
        return go(z+1);
    } else {
        for (int i=1; i<=9; i++) {
            if (c[x,i] == false && c2[y,i] == false && c3[square(x,y),i]== false) {
                c[x,i] = c2[y,i] = c3[square(x,y),i] = true;
                a[x,y] = i;
                if (go(z+1)) {
                    return true;
                }
                a[x,y] = 0;
                c[x,i] = c2[y,i] = c3[square(x,y),i] = false;
            }
        }
    }
    return false;
    }



    
    static void Main(string[] args){
        StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
        StreamReader rd = new StreamReader(Console.OpenStandardInput());
        for(int i = 0; i<n;i++){
            string [] s = new string[n];
            s= rd.ReadLine().Split(' ');
            for(int j = 0; j<n;j++){
                a[i,j] = int.Parse(s[j]);
                if(a[i,j] != 0){
                    c[i,(a[i,j])] =true;
                    c[j,(a[i,j])] =true;
                    c3[square(i,j),a[i,j]] = true;
                }
            
            }
        }
        go(0);
        wr.WriteLine(sb.ToString());
       
        wr.Close();
        rd.Close();  
        }
    }
    
