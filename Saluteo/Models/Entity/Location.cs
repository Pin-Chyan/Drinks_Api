namespace Saluteo.Models.Entity
{
    using Saluteo.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Location
    {
        [Key]
        [Column("PkLocationId")]
        public long LocationId { get; set; }

        public string? Coordinate { get; set; }

        public string? Address { get; set; }

        [Column("FkRegionId")]
        public long RegionId { get; set; }

        public EnumRegion Region { get; set; }
    }
}