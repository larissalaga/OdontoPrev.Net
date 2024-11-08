using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Dtos
{
    public class AnaliseRaioXDtos
    {
        [Required]
        public string DsAnaliseRaioX { get; set; } = string.Empty;

        [Required]
        [Column("dt_analise_raio_x")]
        [DataType(DataType.Date)]
        public DateOnly DtAnaliseRaioX { get; set; } 

        [Required]
        [ForeignKey("RaioX")]
        [MaxLength(20)]
        public int IdRaioX { get; set; }
        public RaioX? RaioX { get; set; }  
    }
}
