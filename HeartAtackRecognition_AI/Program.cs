using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;

namespace HeartAtackRecognition_AI
{
    class FeedBackTrainingData
    {
        public string FeedBackText { get; set; }
        public bool IsGood { get; set; }

    }
    class Program
    {
        static List<FeedBackTrainingData> trainingData = new List<FeedBackTrainingData>();
        static void LoadTraingingData()
        {
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "this is good",
                IsGood=true
            });
            trainingData.Add(new FeedBackTrainingData()
            {
                FeedBackText = "this is horrible",
                IsGood = true
            });
        }
        static void Main(string[] args)
        {
        }
    }
}
