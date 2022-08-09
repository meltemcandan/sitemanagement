using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Block;
using System.Collections.Generic;

namespace SiteManagement.Business.Abstract
{
    public interface IBlockService
    {
        CommandResponse Add(AddBlockDto model);

        CommandResponse Update(UpdateBlockDto model);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();
    }
}
