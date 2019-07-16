using HeartAtackRecognition_AI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HeartAtackRecognition_AI.Procedures
{
    class LoadFiles
    {
        string path = @"C:\Users\FUJITSU\source\repos\CardiologicClinic_WebApp\HeartAtackRecognition_AI\Data\inne.txt";

        public void OpenFile()
        {
            List<string> list = new List<string>();
            String s = "";

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while ((s = sr.ReadLine()) != null)
                        list.Add(s);
                }
            }

            int numberOfDigits = list[list.Count-1].Count(c => char.IsDigit(c));

            for (int k = 0; k < numberOfDigits-1; k++)
            {
                for (int i = 0; i < list.Count; i++)//petla budujaca obiekty klientow z pobranych wczesniej danych
                {
                    s = list[i].Split('\t')[0];
                    list[i] = list[i].Remove(0, s.Length + 1);
                    Console.WriteLine(s);
                }
                Console.WriteLine("=============");
            }
            //wczytanie ostatniego dorobic

            //General general = new General();
        }
    }
}
