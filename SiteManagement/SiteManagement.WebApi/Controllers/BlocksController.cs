using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Block;

namespace SiteManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocksController : ControllerBase
    {
        private readonly IBlockService _blockService;

        public BlocksController(IBlockService blockService)
        {
            _blockService = blockService;
        }

        [HttpPost]
        public IActionResult Add(AddBlockDto request)
        {
            return Ok(_blockService.Add(request));
        }

        [HttpPut]
        public IActionResult Update(UpdateBlockDto dto)
        {
            return Ok(_blockService.Update(dto));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_blockService.Delete(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_blockService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_blockService.Get(id));
        }
    }
}
