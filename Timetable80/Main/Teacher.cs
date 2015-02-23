namespace NUDispSchedule.Main
{
    public class Teacher
    {
        public Teacher()
        {
        }

        public Teacher(string fio)
        {
            FIO = fio;
        }

        public int TeacherId { get; set; }
        public string FIO { get; set; }
    }
}
