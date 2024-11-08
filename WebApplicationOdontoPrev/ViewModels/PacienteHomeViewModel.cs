namespace WebApplicationOdontoPrev.ViewModels
{
    public class PacienteHomeViewModel
    {
        public int IdPaciente { get; set; }
        public string NmPaciente { get; set; } = string.Empty;
        public string NrCpf { get; set; } = string.Empty;
        public int IdPlano { get; set; }
        public string NmPlano { get; set; } = string.Empty;
        public DateOnly DtExtrato { get; set; }
        public int NrNumeroPontos { get; set; }
        public DateOnly DtCheckIn { get; set; }
        public int TotalPontos { get; set; }
    }
}
