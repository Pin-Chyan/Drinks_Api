namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumCurrency
    {
        [Column("PkCurrencyId")]
        public long CurrencyId { get; set; }

        public string Currency { get; set; }
    }
}