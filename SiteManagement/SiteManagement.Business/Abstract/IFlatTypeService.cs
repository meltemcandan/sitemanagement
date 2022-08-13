using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.FlatType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Abstract
{
    public interface IFlatTypeService
    {
        CommandResponse Add(AddFlatTypeDto dto);

        CommandResponse Update(UpdateFlatTypeDto dto);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();
    }
}
