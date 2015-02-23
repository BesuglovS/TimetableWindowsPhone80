namespace NUDispSchedule.Main.FileSave
{
    public class FileSaveRing
    {
        public FileSaveRing()
        {
        }

        public FileSaveRing(string time)
        {
            Time = time;
        }

        public int RingId { get; set; }
        public string Time { get; set; }
    }
}
