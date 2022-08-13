using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Flat;
using SiteManagement.Model.Enums;
using SiteManagement.WebApi.Configuration.Filters.Auth;

namespace SiteManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        private readonly IFlatService _flatService;

        public FlatsController(IFlatService FlatService)
        {
            _flatService = FlatService;
        }

        [HttpPost]
        [Permission(PermissionEnum.FlatPost)]
        public IActionResult Add(AddFlatDto request)
        {
            return Ok(_flatService.Add(request));
        }

        [HttpPut]
        [Permission(PermissionEnum.FlatPut)]
        public IActionResult Update(UpdateFlatDto dto)
        {
            return Ok(_flatService.Update(dto));
        }

        [HttpDelete]
        [Permission(PermissionEnum.FlatDelete)]
        public IActionResult Delete(int id)
        {
            return Ok(_flatService.Delete(id));
        }

        [HttpGet]
        [Permission(PermissionEnum.FlatGet)]
        public IActionResult GetAll()
        {
            return Ok(_flatService.GetAll());
        }

        [HttpGet("GetById")]
        [Permission(PermissionEnum.FlatGetById)]
        public IActionResult GetById(int id)
        {
            return Ok(_flatService.Get(id));
        }
    }
}
