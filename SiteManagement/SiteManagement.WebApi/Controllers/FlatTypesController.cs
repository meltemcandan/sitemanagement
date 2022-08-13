using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.FlatType;
using SiteManagement.Model.Enums;
using SiteManagement.WebApi.Configuration.Filters.Auth;

namespace SiteManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FlatTypesController : ControllerBase
    {
        private readonly IFlatTypeService _flatTypeService;

        public FlatTypesController(IFlatTypeService FlatTypeService)
        {
            _flatTypeService = FlatTypeService;
        }

        [HttpPost]
        [Permission(PermissionEnum.FlatTypePost)]
        public IActionResult Add(AddFlatTypeDto request)
        {
            return Ok(_flatTypeService.Add(request));
        }

        [HttpPut]
        [Permission(PermissionEnum.FlatTypePut)]
        public IActionResult Update(UpdateFlatTypeDto dto)
        {
            return Ok(_flatTypeService.Update(dto));
        }

        [HttpDelete]
        [Permission(PermissionEnum.FlatTypeDelete)]
        public IActionResult Delete(int id)
        {
            return Ok(_flatTypeService.Delete(id));
        }

        [HttpGet]
        [Permission(PermissionEnum.FlatTypeGet)]
        public IActionResult GetAll()
        {
            return Ok(_flatTypeService.GetAll());
        }

        [HttpGet("GetById")]
        [Permission(PermissionEnum.FlatTypeGetById)]
        public IActionResult GetById(int id)
        {
            return Ok(_flatTypeService.Get(id));
        }
    }
}
