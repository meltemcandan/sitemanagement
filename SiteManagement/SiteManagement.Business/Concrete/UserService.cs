using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Extensions;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Configuration.Validator.FluentValidation.User;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.User;
using SiteManagement.Model.Entities;
using SiteManagement.Model.Enums;
using System;
using System.Collections.Generic;

namespace SiteManagement.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public CommandResponse Add(AddUserDto dto)
        {
            try
            {
                var validator = new AddUserDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _mapper.Map<UserEntity>(dto);
                var response = _userRepository.Add(entity);

                _userRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Kullanıcı kaydedildi"
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

        public CommandResponse Update(UpdateUserDto dto)
        {
            try
            {
                var validator = new UpdateUserDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _userRepository.Get(x => x.Id == dto.Id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.Name = dto.Name;
                entity.Surname = dto.Surname;
                entity.Phone = dto.Phone;
                entity.CarPlate = dto.CarPlate;
                var response = _userRepository.Update(entity);

                _userRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Kullanıcı güncellendi"
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
                var entity = _userRepository.Get(x => x.Id == id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.IsDeleted = true;
                _userRepository.Update(entity);

                _userRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Kullanıcı silindi"
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
                var entity = _userRepository.Get(x => x.Id == id && x.IsDeleted == false);

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
                    Message = "Kullanıcı getirildi",
                    Data = _mapper.Map<UserDto>(entity)
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
                var entities = _userRepository.GetAll(x => x.IsDeleted == false);


                return new CommandResponse
                {
                    Status = true,
                    Message = "Kullanıcılar getirildi",
                    Data = _mapper.Map<IEnumerable<UserDto>>(entities)
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
