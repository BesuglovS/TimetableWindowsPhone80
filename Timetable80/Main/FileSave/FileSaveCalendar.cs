namespace NUDispSchedule.Main.FileSave
{
    public class FileSaveCalendar
    {
        public FileSaveCalendar()
        {
        }

        public FileSaveCalendar(string date)
        {
            Date = date;
        }

        public int CalendarId { get; set; }
        public string Date { get; set; } 
    }
}
