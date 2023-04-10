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
        static int[] data = { 6, 5, 3, 1, 8, 7, 2, 4, 9, 10, 11, 12 };

        static void Main(string[] args)
        {
            SortQuick(0, data.Length - 1);

            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
        }

        static void SortQuick(int first, int last)
        {


            //if(first < last)

            if (first < last)
            {
                int pivot = Partition(first, last);
            SortQuick(first, pivot - 1);
            SortQuick(pivot + 1, last);
            }

        }

        /// <summary>
        /// 분류..? 분할...?
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        static int Partition(int first, int last)
        {
            int low, high;
            int pivot = data[last];

            //맨 앞에 원소를 low에다 넣어준다
            low = first;
            high = last - 1;

            while (low < high)
            {
                while (data[low] < pivot)
                    low++;

                while(data[high] > pivot)
                    high--;

                if(low <= high)
                {
                    Swap(data, low, high);
                }
            }

            Swap(data, low, last);

            return low;
        }

        static void Swap(int[] data, int num1, int num2)
        {
            int temp = data[num1];
            data[num1] = data[num2];
            data[num2] = temp;
        }
    }
}