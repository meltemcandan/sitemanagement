using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Site;
using SiteManagement.Model.Entities;
using System;

namespace SiteManagement.Business.Concrete
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IBlockRepository _blockRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public SiteService(ISiteRepository siteRepository, IPersonRepository personRepository, IBlockRepository blockRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _blockRepository = blockRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public CommandResponse SiteRegister(AddSiteDto dto)
        {
            try
            {
                var siteEntity = _mapper.Map<SiteEntity>(dto);
                var personEntity = new PersonEntity
                {
                    Name = dto.PersonName,
                    Surname = dto.PersonSurname,
                    Phone = dto.PersonPhone,
                };

                _siteRepository.Add(siteEntity);
                _siteRepository.SaveChanges();

                var blockEntity = new BlockEntity
                {
                    Name = "A Block",
                    SiteId = siteEntity.Id,
                };
                _blockRepository.Add(blockEntity);
                _blockRepository.SaveChanges();

                personEntity.BlockId = blockEntity.Id;
                personEntity.IsManager = true;
                personEntity.IdentificationNumber = dto.IdentificationNumber;
                _personRepository.Add(personEntity);
                _blockRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Site açılışı yapıldı"
                };
            }
            catch (Exception ex)
            {
                return new CommandResponse
                {
                    Message = ex.Message
                };
            }
        }
    }
}
