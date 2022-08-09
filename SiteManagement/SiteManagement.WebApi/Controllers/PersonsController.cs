using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Person;

namespace SiteManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService PersonService)
        {
            _personService = PersonService;
        }

        [HttpPost]
        public IActionResult Add(AddPersonDto request)
        {
            return Ok(_personService.Add(request));
        }

        [HttpPut]
        public IActionResult Update(UpdatePersonDto dto)
        {
            return Ok(_personService.Update(dto));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_personService.Delete(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_personService.Get(id));
        }
    }
}
