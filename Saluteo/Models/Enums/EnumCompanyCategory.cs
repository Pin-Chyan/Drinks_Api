namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumCompanyCategory
    {
        [Column("PkCompanyCategoryId")]
        public long CompanyCategoryId { get; set; }

        public string CompanyCategory { get; set; }
    }
}