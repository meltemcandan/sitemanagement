using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Site;

namespace SiteManagement.Business.Abstract
{
    public interface ISiteService
    {
        CommandResponse SiteRegister(AddSiteDto dto);
    }
}
