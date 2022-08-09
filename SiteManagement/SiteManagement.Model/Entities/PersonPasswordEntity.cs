using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagement.Model.Entities
{
    public class PersonPasswordEntity : BaseEntity
    {
        public int PersonId { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        [ForeignKey("PersonId")]
        public PersonEntity Person { get; set; }
    }
}
