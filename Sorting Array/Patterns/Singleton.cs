using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Sorting_Array.Patterns
{
    internal class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> cities;

        private SingletonDatabase()
        {
            string path = Directory.GetCurrentDirectory() + "/Patterns/Static files/capitals.txt";
            cities = File.ReadAllLines(path, Encoding.UTF8)
                .Batch(2)
                .ToDictionary(list => list.ElementAt(0).Trim(), list => int.Parse(list.ElementAt(1)));
        }

        private static readonly Lazy<SingletonDatabase> instance =
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public int GetPooulation(string city)
        {
            return cities[city];
        }

        public static SingletonDatabase Instance = instance.Value;
    }
}
