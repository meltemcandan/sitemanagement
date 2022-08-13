using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Message;
using SiteManagement.Model.Enums;
using SiteManagement.WebApi.Configuration.Filters.Auth;

namespace SiteManagement.WebApi.Controllers
{
    [Authorize]
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
        [Permission(PermissionEnum.MessagePost)]
        public IActionResult Add(AddMessageDto request)
        {
            return Ok(_messageService.Add(request));
        }

        [HttpPut]
        [Permission(PermissionEnum.MessagePut)]
        public IActionResult Update(UpdateMessageDto dto)
        {
            return Ok(_messageService.Update(dto));
        }

        [HttpDelete]
        [Permission(PermissionEnum.MessageDelete)]
        public IActionResult Delete(int id)
        {
            return Ok(_messageService.Delete(id));
        }

        [HttpGet]
        [Permission(PermissionEnum.MessageGet)]
        public IActionResult GetAll()
        {
            return Ok(_messageService.GetAll());
        }

        [HttpGet("GetById")]
        [Permission(PermissionEnum.MessageGetById)]
        public IActionResult GetById(int id)
        {
            return Ok(_messageService.Get(id));
        }

        [HttpGet("GetAllByUserId")]
        [Permission(PermissionEnum.MessageGetAllByUserId)]
        public IActionResult GetAllByUserId(int userId)
        {
            return Ok(_messageService.GetAllByUserId(userId));
        }
    }
}
