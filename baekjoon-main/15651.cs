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
    static bool [] visit = new bool[9];
    static int [] v = new int[9];
    static int n;
    static int m;

    static void dfs(int cnt){
        if(cnt == m){
            for(int i=0; i<m; i++){
                sb.Append(v[i]).Append(' ');
            }
            sb.AppendLine();
            return;
        }
        for(int i = 1; i<=n ; i++){
            if(!visit[i]){
                
                v[cnt] = i;
                dfs(cnt + 1);
                visit[i] = false;
            }
        }
    }

    
    static void Main(string[] args){
        
        
        
        string [] s = new string[2];
        s = Console.ReadLine().Split();
        n = int.Parse(s[0]);
        m = int.Parse(s[1]);
        dfs(0);
        Console.WriteLine(sb.ToString());

        
        
        
        
        }
    }
