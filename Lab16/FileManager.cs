using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab16
{
     public static class FileManager
    {
        public static void WriteToFile(string path,string info)
        {
            StreamWriter sw = new StreamWriter(path,false);
            sw.WriteLine(info);
            sw.Close();
        }
        public static string ReadFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string info = sr.ReadToEnd();
            sr.Close();
            return info;
        }
    }
}
