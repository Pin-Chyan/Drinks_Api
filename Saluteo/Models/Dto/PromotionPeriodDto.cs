namespace Saluteo.Models.Entity
{
    public class PromotionPeriodDto
    {
        // Represents a SQL DATE column
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Represents a SQL TIME column
        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
    }
}