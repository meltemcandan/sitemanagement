using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Mesajlar tablosu
    /// </summary>
    public class MessageEntity : BaseEntity
    {
        /// <summary>
        /// Mesajı Gönderen
        /// </summary>
        [Required]
        public int UserId { get; set; }

        [MaxLength(250)]
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime RecordDate { get; set; }

        /// <summary>
        /// Bağlı Mesaj Id
        /// </summary>
        public int? LinkedMessageId { get; set; }

        /// <summary>
        /// Mesaj Durumu => Okundu / Okunmadı
        /// </summary>
        [Required]
        public int MessageStateId { get; set; }


        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
