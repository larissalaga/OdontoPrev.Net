﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using WebApplicationOdontoPrev.Data;

#nullable disable

namespace WebApplicationOdontoPrev.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("SEQ_T_OPBD_ANALISE_RAIO_X");

            modelBuilder.HasSequence("SEQ_T_OPBD_CHECK_IN");

            modelBuilder.HasSequence("SEQ_T_OPBD_DENTISTA");

            modelBuilder.HasSequence("SEQ_T_OPBD_EXTRATO_PONTOS");

            modelBuilder.HasSequence("SEQ_T_OPBD_PACIENTE");

            modelBuilder.HasSequence("SEQ_T_OPBD_PERGUNTAS");

            modelBuilder.HasSequence("SEQ_T_OPBD_PLANO");

            modelBuilder.HasSequence("SEQ_T_OPBD_RAIO_X");

            modelBuilder.HasSequence("SEQ_T_OPBD_RESPOSTAS");

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.AnaliseRaioX", b =>
                {
                    b.Property<int>("IdAnaliseRaioX")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_analise_raio_x")
                        .HasDefaultValueSql("SEQ_T_OPBD_ANALISE_RAIO_X.NEXTVAL");

                    b.Property<string>("DsAnaliseRaioX")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_analise_raio_x");

                    b.Property<string>("DtAnaliseRaioX")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_analise_raio_x");

                    b.Property<int>("IdRaioX")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_raio_x");

                    b.HasKey("IdAnaliseRaioX");

                    b.HasIndex("IdRaioX");

                    b.ToTable("T_OPBD_ANALISE_RAIO_X");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.CheckIn", b =>
                {
                    b.Property<int>("IdCheckIn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_check_in")
                        .HasDefaultValueSql("SEQ_T_OPBD_CHECK_IN.NEXTVAL");

                    b.Property<string>("DtCheckIn")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_check_in");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente");

                    b.Property<int>("IdPergunta")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_pergunta");

                    b.Property<int>("IdResposta")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_resposta");

                    b.HasKey("IdCheckIn");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdPergunta");

                    b.HasIndex("IdResposta");

                    b.ToTable("T_OPBD_CHECK_IN");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.Dentista", b =>
                {
                    b.Property<int>("IdDentista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_dentista")
                        .HasDefaultValueSql("SEQ_T_OPBD_DENTISTA.NEXTVAL");

                    b.Property<string>("DsCro")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("ds_cro");

                    b.Property<string>("DsDocIdentificacao")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("NVARCHAR2(14)")
                        .HasColumnName("ds_doc_identificacao");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("NVARCHAR2(70)")
                        .HasColumnName("ds_email");

                    b.Property<string>("NmDentista")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("nm_dentista");

                    b.Property<string>("NrTelefone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("nr_telefone");

                    b.HasKey("IdDentista");

                    b.ToTable("T_OPBD_DENTISTA");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.ExtratoPontos", b =>
                {
                    b.Property<int>("IdExtratoPontos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_extrato_pontos")
                        .HasDefaultValueSql("SEQ_T_OPBD_EXTRATO_PONTOS.NEXTVAL");

                    b.Property<string>("DsMovimentacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("ds_movimentacao");

                    b.Property<string>("DtExtrato")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_extrato");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente");

                    b.Property<int>("NrNumeroPontos")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("nr_numero_pontos");

                    b.HasKey("IdExtratoPontos");

                    b.HasIndex("IdPaciente");

                    b.ToTable("T_OPBD_EXTRATO_PONTOS");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente")
                        .HasDefaultValueSql("SEQ_T_OPBD_PACIENTE.NEXTVAL");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("NVARCHAR2(70)")
                        .HasColumnName("ds_email");

                    b.Property<string>("DsSexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("NVARCHAR2(1)")
                        .HasColumnName("ds_sexo");

                    b.Property<string>("DtNascimento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_nascimento");

                    b.Property<int>("IdPlano")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_plano");

                    b.Property<string>("NmPaciente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("nm_paciente");

                    b.Property<string>("NrCpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)")
                        .HasColumnName("nr_cpf");

                    b.Property<string>("NrTelefone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("nr_telefone");

                    b.HasKey("IdPaciente");

                    b.HasIndex("IdPlano");

                    b.ToTable("T_OPBD_PACIENTE");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.PacienteDentista", b =>
                {
                    b.Property<int>("IdPaciente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente");

                    b.Property<int>("IdDentista")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_dentista");

                    b.HasKey("IdPaciente", "IdDentista");

                    b.HasIndex("IdDentista");

                    b.ToTable("T_OPBD_PACIENTE_DENTISTA");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.Perguntas", b =>
                {
                    b.Property<int>("IdPergunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_pergunta")
                        .HasDefaultValueSql("SEQ_T_OPBD_PERGUNTAS.NEXTVAL");

                    b.Property<string>("DsPergunta")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR2(300)")
                        .HasColumnName("ds_pergunta");

                    b.HasKey("IdPergunta");

                    b.ToTable("T_OPBD_PERGUNTAS");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.Plano", b =>
                {
                    b.Property<int>("IdPlano")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_plano")
                        .HasDefaultValueSql("SEQ_T_OPBD_PLANO.NEXTVAL");

                    b.Property<string>("DsCodigoPlano")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)")
                        .HasColumnName("ds_codigo_plano");

                    b.Property<string>("NmPlano")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR2(60)")
                        .HasColumnName("nm_plano");

                    b.HasKey("IdPlano");

                    b.ToTable("T_OPBD_PLANO");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.RaioX", b =>
                {
                    b.Property<int>("IdRaioX")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_raio_x")
                        .HasDefaultValueSql("SEQ_T_OPBD_RAIO_X.NEXTVAL");

                    b.Property<string>("DsRaioX")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("ds_raio_x");

                    b.Property<string>("DtDataRaioX")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_data_raio_x");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente");

                    b.Property<byte[]>("ImRaioX")
                        .HasColumnType("RAW(2000)")
                        .HasColumnName("im_raio_x");

                    b.HasKey("IdRaioX");

                    b.HasIndex("IdPaciente");

                    b.ToTable("T_OPBD_RAIO_X");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.Respostas", b =>
                {
                    b.Property<int>("IdResposta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_resposta")
                        .HasDefaultValueSql("SEQ_T_OPBD_RESPOSTAS.NEXTVAL");

                    b.Property<string>("DsResposta")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("NVARCHAR2(400)")
                        .HasColumnName("ds_resposta");

                    b.HasKey("IdResposta");

                    b.ToTable("T_OPBD_RESPOSTAS");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.AnaliseRaioX", b =>
                {
                    b.HasOne("WebApplicationOdontoPrev.Models.RaioX", "RaioX")
                        .WithMany()
                        .HasForeignKey("IdRaioX")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaioX");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.CheckIn", b =>
                {
                    b.HasOne("WebApplicationOdontoPrev.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationOdontoPrev.Models.Perguntas", "Perguntas")
                        .WithMany()
                        .HasForeignKey("IdPergunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationOdontoPrev.Models.Respostas", "Respostas")
                        .WithMany()
                        .HasForeignKey("IdResposta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Perguntas");

                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.ExtratoPontos", b =>
                {
                    b.HasOne("WebApplicationOdontoPrev.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.Paciente", b =>
                {
                    b.HasOne("WebApplicationOdontoPrev.Models.Plano", "Plano")
                        .WithMany()
                        .HasForeignKey("IdPlano")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.PacienteDentista", b =>
                {
                    b.HasOne("WebApplicationOdontoPrev.Models.Dentista", "Dentista")
                        .WithMany()
                        .HasForeignKey("IdDentista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationOdontoPrev.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentista");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("WebApplicationOdontoPrev.Models.RaioX", b =>
                {
                    b.HasOne("WebApplicationOdontoPrev.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
