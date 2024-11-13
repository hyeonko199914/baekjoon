using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace a{
    class dadas{
         
        static void ans(string context, char alp, int start, int end){
            int len = context.Length;
            int [] sum = new int[len];
            for(int i =0; i<len; i++){
                
            
                if(i == 0){
                    if(context[i] == alp){
                        sum[0] = 1;
                    }
                    else
                    sum[0] = 0;
                }
                else{
                    if(context[i] == alp){
                        sum[i] = sum[i-1] + 1;
                    }
                    else{
                        sum[i] = sum[i-1];
                    }
                    
                
               }
                if(i == len -1){
                    if(start == 0){
                        Console.WriteLine(sum[end]);
                    }
                    else{
                        Console.WriteLine(sum[end]-sum[start-1]);
                    }
                    
                    return;
                    }
            }
        }
        static void Main(){
            string a = Console.ReadLine();
            
            int cnt = int.Parse(Console.ReadLine());
            for(int i = 0; i < cnt ; i++){
                string [] arr = new string[3];
                arr = Console.ReadLine().Split(' ');
                char p = char.Parse(arr[0]);
                int m = int.Parse(arr[1]);
                int n = int.Parse(arr[2]);
                ans(a,p,m,n);
            }
        }
    }
}