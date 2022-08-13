using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Auth;
using SiteManagement.Business.Configuration.Extensions;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Configuration.Validator.FluentValidation.Site;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Site;
using SiteManagement.Model.Entities;
using SiteManagement.Model.Enums;
using System;

namespace SiteManagement.Business.Concrete
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IBlockRepository _blockRepository;
        private readonly IFlatRepository _flatRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SiteService(ISiteRepository siteRepository, IUserRepository userRepository, IBlockRepository blockRepository, IFlatRepository flatRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _blockRepository = blockRepository;
            _flatRepository = flatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public CommandResponse SiteRegister(AddSiteDto dto)
        {
            try
            {
                var validator = new AddSiteDtoValidator();
                validator.Validate(dto).ThrowIfException();

                byte[] passwordHash, passwordSalt;
                HashHelper.CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);

                // Site kaydı
                var siteEntity = _mapper.Map<SiteEntity>(dto);
                _siteRepository.Add(siteEntity);
                _siteRepository.SaveChanges();

                // Blok ve Daire kaydı
                for (int i = 0; i < dto.NumberOfBlock; i++)
                {
                    var blockEntity = new BlockEntity
                    {
                        Name = $"{i + 1}. Blok",
                        SiteId = siteEntity.Id,
                    };

                    _blockRepository.Add(blockEntity);
                    _blockRepository.SaveChanges();

                    for (int j = 0; j < dto.NumberOfFloors; j++)
                    {
                        var flatEntity = new FlatEntity
                        {
                            BlockId = blockEntity.Id,
                            FlatTypeId = 3,
                            Floor = j,
                            No = $"{j + 1} Numara"
                        };

                        _flatRepository.Add(flatEntity);
                        _flatRepository.SaveChanges();
                    }
                }

                // Kullanıcı Kaydı
                var userEntity = new UserEntity
                {
                    Name = dto.UserName,
                    Surname = dto.UserSurname,
                    Phone = dto.UserPhone,
                    Email = dto.UserEmail,
                    UserRole = UserRoleEnum.Manager,
                    IdentificationNumber = dto.IdentificationNumber,
                    FlatId = 1
                };

                userEntity.UserPassword = new UserPasswordEntity()
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                _userRepository.Add(userEntity);
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
