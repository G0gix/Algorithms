using MyLib.Models;
using System;
using System.Collections.Generic;

namespace MyLib.Algorithm
{
    public class KnapsackAlgorithm
    {
        private int backpackWeight;
        List<Product> productList;

        public KnapsackAlgorithm(int backpackWeight, List<Product> productList)
        {
            this.productList = productList;
            this.backpackWeight = backpackWeight;
        }

        public void GetReadyBackpackGreedy()
        {
            Product maxPrice = productList[0];

            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].Price > maxPrice.Price)
                {
                    maxPrice = productList[i];
                }
            }

            Console.WriteLine("Жадный алгоритм выбрал продукт с максимальной ценой: " + maxPrice.Name);
        }

        public void DynamicAnswer()
        {
            Dictionary<string, List<Product>> resultProductDic = new Dictionary<string, List<Product>>();


            foreach (Product product in productList)
            {
                List<Product> tempList = new List<Product>();
                if (product.Weight == backpackWeight)
                {
                    tempList.Add(product);
                    resultProductDic.Add(product.Name, tempList);
                }
                else if (product.Weight == 1)
                {
                    tempList.Add(product);
                    resultProductDic.Add(product.Name, tempList);
                }
                else if (product.Weight < backpackWeight)
                {
                    //оставшееся место в рюкзаке
                    int remainingPlace = backpackWeight - product.Weight;

                    //Поиск продуктов по остатку места в рюкзаке
                    List<Product> sameWidthProductsList = FindProductBySameWidth(remainingPlace);
                    Product mostExpensiveProduct = GetExpensiveProduct(sameWidthProductsList);

                    tempList.Add(product);
                    tempList.Add(mostExpensiveProduct);

                    resultProductDic.Add(product.Name, tempList);
                }
            }

            CalculateFinalProductList(resultProductDic);

            Console.WriteLine();
        }



        #region List<Product> - FindProductBySameWidth Поиск продуктов по одинаковой массе
        /// <summary>
        /// Поиск продуктов по одинововой массе
        /// </summary>
        /// <returns></returns>
        private List<Product> FindProductBySameWidth(int weight)
        {
            //продукты с одинаковым весом
            List<Product> productsWithTheSameWeightList = new List<Product>();

            foreach (Product product in productList)
            {
                if (product.Weight == weight)
                {
                    productsWithTheSameWeightList.Add(product);
                }
            }

            return productsWithTheSameWeightList;
        }
        #endregion

        #region Product - GetExpensiveProduct Поиск самого дорогово продукта в списке
        /// <summary>
        /// Поиск самого дорогово продукта в списке
        /// </summary>
        /// <returns></returns>
        public Product GetExpensiveProduct(List<Product> productList)
        {
            Product ProductWithMaxPrice = new Product();

            for (int i = 0; i < productList.Count; i++)
            {
                if (ProductWithMaxPrice.Price < productList[i].Price)
                {
                    ProductWithMaxPrice = productList[i];
                }
            }

            return ProductWithMaxPrice;
        }
        #endregion



        #region void - calculateFinalProductList Рассчитать окончательный список продуктов в рюкзаке
        /// <summary>
        /// Рассчитать окончательный список продуктов в рюкзаке
        /// </summary>
        /// <returns></returns>
        public void CalculateFinalProductList(Dictionary<string, List<Product>> resultProductDic)
        {
            List<Product> finalSetOfProducts = new List<Product>();
            decimal totalPrice = 0;

            foreach (var resultItem in resultProductDic)
            {
                decimal totalPriceOfProducts = 0;
                foreach (Product product in resultItem.Value)
                {
                    totalPriceOfProducts += product.Price;
                }

                if (totalPrice < totalPriceOfProducts)
                {
                    totalPrice = totalPriceOfProducts;

                    finalSetOfProducts.Clear();
                    foreach (Product product in resultItem.Value)
                    {
                        finalSetOfProducts.Add(product);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Лучшая цена: " + totalPrice);

            Console.WriteLine("Продукты для покупки:");
            for (int i = 0; i < finalSetOfProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {finalSetOfProducts[i].Name} Цена: {finalSetOfProducts[i].Price} Вес: {finalSetOfProducts[i].Weight}");
            }
        }
        #endregion


        private void SwapProduct(ref List<Product> productList, int i, int j)
        {
            Product temp = productList[i];
            productList[i] = productList[j];
            productList[j] = temp;
        }
    }
}
