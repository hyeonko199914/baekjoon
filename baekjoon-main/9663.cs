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
    static int [] v = new int[15];
    static int m;
    static int count = 0;
    static bool cco(int cnt){
        for (int i = 0; i < cnt; i++) {
		if (v[cnt] == v[i] || cnt - i == Math.Abs(v[cnt] - v[i])) {
			return false;
		}
	}
	return true;
        
    }

    static void dfs(int cnt){
        if(cnt == m){
            count++;
            return;
        }
        for(int i = 0; i<m ; i++){
                v[cnt] = i;
                
                if(cco(cnt)){
                    dfs(cnt+1);
                }
            
        }
    }

    
    static void Main(string[] args){
        
        m = int.Parse(Console.ReadLine());
        dfs(0);
        Console.WriteLine(count);
        
        

        
        
        
        
        }
    }
