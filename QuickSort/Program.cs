using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class QuickSort
    {
        //정렬이 필요한 int 배열
        static int[] data = { 6, 5, 3, 1, 8, 7, 2, 4, 9, 10, 11, 12, 15, 14, 13 };

        static void Main(string[] args)
        {
            //전체 범위 탐색 시작
            Sort(0, data.Length - 1);

            //정렬이 끝난 뒤 출력
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
        }

        /// <summary>
        /// 퀵 정렬 해주는 함수
        /// </summary>
        /// <param name="first">정렬 시작할 부분(앞 부분)</param>
        /// <param name="last">정렬 끝나는 부분(마지막 부분)</param>
        /// <returns></returns>
        static void Sort(int first, int last)
        {
            //앞부분이 마지막부분보다 같거나 크다면 정렬이 끝난 것이기 때문에 정렬 종료
            if (first >= last)
                return;

            //탐색을 앞에서 시작할 부분은 low, (+1 해주는 이유는 피봇을 제외하기 위해)
            //탐색을 뒤에서 시작할 부분은 high
            int low = first + 1, high = last;

            //뒷 탐색 부분이 앞 탐색 부분보다 크거나 같을때
            while (low <= high)
            {
                //앞 탐색 부분이 마지막 부분(탐색 X)보다 크거나 같고
                //앞 탐색 부분 값이 피봇 부분 값보다 작거나 같을 때
                while (low <= last && data[low] <= data[first])
                    //앞 탐색 부분 1칸 앞으로
                    low++;
                
                //뒷 탐색 부분이 피봇 부분보다 크면서
                //뒷 탐색 부분이 피봇 부분의 값보다 크거나 같을 때
                while (high > first && data[high] >= data[first])
                    //뒷 탐색 부분 1칸 뒤로
                    high--;

                //앞 탐색 부분이 뒷 탐색 부분보다 크다면 (교차 되었을 때)
                if (low > high)
                {
                    //빈곳에 앞보다 작은 뒷 탐색 부분의 값을 넣는다
                    int temp = data[high];
                    //뒷 탐색 부분에 피봇을 넣는다
                    data[high] = data[first];
                    //피봇 부분에 뒷 탐색 부분의 값을 넣는다
                    data[first] = temp;
                }
                //피봇보다 더 작은 부분, 큰 부분을 찾으면 서로 바꿔준다
                else
                {
                    //빈 곳에 뒷 탐색 부분의 값을 넣는다
                    int temp = data[low];
                    //뒷 탐색 부분에 앞 탐색 부분의 값을 넣는다
                    data[low] = data[high];
                    //앞 탐색 부분에 뒷 탐색 부분의 값을 넣는다
                    data[high] = temp;
                }
            }

            //확실해진 피봇을 기준으로 앞 뒤로 짜르고 분할 시키는 기능

            //피봇 부분 부터 뒷 탐색 부분 - 1 (-1 하는 이유는 뒷 탐색 부분이 끝났기 때문이다)
            Sort(first, high - 1);
            //뒷 탐색 부분 + 1(+1 하는 이유는 뒷 탐색 부분이 끝났기 때문이다)부터 마지막 부분
            Sort(high + 1, last);

        }
    }
}