using MyLib.Algorithm;
using MyLib.Models;
using Sorting_Array.Patterns;
using System;
using System.Collections.Generic;

namespace Sorting_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Test
            int[] InsertionSortArray = new int[] { 254, 12, 10, 2, 1, 8, 3, 6, 7, 50, 78, 71, 22 };
            //InsertionSort(InsertionSortArray);

            int[] BubbleSortArray = new int[] { 254, 12, 10, 2, 1, 8, 3, 6, 7, 50, 78, 71, 22 };
            BubbleSort(BubbleSortArray);

            //object searchedint =  Search1.BinarySearchIterative(BubbleSortArray,12);
            //var data = Array.BinarySearch(BubbleSortArray, 22);

            //int number =  TestClass.Sum(new int[] { 2, 4, 6 });
            //int count = TestClass.Count(new int[] { 2, 4, 6 });

            //int maxValue = Recursion.MaxValueInArray(new int[] { 2, 4, 1000, 7, 8,10,11,100 });
            string value = Recursion.ShowAllNumbers(168);
            #endregion

            #region Instance
            //var db = SingletonDatabase.Instance;
            // var city = "Tokyo";
            //Console.WriteLine($"{city}" + " " + db.GetPooulation(city));

            #endregion

            #region Algorithm 
            #region GreedyAlgorithm
            List<Product> productList = new List<Product>
            {
                new Product{Name = "Гитара", Price = 1500, Weight = 1},
                new Product{Name = "Магнитофон", Price = 3000, Weight = 4},
                new Product{Name = "Ноутбук", Price = 2000, Weight = 3},
                new Product{Name = "MP3", Price = 1000, Weight = 1},
                
                
                new Product{Name = "Монитор", Price = 2000, Weight = 4},
                new Product{Name = "Телефон", Price = 5000, Weight = 3},
            };

            KnapsackAlgorithm backpackWeightQuestion = new KnapsackAlgorithm(8, productList);
            backpackWeightQuestion.GetReadyBackpackGreedy();
            
            backpackWeightQuestion.DynamicAnswer();
            #endregion
            #endregion


            Console.ReadLine(); 
        }

        

    }
}
