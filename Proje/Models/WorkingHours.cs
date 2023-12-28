namespace Proje.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
    }
}
