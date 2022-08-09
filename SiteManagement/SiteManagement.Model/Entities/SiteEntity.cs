using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Site Tanımlarını ifade eder
    /// </summary>
    public class SiteEntity : BaseEntity
    {
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [MaxLength(500)]
        [Required]
        public string Address { get; set; }
    }
}
