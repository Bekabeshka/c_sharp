using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickHeapsort
{
    static class Heap
    {
        private static int Parent(int cur)
        {
            return (cur - 1) / 2;
        }

        private static int LeftChild(int cur)
        {
            return 2 * cur + 1;
        }

        private static int RightChild(int cur)
        {
            return 2 * cur + 2;
        }

        public static int GetTop(int[] heap)
        {
            return heap[0];
        }

        public static void Swap(int[] array, int first, int second)
        {
            array[first] = array[first] + array[second];
            array[second] = array[first] - array[second];
            array[first] = array[first] - array[second];
        }

        public static void BuildMaxHeap(int[] array, int k, int length)
        {
            int l = LeftChild(k);
            int r = RightChild(k);

            int largest = k;

            if (l < length && array[l] > array[largest])
            {
                largest = l;
            }

            if (r < length && array[r] > array[largest])
            {
                largest = r;
            }
            
            if (largest != k)
            {
                Swap(array, k, largest);

                BuildMaxHeap(array, length, largest);
            }
        }

        public static void BuildMinHeap(int[] array, int k, int length)
        {
            int l = LeftChild(k);
            int r = RightChild(k);

            int smallest = k;

            if (l < length && array[l] < array[smallest])
            {
                smallest = l;
            }

            if (r < length && array[r] < array[smallest])
            {
                smallest = r;
            }

            if (smallest != k)
            {
                Swap(array, k, smallest);

                BuildMinHeap(array, length, smallest);
            }
        }

        public static void SimpleMinSort(int[] arr)
        {
            int n = arr.Length;
            
            for (int i = n / 2 - 1; i >= 0; i--)
                BuildMinHeap(arr, arr.Length, i);

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);

                BuildMinHeap(arr, i, 0);
            }
        }

        public static void SimpleMaxSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                BuildMinHeap(arr, arr.Length, i);

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);

                BuildMinHeap(arr, i, 0);
            }
        }

        private static int SpecialLeaf(int[] arr, int begin, int end)
        {
            int i = begin + 1;

            while (i < end)
            {
                if (arr[i + 1] < (arr[i]))
                    i++;
                arr[(i + begin - 1) / 2] = arr[i];
                i = 2 * i - begin + 1;
            }

            return (i + begin) / 2;
        }

        private static void TwoLayerMaxHeap(int[] arr, int begin, int end, int k)
        {
            BuildMaxHeap(arr, begin, end);

            for (int i = begin; i <= end; i++)
            {
                int temp = arr[k];
                arr[k] = arr[begin];
                int j = SpecialLeaf(arr, begin, end);
                arr[j] = temp;
                k--;
            }
        }

        private static void TwoLayerMinHeap(int[] arr, int begin, int end, int k)
        {
            BuildMinHeap(arr, begin, end);

            for (int i = begin; i <= end; i++)
            {
                int temp = arr[k];
                arr[k] = arr[begin];
                int j = SpecialLeaf(arr, begin, end);
                arr[j] = temp;
                k++;
            }
        }

        public static void QuickHeapSort(int[] arr, int begin, int end)
        {
            if (begin < end)
            {
                int i = begin + 1, j = end;
                int pivot = arr[begin];

                while (i <= j)
                {
                    while (i <= j && arr[i] > pivot)
                        i++;

                    while (j >= i && arr[j] < pivot)
                       j--;

                    if (i <= j)
                    {
                        Swap(arr, i, j);
                        i++;
                        j--;
                    }
                };

                if (j - begin >= end - j)
                {
                    Swap(arr, begin, end - j + begin);
                    TwoLayerMinHeap(arr, j + 1, end, begin);
                    QuickHeapSort(arr, end - j + begin + 1, end);
                }
                else
                {
                    Swap(arr, begin, end - j + begin);
                    TwoLayerMaxHeap(arr, begin + 1, j, end);
                    QuickHeapSort(arr, begin + 1, 2 * begin - j - 1);
                }
            }
        }
    }
}
