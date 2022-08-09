using AutoMapper;
using SiteManagement.DTO.Block;
using SiteManagement.DTO.Debt;
using SiteManagement.DTO.Flat;
using SiteManagement.DTO.FlatType;
using SiteManagement.DTO.Message;
using SiteManagement.DTO.Mongo;
using SiteManagement.DTO.Person;
using SiteManagement.DTO.Site;
using SiteManagement.Model.Document;
using SiteManagement.Model.Entities;

namespace SiteManagement.Business.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddBlockDto, BlockEntity>();
            CreateMap<UpdateBlockDto, BlockEntity>();
            CreateMap<BlockEntity, BlockDto>();

            CreateMap<AddDebtDto, BlockEntity>();
            CreateMap<UpdateDebtDto, DebtEntity>();
            CreateMap<DebtEntity, DebtDto>();

            CreateMap<AddFlatDto, FlatEntity>();
            CreateMap<UpdateFlatDto, FlatEntity>();
            CreateMap<FlatEntity, FlatDto>();

            CreateMap<AddFlatTypeDto, FlatTypeEntity>();
            CreateMap<UpdateFlatTypeDto, FlatTypeEntity>();
            CreateMap<FlatTypeEntity, FlatTypeDto>();

            CreateMap<AddMessageDto, MessageEntity>();
            CreateMap<UpdateMessageDto, MessageEntity>();
            CreateMap<MessageEntity, MessageDto>();

            CreateMap<AddPersonDto, PersonEntity>();
            CreateMap<UpdatePersonDto, PersonEntity>();
            CreateMap<PersonEntity, PersonDto>();

            CreateMap<AddSiteDto, SiteEntity>();
            CreateMap<SiteEntity, SiteDto>();

            CreateMap<AddCreditCardDto, CreditCardEntity>(); 
        }
    }
}
