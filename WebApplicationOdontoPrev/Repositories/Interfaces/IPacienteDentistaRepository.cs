using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IPacienteDentistaRepository
    {
        Task<PacienteDentista> Create(PacienteDentistaDtos pacienteDentista);
        public void Delete(int id_paciente, int id_dentista);
        Task<bool> DeleteByIdPaciente(int id_paciente);
        Task<List<PacienteDentista>> GetAll();
        Task<PacienteDentista> GetById(int id_paciente, int id_dentista);
        Task<List<PacienteDentista>> GetByPaciente(int id_paciente);        
    }
}
