namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumReviewType
    {
        [Column("PkReviewTypeId")]
        public long ReviewTypeId { get; set; }

        public int ReviewCode { get; set; }

        public string ReviewDescription { get; set; }
    }
}