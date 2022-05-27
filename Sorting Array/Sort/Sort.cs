using System;

namespace Sorting_Array.Sort
{
    internal class Sort
    {
        #region InsertionSort
        static void InsertionSort(int[] array)
        {
            Console.WriteLine("InsertionSort");
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 0) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }

            PrintArrayInConsole(array);
        }
        #endregion

        #region BubbleSort
        static void BubbleSort(int[] array)
        {
            Console.WriteLine("BubbleSort");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < (array.Length - 1); j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            PrintArrayInConsole(array);
        }

        #endregion

        #region PrintArrayInConsole
        static void PrintArrayInConsole(int[] arrayToPrint)
        {
            foreach (var item in arrayToPrint)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" ");
        }
        #endregion

        #region Swap
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        #endregion
    }
}
