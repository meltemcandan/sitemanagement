using AutoMapper;
using Microsoft.AspNetCore.Http;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Extensions;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Configuration.Validator.FluentValidation.Flat;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Flat;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Business.Concrete
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _flatRepository;

        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly int _siteId;

        public FlatService(IFlatRepository FlatRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _flatRepository = FlatRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _siteId = Int32.Parse(_httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "SiteId")?.Value);
        }

        public CommandResponse Add(AddFlatDto dto)
        {
            try
            {
                var validator = new AddFlatDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var response = _flatRepository.Add(_mapper.Map<FlatEntity>(dto));

                _flatRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire kaydedildi"
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

        public CommandResponse Update(UpdateFlatDto dto)
        {
            try
            {
                var validator = new UpdateFlatDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _flatRepository.Get(x => x.Id == dto.Id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.BlockId = dto.BlockId;
                entity.FlatTypeId = dto.FlatTypeId;
                entity.Floor = dto.Floor;
                entity.No = dto.No;
                _flatRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire güncellendi"
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

        public CommandResponse Delete(int id)
        {
            try
            {
                var entity = _flatRepository.Get(x => x.Id == id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.IsDeleted = true;
                _flatRepository.Update(entity);

                _flatRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire silindi"
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

        public CommandResponse Get(int id)
        {
            try
            {
                var entity = _flatRepository.Get(x => x.Id == id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire getirildi",
                    Data = _mapper.Map<FlatDto>(entity)
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

        public CommandResponse GetAll()
        {
            try
            {
                var entities = _flatRepository.GetAll(x => x.Block.SiteId == _siteId && x.IsDeleted == false);


                return new CommandResponse
                {
                    Status = true,
                    Message = "Dairelar getirildi",
                    Data = _mapper.Map<IEnumerable<FlatDto>>(entities)
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
