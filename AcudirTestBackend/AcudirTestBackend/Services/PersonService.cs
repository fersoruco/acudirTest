using AcudirTestBackend.Data;
using AcudirTestBackend.Model;
using AcudirTestBackend.Model.DTO;
using AcudirTestBackend.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AcudirTestBackend.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PersonDTO GetById(int id)
        {
            var persona = _context.Person.FirstOrDefault(x => x.Id == id);

            if (persona == null) return null;

            var personMaper = _mapper.Map<PersonDTO>(persona);

            return personMaper;
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            var list = _context.Person.ToList().Where(x => x.isDeleted == false).ToList();
            var listaMapper = _mapper.Map<List<Person>, List<PersonDTO>>(list);

            return listaMapper;

        }

        public PersonDTO GetAleatory()
        {
            var personAleatory = _context.Person.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
            var personMaper = _mapper.Map<PersonDTO>(personAleatory);
            return personMaper;
        }

        public bool Delete(int id)
        {
            var persona = _context.Person.FirstOrDefault(x => x.Id == id);
            if (persona != null)
            {
                persona.isDeleted = true;
                persona.modifiedDate = DateTime.Now;
                _context.Entry(persona).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
