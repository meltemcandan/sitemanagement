using SiteManagement.DTO.Mongo;
using System.Collections.Generic;

namespace SiteManagement.Business.Configuration.Helper
{
    public static class CreditCardHelper
    {
        public static List<CreditCardDto> CardList { get; set; } = new List<CreditCardDto>()
        {
            new CreditCardDto() { CardNumber = "4030403060506050", ExpireMonth = 11, ExpireYear = 2023 },
            new CreditCardDto() { CardNumber = "4030403060506051", ExpireMonth = 11, ExpireYear = 2023 },
            new CreditCardDto() { CardNumber = "4030403060506052", ExpireMonth = 11, ExpireYear = 2023 },
        };
    }
}
