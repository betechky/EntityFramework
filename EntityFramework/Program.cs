using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        //private static IEnumerable<object> customersList;

        static void Main(string[] args)
        {
            var context = new DbModel.northwindContext();

            var customersList = context.Customers;

            //foreach (var item in customersList)
            //{
            //    Console.WriteLine($"{item.Company}  {item.LastName} {item.FirstName} {item.City}");
            //}


            var cities = customersList.Select(c => c.City).Distinct().ToList();
            // List<string> citiesList = cities.ToList();
            cities.Sort();
            cities.Reverse();

            //foreach (var item in cities)
            //{
            //    Console.WriteLine(item);
            //}

            string joined = string.Join(", ", cities.ToArray());
            Console.WriteLine("\n======================Customer in the Cities========================== "+"\n\n" + joined);

            Console.WriteLine("What is the name of city?");


            var cityname = Console.ReadLine();
            string city = cityname;
            Console.WriteLine("====================Your Results ============================ " + "\n");
            var cusCityList = customersList.Where(c => c.City.Equals(city)).ToList(); // city == "NY"
            Console.WriteLine($"There are {cusCityList.Count()} customer in {city}");
            foreach (var c in cusCityList)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }
    }
    public class SerializedFile : IComparable<SerializedFile>
    {
        public string Name { get; set; }
        public long Size { get; set; }

        public int CompareTo([AllowNull] SerializedFile other)
        {
            return Size.CompareTo(other.Size);
        }
    }
}
