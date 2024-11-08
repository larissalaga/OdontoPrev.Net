using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.ViewModels
{
    public class GerenciarPacientesViewModel
    {
        public class PacienteDados
        {
            public Paciente Paciente { set; get; } = new Paciente();
            public Plano Plano { set; get; } = new Plano();
            public List<Dentista> Dentistas { set; get; } = new List<Dentista>();
        }
        public List<PacienteDados> Pacientes { set; get; } = new List<PacienteDados>();        
    }
}
