using SiteManagement.Model.Enums;
using System.Collections.Generic;

namespace SiteManagement.WebApi.Configuration.Filters.Auth
{
    public static class RolePermission
    {
        public static List<PermissionEnum> ManagerPermissionList { get; set; } = new List<PermissionEnum>()
        {
            PermissionEnum.BlockPost, PermissionEnum.BlockPut, PermissionEnum.BlockDelete, PermissionEnum.BlockGet, PermissionEnum.BlockGetById,

            PermissionEnum.UserPost, PermissionEnum.UserPut, PermissionEnum.UserDelete, PermissionEnum.UserGet, PermissionEnum.UserGetById,

             PermissionEnum.FlatPost, PermissionEnum.FlatPut, PermissionEnum.FlatDelete, PermissionEnum.FlatGet, PermissionEnum.FlatGetById,

             PermissionEnum.MessagePost, PermissionEnum.MessagePut, PermissionEnum.MessageDelete, PermissionEnum.MessageGet, PermissionEnum.MessageGetById,

             PermissionEnum.DebtPost, PermissionEnum.AddDebtPayment, PermissionEnum.AddMultiDebt, PermissionEnum.GetPayListByUserId,
             PermissionEnum.GetDebtListByUserId
        };

        public static List<PermissionEnum> StandartUserPermissionList { get; set; } = new List<PermissionEnum>()
        {
            PermissionEnum.UserPut, PermissionEnum.UserGet,

            PermissionEnum.MessagePost, PermissionEnum.MessagePut, PermissionEnum.MessageDelete,  PermissionEnum.MessageGet, PermissionEnum.MessageGetById, PermissionEnum.MessageGetAllByUserId,

            PermissionEnum.AddDebtPayment, PermissionEnum.GetPayListByUserId, PermissionEnum.GetDebtListByUserId
        };
    }
}
