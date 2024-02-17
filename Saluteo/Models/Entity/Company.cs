namespace Saluteo.Models.Entity
{
    using Saluteo.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Company
    {
        [Key]
        [Column("PkCompanyId")]
        public long CompanyId { get; set; }

        public string CompanyName { get; set; }

        //public Blob? CompanyImage { get; set; }

        [Column("FkCompanyCategoryId")]
        public long CompanyCategoryId { get; set; }

        public EnumCompanyCategory? CompanyCategory { get; set; }
    }
}