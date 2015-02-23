using System.Collections.Generic;
using NUDispSchedule.Main.FileSave;
using NUDispSchedule.Main.Others;
using NUDispSchedule.Main.Web;

namespace NUDispSchedule.Main
{
    public class FileSaveSchedule
    {
        public List<Auditorium> auditoriums { get; set; }
        public List<FileSaveCalendar> calendars { get; set; }
        public List<WebDiscipline> disciplines { get; set; }
        public List<WebLesson> lessons { get; set; }
        public List<FileSaveRing> rings { get; set; }
        public List<WebStudent> students { get; set; }
        public List<StudentGroup> studentGroups { get; set; }
        public List<WebStudentsInGroups> studentsInGroups { get; set; }
        public List<Teacher> teachers { get; set; }
        public List<WebTeacherForDiscipline> teacherForDisciplines { get; set; }
        public List<WebLessonLogEvent> lessonLogEvents { get; set; }
        public List<ConfigOption> configOptions { get; set; }
    }
}
