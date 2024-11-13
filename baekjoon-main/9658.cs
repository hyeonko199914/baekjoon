using System;
using System.Text;
using System.Linq;
namespace Solution {
  class Program {
    static void Main(string[] args) {

      var k = int.Parse(Console.ReadLine());
      int [] dp = new int [1001];
      dp[1] = 0;
      dp[2] = 1;
      dp[3] = 0;
      dp[4] = 1;
      for(int i = 5; i<=k; i++){
          dp[i] = 0;
          if (dp[i-1] == 0 || dp[i-3] == 0 || dp[i-4] == 0) dp[i] = 1;
          
      }
        if(dp[k] == 1) Console.WriteLine("SK");
        if(dp[k] == 0) Console.WriteLine("CY");
        
        
  }
}
}