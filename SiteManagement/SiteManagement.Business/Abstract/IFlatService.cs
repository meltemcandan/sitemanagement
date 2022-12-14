using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Flat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Abstract
{
    public interface IFlatService
    {
        CommandResponse Add(AddFlatDto dto);

        CommandResponse Update(UpdateFlatDto dto);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();
    }
}
