using System;
using System.Diagnostics;
using System.IO;

namespace CardiologicClinic_WebApp.AI
{
    public class ManagementAI
    {
        public void Predict()
        {
            string fileName = "C:/Users/FUJITSU/source/repos/CardiologicClinic_WebApp/CardiologicClinic_WebApp/AI/predict.py";
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo(@"C:/Users/FUJITSU/AppData/Local/Programs/Python/Python37/python.exe", fileName)
            };
            p.StartInfo.WorkingDirectory = "C:/Users/FUJITSU/source/repos/CardiologicClinic_WebApp/CardiologicClinic_WebApp/AI";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
            p.Close();
        }
        public void Training(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                string fileName = "C:/Users/FUJITSU/source/repos/CardiologicClinic_WebApp/CardiologicClinic_WebApp/AI/main.py";
                Process p = new Process
                {
                    StartInfo = new ProcessStartInfo(@"C:/Users/FUJITSU/AppData/Local/Programs/Python/Python37/python.exe", fileName)
                };
                p.StartInfo.WorkingDirectory = "C:/Users/FUJITSU/source/repos/CardiologicClinic_WebApp/CardiologicClinic_WebApp/AI";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                p.WaitForExit();
                p.Close();
            }
        }
        public string GetActualAcc()
        {
            string toReturn;

            using (StreamReader wr = new StreamReader("./AI/bestacc.txt"))
            {
                toReturn = wr.ReadLine();
            }
            toReturn = toReturn.Replace('.', ',');
            double conversion = Convert.ToDouble(toReturn);
            conversion = Math.Round(conversion, 2);
            toReturn = conversion.ToString();
            return toReturn;
        }
    }
}
