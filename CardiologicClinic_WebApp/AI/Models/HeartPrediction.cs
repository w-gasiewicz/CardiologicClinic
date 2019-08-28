using Microsoft.ML.Data;

namespace CardiologicClinic_WebApp.AI.Models
{
    public class HeartPrediction
    {
        [ColumnName("PredictedLabel")] public bool Prediction;
        public float Probability;
        public float Score;
    }
}
