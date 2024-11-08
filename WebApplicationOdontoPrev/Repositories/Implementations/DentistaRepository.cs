using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class DentistaRepository : IDentistaRepository
    {
        private DataContext _context;

        public DentistaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Models.Dentista> Create(DentistaDtos dentista)
        {
            var getDentista = await _context.Dentista.FirstOrDefaultAsync(x => x.DsCro == dentista.DsCro);
            if (getDentista != null) {
                throw new Exception("Dentista já cadastrado.");
            }
            else
            {
                var newDentista = new Models.Dentista
                {
                    NmDentista = dentista.NmDentista,
                    NrTelefone = dentista.NrTelefone,
                    DsEmail = dentista.DsEmail,
                    DsDocIdentificacao = dentista.DsDocIdentificacao
                };
                _context.Dentista.Add(newDentista);
                await _context.SaveChangesAsync();
                return newDentista;
            }
        }

        public async void Delete(string dsCro)
        {
            var getDentista = await _context.Dentista.FirstOrDefaultAsync(x => x.DsCro == dsCro);
            if (getDentista == null)
            {
                throw new Exception("Dentista não encontrado.");
            }
            else
            {
                _context.Dentista.Remove(getDentista);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Models.Dentista>> GetAll()
        {
            var getDentista = await _context.Dentista.ToListAsync();
            if (getDentista != null)
            {
                return getDentista;
            }
            else
            {
                throw new Exception("Nenhum dentista encontrado.");
            }
        }

        public async Task<Models.Dentista> GetById(int id)
        {
            var getDentista = await _context.Dentista.FirstOrDefaultAsync(x => x.IdDentista == id);
            if (getDentista == null)
            {
                throw new Exception("Dentista não encontrado.");
            }
            else
            {
                return getDentista;
            }
        }

        public async Task<List<Models.Dentista>> GetByIdList(List<int> id)
        {
            var getDentista = await _context.Dentista.Where(x => id.Contains(x.IdDentista)).ToListAsync();
            if (getDentista == null)
            {
                throw new Exception("Dentista não encontrado.");
            }
            else
            {
                return getDentista;
            }
        }

        public async Task<Models.Dentista> GetByDsCro(string dsCro)
        {
            var getDentista = await _context.Dentista.FirstOrDefaultAsync(x => x.DsCro == dsCro);
            if (getDentista == null)
            {
                throw new Exception("Dentista não encontrado.");
            }
            else
            {
                return getDentista;
            }
        }

        public async Task<Models.Dentista> Update(string dsCro, DentistaDtos dentista)
        {
            var getDentista = await _context.Dentista.FirstOrDefaultAsync(x => x.DsCro == dsCro);
            if (getDentista == null)
            {
                throw new Exception("Dentista não encontrado.");
            }
            else
            {
                getDentista.NmDentista = dentista.NmDentista;
                getDentista.NrTelefone = dentista.NrTelefone;
                getDentista.DsEmail = dentista.DsEmail;
                getDentista.DsDocIdentificacao = dentista.DsDocIdentificacao;
                await _context.SaveChangesAsync();
                return getDentista;
            }
        }
    }
}
