using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAndreVeiculosAPICarro.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeBanco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFundacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.CNPJ);
                });

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
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeCartao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.NumeroCartao);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
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
                name: "TermoDeUso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Versao = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermoDeUso", x => x.Id);
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
                name: "CNH",
                columns: table => new
                {
                    CNHNumero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNH", x => x.CNHNumero);
                    table.ForeignKey(
                        name: "FK_CNH_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Cliente",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Renda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DocumentoPDF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Cliente_Pessoa_Documento",
                        column: x => x.Documento,
                        principalTable: "Pessoa",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateTable(
                name: "Condutor",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CNHNumero = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutor", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Condutor_CNH_CNHNumero",
                        column: x => x.CNHNumero,
                        principalTable: "CNH",
                        principalColumn: "CNHNumero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Condutor_Pessoa_Documento",
                        column: x => x.Documento,
                        principalTable: "Pessoa",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    ValorComissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                        name: "FK_Funcionario_Pessoa_Documento",
                        column: x => x.Documento,
                        principalTable: "Pessoa",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoNumeroCartao = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BoletoId = table.Column<int>(type: "int", nullable: true),
                    PixId = table.Column<int>(type: "int", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Boleto_BoletoId",
                        column: x => x.BoletoId,
                        principalTable: "Boleto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pagamento_Cartao_CartaoNumeroCartao",
                        column: x => x.CartaoNumeroCartao,
                        principalTable: "Cartao",
                        principalColumn: "NumeroCartao");
                    table.ForeignKey(
                        name: "FK_Pagamento_Pix_PixId",
                        column: x => x.PixId,
                        principalTable: "Pix",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AceiteTermoUso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TermoDeUsoId = table.Column<int>(type: "int", nullable: false),
                    DataAceite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AceiteTermoUso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AceiteTermoUso_Cliente_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Cliente",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AceiteTermoUso_TermoDeUso_TermoDeUsoId",
                        column: x => x.TermoDeUsoId,
                        principalTable: "TermoDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Dependente_Cliente_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Cliente",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dependente_Pessoa_Documento",
                        column: x => x.Documento,
                        principalTable: "Pessoa",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateTable(
                name: "PendenciaFinanceira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPendencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCobranca = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendenciaFinanceira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendenciaFinanceira_Cliente_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Cliente",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Franquia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarroPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CondutorPrincipalDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguro_Carro_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carro",
                        principalColumn: "Placa");
                    table.ForeignKey(
                        name: "FK_Seguro_Cliente_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Cliente",
                        principalColumn: "Documento");
                    table.ForeignKey(
                        name: "FK_Seguro_Condutor_CondutorPrincipalDocumento",
                        column: x => x.CondutorPrincipalDocumento,
                        principalTable: "Condutor",
                        principalColumn: "Documento");
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
                        principalColumn: "Placa");
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Finaciamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    DataFinanciamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BancoCNPJ = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finaciamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Finaciamento_Banco_BancoCNPJ",
                        column: x => x.BancoCNPJ,
                        principalTable: "Banco",
                        principalColumn: "CNPJ");
                    table.ForeignKey(
                        name: "FK_Finaciamento_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AceiteTermoUso_ClienteDocumento",
                table: "AceiteTermoUso",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_AceiteTermoUso_TermoDeUsoId",
                table: "AceiteTermoUso",
                column: "TermoDeUsoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarroServico_CarroPlaca",
                table: "CarroServico",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_CarroServico_ServicoId",
                table: "CarroServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CNH_CategoriaId",
                table: "CNH",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CarroPlaca",
                table: "Compra",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Condutor_CNHNumero",
                table: "Condutor",
                column: "CNHNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_ClienteDocumento",
                table: "Dependente",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Finaciamento_BancoCNPJ",
                table: "Finaciamento",
                column: "BancoCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Finaciamento_VendaId",
                table: "Finaciamento",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

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
                name: "IX_PendenciaFinanceira_ClienteDocumento",
                table: "PendenciaFinanceira",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pix_TipoId",
                table: "Pix",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguro_CarroPlaca",
                table: "Seguro",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Seguro_ClienteDocumento",
                table: "Seguro",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Seguro_CondutorPrincipalDocumento",
                table: "Seguro",
                column: "CondutorPrincipalDocumento");

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
                name: "AceiteTermoUso");

            migrationBuilder.DropTable(
                name: "CarroServico");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Finaciamento");

            migrationBuilder.DropTable(
                name: "PendenciaFinanceira");

            migrationBuilder.DropTable(
                name: "Seguro");

            migrationBuilder.DropTable(
                name: "TermoDeUso");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Condutor");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "CNH");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "TipoPix");
        }
    }
}
