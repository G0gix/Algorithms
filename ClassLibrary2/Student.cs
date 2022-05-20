using System;

namespace MyLib
{
    public class Student
    {
        private string Name  { get; set; }

        public Student(string name)
        {
            Name = name;
        }

        public void PrintName()
        {
            Console.WriteLine(this.Name);
        }
    }
}
