namespace NUDispSchedule.Main
{
    public class WebDiscipline
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public int Attestation { get; set; } // 0 - ничего; 1 - зачёт; 2 - экзамен; 3 - зачёт и экзамен
        public int AuditoriumHours { get; set; }
        public int LectureHours { get; set; }
        public int PracticalHours { get; set; }
        public int StudentGroupId { get; set; }

        public WebDiscipline()
        {
        }

        public WebDiscipline(string name, int studentGroupId,
            int attestation, int auditoriumHours, int lectureHours, int practicalHours)
        {
            Name = name;
            StudentGroupId = studentGroupId;
            Attestation = attestation;
            AuditoriumHours = auditoriumHours;
            LectureHours = lectureHours;
            PracticalHours = practicalHours;
        }       
    }
}
