using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAPICarro.Migrations
{
    public partial class _4Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    NumeroCartao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoSeguranca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataValidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCartao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.NumeroCartao);
                });

            migrationBuilder.CreateTable(
                name: "TipoPix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    ChavePix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pix_TipoPix_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoPix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoNumeroCartao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BoletoId = table.Column<int>(type: "int", nullable: false),
                    PixId = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Boleto_BoletoId",
                        column: x => x.BoletoId,
                        principalTable: "Boleto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_Cartao_CartaoNumeroCartao",
                        column: x => x.CartaoNumeroCartao,
                        principalTable: "Cartao",
                        principalColumn: "NumeroCartao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_Pix_PixId",
                        column: x => x.PixId,
                        principalTable: "Pix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_BoletoId",
                table: "Pagamento",
                column: "BoletoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CartaoNumeroCartao",
                table: "Pagamento",
                column: "CartaoNumeroCartao");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_PixId",
                table: "Pagamento",
                column: "PixId");

            migrationBuilder.CreateIndex(
                name: "IX_Pix_TipoId",
                table: "Pix",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "TipoPix");
        }
    }
}
