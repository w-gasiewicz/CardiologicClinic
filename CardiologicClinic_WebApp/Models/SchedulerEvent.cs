using System;

namespace CardiologicClinic_WebApp.Models
{
    public class SchedulerEvent
    {
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public String text { get; set; }

        public SchedulerEvent(DateTime start, DateTime end, String text)
        {
            this.start_date = start;
            this.end_date = end.AddHours(1);//visit take always 1 hour
            this.text = text;
        }
    }
}
