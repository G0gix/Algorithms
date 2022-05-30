using MyLib.Models;
using System;
using System.Collections.Generic;

namespace MyLib.Algorithm
{
    public class KnapsackAlgorithm
    {
        private readonly int backpackWeight;
        private readonly List<Product> productList;

        public KnapsackAlgorithm(int backpackWeight, List<Product> productList)
        {
            this.productList = productList;
            this.backpackWeight = backpackWeight;
        }

        #region void GetReadyBackpackGreedy Метод жадного аглоритма
        /// <summary>
        /// Метод жадного аглоритма
        /// </summary>
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
        #endregion

        #region void DynamicAnswer Поиск продуктов с помощью динамического программирования
        /// <summary>
        /// Поиск продуктов с помощью динамического программирования
        /// </summary>
        public void DynamicAnswer()
        {
            // TOFIX - При одинаковых именах продуках возникает исключение
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
                    int remainingPlace = backpackWeight - product.Weight;

                    if (remainingPlace == 1)
                    {
                        Product mostExpensiveProduct = GetMostExpensiveProductByWeight(remainingPlace);

                        if (mostExpensiveProduct == null) continue;

                        tempList.Add(product);
                        tempList.Add(mostExpensiveProduct);
                        resultProductDic.Add(product.Name, tempList);
                    }
                    else
                    {
                        int localRemainingPlace = remainingPlace;

                        while (localRemainingPlace > 0)
                        {

                            Product mostExpensiveProduct = GetMostExpensiveProductByWeight(localRemainingPlace);

                            if (mostExpensiveProduct == null)
                            {
                                localRemainingPlace--;
                                continue;
                            };

                            tempList.Add(mostExpensiveProduct);

                            localRemainingPlace--;
                        }

                        resultProductDic.Add(product.Name, tempList);
                    }
                }
            }

            (List<Product> calculatedProductList, decimal totalPrice) = CalculateFinalProductPrice(resultProductDic);

            PrintFinalProductListToConsole(calculatedProductList, totalPrice);

        }
        #endregion

        #region Product - GetMostExpensiveProductFromListByWeight Получить наиболее дорогой продукт из списка продуктов по массе
        public Product GetMostExpensiveProductByWeight(int remainingPalce)
        {
            List<Product> sameWeightProductsList = FindProductBySameWeight(remainingPalce);
            Product mostExpensiveProduct = GetExpensiveProductFromList(sameWeightProductsList);

            return mostExpensiveProduct;
        }
        #endregion

        #region List<Product> - FindProductBySameWeight Поиск продуктов по одинаковой массе
        /// <summary>
        /// Поиск продуктов по одинововой массе
        /// </summary>
        /// <returns></returns>
        private List<Product> FindProductBySameWeight(int weight)
        {
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
        public Product GetExpensiveProductFromList(List<Product> productList)
        {
            if (productList.Count == 1)
            {
                return productList[0];
            }
            else if (productList.Count == 0)
            {
                return null;
            }
            else
            {
                Product ProductWithMaxPrice = new Product();
                for (int i = 0; i < productList.Count; i++)
                {
                    if (ProductWithMaxPrice.Price <= productList[i].Price)
                    {
                        ProductWithMaxPrice = productList[i];
                    }
                }

                return ProductWithMaxPrice;
            }
        }
        #endregion

        #region (List<Product>, decimal) - CalculateFinalProductPrice Рассчитать окончательную сумму  продуктов в рюкзаке
        /// <summary>
        /// Рассчитать окончательный список продуктов в рюкзаке
        /// </summary>
        /// <returns></returns>
        public (List<Product>, decimal) CalculateFinalProductPrice(Dictionary<string, List<Product>> resultProductDic)
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

                    //TODO - Убрать добовление в List при проверке суммы. 
                    foreach (Product product in resultItem.Value)
                    {
                        finalSetOfProducts.Add(product);
                    }
                }
            }

            return (finalSetOfProducts, totalPrice);
        }
        #endregion

        #region void - PrintFinalProductListToConsole 
        public void PrintFinalProductListToConsole(List<Product> finalSetOfProducts, decimal totalPrice)
        {
            Console.WriteLine();
            Console.WriteLine($"Вместимость рюкзака - {backpackWeight}");
            Console.WriteLine("Лучшая цена: " + totalPrice);
            Console.WriteLine("Продукты для покупки:");
            for (int i = 0; i < finalSetOfProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {finalSetOfProducts[i].Name} Цена: {finalSetOfProducts[i].Price} Вес: {finalSetOfProducts[i].Weight}");
            }
        }
        #endregion
    }
}
