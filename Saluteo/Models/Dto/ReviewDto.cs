namespace Saluteo.Models.Entity
{
    public class ReviewDto
    {
        public string ReviewJson { get; set; }

        public long ReviewConfigurationId { get; set; }

        public long PromotionProductId { get; set; }

        public long ClientId { get; set; }
    }
}