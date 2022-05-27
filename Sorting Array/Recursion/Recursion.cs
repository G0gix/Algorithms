using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Array
{
    public class Recursion
    {
        public static int Sum(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            else
            {
                int testArray = array[0] + Sum(array.Skip(1).ToArray());
                return testArray;
            }
        }

        public static int Count(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            else
            {
                var data = array.Skip(1).ToArray();
                return 1 + Count(array.Skip(1).ToArray());  
            }
        }
        
        public static int MaxValueInArray(int[] array)
        {
            if (array.Length == 2)
            {
                if (array[0] > array[1])
                {
                    return array[0];
                }
                else
                {
                    return array[1];
                };
            }
            else
            {
                int maxValue =  MaxValueInArray(array.Skip(1).ToArray());
                if (maxValue > array[0])
                {
                    return maxValue;
                }
                else
                {
                    return array[0];
                }
            }            
            
        }



        #region string - ShowAllNumbers Выведите все его цифры по одной, в обычном порядке, разделяя их пробелами или новыми строками.
        /// <summary>
        /// Выведите все его цифры по одной, в обычном порядке, разделяя их пробелами или новыми строками.
        /// </summary>
        /// <returns></returns>
        public static string ShowAllNumbers(int number)
        {
            if (number < 10)
            {
                return number.ToString();
            }
            else
            {
                Console.WriteLine(number % 10 + " ");
                return ShowAllNumbers(number / 10);
            }

        }
        #endregion


    }
}
