using Microsoft.ML.Data;

namespace CardiologicClinic_WebApp.AI.Models
{
    class FeedBackPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsGood { get; set; }
    }
}