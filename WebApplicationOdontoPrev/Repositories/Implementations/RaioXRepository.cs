using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class RaioXRepository : IRaioXRepository
    {
        private DataContext _context;
        public RaioXRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Models.RaioX> Create(RaioXDtos raioX)
        {
            var newRaioX = new Models.RaioX
            {
                DsRaioX = raioX.DsRaioX,
                ImRaioX = raioX.ImRaioX,
                DtDataRaioX = raioX.DtDataRaioX,
                IdPaciente = raioX.IdPaciente
            };
            _context.RaioX.Add(newRaioX);
            await _context.SaveChangesAsync();
            return newRaioX;
        }

        public async void Delete(int idRaioX)
        {
            var getRaioX = await _context.RaioX.FirstOrDefaultAsync(x => x.IdRaioX == idRaioX);
            if (getRaioX == null)
            {
                throw new Exception("RaioX não encontrado.");
            }
            else
            {
                _context.RaioX.Remove(getRaioX);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Models.RaioX>> GetAll()
        {
            var getRaioX = await _context.RaioX.ToListAsync();
            if (getRaioX != null)
            {
                return getRaioX;
            }
            else
            {
                throw new Exception("Nenhum raioX encontrado.");
            }
        }

        public async Task<Models.RaioX> GetById(int idRaioX)
        {
            var getRaioX = await _context.RaioX.FirstOrDefaultAsync(x => x.IdRaioX == idRaioX);
            if (getRaioX == null)
            {
                throw new Exception("RaioX não encontrado.");
            }
            else
            {
                return getRaioX;
            }
        }

        public async Task<Models.RaioX> Update(int idRaioX, RaioXDtos raioX)
        {
            var getRaioX = await _context.RaioX.FirstOrDefaultAsync(x => x.IdRaioX == idRaioX);
            if (getRaioX == null)
            {
                throw new Exception("RaioX não encontrado.");
            }
            else
            {
                getRaioX.DsRaioX = raioX.DsRaioX;
                getRaioX.ImRaioX = raioX.ImRaioX;
                getRaioX.DtDataRaioX = raioX.DtDataRaioX;
                getRaioX.IdPaciente = raioX.IdPaciente;
                await _context.SaveChangesAsync();
                return getRaioX;
            }
        }

    }
}
