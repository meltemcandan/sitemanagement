using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Person;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;

namespace SiteManagement.Business.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository PersonRepository, IMapper mapper)
        {
            _personRepository = PersonRepository;
            _mapper = mapper;
        }

        public CommandResponse Add(AddPersonDto dto)
        {
            try
            {
                var response = _personRepository.Add(_mapper.Map<PersonEntity>(dto));

                _personRepository.SaveChanges();

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

        public CommandResponse Update(UpdatePersonDto dto)
        {
            try
            {
                var response = _personRepository.Update(_mapper.Map<PersonEntity>(dto));

                _personRepository.SaveChanges();

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
                var entity = _personRepository.Get(x => x.Id == id);

                _personRepository.Delete(entity);

                _personRepository.SaveChanges();

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
                var entity = _personRepository.Get(x => x.Id == id);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Blok getirildi",
                    Data = _mapper.Map<PersonDto>(entity)
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
                var entities = _personRepository.GetAll();


                return new CommandResponse
                {
                    Status = true,
                    Message = "Bloklar getirildi",
                    Data = _mapper.Map<IEnumerable<PersonDto>>(entities)
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
