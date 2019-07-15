using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartAtackRecognition_AI.Procedures
{
    class LoadFiles
    {
        string path = @"C:\Users\FUJITSU\source\repos\CardiologicClinic_WebApp\HeartAtackRecognition_AI\Data\inne.txt";

        public void OpenFile()
        {
            List<string> list = new List<string>();

            if(File.Exists(path))
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                        list.Add(s);
                    }
                    int x = 0;
                }
            }
        }
    }
}
