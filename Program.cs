using System;

namespace Quick_Sort
{
    class Program
    {
        static void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Random rnd = new Random();
                array[i] = rnd.Next(50) - 10;
            }
        }

        static int[] QuickSort(int[] array, int startIndex, int finishIndex)
        {
            if (startIndex >= finishIndex)
            {
                return array;
            }

            int pivotIndex = GetPivotIndex(array, startIndex, finishIndex);

            // рекурсия с левым и правым подмассивами
            QuickSort(array, startIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, finishIndex);

            return array;
        }

        static int GetPivotIndex(int[] array, int startIndex, int finishIndex)
        {
            int pivot = startIndex - 1;

            for (int i = startIndex; i <= finishIndex; i++)
            {
                if (array[i] < array[finishIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            // перестановка опорного элемента(pivot)
            pivot++;
            Swap(ref array[pivot], ref array[finishIndex]);

            return pivot;
        }

        static void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        static void Main()
        {
            int[] arr = new int[8];

            FillArray(arr);
            Console.WriteLine($"Sorted array: {string.Join(", ", arr)}");       // вывод массива через разделитель ","
            int[] sortedArray = QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine($"Sorted array: {string.Join(", ", sortedArray)}");
        }

    }
}

