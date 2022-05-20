using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class LockalFunc
    {

        #region void - TestMethod Тестовый метод
        /// <summary>
        /// Тестовый метод
        /// </summary>
        /// <returns></returns>
        public static int TestMethod(List<int> list1, List<int> list2)
        {
            return Sum(list1);
            

            int Sum(List<int> list1)
            {
                return list1.Max();
            }
        }
        #endregion


    }
}
