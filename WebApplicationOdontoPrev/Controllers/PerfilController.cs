using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class PerfilController : Controller
    {
        public readonly IPacienteRepository _paciente;
        public readonly IPlanoRepository _plano;

        private PerfilViewModel _perfilViewModel;

        public PerfilController(
            IPacienteRepository paciente,
            IPlanoRepository plano
            )
        {
            _paciente = paciente;
            _plano = plano;
            _perfilViewModel = new PerfilViewModel();
        }

        public async Task<IActionResult> Index(int id)
        {
            var paciente = await _paciente.GetById(id);
            var plano = await _plano.GetById(paciente.IdPlano);

            var _perfilViewModel = new PerfilViewModel
            {
                IdPaciente = paciente.IdPaciente,
                NmPaciente = paciente.NmPaciente,
                NrCpf = paciente.NrCpf,
                NmPlano = plano.NmPlano,
                DtNascimento = paciente.DtNascimento,
                DsSexo = paciente.DsSexo,
                NrTelefone = paciente.NrTelefone,
                DsEmail = paciente.DsEmail
            };
            return View(_perfilViewModel);
        }
    }
}
