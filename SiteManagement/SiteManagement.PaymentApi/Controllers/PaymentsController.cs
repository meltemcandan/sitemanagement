using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Mongo;

namespace SiteManagement.PaymentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public PaymentsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost]
        public IActionResult Add(AddCreditCardDto request)
        {
            return Ok(_creditCardService.Add(request));
        }
    }
}
