using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int PaymentTypeId { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        public int YearId { get; set; }

        [Required]
        public int MonthId { get; set; }

        [Required]
        public int DeptTypeId { get; set; }

        [Required]
        public double Price { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsItPaid { get; set; }
    }
}
