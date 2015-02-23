namespace NUDispSchedule.Main
{
    public class Student
    {        
        public Student()
        {
        }

        public Student(int studentId, string f, string i, string o, bool starosta, bool nFactor, bool expelled)
        {
            StudentId = studentId;
            F = f;
            I = i;
            O = o;
            Starosta = starosta;
            NFactor = nFactor;
            Expelled = expelled;
        }

        public string FIO { get { return F + " " + I + " " + O; } }
        

        public int StudentId { get; set; }
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public bool Starosta { get; set; }
        public bool NFactor { get; set; }
        public bool Expelled { get; set; }
    }    
}
