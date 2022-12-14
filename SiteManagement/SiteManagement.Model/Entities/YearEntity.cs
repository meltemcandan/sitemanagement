using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Borç yılları tanımlarını ifade eder
    /// </summary>
    public class YearEntity : BaseEntity
    {
        [MaxLength(4)]
        [Required]
        public string Name { get; set; }
    }
}
