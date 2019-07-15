using Microsoft.ML.Data;
namespace HeartAtackRecognition_AI.Models
{
    class FeedBackPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsGood { get; set; }
    }
}