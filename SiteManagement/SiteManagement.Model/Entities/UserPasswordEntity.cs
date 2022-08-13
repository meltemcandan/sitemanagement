using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagement.Model.Entities
{
    public class UserPasswordEntity : BaseEntity
    {
        public int UserId { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
