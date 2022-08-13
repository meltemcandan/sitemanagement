using SiteManagement.Model.Enums;
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
    public class UserEntity : BaseEntity
    {
        public int FlatId { get; set; }

        public int? UserTypeId { get; set; }

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
        /// Kullanıcı Rolü
        /// </summary>
        [Required]
        public UserRoleEnum UserRole { get; set; }

        [ForeignKey("FlatId")]
        public FlatEntity Flat { get; set; }

        [ForeignKey("UserTypeId")]
        public UserTypeEntity UserType { get; set; }

        public UserPasswordEntity UserPassword { get; set; }
    }
}
