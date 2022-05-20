using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Array.Search
{
    public class Search1
    {
        public static object BinarySearchIterative(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == (inputArray[mid]))
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return null;
        }
    }
}
