using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        static void f1()
        {
            FileStream fs = new FileStream(@"C:\Users\Sony\Desktop\data.xml", FileMode.Create,FileAccess.Write);
            XmlSerializer xl = new XmlSerializer(typeof(Complex));
            Complex n = new Complex(1, 2);
            try
            {
                xl.Serialize(fs, n);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        static void f2()
        {
            Complex cur = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Complex));

            StreamReader reader = new StreamReader(@"C:\Users\Sony\Desktop\data.xml");
            cur = (Complex)serializer.Deserialize(reader);
            reader.Close();
        }
        static void Main(string[] args)
        {
            //f1();
            //f2();

            Complex n = new Complex(1, 2);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\Sony\Desktop\Data.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, n);
            stream.Close();
            
            IFormatter formatter1 = new BinaryFormatter();
            Stream streamReader = new FileStream(@"C:\Users\Sony\Desktop\Data.bin", FileMode.Open, FileAccess.Read);
            Complex n1 = (Complex)formatter1.Deserialize(streamReader);
            streamReader.Close();
            
        }
    }
}
