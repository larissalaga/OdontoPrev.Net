using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Dtos;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IRaioXRepository
    {
        Task<RaioX> Create(RaioXDtos raioX);
        Task<RaioX> Update(int id, RaioXDtos raioX);
        public void Delete(int id);
        Task<List<RaioX>> GetAll();
        Task<RaioX> GetById(int id);
    }
}
