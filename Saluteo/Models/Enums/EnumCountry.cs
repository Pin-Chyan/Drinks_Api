namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumCountry
    {
        [Column("PkCountryId")]
        public long CountryId { get; set; }

        public string Country { get; set; }
    }
}