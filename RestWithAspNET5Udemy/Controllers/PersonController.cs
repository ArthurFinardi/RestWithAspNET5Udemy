using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNET5Udemy.Data.VO;
using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Services;

namespace RestWithAspNET5Udemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }        
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Post ([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }





}
