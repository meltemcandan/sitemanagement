using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.FlatType
{
    public class UpdateFlatTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double NetM2 { get; set; }
    }
}
