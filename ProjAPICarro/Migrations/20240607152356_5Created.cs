using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAPICarro.Migrations
{
    public partial class _5Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Cartao_CartaoNumeroCartao",
                table: "Pagamento");

            migrationBuilder.AlterColumn<string>(
                name: "CartaoNumeroCartao",
                table: "Pagamento",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Carro_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carro",
                        principalColumn: "Placa");
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FuncionarioDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Carro_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carro",
                        principalColumn: "Placa");
                    table.ForeignKey(
                        name: "FK_Venda_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Pessoas_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                    table.ForeignKey(
                        name: "FK_Venda_Pessoas_FuncionarioDocumento",
                        column: x => x.FuncionarioDocumento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateTable(
                name: "CarroServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarroServico_Carro_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carro",
                        principalColumn: "Placa");
                    table.ForeignKey(
                        name: "FK_CarroServico_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroServico_CarroPlaca",
                table: "CarroServico",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_CarroServico_ServicoId",
                table: "CarroServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CarroPlaca",
                table: "Compra",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_CarroPlaca",
                table: "Venda",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteDocumento",
                table: "Venda",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_FuncionarioDocumento",
                table: "Venda",
                column: "FuncionarioDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_PagamentoId",
                table: "Venda",
                column: "PagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Cartao_CartaoNumeroCartao",
                table: "Pagamento",
                column: "CartaoNumeroCartao",
                principalTable: "Cartao",
                principalColumn: "NumeroCartao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Cartao_CartaoNumeroCartao",
                table: "Pagamento");

            migrationBuilder.DropTable(
                name: "CarroServico");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.AlterColumn<string>(
                name: "CartaoNumeroCartao",
                table: "Pagamento",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Cartao_CartaoNumeroCartao",
                table: "Pagamento",
                column: "CartaoNumeroCartao",
                principalTable: "Cartao",
                principalColumn: "NumeroCartao",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
