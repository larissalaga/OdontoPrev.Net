using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOdontoPrev.Dtos
{
    public class PlanoDtos
    {
        [Required]
        [MaxLength(15)]
        public string DsCodigoPlano { get; set; } = string.Empty;

        [Required]
        [MaxLength(60)]
        public string NmPlano { get; set; } = string.Empty;
    }
}
