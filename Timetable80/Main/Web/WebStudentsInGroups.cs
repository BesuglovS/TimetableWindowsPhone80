namespace NUDispSchedule.Main
{
    public class WebStudentsInGroups
    {
        public WebStudentsInGroups()
        {
        }

        public WebStudentsInGroups(int studentId, int studentGroupId)
        {
            StudentId = studentId;
            StudentGroupId = studentGroupId;
        }

        public int StudentsInGroupsId { get; set; }
        public int StudentId { get; set; }
        public int StudentGroupId { get; set; }
    }
}
