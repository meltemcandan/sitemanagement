namespace SiteManagement.DTO.Site
{
    public class AddSiteDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string IdentificationNumber { get; set; }
        
        public string UserEmail { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserPhone { get; set; }

        public string Password { get; set; }

        public string PasswordRepeat { get; set; }

        public int NumberOfBlock { get; set; }

        public int NumberOfFloors { get; set; }
    }
}
