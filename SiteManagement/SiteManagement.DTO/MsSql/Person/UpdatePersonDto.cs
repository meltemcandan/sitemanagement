using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.Person
{
    public class UpdatePersonDto
    {
        public int Id { get; set; }

        public int FlatId { get; set; }

        public int PersonTypeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdentificationNumber { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CarPlate { get; set; }
    }
}
