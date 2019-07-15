using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartAtackRecognition_AI.Models
{
    class Patient
    {
        //general
        int age;
        bool sex;
        //pain
        int painLocation;
        int chestPainRadiation;
        int painCharacter;
        int onsetOfPain;
        int numberOfHoursSinceOnset;
        int durationOfTheLastEpisode;
        //associated symptoms
        bool nausea;
        bool diaphoresis;
        bool palpitations;
        bool dyspnea;
        bool dizziness;
        bool burping;
        int palliativeFactors;
        //history of similar pain
        bool priorChestPainOfThisType;//0|1
        bool physicianConsultedForPriorPain;//0|1
        bool priorPainRelatedToHeart;
        bool priorPainDueToML;
        bool priorPainDueToAnginaPrectoris;
        //past medical history
        bool priorML;
        bool priorAnginaPrectoris;
        bool priorAtypicalChestPain;
        bool congestiveHeartFailure;
        bool peripheralVascularDisease;
        bool hiatalHernia;
        bool hypertension;
        bool diabetes;
        bool smoker;
        //current medication usage
        bool diurecties;
        bool nitrates;
        bool betaBlockers;
        bool digitalis;
        bool nonsteroidalAntiInflammatory;
        bool antacidsH2Blockers;
        //physicalExaminations
        int systolicBloodPresure;
        int diastolicBloodPresure;
        int heartRate;
        int respirationRate;
        bool rales;
        bool cyanosis;
        bool pallor;        bool systolicMurmur;
        bool diastolicMurmur;
        bool oedema;
        bool s3Gallop;
        bool s4Gallop;
        bool chestWall;
        bool diaphoresis2;
        //ecg examination

        Patient()
        {

        }
    }
}
