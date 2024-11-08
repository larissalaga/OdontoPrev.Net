using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationOdontoPrev.Models
{
    [Table("T_OPBD_ANALISE_RAIO_X")]
    public class AnaliseRaioX
    {
        [Key]
        [Required]        
        [Column("id_analise_raio_x")]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnaliseRaioX { get; set; }

        [Required]
        [Column("ds_analise_raio_x")]
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