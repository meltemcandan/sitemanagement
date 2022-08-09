using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Apartmandaki bir daireyi ifade eder
    /// </summary>
    public class FlatEntity : BaseEntity
    {
        [Required]
        public int BlockId { get; set; }

        [Required]
        public int FlatTypeId { get; set; }

        /// <summary>
        /// Daire kaçıncı katta
        /// </summary>
        [Required]
        public int Floor { get; set; }

        [Required]
        [MaxLength(20)]
        public string No { get; set; }

        [ForeignKey("BlockId")]
        public BlockEntity Block { get; set; }

        [ForeignKey("FlatTypeId")]
        public FlatTypeEntity FlatType { get; set; }
    }
}
