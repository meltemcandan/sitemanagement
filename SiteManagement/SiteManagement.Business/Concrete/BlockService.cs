using AutoMapper;
using Microsoft.AspNetCore.Http;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Extensions;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Configuration.Validator.FluentValidation.Block;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Block;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Business.Concrete
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;

        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly int _siteId;

        public BlockService(IBlockRepository blockRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _blockRepository = blockRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _siteId = Int32.Parse(_httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "SiteId")?.Value);
        }

        public CommandResponse Add(AddBlockDto dto)
        {
            try
            {
                var validator = new AddBlockDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _mapper.Map<BlockEntity>(dto);
                entity.SiteId = _siteId;
                var response = _blockRepository.Add(entity);

                _blockRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Blok kaydedildi"
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

        public CommandResponse Update(UpdateBlockDto dto)
        {
            try
            {
                var validator = new UpdateBlockDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _blockRepository.Get(x => x.Id == dto.Id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.Name = dto.Name;
                entity.NumberOfFloors = dto.NumberOfFloors;
                var response = _blockRepository.Update(entity);

                _blockRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Blok güncellendi"
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
                var entity = _blockRepository.Get(x => x.Id == id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.IsDeleted = true;
                _blockRepository.Update(entity);

                _blockRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Blok silindi"
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
                var entity = _blockRepository.Get(x => x.Id == id && x.IsDeleted == false);

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
                    Message = "Blok getirildi",
                    Data = _mapper.Map<BlockDto>(entity)
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
                var entities = _blockRepository.GetAll(x => x.SiteId == _siteId && x.IsDeleted == false);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Bloklar getirildi",
                    Data = _mapper.Map<IEnumerable<BlockDto>>(entities)
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
