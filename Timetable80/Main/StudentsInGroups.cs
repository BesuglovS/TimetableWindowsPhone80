namespace NUDispSchedule.Main
{
    public class StudentsInGroups
    {
        public StudentsInGroups()
        {
        }

        public StudentsInGroups(int studentsInGroups, Student student, StudentGroup studentGroup)
        {
            StudentsInGroupsId = studentsInGroups;
            Student = student;
            StudentGroup = studentGroup;
        }

        public int StudentsInGroupsId { get; set; }
        public Student Student { get; set; }
        public StudentGroup StudentGroup { get; set; }
    }
}
