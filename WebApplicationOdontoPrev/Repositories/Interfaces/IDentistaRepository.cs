using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IDentistaRepository
    {
        Task<Dentista> Create(DentistaDtos dentista);
        Task<Dentista> Update(string dsCro, DentistaDtos dentista);
        public void Delete(string dsCro);
        Task<List<Dentista>> GetAll();
        Task<Dentista> GetByDsCro(string dsCro);
        Task<Models.Dentista> GetById(int id);
        Task<List<Models.Dentista>> GetByIdList(List<int> id);
    }
}
