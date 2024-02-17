namespace Saluteo.Models.Entity
{
    using Saluteo.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection.Metadata;

    public class Product
    {
        [Key]
        [Column("PkProductId")]
        public long ProductId { get; set; }

        public string Barcode { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        //public Blob? ProductImage { get; set; }

        [Column("FkProductCategoryId")]
        public long ProductCategoryId { get; set; }

        public EnumProductCategory ProductCategory { get; set; }

        [Column("FkCountryId")]
        public long CountryId { get; set; }

        public EnumCountry Country { get; set; }

        [Column("FkCurrencyId")]
        public long CurrencyId { get; set; }

        public EnumCurrency Currency { get; set; }
    }
}