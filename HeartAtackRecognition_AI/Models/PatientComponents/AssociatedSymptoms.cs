namespace HeartAtackRecognition_AI.Models.PatientComponents
{
    class AssociatedSymptoms
    {
        bool nausea;
        bool diaphoresis;
        bool palpitations;
        bool dyspnea;
        bool dizziness;
        bool burping;
        int palliativeFactors;

        public AssociatedSymptoms(bool nauseaToSet, bool diaphoresisToSet, bool palpitationsToSet, bool dyspneaToSet, bool dizzinessToSet,
        bool burpingToSet, int palliativeFactorsToSet)
        {
            this.nausea = nauseaToSet;
            this.diaphoresis = diaphoresisToSet;
            this.palpitations = palpitationsToSet;
            this.dyspnea = dyspneaToSet;
            this.dizziness = dizzinessToSet;
            this.burping = burpingToSet;
            this.palliativeFactors = palliativeFactorsToSet;
        }
    }
}
