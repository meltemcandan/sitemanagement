using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Helper;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Mongo;
using SiteManagement.Model.Document;
using System;
using System.Linq;

namespace SiteManagement.Business.Concrete
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCartRepository _repository;

        private readonly IMapper _mapper;

        public CreditCardService(ICreditCartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CommandResponse Add(AddCreditCardDto dto)
        {
            try
            {
                var creditCard = CreditCardHelper.CardList.Where(x => x.CardNumber == dto.CardNumber).SingleOrDefault();

                if (creditCard == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kredi kartı numaranız yanlış."
                    };
                }

                if (creditCard.ExpireYear != dto.ExpireYear)
                {
                    return new CommandResponse
                    {
                        Message = "Son kullanma yılı yanlış girilmiş."
                    };
                }

                if (creditCard.ExpireYear != dto.ExpireYear)
                {
                    return new CommandResponse
                    {
                        Message = "Son kullanma ayı yanlış girilmiş."
                    };
                }


                var entity = _mapper.Map<CreditCardEntity>(dto);
                entity.AddedDate = DateTime.Now;
               _repository.Add(entity);

                return new CommandResponse
                {
                    Status = true,
                    Message = $"Ödeme kredi kartı ile alındı.",
                    Data = entity.ObjectId
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
