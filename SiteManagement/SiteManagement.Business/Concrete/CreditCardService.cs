using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Mongo;
using SiteManagement.Model.Document;
using System;

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
                _repository.Add(_mapper.Map<CreditCardEntity>(dto));

                return new CommandResponse
                {
                    Status = true,
                    Message = "Kredi kartı ile ödeme alındı."
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
