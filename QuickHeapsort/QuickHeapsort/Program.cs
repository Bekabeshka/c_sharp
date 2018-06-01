using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickHeapsort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 43, 17, 4, 3, 47, 76, 54, 101, 1111, 123, 3, -4 };

            Heap.QuickHeapSort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            Console.ReadKey();
        }
    }
}
