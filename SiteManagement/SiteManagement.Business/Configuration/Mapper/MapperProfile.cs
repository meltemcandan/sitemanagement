using AutoMapper;
using SiteManagement.DTO.Block;
using SiteManagement.DTO.Debt;
using SiteManagement.DTO.Flat;
using SiteManagement.DTO.FlatType;
using SiteManagement.DTO.Message;
using SiteManagement.DTO.Mongo;
using SiteManagement.DTO.User;
using SiteManagement.DTO.Site;
using SiteManagement.Model.Document;
using SiteManagement.Model.Entities;
using SiteManagement.DTO.MsSql.Debt;

namespace SiteManagement.Business.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddBlockDto, BlockEntity>();
            CreateMap<UpdateBlockDto, BlockEntity>();
            CreateMap<BlockEntity, BlockDto>();

            CreateMap<AddMultiDebtDto, BlockEntity>();
            CreateMap<PayDebtDto, DebtEntity>();
            CreateMap<AddDebtDto, DebtEntity>();
            CreateMap<AddDebtPaymentDto, AddCreditCardDto>();

            CreateMap<AddFlatDto, FlatEntity>();
            CreateMap<UpdateFlatDto, FlatEntity>();
            CreateMap<FlatEntity, FlatDto>();

            CreateMap<AddFlatTypeDto, FlatTypeEntity>();
            CreateMap<UpdateFlatTypeDto, FlatTypeEntity>();
            CreateMap<FlatTypeEntity, FlatTypeDto>();

            CreateMap<AddMessageDto, MessageEntity>();
            CreateMap<UpdateMessageDto, MessageEntity>();
            CreateMap<MessageEntity, MessageDto>();

            CreateMap<AddUserDto, UserEntity>();
            CreateMap<UpdateUserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<AddSiteDto, SiteEntity>();
            CreateMap<SiteEntity, SiteDto>();

            CreateMap<AddCreditCardDto, CreditCardEntity>(); 
        }
    }
}
