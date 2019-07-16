namespace HeartAtackRecognition_AI.Models.PatientComponents
{
    class PastMedicalHistory
    {
        bool priorML;
        bool priorAnginaPrectoris;
        bool priorAtypicalChestPain;
        bool congestiveHeartFailure;
        bool peripheralVascularDisease;
        bool hiatalHernia;
        bool hypertension;
        bool diabetes;
        bool smoker;

        public PastMedicalHistory(bool priorMLToSet, bool priorAnginaPrectorisToSet, bool priorAtypicalChestPainToSet, bool congestiveHeartFailureToSet,
        bool peripheralVascularDiseaseToSet, bool hiatalHerniaToSet, bool hypertensionToSet, bool diabetesToSet, bool smokerToSet)
        {
            this.priorML = priorMLToSet;
            this.priorAnginaPrectoris = priorAnginaPrectorisToSet;
            this.priorAtypicalChestPain = priorAtypicalChestPainToSet;
            this.congestiveHeartFailure = congestiveHeartFailureToSet;
            this.peripheralVascularDisease = peripheralVascularDiseaseToSet;
            this.hiatalHernia = hiatalHerniaToSet;
            this.diabetes = diabetesToSet;
            this.smoker = smokerToSet;
        }
    }
}
