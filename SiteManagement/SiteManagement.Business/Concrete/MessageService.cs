using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Message;
using SiteManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository MessageRepository, IMapper mapper)
        {
            _messageRepository = MessageRepository;
            _mapper = mapper;
        }

        public CommandResponse Add(AddMessageDto dto)
        {
            try
            {
                var response = _messageRepository.Add(_mapper.Map<MessageEntity>(dto));

                _messageRepository.SaveChanges();

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

        public CommandResponse Update(UpdateMessageDto dto)
        {
            try
            {
                var response = _messageRepository.Update(_mapper.Map<MessageEntity>(dto));

                _messageRepository.SaveChanges();

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
                var entity = _messageRepository.Get(x => x.Id == id);

                _messageRepository.Delete(entity);

                _messageRepository.SaveChanges();

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
                var entity = _messageRepository.Get(x => x.Id == id);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Blok getirildi",
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
                var entities = _messageRepository.GetAll();


                return new CommandResponse
                {
                    Status = true,
                    Message = "Bloklar getirildi",
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
