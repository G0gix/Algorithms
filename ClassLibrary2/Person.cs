using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Person
    {
        private string Name { get; set; }

        public Person(string name)
        {
           this.Name = name;
        }

        #region void - PrintName 
        /// <summary>
        /// PrintName 
        /// </summary>
        /// <returns></returns>
        public void PrintName()
        {
            Console.WriteLine(Name);

        }
        #endregion
    }
}
