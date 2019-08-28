using Microsoft.ML;
using System;
using System.Linq;

namespace CardiologicClinic_WebApp.AI.Models
{
    public class RunAI
    {
        private static readonly string pathData = @"C:\Users\FUJITSU\source\repos\HearAttackRecognition_ML\HearAttackRecognition_ML\Data\dane.txt";
        private HeartData _patient = new HeartData();

        public static float result;
        public static bool isIll;
        //public HeartData LoadPatientData(float age, float sex, float painlocation, float chestpainradiation,
        //    float paincharacter, float onsetofpain, float numofhso)
        //{
        //    var toReturn = new HeartData();
        //    toReturn.Age = age;
        //    toReturn.Sex = sex;
        //    toReturn.PainLocation = painlocation;
        //    toReturn.ChestPainRadiation = chestpainradiation;
        //    toReturn.PainCharacter = paincharacter;
        //    toReturn.OnsetOfPain = onsetofpain;
        //    toReturn.NumOfHoursSinceOnset = numofhso;
        //    toReturn.DurationOfTheLastEpizode = 2,
        //    toReturn.Nausea = 0,
        //    toReturn.Diaphoresis = 0,
        //    toReturn.Palpitations = 0,
        //    toReturn.Dyspnea = 0,
        //    toReturn.Dizziness = 1,
        //    toReturn.Burping = 1,
        //    toReturn.PallativeFactors = 1,
        //    toReturn.PriorChestPainOfThisType = 1,
        //    toReturn.PhysicianConsultedForPriorPain = 0,
        //    toReturn.PriorPainRelatedToHeart = 1,
        //    toReturn.PriorPainDueToMI = 0,
        //    toReturn.PriorPainDueToAnginaPectoris = 1,
        //    toReturn.PriorMI = 0,
        //    toReturn.PriorAnginaPectoris = 1,
        //    toReturn.PriorAntypicalChestPain = 0,
        //    toReturn.CongestiveHeartFailure = 1,
        //    toReturn.PeripheralVascularFailure = 0,
        //    toReturn.HiatalHernia = 0,
        //    toReturn.Hypertension = 1,
        //    toReturn.Diabetes = 0,
        //    toReturn.Smoker = 0,
        //    toReturn.Diuretics = 1,
        //    toReturn.Nitrates = 1,
        //    toReturn.BetaBlockers = 1,
        //    toReturn.Digitalis = 0,
        //    toReturn.Nonsteroidal = 1,
        //    toReturn.Antacids = 0,
        //    toReturn.SystolicBloodPressure = 152,
        //    toReturn.DiastolicBloodPressure = 80,
        //    toReturn.HeartRate = 93,
        //    toReturn.RespirationRate = 18,
        //    toReturn.Rales = 1,
        //    toReturn.Cyanosis = 0,
        //    toReturn.Pallor = 0,
        //    toReturn.SystolicMurmur = 1,
        //    toReturn.DiastolicMurmur = 1,
        //    toReturn.Oedema = 1,
        //    toReturn.S3Gallop = 1,
        //    toReturn.S4Gallop = 1,
        //    toReturn.ChestWallTenderness = 0,
        //    toReturn.DiaphoresisPE = 1,
        //    toReturn.NewQWave = 1,
        //    toReturn.AnyQWave = 0,
        //    toReturn.NewSTSegmentElevation = 1,
        //    toReturn.AnySTSegmentElevation = 1,
        //    toReturn.NewSTSegmentDepression = 0,
        //    toReturn.AnySTSegmentDepression = 1,
        //    toReturn.NewTWaveInversion = 0,
        //    toReturn.AnyTWaveInversion = 1,
        //    toReturn.NewIntraventricularConductionDefect = 1,
        //    toReturn.AnyIntraventricularConductionDefect = 1

        //    return toReturn;
        //}
        public static void Test(HeartData userData)
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromTextFile<HeartData>(path: pathData, hasHeader: true, separatorChar: ',');

            DataOperationsCatalog.TrainTestData dataSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.97);
            var trainingHeartDataView = dataSplit.TrainSet;
            var testHeartDataView = dataSplit.TestSet;

            var pipelineHeartData = mlContext.Transforms.Concatenate(
                "Features",
                "Age",
                "Sex",
                "PainLocation",
                "ChestPainRadiation",
                "PainCharacter",
                "OnsetOfPain",
                "NumOfHoursSinceOnset",
                "DurationOfTheLastEpizode",
                "Nausea",
                "Diaphoresis",
                "Palpitations",
                "Dyspnea",
                "Dizziness",
                "Burping",
                "PallativeFactors",
                "PriorChestPainOfThisType",
                "PhysicianConsultedForPriorPain",
                "PriorPainRelatedToHeart",
                "PriorPainDueToMI",
                "PriorPainDueToAnginaPectoris",
                "PriorMI",
                "PriorAnginaPectoris",
                "PriorAntypicalChestPain",
                "CongestiveHeartFailure",
                "PeripheralVascularFailure",
                "HiatalHernia",
                "Hypertension",
                "Diabetes",
                "Smoker",
                "Diuretics",
                "Nitrates",
                "BetaBlockers",
                "Digitalis",
                "Nonsteroidal",
                "Antacids",
                "SystolicBloodPressure",
                "DiastolicBloodPressure",
                "HeartRate",
                "RespirationRate",
                "Rales",
                "Cyanosis",
                "Pallor",
                "SystolicMurmur",
                "DiastolicMurmur",
                "Oedema",
                "S3Gallop",
                "S4Gallop",
                "ChestWallTenderness",
                "DiaphoresisPE",
                "NewQWave",
                "AnyQWave",
                "NewSTSegmentElevation",
                "AnySTSegmentElevation",
                "NewSTSegmentDepression",
                "AnySTSegmentDepression",
                "NewTWaveInversion",
                "AnyTWaveInversion",
                "NewIntraventricularConductionDefect",
                "AnyIntraventricularConductionDefect"
                ).Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression());//.FastTree(numberOfLeaves: 20, numberOfTrees: 100, minimumExampleCountPerLeaf: 10));

            var trainedModel = pipelineHeartData.Fit(trainingHeartDataView);

            var predictions = trainedModel.Transform(testHeartDataView);
            var metrics = mlContext.BinaryClassification.Evaluate(
                data: predictions,
                labelColumnName: "Label",
                predictedLabelColumnName: "PredictedLabel"
                );

            var examplePatient = new HeartData()
            {
                Age = 21, //Age =53,
                Sex = 0, //Sex = 0,
                PainLocation = 7,//PainLocation = 6,
                ChestPainRadiation = 1, //ChestPainRadiation = 2,
                PainCharacter = 1,//PainCharacter = 2,
                OnsetOfPain = 3, //OnsetOfPain = 1,
                NumOfHoursSinceOnset = 15,//NumOfHoursSinceOnset = 11,
                DurationOfTheLastEpizode = 6,//DurationOfTheLastEpizode = 2,
                Nausea = 0,//Nausea = 0,
                Diaphoresis = 0,//Diaphoresis = 0,
                Palpitations = 0,//Palpitations = 0,
                Dyspnea = 1,//Dyspnea = 0,
                Dizziness = 0,//Dizziness = 1,
                Burping = 1,//Burping = 1,
                PallativeFactors = 1, //PallativeFactors = 1,
                PriorChestPainOfThisType = 1,//PriorChestPainOfThisType = 1,
                PhysicianConsultedForPriorPain = 0,//PhysicianConsultedForPriorPain = 0,
                PriorPainRelatedToHeart = 0,//PriorPainRelatedToHeart = 1,
                PriorPainDueToMI = 0,//PriorPainDueToMI = 0,
                PriorPainDueToAnginaPectoris = 0,//PriorPainDueToAnginaPectoris = 1,
                PriorMI = 0,//PriorMI = 0,
                PriorAnginaPectoris = 1,//PriorAnginaPectoris = 1,
                PriorAntypicalChestPain = 1,//PriorAntypicalChestPain = 0,
                CongestiveHeartFailure = 1, //CongestiveHeartFailure = 1,
                PeripheralVascularFailure = 0,//PeripheralVascularFailure = 0,
                HiatalHernia = 0,//HiatalHernia = 0,
                Hypertension = 1,//Hypertension = 1,
                Diabetes = 1, //Diabetes = 0,
                Smoker = 1,//Smoker = 0,
                Diuretics = 0, //Diuretics = 1,
                Nitrates = 1,//Nitrates = 1,
                BetaBlockers = 1,//BetaBlockers = 1,
                Digitalis = 0,//Digitalis = 0,
                Nonsteroidal = 0,//Nonsteroidal = 1,
                Antacids = 0,//Antacids = 0,
                SystolicBloodPressure = 157, //SystolicBloodPressure = 152,
                DiastolicBloodPressure = 89,//DiastolicBloodPressure = 80,
                HeartRate = 76,//HeartRate = 93,
                RespirationRate = 21,//RespirationRate = 18,
                Rales = 0,//Rales = 1,
                Cyanosis = 0,//Cyanosis = 0,
                Pallor = 0,//Pallor = 0,
                SystolicMurmur = 0,//SystolicMurmur = 1,
                DiastolicMurmur = 0, //DiastolicMurmur = 1,
                Oedema = 0,//Oedema = 1,
                S3Gallop = 0,//S3Gallop = 1,
                S4Gallop = 1,//S4Gallop = 1,
                ChestWallTenderness = 1,//ChestWallTenderness = 0,
                DiaphoresisPE = 1, //DiaphoresisPE = 1,
                NewQWave = 1, //NewQWave = 1,
                AnyQWave = 0,//AnyQWave = 0,
                NewSTSegmentElevation = 0,//NewSTSegmentElevation = 1,
                AnySTSegmentElevation = 1,//AnySTSegmentElevation = 1,
                NewSTSegmentDepression = 1,//NewSTSegmentDepression = 0,
                AnySTSegmentDepression = 0,//AnySTSegmentDepression = 1,
                NewTWaveInversion = 0,//NewTWaveInversion = 0,
                AnyTWaveInversion = 0, //AnyTWaveInversion = 1,
                NewIntraventricularConductionDefect = 0, //NewIntraventricularConductionDefect = 1,
                AnyIntraventricularConductionDefect = 0 //AnyIntraventricularConductionDefect = 1
            };

            var predictionFunction = mlContext.Model.CreatePredictionEngine<HeartData, HeartPrediction>(trainedModel);
            var prediction = predictionFunction.Predict(examplePatient);

            isIll = prediction.Prediction;
            result = prediction.Probability;
        }
        public void LoadPatientData(HeartData input)
        {
            _patient = input;
        }
        public static void Run()
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromTextFile<HeartData>(path: pathData, hasHeader: true, separatorChar: ',');

            DataOperationsCatalog.TrainTestData dataSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.97);
            var trainingHeartDataView = dataSplit.TrainSet;
            var testHeartDataView = dataSplit.TestSet;

            var pipelineHeartData = mlContext.Transforms.Concatenate(
                "Features",
                "Age",
                "Sex",
                "PainLocation",
                "ChestPainRadiation",
                "PainCharacter",
                "OnsetOfPain",
                "NumOfHoursSinceOnset",
                "DurationOfTheLastEpizode",
                "Nausea",
                "Diaphoresis",
                "Palpitations",
                "Dyspnea",
                "Dizziness",
                "Burping",
                "PallativeFactors",
                "PriorChestPainOfThisType",
                "PhysicianConsultedForPriorPain",
                "PriorPainRelatedToHeart",
                "PriorPainDueToMI",
                "PriorPainDueToAnginaPectoris",
                "PriorMI",
                "PriorAnginaPectoris",
                "PriorAntypicalChestPain",
                "CongestiveHeartFailure",
                "PeripheralVascularFailure",
                "HiatalHernia",
                "Hypertension",
                "Diabetes",
                "Smoker",
                "Diuretics",
                "Nitrates",
                "BetaBlockers",
                "Digitalis",
                "Nonsteroidal",
                "Antacids",
                "SystolicBloodPressure",
                "DiastolicBloodPressure",
                "HeartRate",
                "RespirationRate",
                "Rales",
                "Cyanosis",
                "Pallor",
                "SystolicMurmur",
                "DiastolicMurmur",
                "Oedema",
                "S3Gallop",
                "S4Gallop",
                "ChestWallTenderness",
                "DiaphoresisPE",
                "NewQWave",
                "AnyQWave",
                "NewSTSegmentElevation",
                "AnySTSegmentElevation",
                "NewSTSegmentDepression",
                "AnySTSegmentDepression",
                "NewTWaveInversion",
                "AnyTWaveInversion",
                "NewIntraventricularConductionDefect",
                "AnyIntraventricularConductionDefect"
                ).Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression());//.FastTree(numberOfLeaves: 20, numberOfTrees: 100, minimumExampleCountPerLeaf: 10));

            Console.WriteLine("Training model...");
            var trainedModel = pipelineHeartData.Fit(trainingHeartDataView);
            Console.WriteLine("Done!");

            var predictions = trainedModel.Transform(testHeartDataView);
            var metrics = mlContext.BinaryClassification.Evaluate(
                data: predictions,
                labelColumnName: "Label",
                predictedLabelColumnName: "PredictedLabel"
                );

            Console.WriteLine("Accuracy: " + metrics.Accuracy);
            Console.WriteLine("AUC: " + metrics.AreaUnderRocCurve);
            Console.WriteLine("Auprc: " + metrics.AreaUnderPrecisionRecallCurve);
            Console.WriteLine("F1Score: " + metrics.F1Score);
            Console.WriteLine("LogLoss: " + metrics.LogLoss);
            Console.WriteLine("LogLossReduction: " + metrics.LogLossReduction);
            Console.WriteLine("PositivePrecision: " + metrics.PositivePrecision);
            Console.WriteLine("PositiveRecall: " + metrics.PositiveRecall);
            Console.WriteLine("NegativePrecision: " + metrics.NegativePrecision);
            Console.WriteLine("NegativeRecall: " + metrics.NegativeRecall);
            Console.WriteLine();

            var examplePatient = new HeartData()
            {
                Age = 21, //Age =53,
                Sex = 0, //Sex = 0,
                PainLocation = 7,//PainLocation = 6,
                ChestPainRadiation = 1, //ChestPainRadiation = 2,
                PainCharacter = 1,//PainCharacter = 2,
                OnsetOfPain = 3, //OnsetOfPain = 1,
                NumOfHoursSinceOnset = 15,//NumOfHoursSinceOnset = 11,
                DurationOfTheLastEpizode = 6,//DurationOfTheLastEpizode = 2,
                Nausea = 0,//Nausea = 0,
                Diaphoresis = 0,//Diaphoresis = 0,
                Palpitations = 0,//Palpitations = 0,
                Dyspnea = 1,//Dyspnea = 0,
                Dizziness = 0,//Dizziness = 1,
                Burping = 1,//Burping = 1,
                PallativeFactors = 1, //PallativeFactors = 1,
                PriorChestPainOfThisType = 1,//PriorChestPainOfThisType = 1,
                PhysicianConsultedForPriorPain = 0,//PhysicianConsultedForPriorPain = 0,
                PriorPainRelatedToHeart = 0,//PriorPainRelatedToHeart = 1,
                PriorPainDueToMI = 0,//PriorPainDueToMI = 0,
                PriorPainDueToAnginaPectoris = 0,//PriorPainDueToAnginaPectoris = 1,
                PriorMI = 0,//PriorMI = 0,
                PriorAnginaPectoris = 1,//PriorAnginaPectoris = 1,
                PriorAntypicalChestPain = 1,//PriorAntypicalChestPain = 0,
                CongestiveHeartFailure = 1, //CongestiveHeartFailure = 1,
                PeripheralVascularFailure = 0,//PeripheralVascularFailure = 0,
                HiatalHernia = 0,//HiatalHernia = 0,
                Hypertension = 1,//Hypertension = 1,
                Diabetes = 1, //Diabetes = 0,
                Smoker = 1,//Smoker = 0,
                Diuretics = 0, //Diuretics = 1,
                Nitrates = 1,//Nitrates = 1,
                BetaBlockers = 1,//BetaBlockers = 1,
                Digitalis = 0,//Digitalis = 0,
                Nonsteroidal = 0,//Nonsteroidal = 1,
                Antacids = 0,//Antacids = 0,
                SystolicBloodPressure = 157, //SystolicBloodPressure = 152,
                DiastolicBloodPressure = 89,//DiastolicBloodPressure = 80,
                HeartRate = 76,//HeartRate = 93,
                RespirationRate = 21,//RespirationRate = 18,
                Rales = 0,//Rales = 1,
                Cyanosis = 0,//Cyanosis = 0,
                Pallor = 0,//Pallor = 0,
                SystolicMurmur = 0,//SystolicMurmur = 1,
                DiastolicMurmur = 0, //DiastolicMurmur = 1,
                Oedema = 0,//Oedema = 1,
                S3Gallop = 0,//S3Gallop = 1,
                S4Gallop = 1,//S4Gallop = 1,
                ChestWallTenderness = 1,//ChestWallTenderness = 0,
                DiaphoresisPE = 1, //DiaphoresisPE = 1,
                NewQWave = 1, //NewQWave = 1,
                AnyQWave = 0,//AnyQWave = 0,
                NewSTSegmentElevation = 0,//NewSTSegmentElevation = 1,
                AnySTSegmentElevation = 1,//AnySTSegmentElevation = 1,
                NewSTSegmentDepression = 1,//NewSTSegmentDepression = 0,
                AnySTSegmentDepression = 0,//AnySTSegmentDepression = 1,
                NewTWaveInversion = 0,//NewTWaveInversion = 0,
                AnyTWaveInversion = 0, //AnyTWaveInversion = 1,
                NewIntraventricularConductionDefect = 0, //NewIntraventricularConductionDefect = 1,
                AnyIntraventricularConductionDefect = 0 //AnyIntraventricularConductionDefect = 1
            };
            var predictionFunction = mlContext.Model.CreatePredictionEngine<HeartData, HeartPrediction>(trainedModel);
            var prediction = predictionFunction.Predict(examplePatient);

            isIll = prediction.Prediction;
            result = prediction.Probability;

            Console.WriteLine("Prawdopodobieństwo: " + (prediction.Probability) + "%");
            Console.WriteLine("Prawdopodobieństwo wystąpienia zawału serca: " + (prediction.Prediction ? "zawał może występować" : " zawał nie występuje"));
            Console.Read();
        }
    }
}
