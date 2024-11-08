using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class PacienteHomeController : Controller
    {
        private readonly IPacienteRepository _paciente;
        private readonly IPlanoRepository _plano;
        private readonly IExtratoPontosRepository _extratoPontos;
        private readonly ICheckInRepository _checkIn;

        private PacienteHomeViewModel _pacienteHomeViewModel;

        public PacienteHomeController(
            IPacienteRepository paciente,
            IPlanoRepository plano,
            IExtratoPontosRepository extratoPontos,
            ICheckInRepository checkIn
            )
        {
            _paciente = paciente;
            _plano = plano;
            _extratoPontos = extratoPontos;
            _checkIn = checkIn;
            _pacienteHomeViewModel = new PacienteHomeViewModel();
        }

        public async Task<IActionResult> Index()
        {
            string NrCpf = "18207586322";

            var paciente = await _paciente.GetByNrCpf(NrCpf);
            var plano = await _plano.GetById(paciente.IdPlano);
            var checkIn = await _checkIn.GetByIdPaciente(paciente.IdPaciente);
            int totalPontos = await _extratoPontos.GetTotalPontosByPacienteId(paciente.IdPaciente);

            var _pacienteHomeViewModel = new PacienteHomeViewModel
            {
                IdPaciente = paciente.IdPaciente,
                NmPaciente = paciente.NmPaciente,
                IdPlano = paciente.IdPlano,
                NmPlano = plano.NmPlano,
                TotalPontos = totalPontos
            };
     
            return View(_pacienteHomeViewModel);
        }
    }
}
