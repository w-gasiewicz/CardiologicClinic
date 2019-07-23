namespace CardiologicClinic_WebApp.AI.Models.PatientComponents
{
    class Pain
    {
        int painLocation;
        int chestPainRadiation;
        int painCharacter;
        int onsetOfPain;
        int numberOfHoursSinceOnset;
        int durationOfTheLastEpisode;

        public Pain(int painLocationToSet, int chestPainRadiationToSet, int painCharacterToSet, int onsetOfPainToSet, int numberOfHoursSinceOnsetToSet, int durationOfTheLastEpisodeToSet)
        {
            this.painLocation = painLocationToSet;
            this.chestPainRadiation = chestPainRadiationToSet;
            this.painCharacter = painCharacterToSet;
            this.onsetOfPain = onsetOfPainToSet;
            this.numberOfHoursSinceOnset = numberOfHoursSinceOnsetToSet;
            this.durationOfTheLastEpisode = durationOfTheLastEpisodeToSet;
        }
    }
}
