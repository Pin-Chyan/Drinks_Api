namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumProductCategory
    {
        [Column("PkProductCategoryId")]
        public long ProductCategoryId { get; set; }

        public string ProductCategory { get; set; }
    }
}