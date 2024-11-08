using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        
        public DbSet<AnaliseRaioX> AnaliseRaioX { get; set; }
        public DbSet<CheckIn> CheckIn { get; set; }
        public DbSet<Dentista> Dentista { get; set; }
        public DbSet<ExtratoPontos> ExtratoPontos { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Perguntas> Perguntas { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<RaioX> RaioX { get; set; }
        public DbSet<Respostas> Respostas { get; set; }
        public DbSet<PacienteDentista> PacienteDentista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("SEQ_T_OPBD_PLANO").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_DENTISTA").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_PERGUNTAS").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_PACIENTE").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_EXTRATO_PONTOS").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_RESPOSTAS").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_CHECK_IN").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_RAIO_X").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_T_OPBD_ANALISE_RAIO_X").StartsAt(1).IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }

    }
    
}

