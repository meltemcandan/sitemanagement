using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Flat;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;

namespace SiteManagement.Business.Concrete
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IMapper _mapper;

        public FlatService(IFlatRepository FlatRepository, IMapper mapper)
        {
            _flatRepository = FlatRepository;
            _mapper = mapper;
        }

        public CommandResponse Add(AddFlatDto dto)
        {
            try
            {
                var response = _flatRepository.Add(_mapper.Map<FlatEntity>(dto));

                _flatRepository.SaveChanges();

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

        public CommandResponse Update(UpdateFlatDto dto)
        {
            try
            {
                var response = _flatRepository.Update(_mapper.Map<FlatEntity>(dto));

                _flatRepository.SaveChanges();

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
                var entity = _flatRepository.Get(x => x.Id == id);

                _flatRepository.Delete(entity);

                _flatRepository.SaveChanges();

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
                var entity = _flatRepository.Get(x => x.Id == id);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Blok getirildi",
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
                var entities = _flatRepository.GetAll();


                return new CommandResponse
                {
                    Status = true,
                    Message = "Bloklar getirildi",
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
