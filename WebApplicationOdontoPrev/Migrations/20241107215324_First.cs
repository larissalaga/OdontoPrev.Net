using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationOdontoPrev.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_ANALISE_RAIO_X");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_CHECK_IN");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_DENTISTA");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_EXTRATO_PONTOS");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_PACIENTE");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_PERGUNTAS");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_PLANO");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_RAIO_X");

            migrationBuilder.CreateSequence(
                name: "SEQ_T_OPBD_RESPOSTAS");

            migrationBuilder.CreateTable(
                name: "T_OPBD_DENTISTA",
                columns: table => new
                {
                    id_dentista = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_dentista = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ds_cro = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ds_email = table.Column<string>(type: "NVARCHAR2(70)", maxLength: 70, nullable: false),
                    nr_telefone = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ds_doc_identificacao = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_DENTISTA", x => x.id_dentista);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_PERGUNTAS",
                columns: table => new
                {
                    id_pergunta = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_pergunta = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_PERGUNTAS", x => x.id_pergunta);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_PLANO",
                columns: table => new
                {
                    id_plano = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_codigo_plano = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    nm_plano = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_PLANO", x => x.id_plano);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_RESPOSTAS",
                columns: table => new
                {
                    id_resposta = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_resposta = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_RESPOSTAS", x => x.id_resposta);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_PACIENTE",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_paciente = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    dt_nascimento = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    nr_cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    ds_sexo = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    nr_telefone = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ds_email = table.Column<string>(type: "NVARCHAR2(70)", maxLength: 70, nullable: false),
                    IdPlano = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_PACIENTE", x => x.id_paciente);
                    table.ForeignKey(
                        name: "FK_T_OPBD_PACIENTE_T_OPBD_PLANO_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "T_OPBD_PLANO",
                        principalColumn: "id_plano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_CHECK_IN",
                columns: table => new
                {
                    id_check_in = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_check_in = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    IdPaciente = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false),
                    IdPergunta = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false),
                    IdResposta = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_CHECK_IN", x => x.id_check_in);
                    table.ForeignKey(
                        name: "FK_T_OPBD_CHECK_IN_T_OPBD_PACIENTE_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "T_OPBD_PACIENTE",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_OPBD_CHECK_IN_T_OPBD_PERGUNTAS_IdPergunta",
                        column: x => x.IdPergunta,
                        principalTable: "T_OPBD_PERGUNTAS",
                        principalColumn: "id_pergunta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_OPBD_CHECK_IN_T_OPBD_RESPOSTAS_IdResposta",
                        column: x => x.IdResposta,
                        principalTable: "T_OPBD_RESPOSTAS",
                        principalColumn: "id_resposta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_EXTRATO_PONTOS",
                columns: table => new
                {
                    id_extrato_pontos = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_extrato = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    nr_numero_pontos = table.Column<int>(type: "NUMBER(10)", maxLength: 10, nullable: false),
                    ds_movimentacao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    IdPaciente = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_EXTRATO_PONTOS", x => x.id_extrato_pontos);
                    table.ForeignKey(
                        name: "FK_T_OPBD_EXTRATO_PONTOS_T_OPBD_PACIENTE_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "T_OPBD_PACIENTE",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_PACIENTE_DENTISTA",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false),
                    IdDentista = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_PACIENTE_DENTISTA", x => new { x.IdPaciente, x.IdDentista });
                    table.ForeignKey(
                        name: "FK_T_OPBD_PACIENTE_DENTISTA_T_OPBD_DENTISTA_IdDentista",
                        column: x => x.IdDentista,
                        principalTable: "T_OPBD_DENTISTA",
                        principalColumn: "id_dentista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_OPBD_PACIENTE_DENTISTA_T_OPBD_PACIENTE_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "T_OPBD_PACIENTE",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_RAIO_X",
                columns: table => new
                {
                    id_raio_x = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_raio_x = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    im_raio_x = table.Column<byte[]>(type: "RAW(2000)", nullable: true),
                    dt_data_raio_x = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    IdPaciente = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_RAIO_X", x => x.id_raio_x);
                    table.ForeignKey(
                        name: "FK_T_OPBD_RAIO_X_T_OPBD_PACIENTE_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "T_OPBD_PACIENTE",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OPBD_ANALISE_RAIO_X",
                columns: table => new
                {
                    id_analise_raio_x = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_analise_raio_x = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_analise_raio_x = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    IdRaioX = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OPBD_ANALISE_RAIO_X", x => x.id_analise_raio_x);
                    table.ForeignKey(
                        name: "FK_T_OPBD_ANALISE_RAIO_X_T_OPBD_RAIO_X_IdRaioX",
                        column: x => x.IdRaioX,
                        principalTable: "T_OPBD_RAIO_X",
                        principalColumn: "id_raio_x",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_ANALISE_RAIO_X_IdRaioX",
                table: "T_OPBD_ANALISE_RAIO_X",
                column: "IdRaioX");

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_CHECK_IN_IdPaciente",
                table: "T_OPBD_CHECK_IN",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_CHECK_IN_IdPergunta",
                table: "T_OPBD_CHECK_IN",
                column: "IdPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_CHECK_IN_IdResposta",
                table: "T_OPBD_CHECK_IN",
                column: "IdResposta");

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_EXTRATO_PONTOS_IdPaciente",
                table: "T_OPBD_EXTRATO_PONTOS",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_PACIENTE_IdPlano",
                table: "T_OPBD_PACIENTE",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_PACIENTE_DENTISTA_IdDentista",
                table: "T_OPBD_PACIENTE_DENTISTA",
                column: "IdDentista");

            migrationBuilder.CreateIndex(
                name: "IX_T_OPBD_RAIO_X_IdPaciente",
                table: "T_OPBD_RAIO_X",
                column: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_OPBD_ANALISE_RAIO_X");

            migrationBuilder.DropTable(
                name: "T_OPBD_CHECK_IN");

            migrationBuilder.DropTable(
                name: "T_OPBD_EXTRATO_PONTOS");

            migrationBuilder.DropTable(
                name: "T_OPBD_PACIENTE_DENTISTA");

            migrationBuilder.DropTable(
                name: "T_OPBD_RAIO_X");

            migrationBuilder.DropTable(
                name: "T_OPBD_PERGUNTAS");

            migrationBuilder.DropTable(
                name: "T_OPBD_RESPOSTAS");

            migrationBuilder.DropTable(
                name: "T_OPBD_DENTISTA");

            migrationBuilder.DropTable(
                name: "T_OPBD_PACIENTE");

            migrationBuilder.DropTable(
                name: "T_OPBD_PLANO");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_ANALISE_RAIO_X");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_CHECK_IN");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_DENTISTA");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_EXTRATO_PONTOS");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_PACIENTE");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_PERGUNTAS");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_PLANO");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_RAIO_X");

            migrationBuilder.DropSequence(
                name: "SEQ_T_OPBD_RESPOSTAS");
        }
    }
}
