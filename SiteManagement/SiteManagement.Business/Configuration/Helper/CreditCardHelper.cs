using SiteManagement.DTO.Mongo;
using System.Collections.Generic;

namespace SiteManagement.Business.Configuration.Helper
{
    public static class CreditCardHelper
    {
        public static List<CreditCardDto> CardList { get; set; } = new List<CreditCardDto>()
        {
            new CreditCardDto() { CardNumber = "4030-4030-6050-6050", ExpireMonth = 01, ExpireYear = 2023 },
            new CreditCardDto() { CardNumber = "4030-4030-6050-6051", ExpireMonth = 01, ExpireYear = 2023 },
            new CreditCardDto() { CardNumber = "4030-4030-6050-6052", ExpireMonth = 01, ExpireYear = 2023 },
        };
    }
}
