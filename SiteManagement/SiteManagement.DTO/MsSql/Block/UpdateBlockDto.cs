using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.Block
{
    public class UpdateBlockDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfFloors { get; set; }

        public int NumberOfFlatsOnTheFloor { get; set; }
    }
}
