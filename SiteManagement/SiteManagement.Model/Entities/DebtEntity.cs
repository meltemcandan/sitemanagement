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
    /// Borçların bulunduğu tablo
    /// </summary>
    public class DebtEntity : BaseEntity
    {
        public PaymentTypeEnum? PaymentType { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int YearId { get; set; }

        [Required]
        public int MonthId { get; set; }

        [Required]
        public int DebtTypeId { get; set; }

        [Required]
        public double Price { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsItPaid { get; set; }

        [ForeignKey("DebtTypeId")]
        public DebtTypeEntity DebtType { get; set; }
    }
}
