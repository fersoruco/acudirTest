using AcudirTestBackend.Model;
using AcudirTestBackend.Model.DTO;

namespace AcudirTestBackend.Services.Interfaces
{
    public interface IPersonService
    {
        PersonDTO GetById(int id);
        IEnumerable<PersonDTO> GetAll();
        PersonDTO GetAleatory();
        bool Delete(int id);
    }
}
