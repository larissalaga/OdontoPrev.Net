using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class AnaliseRaioXRepository : IAnaliseRaioXRepository
    {
        private DataContext _context;

        public AnaliseRaioXRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Models.AnaliseRaioX> Create(AnaliseRaioXDtos analiseRaioX)
        {
            var getAnaliseRaioX = await _context.AnaliseRaioX.FirstOrDefaultAsync(x => x.IdRaioX == analiseRaioX.IdRaioX);
            if (getAnaliseRaioX != null)
            {
                throw new Exception("Análise de Raio-X já cadastrada.");
            }
            else
            {
                var newAnaliseRaioX = new Models.AnaliseRaioX
                {
                    DsAnaliseRaioX = analiseRaioX.DsAnaliseRaioX,
                    DtAnaliseRaioX = analiseRaioX.DtAnaliseRaioX,
                    IdRaioX = analiseRaioX.IdRaioX
                };
                _context.AnaliseRaioX.Add(newAnaliseRaioX);
                await _context.SaveChangesAsync();
                return newAnaliseRaioX;
            }

        }
        public async Task<bool> DeleteByIdRaioX(int raioX)
        {
            var getAnaliseRaioX = await _context.AnaliseRaioX.FirstOrDefaultAsync(x => x.IdRaioX == raioX);
            if (getAnaliseRaioX == null)
            {
                return true;
            }
            else
            {
                _context.AnaliseRaioX.Remove(getAnaliseRaioX);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        public async void Delete(int idRaioX)
        {
            var getAnaliseRaioX = await _context.AnaliseRaioX.FirstOrDefaultAsync(x => x.IdRaioX == idRaioX);
            if (getAnaliseRaioX == null)
            {
                throw new Exception("Análise de Raio-X não encontrada.");
            }
            else
            {
                _context.AnaliseRaioX.Remove(getAnaliseRaioX);
                await _context.SaveChangesAsync();
            }


        }

        public async Task<List<Models.AnaliseRaioX>> GetAll()
        {
            var getAnaliseRaioX = await _context.AnaliseRaioX.ToListAsync();
            if (getAnaliseRaioX != null)
            {
                return getAnaliseRaioX;
            }
            else
            {
                throw new Exception("Nenhuma análise de Raio-X encontrada.");
            }
        }

        public async Task<Models.AnaliseRaioX> GetById(int idRaioX)
        {
            var getAnaliseRaioX = await _context.AnaliseRaioX.FirstOrDefaultAsync(x => x.IdRaioX == idRaioX);
            if (getAnaliseRaioX == null)
                throw new Exception("Análise de Raio-X não encontrada.");
            else
                return getAnaliseRaioX;
        }

        public async Task<Models.AnaliseRaioX> Update(int idRaioX, AnaliseRaioXDtos analiseRaioX)
        {
            var getAnaliseRaioX = await _context.AnaliseRaioX.FirstOrDefaultAsync(x => x.IdRaioX == idRaioX);
            if (getAnaliseRaioX == null)
            {
                throw new Exception("Análise de Raio-X não encontrada.");
            }
            else
            {
                getAnaliseRaioX.DsAnaliseRaioX = analiseRaioX.DsAnaliseRaioX;
                getAnaliseRaioX.DtAnaliseRaioX = analiseRaioX.DtAnaliseRaioX;
                getAnaliseRaioX.IdRaioX = analiseRaioX.IdRaioX;
                await _context.SaveChangesAsync();
                return getAnaliseRaioX;
            }
        }
    }
}
