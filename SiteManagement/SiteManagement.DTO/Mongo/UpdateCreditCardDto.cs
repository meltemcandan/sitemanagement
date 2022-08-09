namespace SiteManagement.DTO.Mongo
{
    public class UpdateCreditCardDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
    }
}
