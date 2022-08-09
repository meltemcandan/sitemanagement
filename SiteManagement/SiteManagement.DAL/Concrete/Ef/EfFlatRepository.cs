using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfFlatRepository : EfBaseRepository<FlatEntity, SiteManagementDbContext>, IFlatRepository
    {
        public EfFlatRepository(SiteManagementDbContext context) : base(context)
        {

        }
    }
}
