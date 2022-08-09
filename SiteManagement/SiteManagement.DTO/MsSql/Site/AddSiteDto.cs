using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.Site
{
    public class AddSiteDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string IdentificationNumber { get; set; }
        
        public string PersonName { get; set; }

        public string PersonSurname { get; set; }

        public string PersonPhone { get; set; }
    }
}
