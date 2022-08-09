using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Model.Entities
{
    public class YearEntity : BaseEntity
    {
        [MaxLength(4)]
        [Required]
        public string Name { get; set; }
    }
}
