using System;
using System.Text;
using System.Linq;
namespace Solution {
  class Program {
    static void Main(string[] args) {

      var input = Console.ReadLine().Split(' ');
      var k = int.Parse(input[0]);
      var n = int.Parse(input[1]);

      var house = new int[k];
      for (int i = 0; i < k; i++)
        house[i] = int.Parse(Console.ReadLine());
      Array.Sort(house);

      var right = house[k-1]-house[0];
      int left = 1;
      int ans = 0;

      while (left <= right) {
        var mid = (left + right) / 2;
        int currenthouse = house[0];
        int cnt = 1;

        for (int i = 1; i < k; i++){
            if (house[i] - currenthouse >= mid){
                cnt++;  // 공유기 설치
                currenthouse = house[i];  // 다음 기준 집으로 갱신
            }
        }

        if (cnt >= n)
            {
                ans = mid;  // 가능한 최대 거리 갱신
                left = mid + 1;  // 더 큰 거리로 탐색
            }
            else
            {
                right = mid - 1;  // 공유기 설치 불가, 거리를 줄임
            }
      }

      Console.WriteLine(ans);

    }
  }
}