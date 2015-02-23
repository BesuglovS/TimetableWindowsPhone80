namespace NUDispSchedule.Main
{
    public class WebLesson
    {
        public WebLesson()
        {
        }

        public WebLesson(int teacherForDisciplineId, int calendarId,
                      int ringId, int auditoriumId)
        {
            TeacherForDisciplineId = teacherForDisciplineId;
            CalendarId = calendarId;
            RingId = ringId;
            AuditoriumId = auditoriumId;
        }

        public int LessonId { get; set; }
        public int IsActive { get; set; }
        public int TeacherForDisciplineId { get; set; }
        public int CalendarId { get; set; }
        public int RingId { get; set; }
        public int AuditoriumId { get; set; }
    }
}
