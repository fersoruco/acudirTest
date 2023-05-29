using AcudirTestBackend.Model;
using AcudirTestBackend.Model.DTO;
using AutoMapper;

namespace AcudirTestBackend.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
        }
    }
}
