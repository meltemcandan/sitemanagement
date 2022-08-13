using Microsoft.AspNetCore.Mvc;
using SiteManagement.Model.Enums;

namespace SiteManagement.WebApi.Configuration.Filters.Auth
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(PermissionEnum permission) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}
