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
    /// Dairede oturan ikamet eden kişi
    /// </summary>
    public class PersonEntity : BaseEntity
    {
        public int BlockId { get; set; }

        public int? FlatId { get; set; }

        public int? PersonTypeId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Kimlik Numarası
        /// </summary>
        [MaxLength(11)]
        [Required]
        public string IdentificationNumber { get; set; }

        [MaxLength(11)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Araç Plaka 
        /// </summary>
        [MaxLength(250)]
        public string? CarPlate { get; set; }

        /// <summary>
        /// Yönetici mi?
        /// </summary>
        public bool IsManager { get; set; }

        [ForeignKey("FlatId")]
        public FlatEntity Flat { get; set; }

        [ForeignKey("PersonTypeId")]
        public PersonTypeEntity ResidentType { get; set; }
    }
}
