using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Block;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;

namespace SiteManagement.Business.Concrete
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IMapper _mapper;

        public BlockService(IBlockRepository blockRepository, IMapper mapper)
        {
            _blockRepository = blockRepository;
            _mapper = mapper;
        }

        public CommandResponse Add(AddBlockDto dto)
        {
            try
            {
                var response = _blockRepository.Add(_mapper.Map<BlockEntity>(dto));

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
                var response = _blockRepository.Update(_mapper.Map<BlockEntity>(dto));

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
                var entity = _blockRepository.Get(x => x.Id == id);

                _blockRepository.Delete(entity);

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
                var entity = _blockRepository.Get(x => x.Id == id);

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
                var entities = _blockRepository.GetAll();


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
