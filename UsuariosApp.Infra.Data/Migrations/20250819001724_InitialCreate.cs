using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionamentoApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VEICULOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEDONO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAILDONO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PLACA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HORARIOENTRADA = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    HORARIOSAIDA = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULOS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VEICULOS_EMAILDONO",
                table: "VEICULOS",
                column: "EMAILDONO",
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
