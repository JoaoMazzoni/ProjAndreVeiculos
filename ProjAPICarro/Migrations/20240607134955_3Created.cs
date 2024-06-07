using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAPICarro.Migrations
{
    public partial class _3Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Comissao",
                table: "Pessoas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorComissao",
                table: "Pessoas",
                type: "decimal(18,2)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CargoId",
                table: "Pessoas",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cargo_CargoId",
                table: "Pessoas",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cargo_CargoId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CargoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Comissao",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ValorComissao",
                table: "Pessoas");
        }
    }
}
