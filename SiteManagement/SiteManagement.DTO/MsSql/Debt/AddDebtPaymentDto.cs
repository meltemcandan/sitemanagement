using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.MsSql.Debt
{
    public class AddDebtPaymentDto
    {
        public int DebtId { get; set; }

        public string CardNumber { get; set; }

        public string CustomerName { get; set; }

        public int ExpireMonth { get; set; }

        public int ExpireYear { get; set; }
    }
}
