using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Message;

namespace SiteManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService MessageService)
        {
            _messageService = MessageService;
        }

        [HttpPost]
        public IActionResult Add(AddMessageDto request)
        {
            return Ok(_messageService.Add(request));
        }

        [HttpPut]
        public IActionResult Update(UpdateMessageDto dto)
        {
            return Ok(_messageService.Update(dto));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_messageService.Delete(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_messageService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_messageService.Get(id));
        }
    }
}
