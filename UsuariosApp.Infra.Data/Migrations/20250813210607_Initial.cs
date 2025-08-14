using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VEICULOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_DONO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL_DONO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PLACA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HORARIO_ENTRADA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HORARIO_SAIDA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULOS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VEICULOS_EMAIL_DONO",
                table: "VEICULOS",
                column: "EMAIL_DONO",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VEICULOS");
        }
    }
}
