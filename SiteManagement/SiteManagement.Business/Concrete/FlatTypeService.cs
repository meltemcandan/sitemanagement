using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Extensions;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Configuration.Validator.FluentValidation.FlatType;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.FlatType;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;

namespace SiteManagement.Business.Concrete
{
    public class FlatTypeService : IFlatTypeService
    {
        private readonly IFlatTypeRepository _flatTypeRepository;

        private readonly IMapper _mapper;

        public FlatTypeService(IFlatTypeRepository flatTypeRepository, IMapper mapper)
        {
            _flatTypeRepository = flatTypeRepository;
            _mapper = mapper;
        }

        public CommandResponse Add(AddFlatTypeDto dto)
        {
            try
            {
                var validator = new AddFlatTypeDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _mapper.Map<FlatTypeEntity>(dto);
                var response = _flatTypeRepository.Add(entity);

                _flatTypeRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire tipi kaydedildi"
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

        public CommandResponse Update(UpdateFlatTypeDto dto)
        {
            try
            {
                var validator = new UpdateFlatTypeDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _flatTypeRepository.Get(x => x.Id == dto.Id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.Name = dto.Name;
                var response = _flatTypeRepository.Update(entity);

                _flatTypeRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire tipi güncellendi"
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
                var entity = _flatTypeRepository.Get(x => x.Id == id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.IsDeleted = true;
                _flatTypeRepository.Update(entity);

                _flatTypeRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire tipi silindi"
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
                var entity = _flatTypeRepository.Get(x => x.Id == id && x.IsDeleted == false);

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
                    Message = "Daire tipi getirildi",
                    Data = _mapper.Map<FlatTypeDto>(entity)
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
                var entities = _flatTypeRepository.GetAll(x => x.IsDeleted == false);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Daire tipleri getirildi",
                    Data = _mapper.Map<IEnumerable<FlatTypeDto>>(entities)
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
