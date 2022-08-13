using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Block;
using SiteManagement.Model.Enums;
using SiteManagement.WebApi.Configuration.Filters.Auth;

namespace SiteManagement.WebApi.Controllers
{
    [Authorize]
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
        [Permission(PermissionEnum.BlockPost)]
        public IActionResult Add(AddBlockDto request)
        {
            return Ok(_blockService.Add(request));
        }

        [HttpPut]
        [Permission(PermissionEnum.BlockPut)]
        public IActionResult Update(UpdateBlockDto dto)
        {
            return Ok(_blockService.Update(dto));
        }

        [HttpDelete]
        [Permission(PermissionEnum.BlockDelete)]
        public IActionResult Delete(int id)
        {
            return Ok(_blockService.Delete(id));
        }

        [HttpGet]
        [Permission(PermissionEnum.BlockGet)]
        public IActionResult GetAll()
        {
            return Ok(_blockService.GetAll());
        }

        [HttpGet("GetById")]
        [Permission(PermissionEnum.BlockGetById)]
        public IActionResult GetById(int id)
        {
            return Ok(_blockService.Get(id));
        }
    }
}
