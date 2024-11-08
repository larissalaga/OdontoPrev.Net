using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPacienteRepository _paciente;

        private LoginViewModel _loginViewModel;

        public LoginController(
            IPacienteRepository paciente
            )
        {
            _paciente = paciente;
            _loginViewModel = new LoginViewModel();
        }

        [HttpGet]
        public IActionResult PesquisarPaciente(LoginViewModel model)
        {
            return View();
        }

    }
}
