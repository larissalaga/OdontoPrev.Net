using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class CheckInRepository : ICheckInRepository
    {
        private DataContext _context;

        public CheckInRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Models.CheckIn> Create(CheckInDtos checkIn)
        {                            
            var newCheckIn = new Models.CheckIn
            {
                DtCheckIn = checkIn.DtCheckIn,
                IdPaciente = checkIn.IdPaciente,
                IdPergunta = checkIn.IdPergunta,
                IdResposta = checkIn.IdResposta
            };
            _context.CheckIn.Add(newCheckIn);
            await _context.SaveChangesAsync();
            return newCheckIn;
        }
        public async void Delete(int id_check_in)
        {
            var getCheckIn = await _context.CheckIn.FirstOrDefaultAsync(x => x.IdCheckIn == id_check_in);
            if (getCheckIn == null)
            {
                throw new Exception("CheckIn não encontrado.");
            }
            else
            {
                _context.CheckIn.Remove(getCheckIn);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Models.CheckIn>> GetAll()
        {
            var getCheckIn = await _context.CheckIn.ToListAsync();
            if (getCheckIn != null)
            {
                return getCheckIn;
            }
            else
            {
                throw new Exception("CheckIn não encontrado.");
            }
        }
        public async Task<Models.CheckIn> GetById(int id_check_in)
        {
            var getCheckIn = await _context.CheckIn.FirstOrDefaultAsync(x => x.IdCheckIn == id_check_in);
            if (getCheckIn != null)
            {
                return getCheckIn;
            }
            else
            {
                throw new Exception("CheckIn não encontrado.");
            }
        }
        public async Task<List<Models.CheckIn>> GetByIdPaciente(int idPaciente)
        {
            var getCheckInIdPaciente = await _context.CheckIn.Where(x => x.IdPaciente == idPaciente).ToListAsync();
            if (getCheckInIdPaciente != null)
            {
                return getCheckInIdPaciente;
            }
            else
            {
                throw new Exception("CheckIn não encontrado.");
            }
        }

        public async Task<Models.CheckIn> Update(int idCheckIn, CheckInDtos checkIn)
        {
            var getCheckIn = await _context.CheckIn.FirstOrDefaultAsync(x => x.IdCheckIn == idCheckIn);
            if (getCheckIn == null)
            {
                throw new Exception("CheckIn não encontrado.");
            }
            else
            {
                getCheckIn.DtCheckIn = checkIn.DtCheckIn;
                getCheckIn.IdPaciente = checkIn.IdPaciente;
                getCheckIn.IdPergunta = checkIn.IdPergunta;
                getCheckIn.IdResposta = checkIn.IdResposta;
                await _context.SaveChangesAsync();
                return getCheckIn;
            }
        }
    }
}
