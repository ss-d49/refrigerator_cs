using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace refrigerator
{
    public class ObjectIO
    {
        public static void WriteObjectToFile(Object serObj, String filepath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream objectOut = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(objectOut, serObj);
            objectOut.Close();
            Console.WriteLine("The Object  was successfully written to a file");
        }

        public static Object ReadObjectFromFile(String filepath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream objectIn = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Object obj = formatter.Deserialize(objectIn);
            objectIn.Close();
            return obj;
        }
    }
}