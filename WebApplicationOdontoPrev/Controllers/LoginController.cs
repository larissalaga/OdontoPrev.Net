using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPacienteRepository _paciente;

        public LoginController(
            IPacienteRepository paciente
            )
        {
            _paciente = paciente;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ObterPaciente(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.NrCpf))
            {
                ModelState.AddModelError("NrCpf", "Insira UM cpf válido");
                return View("Index", model);
            }

            var paciente = await _paciente.GetByNrCpf(model.NrCpf);

            if (paciente == null)
            {
                ModelState.AddModelError("NrCpf", "Paciente não encontrado");
                return View("Index", model);
            }
            
            model.IdPaciente = paciente.IdPaciente;

            return View("Index", model);
        }

    }
}
