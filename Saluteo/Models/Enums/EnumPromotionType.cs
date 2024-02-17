namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumPromotionType
    {
        [Column("PkPromotionTypeId")]
        public long PromotionTypeId { get; set; }

        public string PromotionType { get; set; }
    }
}