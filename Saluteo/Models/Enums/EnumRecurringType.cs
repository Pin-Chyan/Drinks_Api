namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumRecurringType
    {
        [Column("PkRecurringTypeId")]
        public long RecurringTypeId { get; set; }

        public string RecurringType { get; set; }
    }
}