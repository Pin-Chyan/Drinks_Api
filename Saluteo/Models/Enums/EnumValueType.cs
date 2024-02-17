namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumValueType
    {
        [Column("PkValueTypeId")]
        public long ValueTypeId { get; set; }

        public string ValueType { get; set; }
    }
}