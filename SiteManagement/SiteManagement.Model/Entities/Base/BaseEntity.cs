using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Model.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
