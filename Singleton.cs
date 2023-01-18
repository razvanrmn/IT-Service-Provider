using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace MultiLanguage
{
    public class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();
        string fileName = @"C:\Users\razva\Desktop\MultiLanguage\loggin.txt";
        Singleton()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            else
            {
                using (FileStream fs = File.Create(fileName)) { }
            }
            Console.WriteLine("File created");
        }

        public void writeMessage(string message)
        {
            try
            {
                File.AppendAllText(fileName, message);
                File.AppendAllText(fileName, "\n");
            }
            catch
            {
                Console.WriteLine("Exception");
            }
            
        }
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}