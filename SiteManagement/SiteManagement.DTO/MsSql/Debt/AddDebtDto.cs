using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.MsSql.Debt
{
    public class AddDebtDto
    {
        public double Price { get; set; }

        public int MonthId { get; set; }

        public int YearId { get; set; }

        public int DebtTypeId { get; set; }

        public int UserId { get; set; }
    }
}
