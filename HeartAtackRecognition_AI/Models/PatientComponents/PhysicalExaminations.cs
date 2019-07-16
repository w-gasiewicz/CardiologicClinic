namespace HeartAtackRecognition_AI.Models.PatientComponents
{
    class PhysicalExaminations
    {
        int systolicBloodPresure;
        int diastolicBloodPresure;
        int heartRate;
        int respirationRate;
        bool rales;
        bool cyanosis;
        bool pallor;
        bool systolicMurmur;
        bool diastolicMurmur;
        bool oedema;
        bool s3Gallop;
        bool s4Gallop;
        bool chestWall;
        bool diaphoresis;

        public PhysicalExaminations(int systolicBloodPresureToSet, int diastolicBloodPresureToSet, int heartRateToSet, int respirationRateToSet, bool ralesToSet,
        bool cyanosisToSet, bool pallorToSet, bool systolicMurmurToSet, bool diastolicMurmurToSet, bool oedemaToSet, bool s3GallopToSet, bool s4GallopToSet,
        bool chestWallToSet, bool diaphoresisToSet)
        {
            this.systolicBloodPresure = systolicBloodPresureToSet;
            this.diastolicBloodPresure = diastolicBloodPresureToSet;
            this.heartRate = heartRateToSet;
            this.respirationRate = respirationRateToSet;
            this.rales = ralesToSet;
            this.cyanosis = cyanosisToSet;
            this.pallor = pallorToSet;
            this.systolicMurmur = systolicMurmurToSet;
            this.diastolicMurmur = diastolicMurmurToSet;
            this.oedema = oedemaToSet;
            this.s3Gallop = s3GallopToSet;
            this.s4Gallop = s4GallopToSet;
            this.chestWall = chestWallToSet;
            this.diaphoresis = diaphoresisToSet;
        }
    }
}
