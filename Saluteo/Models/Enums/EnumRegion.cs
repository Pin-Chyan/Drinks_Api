namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumRegion
    {
        [Column("PkRegionId")]
        public long RegionId { get; set; }

        [Column("FkCountryId")]
        public long CountryId { get; set; }

        public EnumCountry Country { get; set; }

        public string Region { get; set; }
    }
}