using SiteManagement.Model.Document.Base;
using System;

namespace SiteManagement.Model.Document
{
    public class CreditCardEntity : DocumentBaseEntity
    {
        public string CustomerName { get; set; }

        public string CardNumber { get; set; }

        public int ExpireMonth { get; set; }

        public int ExpireYear { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
