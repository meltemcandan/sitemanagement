using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.Business.Integration.Abstract;
using SiteManagement.DTO.Mongo;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SiteManagement.Business.Integration.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CommandResponse> PayAsync(AddCreditCardDto dto)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("PaymentApi");
                var httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("https://localhost:5021/api/payments", httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    return new CommandResponse
                    {
                        Message = "Kredi kartı ile ödeme alınırken bir hata oluştu."
                    };
                }

                return new CommandResponse
                {
                    Status = true,
                    Message = "Kredi kartı ile ödeme alındı 2"
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
