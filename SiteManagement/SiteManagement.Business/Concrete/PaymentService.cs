using Newtonsoft.Json;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Mongo;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CommandResponse> Payment(AddCreditCardDto dto)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("PaymentApi");

                string strJson = JsonConvert.SerializeObject(dto);

                var httpContent = new StringContent(strJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("https://localhost:5021/api/payments", httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    return new CommandResponse
                    {
                        Message = "Kredi kartı ile ödeme alınırken bir hata oluştu."
                    };
                }

                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<CommandResponse>(content);

                return responseObj;
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
