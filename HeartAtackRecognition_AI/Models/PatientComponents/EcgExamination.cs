namespace HeartAtackRecognition_AI.Models.PatientComponents
{
    class EcgExamination
    {
        bool newQwave;
        bool anyQwave;
        bool newSTsegmentElevation;
        bool anySTsegmentElevation;
        bool newSTsegmentDepression;
        bool anySTsegmentDepression;
        bool newTwaveInversion;
        bool anyTwaveInversion;
        bool newIntraventricularConductionDefect;
        bool anyIntraventricularConductionDefect;

        public EcgExamination(bool newQwaveToSet, bool anyQwaveToSet, bool newSTsegmentElevationToSet, bool anySTsegmentElevationToSet,
        bool newSTsegmentDepressionToSet, bool anySTsegmentDepressionToSet, bool newTwaveInversionToSet, bool anyTwaveInversionToSet,
        bool newIntraventricularConductionDefectToSet, bool anyIntraventricularConductionDefectToSet)
        {
            this.newQwave = newQwaveToSet;
            this.anyQwave = anyQwaveToSet;
            this.newSTsegmentElevation = newSTsegmentElevationToSet;
            this.anySTsegmentElevation = anySTsegmentElevationToSet;
            this.newSTsegmentDepression = newSTsegmentDepressionToSet;
            this.anySTsegmentDepression = anySTsegmentDepressionToSet;
            this.newTwaveInversion = newTwaveInversionToSet;
            this.anyTwaveInversion = newTwaveInversionToSet;
            this.newIntraventricularConductionDefect = newIntraventricularConductionDefectToSet;
            this.anyIntraventricularConductionDefect = anyIntraventricularConductionDefectToSet;
        }
    }
}