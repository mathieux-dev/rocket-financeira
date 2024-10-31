using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RocketFinanceira.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    LOGRADOURO = table.Column<string>(type: "text", nullable: false),
                    NUMERO = table.Column<string>(type: "text", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "text", nullable: true),
                    BAIRRO = table.Column<string>(type: "text", nullable: false),
                    CIDADE = table.Column<string>(type: "text", nullable: false),
                    ESTADO = table.Column<string>(type: "text", nullable: false),
                    CEP = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INSTITUICOES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    NOME = table.Column<string>(type: "text", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    ENDERECO_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    EMAIL_CONTATO = table.Column<string>(type: "text", nullable: false),
                    TELEFONE_CONTATO = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTITUICOES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INSTITUICOES_ENDERECOS_ENDERECO_ID",
                        column: x => x.ENDERECO_ID,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAGADORES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    NOME = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    ENDERECO_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    EMAIL_CONTATO = table.Column<string>(type: "text", nullable: false),
                    TELEFONE_CONTATO = table.Column<string>(type: "text", nullable: false),
                    INSTITUICAO_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGADORES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAGADORES_ENDERECOS_ENDERECO_ID",
                        column: x => x.ENDERECO_ID,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGADORES_INSTITUICOES_INSTITUICAO_ID",
                        column: x => x.INSTITUICAO_ID,
                        principalTable: "INSTITUICOES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COBRANCAS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    TIPO_COBRANCA = table.Column<string>(type: "text", nullable: false),
                    TIPO_PAGAMENTO = table.Column<string>(type: "text", nullable: false),
                    STATUS_COBRANCA = table.Column<string>(type: "text", nullable: false),
                    RECORRENTE = table.Column<bool>(type: "boolean", nullable: false),
                    INTERVALO_RECORRENCIA = table.Column<string>(type: "text", nullable: false),
                    DATA_COBRANCA = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VALOR = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PAGADOR_ID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COBRANCAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COBRANCAS_PAGADORES_PAGADOR_ID",
                        column: x => x.PAGADOR_ID,
                        principalTable: "PAGADORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICACOES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PagadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CobrancaId = table.Column<Guid>(type: "uuid", nullable: false),
                    TIPO = table.Column<string>(type: "text", nullable: false),
                    DATA_ENVIO = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MENSAGEM = table.Column<string>(type: "text", nullable: false),
                    ENVIADO = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICACOES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTIFICACOES_COBRANCAS_CobrancaId",
                        column: x => x.CobrancaId,
                        principalTable: "COBRANCAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTIFICACOES_PAGADORES_PagadorId",
                        column: x => x.PagadorId,
                        principalTable: "PAGADORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COBRANCAS_PAGADOR_ID",
                table: "COBRANCAS",
                column: "PAGADOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUICOES_ENDERECO_ID",
                table: "INSTITUICOES",
                column: "ENDERECO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACOES_CobrancaId",
                table: "NOTIFICACOES",
                column: "CobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACOES_PagadorId",
                table: "NOTIFICACOES",
                column: "PagadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PAGADORES_ENDERECO_ID",
                table: "PAGADORES",
                column: "ENDERECO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAGADORES_INSTITUICAO_ID",
                table: "PAGADORES",
                column: "INSTITUICAO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTIFICACOES");

            migrationBuilder.DropTable(
                name: "COBRANCAS");

            migrationBuilder.DropTable(
                name: "PAGADORES");

            migrationBuilder.DropTable(
                name: "INSTITUICOES");

            migrationBuilder.DropTable(
                name: "ENDERECOS");
        }
    }
}
