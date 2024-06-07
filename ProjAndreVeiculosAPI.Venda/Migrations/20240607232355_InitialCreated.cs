using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAndreVeiculosAPIVenda.Migrations
{
    public partial class InitialCreated : Migration
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
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoModelo = table.Column<int>(type: "int", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Placa);
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
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
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
                name: "Cliente",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Renda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    ValorComissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroPlaca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FuncionarioDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Carro_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carro",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Cliente",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Funcionario_FuncionarioDocumento",
                        column: x => x.FuncionarioDocumento,
                        principalTable: "Funcionario",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Endereco");

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
