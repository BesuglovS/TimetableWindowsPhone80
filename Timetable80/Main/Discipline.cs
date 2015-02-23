namespace NUDispSchedule.Main
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public int Attestation { get; set; } // 0 - ничего; 1 - зачёт; 2 - экзамен; 3 - зачёт и экзамен
        public int AuditoriumHours { get; set; }
        public int LectureHours { get; set; }
        public int PracticalHours { get; set; }
        public StudentGroup StudentGroup { get; set; }

        public Discipline()
        {
        }

        public Discipline(int disciplineId, string name, StudentGroup studentGroup,
            int attestation, int auditoriumHours, int lectureHours, int practicalHours)
        {
            DisciplineId = disciplineId;
            Name = name;
            StudentGroup = studentGroup;
            Attestation = attestation;
            AuditoriumHours = auditoriumHours;
            LectureHours = lectureHours;
            PracticalHours = practicalHours;
        }       
    }
}
