using AcudirTestBackend.Data;
using AcudirTestBackend.Model;
using AcudirTestBackend.Model.DTO;
using AcudirTestBackend.Services;
using AcudirTestBackend.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcudirTestBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonService _personService;
        private readonly IMapper mapper;

        public PersonController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _personService = new PersonService(_context, mapper);
        }

        [HttpGet("{id}", Name = "Get")]
        public PersonDTO Get(int id)
        {
            var persona = _personService.GetById(id);
            return persona;
        }

        [HttpGet]
        public IEnumerable<PersonDTO> People()
        {
            var personas = _personService.GetAll();
            return personas;
        }

        [HttpGet]
        [ActionName("shuffle")]
        public PersonDTO shuffle()
        {
            var persona = _personService.GetAleatory();
            return persona;
        }

        [HttpDelete("{id}")]
        public bool delete(int id)
        {
            var resultado = _personService.Delete(id);
            return resultado;            
        }

    }
}
