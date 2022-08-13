using SiteManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.User
{
    public class AddUserDto
    {
        public int FlatId { get; set; }

        public int UserTypeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdentificationNumber { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CarPlate { get; set; }

        public UserRoleEnum UserRole { get; set; }
    }
}
