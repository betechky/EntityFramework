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

            
           foreach (var item in customersList)
           {
               Console.WriteLine($"{item.LastName} {item.FirstName} {item.JobTitle}");
           }
           
            //Helper.Serializer.ToJson(customersList, "customers.json");
            // Helper.Serializer.ToXml(customersList, "customers.xml");
            Helper.Serializer.ToBinary(customersList.ToList(), "customers.dat");

            //FileInfo

            List<SerializedFile> fileList = new List<SerializedFile>
            {
                new SerializedFile
                {
                    Name = "customers.json",
                    Size = new FileInfo("customers.json").Length
                },
                new SerializedFile
                {
                    Name = "customers.xml",
                    Size = new FileInfo("customers.xml").Length
                },
                new SerializedFile
                {
                    Name = "customers.dat",
                    Size = new FileInfo("customers.dat").Length
                }
            };

            fileList.Sort();

            Console.WriteLine("========================================");
            foreach (var item in fileList)
            {
                Console.WriteLine($"{item.Name} has {item.Size} bytes");
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
