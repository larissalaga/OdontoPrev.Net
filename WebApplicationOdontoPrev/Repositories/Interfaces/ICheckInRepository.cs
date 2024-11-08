using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface ICheckInRepository
    {
        Task<CheckIn> Create(CheckInDtos checkIn);
        public void Delete(int id);
        Task<List<CheckIn>> GetAll();
        Task<CheckIn> GetById(int id);
        Task<List<CheckIn>> GetByIdPaciente(int idPaciente);
    }
}
