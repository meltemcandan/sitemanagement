using AutoMapper;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.Debt;
using SiteManagement.DTO.Mongo;
using SiteManagement.DTO.MsSql.Debt;
using SiteManagement.Model.Entities;
using SiteManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManagement.Business.Concrete
{
    public class DebtService : IDebtService
    {
        private readonly IPaymentService _paymentService;

        private readonly IDebtRepository _debtRepository;

        private readonly IMapper _mapper;

        public DebtService(IDebtRepository debtRepository, IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _debtRepository = debtRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse> AddDebtPayment(AddDebtPaymentDto dto)
        {
            try
            {
                var addCreditCardDto = _mapper.Map<AddCreditCardDto>(dto);

                var response = await _paymentService.Payment(addCreditCardDto);

                if (!response.Status)
                {
                    return response;
                }

                PayDebt(new PayDebtDto
                {
                    DebtId = dto.DebtId,
                });

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

        public CommandResponse AddMultiDebt(AddMultiDebtDto dto)
        {
            try
            {

                foreach (var userId in dto.UserIds)
                {
                    foreach (var monthId in dto.MonthIds)
                    {
                        var response = AddDebt(new AddDebtDto
                        {
                            Price = dto.Price,
                            DebtTypeId = dto.DebtTypeId,
                            YearId = dto.YearId,
                            MonthId = monthId,
                            UserId = userId
                        });
                    }
                }

                return new CommandResponse
                {
                    Status = true,
                    Message = "Toplu borçlanma yapıldı"
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

        public CommandResponse AddDebt(AddDebtDto dto)
        {
            try
            {
                var response = _debtRepository.Add(_mapper.Map<DebtEntity>(dto));

                _debtRepository.SaveChanges();


                return new CommandResponse
                {
                    Status = true,
                    Message = "Borç kaydedildi"
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

        public CommandResponse PayDebt(PayDebtDto dto)
        {
            try
            {
                var entity = _debtRepository.Get(x => x.Id == dto.DebtId && x.IsDeleted == false);

                if (entity == null)
                {
                    return new CommandResponse
                    {
                        Message = "Kayıt bulunamadı."
                    };
                }

                entity.PaymentDate = DateTime.Now;
                entity.IsItPaid = true;
                entity.PaymentType = PaymentTypeEnum.CreditCart;

                var response = _debtRepository.Add(_mapper.Map<DebtEntity>(dto));

                _debtRepository.SaveChanges();


                return new CommandResponse
                {
                    Status = true,
                    Message = "Borç ödendi"
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

        public CommandResponse GetDebtListByUserId(int userId)
        {
            try
            {
                var entities = _debtRepository.GetAll(x => x.IsDeleted == false && x.UserId == userId && x.IsItPaid == false && x.IsDeleted == false);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Borç listesi getirildi",
                    Data = _mapper.Map<IEnumerable<DebtDto>>(entities)
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

        public CommandResponse GetPayListByUserId(int userId)
        {
            try
            {
                var entities = _debtRepository.GetAll(x => x.IsDeleted == false && x.UserId == userId && x.IsItPaid == true && x.IsDeleted == false);

                return new CommandResponse
                {
                    Status = true,
                    Message = "Ödeme listesi getirildi",
                    Data = _mapper.Map<IEnumerable<DebtDto>>(entities)
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
