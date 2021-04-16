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
            var productList = context.Products;
            Console.WriteLine("\n\n==============Customer Listing======================\n\n");
            foreach (var item in customersList)
            {
                Console.WriteLine($"{item.LastName} {item.FirstName} {item.JobTitle}");

            }
           

            //Helper.Serializer.ToJson(customersList, "customers.json");
            // Helper.Serializer.ToXml(customersList, "customers.xml");
            //Helper.Serializer.ToBinary(customersList.ToList(), "customers.dat");
           // Helper.Serializer.ToJson(productList, "products.json");
           // Helper.Serializer.ToJson(productList, "products.xml");
            Helper.Serializer.ToBinary(productList.ToList(), "products.dat");

            // FileInfo
           
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

            Console.WriteLine("\n\n==============Product Listing======================\n\n");
            foreach (var item in productList)
            {
                Console.WriteLine($"{item.ProductCode}{item.ProductName} {item.Description}{item.QuantityPerUnit}");
            }
            List<SerializedFile> productListing = new List<SerializedFile>
            {
                new SerializedFile
                {
                    Name = "product.json",
                    Size = new FileInfo("products.json").Length
                },
                new SerializedFile
                {
                    Name = "product.xml",
                    Size = new FileInfo("products.xml").Length
                },
                new SerializedFile
                {
                    Name = "product.dat",
                    Size = new FileInfo("products.dat").Length
                }

            };
            productListing.Sort();
            Console.WriteLine("========================================");
            foreach (var item in productListing)
            {
                Console.WriteLine($"{item} has {item.Size} bytes");
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
