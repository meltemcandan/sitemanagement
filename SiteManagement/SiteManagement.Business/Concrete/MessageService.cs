using AutoMapper;
using Microsoft.AspNetCore.Http;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Extensions;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Configuration.Validator.FluentValidation.Message;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Message;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly int _siteId;

        public MessageService(IMessageRepository MessageRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _messageRepository = MessageRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _siteId = Int32.Parse(_httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "SiteId")?.Value);
        }

        public CommandResponse Add(AddMessageDto dto)
        {
            try
            {
                var validator = new AddMessageDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var response = _messageRepository.Add(_mapper.Map<MessageEntity>(dto));

                _messageRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Mesaj kaydedildi"
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

        public CommandResponse Update(UpdateMessageDto dto)
        {
            try
            {
                var validator = new UpdateMessageDtoValidator();
                validator.Validate(dto).ThrowIfException();

                var entity = _messageRepository.Get(x => x.Id == dto.Id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.Subject = dto.Subject;
                entity.Text = dto.Text;
                var response = _messageRepository.Update(entity);

                _messageRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Mesaj güncellendi"
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
                var entity = _messageRepository.Get(x => x.Id == id && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.IsDeleted = true;
                _messageRepository.Update(entity);

                _messageRepository.SaveChanges();

                return new CommandResponse
                {
                    Status = true,
                    Message = "Mesaj silindi"
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
                var entity = _messageRepository.Get(x => x.Id == id && x.IsDeleted == false);

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
                    Message = "Mesaj getirildi",
                    Data = _mapper.Map<MessageDto>(entity)
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
                var entities = _messageRepository.GetAll(x => x.User.Flat.Block.SiteId == _siteId && x.IsDeleted == false);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Mesajlar getirildi",
                    Data = _mapper.Map<IEnumerable<MessageDto>>(entities)
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

        public CommandResponse GetAllByUserId(int userId)
        {
            try
            {
                var entities = _messageRepository.GetAll(x => x.UserId == userId && x.IsDeleted == false);


                return new CommandResponse
                {
                    Status = true,
                    Message = "Mesajlar getirildi",
                    Data = _mapper.Map<IEnumerable<MessageDto>>(entities)
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
