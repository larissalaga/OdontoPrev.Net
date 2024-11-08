using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IPlanoRepository
    {
        Task<Plano> Create(PlanoDtos plano);
        Task<Plano> Update(int id, PlanoDtos plano);
        public void Delete(int id);
        Task<List<Plano>> GetAll();
        Task<Plano> GetById(int id);
        Task<Models.Plano> GetByDsCodigoPlano(string dsCodigoPlano);
    }
}
