using System.Collections.Generic;

namespace SiteManagement.DTO.Debt
{
    public class AddMultiDebtDto
    {
        public List<int> UserIds { get; set; }

        public int YearId { get; set; }

        public List<int> MonthIds { get; set; }

        public double Price { get; set; }

        public int DebtTypeId { get; set; }
    }
}
