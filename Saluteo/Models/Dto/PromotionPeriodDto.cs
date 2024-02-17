namespace Saluteo.Models.Entity
{
    public class PromotionPeriodDto
    {
        // Represents a SQL DATE column
        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        // Represents a SQL TIME column
        public TimeSpan? startTime { get; set; }

        public TimeSpan? endTime { get; set; }
    }
}