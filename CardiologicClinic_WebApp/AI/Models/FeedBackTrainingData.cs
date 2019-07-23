using Microsoft.ML.Data;

namespace CardiologicClinic_WebApp.AI.Models
{
    class FeedBackTrainingData
    {
        //[ColumnName(name: "Label Feedback")]
        public string FeedBackText { get; set; }
        [ColumnName(name: "Label")]
        public bool IsGood { get; set; }
    }
}

