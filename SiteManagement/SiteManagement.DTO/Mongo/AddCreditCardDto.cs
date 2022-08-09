namespace SiteManagement.DTO.Mongo
{
    public class AddCreditCardDto
    {
        public string CustomerName { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
    }
}
