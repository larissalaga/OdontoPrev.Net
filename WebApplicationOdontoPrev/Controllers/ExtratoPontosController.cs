using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;
using System.Linq;
using static WebApplicationOdontoPrev.ViewModels.ExtratoPontosViewModel;

namespace WebApplicationOdontoPrev.Controllers
{
    public class ExtratoPontosController : Controller
    {
        private readonly IExtratoPontosRepository _extratoPontos;
        private readonly IPacienteRepository _paciente;
        private readonly IPlanoRepository _plano;

        private ExtratoPontosViewModel _extratoPontosViewModel;

        public ExtratoPontosController(
            IExtratoPontosRepository extratoPontos,
            IPacienteRepository paciente,
            IPlanoRepository plano
            )
        {
            _extratoPontos = extratoPontos;
            _paciente = paciente;
            _plano = plano;
        }

        public async Task<IActionResult> Index(int id)
        {
            var paciente = await _paciente.GetById(id);
            var plano = await _plano.GetById(paciente.IdPlano);
            var extratos = await _extratoPontos.GetById(paciente.IdPaciente);
            int totalPontos = await _extratoPontos.GetTotalPontosByPacienteId(paciente.IdPaciente);

            var _extratoPontosViewModel = new ExtratoPontosViewModel
            {
                IdPaciente = paciente.IdPaciente,
                NmPaciente = paciente.NmPaciente,
                NmPlano = plano.NmPlano,
                TotalPontos = totalPontos,

                ExtratoPontos = extratos.Select(x => new ExtratoPontosItemViewModel
                {
                    DtExtrato = x.DtExtrato,
                    NrNumeroPontos = x.NrNumeroPontos,
                    DsMovimentacao = x.DsMovimentacao
                }).ToList()
            };

            return View(_extratoPontosViewModel);
        }
    }
}
