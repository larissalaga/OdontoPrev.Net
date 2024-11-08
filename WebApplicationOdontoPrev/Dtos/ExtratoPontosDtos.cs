using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Dtos
{
    public class ExtratoPontosDtos
    {
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DtExtrato { get; set; }

        [Required]
        [MaxLength(10)]
        public int NrNumeroPontos { get; set; }

        [Required]
        [MaxLength(50)]
        public string DsMovimentacao { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public int IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
