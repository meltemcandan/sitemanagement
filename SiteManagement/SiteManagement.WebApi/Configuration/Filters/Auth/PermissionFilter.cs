using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SiteManagement.Model.Enums;
using System;
using System.Linq;
using System.Security.Claims;

namespace SiteManagement.WebApi.Configuration.Filters.Auth
{
    public class PermissionFilter : IAuthorizationFilter
    {
        private readonly PermissionEnum _permission;

        public PermissionFilter(PermissionEnum permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRoleId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            if (userRoleId == null)
                context.Result = new BadRequestResult();


            if (Int32.Parse(userRoleId.Value) == (int)UserRoleEnum.Manager)
            {
                if (!RolePermission.ManagerPermissionList.Any(x => x == _permission))
                {
                    context.Result = new ForbidResult("Bu metoda yetkiniz yok");
                }
            }
            else if (Int32.Parse(userRoleId.Value) == (int)UserRoleEnum.StandartUser)
            {
                if (!RolePermission.StandartUserPermissionList.Any(x => x == _permission))
                {
                    context.Result = new ForbidResult("Bu metoda yetkiniz yok");
                }
            }
            else if (Int32.Parse(userRoleId.Value) == (int)UserRoleEnum.Admin)
            {
                // Herşeye yetkisi var
            }
        }
    }
}
