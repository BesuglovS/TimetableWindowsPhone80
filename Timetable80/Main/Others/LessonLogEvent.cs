using System;

namespace NUDispSchedule.Main.Others
{
    public class LessonLogEvent
    {
        public int LessonLogEventId { get; set; }
        public Lesson OldLesson { get; set; }
        public Lesson NewLesson { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
    }
}
