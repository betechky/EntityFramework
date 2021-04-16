using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace JsonXml
{
    [Serializable]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Square))]
    public class Shape
    {
        [XmlElement]
        public virtual string Name { get; }
        [XmlElement]
        public virtual double Area { get; }
        [XmlElement]
        public virtual string Color { get; set; }
    }
    [Serializable]
    public class Rectangle : Shape
    {

        public double Height { set; get; }
        public double Width { set; get; }

        public override string Color { get => base.Color; set => base.Color = value; }
        public override string Name => GetType().Name;
        public override double Area => Height * Width;
    }

    [Serializable]
    public class Square : Shape
    {
        public double Size { set; get; }

        public override string Color { get => base.Color; set => base.Color = value; }
        public override double Area => Size * Size;
        public override string Name => GetType().Name;
    }
    public class Item
    {
        public string id { set; get; }
        public string label { set; get; }
    }

    public class Menu
    {
        public string header { set; get; }
        public List<Item> items { set; get; }
    }

    public class Top
    {
        public Menu menu { set; get; }

        public void Print()
        {
            Console.WriteLine(menu.header);

            foreach (var item in menu.items)
            {
                Console.WriteLine("\t");

                if (item != null)
                {
                    if (item.id != null)
                        Console.Write(" id = " + item.id);
                    if (item.label != null)
                        Console.Write(" label = " + item.label);
                }
                else
                {
                    Console.WriteLine("\t null");
                }
            }
        }
    }
    class Program
    {
        public static object JsonConvert { get; private set; }

        static void Main(string[] args)
        {

            string json = File.ReadAllText("data.json");

            // Top obj = JsonSerializer.Deserialize<Top>(json);
            // obj.Print();

            //Top obj = JsonConvert.DeserializeObject<Top>(json);
            //obj.Print();

            Console.WriteLine("\n==========================================\n");
        }

        private static void ToBinary(object customers, string v)
        {
            throw new NotImplementedException();
        }

        public static void ToBinary<T>(T obj, string path)
        {
            using (Stream st = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, obj);
            }
        }
        public static void ToXml<T>(T obj, string path)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sw, obj);
                File.WriteAllText(path, sw.ToString());
            }
        }

        public static T FromXml<T>(string path)
        {
            string xmlString = File.ReadAllText(path);
            using (StringReader sr = new StringReader(xmlString))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(sr);
            }
        }
    }
}
