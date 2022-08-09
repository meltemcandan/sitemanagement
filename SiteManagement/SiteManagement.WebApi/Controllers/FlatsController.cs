using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Flat;

namespace SiteManagement.WebApi.Controllers
{
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
        public IActionResult Add(AddFlatDto request)
        {
            return Ok(_flatService.Add(request));
        }

        [HttpPut]
        public IActionResult Update(UpdateFlatDto dto)
        {
            return Ok(_flatService.Update(dto));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_flatService.Delete(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_flatService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_flatService.Get(id));
        }
    }
}
