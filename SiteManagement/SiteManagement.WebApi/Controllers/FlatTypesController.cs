using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.FlatType;

namespace SiteManagement.WebApi.Controllers
{
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
        public IActionResult Add(AddFlatTypeDto request)
        {
            return Ok(_flatTypeService.Add(request));
        }

        [HttpPut]
        public IActionResult Update(UpdateFlatTypeDto dto)
        {
            return Ok(_flatTypeService.Update(dto));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_flatTypeService.Delete(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_flatTypeService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_flatTypeService.Get(id));
        }
    }
}
