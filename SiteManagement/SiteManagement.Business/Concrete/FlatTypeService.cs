using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.FlatType;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var response = _flatTypeRepository.Add(_mapper.Map<FlatTypeEntity>(dto));

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
                var response = _flatTypeRepository.Update(_mapper.Map<FlatTypeEntity>(dto));

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
                var entity = _flatTypeRepository.Get(x => x.Id == id);

                _flatTypeRepository.Delete(entity);

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
                var entity = _flatTypeRepository.Get(x => x.Id == id);

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
                var entities = _flatTypeRepository.GetAll();


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
