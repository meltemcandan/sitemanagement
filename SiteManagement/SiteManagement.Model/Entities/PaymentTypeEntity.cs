using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Ödeme Tipi (K.Kartı - Nakit)
    /// </summary>
    public class PaymentTypeEntity : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
