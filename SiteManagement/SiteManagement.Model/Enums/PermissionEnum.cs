namespace SiteManagement.Model.Enums
{
    public enum PermissionEnum
    {
        BlockPost = 1,
        BlockPut = 2,
        BlockDelete = 3,
        BlockGet = 4,
        BlockGetById = 5,

        DebtPost = 10,
        AddMultiDebt = 11,
        AddDebtPayment = 12,
        GetPayListByUserId = 13,
        GetDebtListByUserId = 14,


        FlatPost = 20,
        FlatPut = 21,
        FlatDelete = 22,
        FlatGet = 23,
        FlatGetById = 24,

        FlatTypePost = 30,
        FlatTypePut = 31,
        FlatTypeDelete = 32,
        FlatTypeGet = 33,
        FlatTypeGetById = 34,

        MessagePost = 40,
        MessagePut = 41,
        MessageDelete = 42,
        MessageGet = 43,
        MessageGetById = 44,
        MessageGetAllByUserId = 45,

        UserPost = 50,
        UserPut = 51,
        UserDelete = 52,
        UserGet = 53,
        UserGetById = 54
    }
}
