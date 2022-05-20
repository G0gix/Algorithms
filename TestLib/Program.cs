using MyLib;
using System;
using System.Collections.Generic;

namespace TestLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student("Петр");
            st.PrintName();

            Student st2 = new Student("Георий");
            st2.PrintName();

            Person per1 = new Person("George");
            per1.PrintName();

            int test1 =  LockalFunc.TestMethod(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
        }
    }
}
