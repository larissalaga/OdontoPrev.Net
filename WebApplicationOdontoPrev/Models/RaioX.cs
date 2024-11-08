using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Reflection.Metadata;

namespace WebApplicationOdontoPrev.Models
{
    [Table("T_OPBD_RAIO_X")]
    public class RaioX
    {
        [Key]
        [Required]
        [Column("id_raio_x")]
        //[MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRaioX { get; set; }

        [Required]
        [Column("ds_raio_x")]
        [MaxLength(200)]
        public string DsRaioX { get; set; } = string.Empty;

        [Column("im_raio_x")]
        [AllowNull]
        public byte[]? ImRaioX { get; set; } = new byte[0];

        [Required]
        [Column("dt_data_raio_x")]
        [DataType(DataType.Date)]
        public DateOnly DtDataRaioX { get; set; }

        [Required]
        [ForeignKey("Paciente")]
        //[MaxLength(20)]
        public int IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }
    }
}