using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Block;
using System.Collections.Generic;

namespace SiteManagement.Business.Abstract
{
    public interface IBlockService
    {
        CommandResponse Add(AddBlockDto dto);

        CommandResponse Update(UpdateBlockDto dto);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();
    }
}
