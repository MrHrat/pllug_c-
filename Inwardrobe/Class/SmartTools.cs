using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Inwardrobe.Class
{
    public class SmartTools
    {
        public static List<Type> typesList;

        static SmartTools()
        {
            typesList = new List<Type>();
            typesList.AddRange(Builder.LoadSelectList(typeof(Passageway)));
            typesList.AddRange(Builder.LoadSelectList(typeof(VolumetricBody)));
        }

        public static void SaveXML(object obj, string FileName = "temple.xml")
        {
            using (Stream writer = new FileStream(FileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType(), typesList.ToArray());
                serializer.Serialize(writer, obj);
            }
        }

        public static T OpenXML<T>(string FileName = "./temple.xml")
        {
            T obj;

            try
            {
                using (Stream stream = new FileStream(FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T), typesList.ToArray());
                    obj = (T)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not read file from disk. Original error: " + ex.Message);
            }

            return obj;
        }
    }
}
