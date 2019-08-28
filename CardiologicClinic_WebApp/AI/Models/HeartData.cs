using Microsoft.ML.Data;

namespace CardiologicClinic_WebApp.AI.Models
{
    public class HeartData
    {
        [LoadColumn(0)] public float Age { get; set; }
        [LoadColumn(1)] public float Sex { get; set; }
        [LoadColumn(2)] public float PainLocation { get; set; }
        [LoadColumn(3)] public float ChestPainRadiation { get; set; }
        [LoadColumn(4)] public float PainCharacter { get; set; }
        [LoadColumn(5)] public float OnsetOfPain { get; set; }
        [LoadColumn(6)] public float NumOfHoursSinceOnset { get; set; }
        [LoadColumn(7)] public float DurationOfTheLastEpizode { get; set; }
        [LoadColumn(8)] public float Nausea { get; set; }
        [LoadColumn(9)] public float Diaphoresis { get; set; }
        [LoadColumn(10)] public float Palpitations { get; set; }
        [LoadColumn(11)] public float Dyspnea { get; set; }
        [LoadColumn(12)] public float Dizziness { get; set; }
        [LoadColumn(13)] public float Burping { get; set; }
        [LoadColumn(14)] public float PallativeFactors { get; set; }

        //history of similar pain
        [LoadColumn(15)] public float PriorChestPainOfThisType { get; set; }
        [LoadColumn(16)] public float PhysicianConsultedForPriorPain { get; set; }
        [LoadColumn(17)] public float PriorPainRelatedToHeart { get; set; }
        [LoadColumn(18)] public float PriorPainDueToMI { get; set; }
        [LoadColumn(19)] public float PriorPainDueToAnginaPectoris { get; set; }

        //Past Medical History 
        [LoadColumn(20)] public float PriorMI { get; set; }
        [LoadColumn(21)] public float PriorAnginaPectoris { get; set; }
        [LoadColumn(22)] public float PriorAntypicalChestPain { get; set; }
        [LoadColumn(23)] public float CongestiveHeartFailure { get; set; }
        [LoadColumn(24)] public float PeripheralVascularFailure { get; set; }
        [LoadColumn(25)] public float HiatalHernia { get; set; }
        [LoadColumn(26)] public float Hypertension { get; set; }
        [LoadColumn(27)] public float Diabetes { get; set; }
        [LoadColumn(28)] public float Smoker { get; set; }

        // Current Medication Usage
        [LoadColumn(29)] public float Diuretics { get; set; }
        [LoadColumn(30)] public float Nitrates { get; set; }
        [LoadColumn(31)] public float BetaBlockers { get; set; }
        [LoadColumn(32)] public float Digitalis { get; set; }
        [LoadColumn(33)] public float Nonsteroidal { get; set; }
        [LoadColumn(34)] public float Antacids { get; set; }

        //Physical Examinations
        [LoadColumn(35)] public float SystolicBloodPressure { get; set; }
        [LoadColumn(36)] public float DiastolicBloodPressure { get; set; }
        [LoadColumn(37)] public float HeartRate { get; set; }
        [LoadColumn(38)] public float RespirationRate { get; set; }
        [LoadColumn(39)] public float Rales { get; set; }
        [LoadColumn(40)] public float Cyanosis { get; set; }
        [LoadColumn(41)] public float Pallor { get; set; }
        [LoadColumn(42)] public float SystolicMurmur { get; set; }
        [LoadColumn(43)] public float DiastolicMurmur { get; set; }
        [LoadColumn(44)] public float Oedema { get; set; }
        [LoadColumn(45)] public float S3Gallop { get; set; }
        [LoadColumn(46)] public float S4Gallop { get; set; }
        [LoadColumn(47)] public float ChestWallTenderness { get; set; }
        [LoadColumn(48)] public float DiaphoresisPE { get; set; }

        //ecg examination
        [LoadColumn(49)] public float NewQWave { get; set; }
        [LoadColumn(50)] public float AnyQWave { get; set; }
        [LoadColumn(51)] public float NewSTSegmentElevation { get; set; }
        [LoadColumn(52)] public float AnySTSegmentElevation { get; set; }
        [LoadColumn(53)] public float NewSTSegmentDepression { get; set; }
        [LoadColumn(54)] public float AnySTSegmentDepression { get; set; }
        [LoadColumn(55)] public float NewTWaveInversion { get; set; }
        [LoadColumn(56)] public float AnyTWaveInversion { get; set; }
        [LoadColumn(57)] public float NewIntraventricularConductionDefect { get; set; }
        [LoadColumn(58)] public float AnyIntraventricularConductionDefect { get; set; }

        [LoadColumn(59)][ColumnName("Label")] public bool Label { get; set; }
    }
}
