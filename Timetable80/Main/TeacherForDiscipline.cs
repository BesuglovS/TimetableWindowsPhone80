namespace NUDispSchedule.Main
{
    public class TeacherForDiscipline
    {
        public TeacherForDiscipline()
        {
        }

        public TeacherForDiscipline(int teacherForDiscipline, Teacher teacher, Discipline discipline)
        {
            TeacherForDisciplineId = teacherForDiscipline;
            Teacher = teacher;
            Discipline = discipline;
        }

        public int TeacherForDisciplineId { get; set; }
        public Teacher Teacher { get; set; }
        public Discipline Discipline { get; set; }
    }
}
