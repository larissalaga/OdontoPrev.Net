using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class PlanoRepository : IPlanoRepository
    {
        private DataContext _context;
        public PlanoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Models.Plano> Create(PlanoDtos plano)
        {
            var newPlano = new Models.Plano
            {
                NmPlano = plano.NmPlano,
                DsCodigoPlano = plano.DsCodigoPlano
            };
            _context.Plano.Add(newPlano);
            await _context.SaveChangesAsync();
            return newPlano;
        }

        public async void Delete(int idPlano)
        {
            var getPlano = await _context.Plano.FirstOrDefaultAsync(x => x.IdPlano == idPlano);
            if (getPlano == null)
            {
                throw new Exception("Plano não encontrado.");
            }
            else
            {
                _context.Plano.Remove(getPlano);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Models.Plano>> GetAll()
        {
            var getPlano = await _context.Plano.ToListAsync();
            if (getPlano != null)
            {
                return getPlano;
            }
            else
            {
                throw new Exception("Nenhum plano encontrado.");
            }
        }

        public async Task<Models.Plano> GetById(int idPlano)
        {
            var getPlano = await _context.Plano.FirstOrDefaultAsync(x => x.IdPlano == idPlano);
            if (getPlano == null)
            {
                throw new Exception("Plano não encontrado.");
            }
            return getPlano;
        }
        public async Task<Models.Plano> GetByDsCodigoPlano(string dsCodigoPlano)
        {
            var getPlano = await _context.Plano.FirstOrDefaultAsync(x => x.DsCodigoPlano == dsCodigoPlano);
            if (getPlano == null)
            {
                throw new Exception("Plano não encontrado.");
            }
            return getPlano;
        }
        public async Task<Models.Plano> Update(int idPlano, PlanoDtos plano)
        {
            var getPlano = await _context.Plano.FirstOrDefaultAsync(x => x.IdPlano == idPlano);
            if (getPlano == null)
            {
                throw new Exception("Plano não encontrado.");
            }
            else
            {
                getPlano.NmPlano = plano.NmPlano;
                getPlano.DsCodigoPlano = plano.DsCodigoPlano;
                await _context.SaveChangesAsync();
                return getPlano;
            }
        }
    }
}
