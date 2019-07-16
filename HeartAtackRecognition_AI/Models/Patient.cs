using HeartAtackRecognition_AI.Models.PatientComponents;

namespace HeartAtackRecognition_AI.Models
{
    class Patient
    {
        private void SetBoolValue(bool value, bool valueToSet)
        {
            if (value)
                valueToSet = true;
            else
                valueToSet = false;
        }
        public Patient(General general, Pain pain,AssociatedSymptoms associatedSymptoms, HistoryOfSimilarPain historyOfSimilarPain, PastMedicalHistory pastMedicalHistory, CurrentMedicationUsage currentMedicationUsage, PhysicalExaminations physicalExaminations, EcgExamination ecgExamination)
        {

        }
    }
}
