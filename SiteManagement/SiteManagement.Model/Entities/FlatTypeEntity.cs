using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Apartmandaki Daire Tipi (1+1, 2+1, 3+1, 4x+1)
    /// </summary>
    public class FlatTypeEntity : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public double NetM2 { get; set; }
    }
}
