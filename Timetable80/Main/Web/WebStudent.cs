namespace NUDispSchedule.Main.Web
{
    public class WebStudent
    {        
        public WebStudent()
        {
        }

        public WebStudent(string f, string i, string o, int starosta, int nFactor, int expelled)
        {
            F = f;
            I = i;
            O = o;
            Starosta = starosta;
            NFactor = nFactor;
            Expelled = expelled;
        }

        public int StudentId { get; set; }
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public int Starosta { get; set; }
        public int NFactor { get; set; }
        public int Expelled { get; set; }
    }    
}
