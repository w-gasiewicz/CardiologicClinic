using HeartAtackRecognition_AI.Models.PatientComponents;
using System.Collections.Generic;

namespace HeartAtackRecognition_AI.Models
{
     class Patient
    {
        public General general;
        public Pain pain;
        public AssociatedSymptoms associatedSymptoms;
        public HistoryOfSimilarPain historyOfSimilarPain;
        public PastMedicalHistory pastMedicalHistory;
        public CurrentMedicationUsage currentMedicationUsage;
        public PhysicalExaminations physicalExaminations;
        public EcgExamination ecgExamination;

        public Patient(General general, Pain pain, AssociatedSymptoms associatedSymptoms, HistoryOfSimilarPain historyOfSimilarPain, PastMedicalHistory pastMedicalHistory,
            CurrentMedicationUsage currentMedicationUsage, PhysicalExaminations physicalExaminations, EcgExamination ecgExamination)
        {
            this.general = general;
            this.pain = pain;
            this.associatedSymptoms = associatedSymptoms;
            this.historyOfSimilarPain = historyOfSimilarPain;
            this.pastMedicalHistory = pastMedicalHistory;
            this.currentMedicationUsage = currentMedicationUsage;
            this.physicalExaminations = physicalExaminations;
            this.ecgExamination = ecgExamination;
        }
    }
}