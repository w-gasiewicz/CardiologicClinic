using CardiologicClinic_WebApp.AI.Models;
using CardiologicClinic_WebApp.AI.Procedures;
using Microsoft.ML;
using Microsoft.ML.Transforms.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardiologicClinic_WebApp.AI
{
    public class RunAIAlgorythm
    {
        static List<FeedBackTrainingData> trainingData = new List<FeedBackTrainingData>();
        static List<FeedBackTrainingData> testData = new List<FeedBackTrainingData>();

        public void RunAI()
        { //Load the trainingdata
            LoadFiles lf = new LoadFiles();
            lf.OpenFile();

            LoadTrainingData();
            //(Instead of shit say poo) Create object of MLContext
            var mlContext = new MLContext();
            //Step 3 Convert classes with data to IDataView
            IDataView trainingDataView = mlContext.Data.LoadFromEnumerable(trainingData);
            IDataView testDataView = mlContext.Data.LoadFromEnumerable(testData);
            //Create pipeline and define workflow 
            var options = new TextFeaturizingEstimator.Options()
            {    // Also output tokenized words
                OutputTokensColumnName = "OutputTokens",
                CaseMode = TextNormalizingEstimator.CaseMode.Lower,
                // Use ML.NET's built-in stop word remover
                StopWordsRemoverOptions = new StopWordsRemovingEstimator.Options()
                {
                    Language = TextFeaturizingEstimator.Language.English
                },
                WordFeatureExtractor = new WordBagEstimator.Options()
                {
                    NgramLength = 2,
                    UseAllLengths = true
                },
                CharFeatureExtractor = new WordBagEstimator.Options()
                {
                    NgramLength = 3,
                    UseAllLengths = false
                },
            };

            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", options, "FeedBackText")
                .Append(mlContext.BinaryClassification.Trainers.FastTree(numberOfLeaves: 50, numberOfTrees: 50, minimumExampleCountPerLeaf: 1));

            //Training the algorithm
            var model = pipeline.Fit(trainingDataView);
            //Load and run TestData
            LoadTestData();

            var predictions = model.Transform(testDataView);
            var metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");

            //Loop added so the code reruns without restarting every time
            string strcont = "Y";
            while (strcont == "Y")
            {                //Reads feedback to string and predicts if IsGood = true or false
                Console.WriteLine("Enter feedback: ");
                string feedbackString = Console.ReadLine().ToString();
                var predictionFunction = mlContext.Model.CreatePredictionEngine<FeedBackTrainingData, FeedBackPrediction>(model);

                var feedbackInput = new FeedBackTrainingData();
                feedbackInput.FeedBackText = feedbackString;
                var feedbackPredicted = predictionFunction.Predict(feedbackInput);
                //Prints prediction together with accuracy
                string feedbackMessage;
                double accuracyToPercent = Convert.ToDouble(metrics.Accuracy) * 100;

                if (feedbackPredicted.IsGood == true)
                    feedbackMessage = "Feedback is positive with " + accuracyToPercent + "% accuracy";
                else
                    feedbackMessage = "Feedback is negative with " + accuracyToPercent + "% accuracy";

                Console.WriteLine(feedbackMessage);
            }
            Console.Read();
        }

        //Methods for adding and loading testdata. The data itself needs more work and is only here as a (bad?) example
        static void LoadTestData()
        {
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "good",
                IsGood = true
            });
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "best",
                IsGood = true
            });
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "awesome",
                IsGood = true
            });
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "bad",
                IsGood = false
            });
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "haggard",
                IsGood = false
            });
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "good",
                IsGood = true
            });
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "aweful",
                IsGood = false
            });
            testData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "This is good",
                IsGood = true
            });
        }

        static void LoadTrainingData()
        {
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "good",
                IsGood = true
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "this is really good",
                IsGood = true
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "very fail",
                IsGood = false
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "aweful and it sucks",
                IsGood = false
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "haggard shit",
                IsGood = false
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "this would litterarly be the worst",
                IsGood = false
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "kinda ok",
                IsGood = true
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "awesome job man",
                IsGood = true
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "It's the best",
                IsGood = true
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "good job!",
                IsGood = true
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = " i think this is shit",
                IsGood = false
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "this is good",
                IsGood = true
            });
        }
    }
}
