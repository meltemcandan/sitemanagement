using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.Flat
{
    public class AddFlatDto
    {
        public int BlockId { get; set; }

        public int FlatTypeId { get; set; }

        public int Floor { get; set; }

        public string No { get; set; }
    }
}
