using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Integration.Abstract;
using SiteManagement.DTO.Debt;
using SiteManagement.DTO.Mongo;
using System;

namespace SiteManagement.Business.Concrete
{
    public class DebtService : IDebtService
    {
        private readonly IPaymentService _paymentService;

        public DebtService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public CommandResponse Add(AddDebtDto model)
        {
            try
            {
                var response = _paymentService.PayAsync(new AddCreditCardDto
                {
                    CardNumber = "12313123132",
                    CustomerName = "Meltem Candan",
                    ExpireMonth = 10,
                    ExpireYear = 2012
                }).Result;

                return new CommandResponse
                {
                    Status = true,
                    Message = response.Message
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
