namespace Saluteo.Models.Entity
{
    public class ProductDto
    {
        public string Barcode { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        //public Blob? ProductImage { get; set; }

        public long ProductCategoryId { get; set; }

        public long CountryId { get; set; }

        public long CurrencyId { get; set; }
    }
}