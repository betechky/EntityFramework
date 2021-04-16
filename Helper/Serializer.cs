using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Helper
{
    public class Serializer
    {
        public static void ToXml<T>(T obj, string path)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sw, obj);
                File.WriteAllText(path, sw.ToString());
            }
        }

        public static void ToBinary<T>(T obj, string path)
        {
            using (Stream st = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, obj);
            }
        }

        public static void ToJson<T>(T obj, string path)
        {
            String json = JsonSerializer.Serialize(obj);
            File.WriteAllText(path, json);
        }
    }
}
