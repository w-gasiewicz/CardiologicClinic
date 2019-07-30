using CardiologicClinic_WebApp.AI.Models;
using CardiologicClinic_WebApp.AI.Models.PatientComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CardiologicClinic_WebApp.AI.Procedures
{
    public class LoadFiles
    {
        private string path = @"C:\Users\FUJITSU\source\repos\CardiologicClinic_WebApp\CardiologicClinic_WebApp\HeartData\inne.txt";
        List<Patient> patientsList = new List<Patient>();
        private Patient patient;
        public bool loadingStatus=false;

        private bool SetBoolValue(int value)
        {
            if (value == 1)
                return true;
            else
                return false;
        }

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

            int numberOfRecords = list[list.Count - 1].Count(c => char.IsDigit(c));
            Console.WriteLine("Data loading started!");
            for (int k = 0; k < numberOfRecords - 1; k++)
            {
                for (int i = 0; i < list.Count; i++)//petla budujaca obiekty klientow z pobranych wczesniej danych
                {
                    General general = new General(Convert.ToInt32(list[0].Split('\t')[0]), SetBoolValue(Convert.ToInt32(list[1].Split('\t')[0])));
                    Pain pain = new Pain(Convert.ToInt32(list[2].Split('\t')[0]), Convert.ToInt32(list[3].Split('\t')[0]), Convert.ToInt32(list[4].Split('\t')[0]),
                        Convert.ToInt32(list[5].Split('\t')[0]), Convert.ToInt32(list[6].Split('\t')[0]), Convert.ToInt32(list[7].Split('\t')[0]));
                    AssociatedSymptoms associatedSymptoms = new AssociatedSymptoms(SetBoolValue(Convert.ToInt32(list[8].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[9].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[10].Split('\t')[0])),
                        SetBoolValue(Convert.ToInt32(list[11].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[12].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[13].Split('\t')[0])), Convert.ToInt32(list[14].Split('\t')[0]));
                    HistoryOfSimilarPain historyOfSimilarPain = new HistoryOfSimilarPain(SetBoolValue(Convert.ToInt32(list[15].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[16].Split('\t')[0])),
                        SetBoolValue(Convert.ToInt32(list[17].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[18].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[19].Split('\t')[0])));
                    PastMedicalHistory pastMedicalHistory = new PastMedicalHistory(SetBoolValue(Convert.ToInt32(list[20].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[21].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[22].Split('\t')[0])),
                        SetBoolValue(Convert.ToInt32(list[23].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[24].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[25].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[26].Split('\t')[0])),
                        SetBoolValue(Convert.ToInt32(list[27].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[28].Split('\t')[0])));
                    CurrentMedicationUsage currentMedicationUsage = new CurrentMedicationUsage(SetBoolValue(Convert.ToInt32(list[29].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[30].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[31].Split('\t')[0])),
                        SetBoolValue(Convert.ToInt32(list[32].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[33].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[34].Split('\t')[0])));
                    PhysicalExaminations physicalExaminations = new PhysicalExaminations(Convert.ToInt32(list[35].Split('\t')[0]), Convert.ToInt32(list[36].Split('\t')[0]), Convert.ToInt32(list[37].Split('\t')[0]), Convert.ToInt32(list[38].Split('\t')[0]),
                        SetBoolValue(Convert.ToInt32(list[39].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[40].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[41].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[42].Split('\t')[0])),
                        SetBoolValue(Convert.ToInt32(list[43].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[44].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[45].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[46].Split('\t')[0])),
                        SetBoolValue(Convert.ToInt32(list[47].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[48].Split('\t')[0])));
                    EcgExamination ecgExamination = new EcgExamination(SetBoolValue(Convert.ToInt32(list[49].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[50].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[51].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[52].Split('\t')[0])),
                         SetBoolValue(Convert.ToInt32(list[53].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[54].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[55].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[56].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[57].Split('\t')[0])), SetBoolValue(Convert.ToInt32(list[58].Split('\t')[0])));

                    patient = new Patient(general, pain, associatedSymptoms, historyOfSimilarPain, pastMedicalHistory, currentMedicationUsage, physicalExaminations, ecgExamination);

                    s = list[i].Split('\t')[0];
                    list[i] = list[i].Remove(0, s.Length + 1);
                    patientsList.Add(patient);
                }
            }
            Console.WriteLine("Data loaded!");
            loadingStatus = true;
        }
    }
}

