using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Sitenin bloklarını ifade eder (A Blok - B Blok - C Blok)
    /// </summary>
    public class BlockEntity : BaseEntity
    {
        [Required]
        public int SiteId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Kat sayısı
        /// </summary>
        public int? NumberOfFloors { get; set; }

        /// <summary>
        /// Bir Katta kaç daire var 
        /// </summary>
        public int? NumberOfFlatsOnTheFloor { get; set; }
        

        [ForeignKey("SiteId")]
        public SiteEntity Site { get; set; }
    }
}
