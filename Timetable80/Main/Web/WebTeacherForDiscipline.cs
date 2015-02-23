namespace NUDispSchedule.Main
{
    public class WebTeacherForDiscipline
    {
        public WebTeacherForDiscipline()
        {
        }

        public WebTeacherForDiscipline(int teacherId, int disciplineId)
        {
            TeacherId = teacherId;
            DisciplineId = disciplineId;
        }

        public int TeacherForDisciplineId { get; set; }
        public int TeacherId { get; set; }
        public int DisciplineId { get; set; }
    }
}
