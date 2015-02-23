using System;

namespace NUDispSchedule.Main.Others
{
    public class WebLessonLogEvent
    {
        public int LessonLogEventId { get; set; }
        public int OldLessonId { get; set; }
        public int NewLessonId { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
    }
}
