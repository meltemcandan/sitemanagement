using SiteManagement.Business.Configuration.Auth;
using SiteManagement.Business.Configuration.Response;

namespace SiteManagement.Business.Abstract
{
    public interface IAuthService
    {
        CommandResponse Login(string email, string password);
    }
}
