namespace HeartAtackRecognition_AI.Models.PatientComponents
{
    class HistoryOfSimilarPain
    {
        bool priorChestPainOfThisType;
        bool physicianConsultedForPriorPain;
        bool priorPainRelatedToHeart;
        bool priorPainDueToML;
        bool priorPainDueToAnginaPrectoris;

        public HistoryOfSimilarPain(bool priorChestPainOfThisTypeToSet, bool physicianConsultedForPriorPainToSet, bool priorPainRelatedToHeartToSet,
        bool priorPainDueToMLToSet, bool priorPainDueToAnginaPrectorisToSet)
        {
            this.priorChestPainOfThisType = priorChestPainOfThisTypeToSet;
            this.physicianConsultedForPriorPain = physicianConsultedForPriorPainToSet;
            this.priorPainRelatedToHeart = priorPainRelatedToHeartToSet;
            this.priorPainDueToML = priorPainDueToMLToSet;
            this.priorPainDueToAnginaPrectoris = priorPainDueToAnginaPrectorisToSet;
        }
    }
}
