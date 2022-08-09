using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DAL.Abstract
{
    public interface ISiteRepository : IEfBaseRepository<SiteEntity>
    {
    }
}
