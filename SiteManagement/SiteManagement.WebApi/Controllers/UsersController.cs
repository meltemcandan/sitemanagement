using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.User;
using SiteManagement.Model.Enums;
using SiteManagement.WebApi.Configuration.Filters.Auth;

namespace SiteManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Permission(PermissionEnum.UserPost)]
        public IActionResult Add(AddUserDto request)
        {
            return Ok(_userService.Add(request));
        }

        [HttpPut]
        [Permission(PermissionEnum.UserPut)]
        public IActionResult Update(UpdateUserDto dto)
        {
            return Ok(_userService.Update(dto));
        }

        [HttpDelete]
        [Permission(PermissionEnum.UserDelete)]
        public IActionResult Delete(int id)
        {
            return Ok(_userService.Delete(id));
        }

        [HttpGet]
        [Permission(PermissionEnum.UserGet)]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("GetById")]
        [Permission(PermissionEnum.UserGetById)]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.Get(id));
        }
    }
}
