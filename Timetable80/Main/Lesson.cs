namespace NUDispSchedule.Main
{
    public class Lesson
    {
        public Lesson()
        {
        }

        public Lesson(int lessonId,
                      TeacherForDiscipline teacherForDiscipline, Calendar calendar,
                      Ring ring, Auditorium auditorium, bool isActive)
        {
            LessonId = lessonId;
            TeacherForDiscipline = teacherForDiscipline;
            Calendar = calendar;
            Ring = ring;
            Auditorium = auditorium;
            IsActive = isActive;
        }

        public int LessonId { get; set; }
        public bool IsActive { get; set; }
        public TeacherForDiscipline TeacherForDiscipline { get; set; }
        public Calendar Calendar { get; set; }
        public Ring Ring { get; set; }
        public Auditorium Auditorium { get; set; }
    }
}
