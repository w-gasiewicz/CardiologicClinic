namespace CardiologicClinic_WebApp.AI.Models.PatientComponents
{
    class CurrentMedicationUsage
    {
        bool diurecties;
        bool nitrates;
        bool betaBlockers;
        bool digitalis;
        bool nonsteroidalAntiInflammatory;
        bool antacidsH2Blockers;

        public CurrentMedicationUsage(bool diurectiesToSet, bool nitratesToSet, bool betaBlockersToSet, bool digitalisToSet, bool nonsteroidalAntiInflammatoryToSet,
        bool antacidsH2BlockersToSet)
        {
            this.diurecties = diurectiesToSet;
            this.nitrates = nitratesToSet;
            this.betaBlockers = betaBlockersToSet;
            this.digitalis = digitalisToSet;
            this.nonsteroidalAntiInflammatory = nonsteroidalAntiInflammatoryToSet;
            this.antacidsH2Blockers = antacidsH2BlockersToSet;
        }
    }
}
