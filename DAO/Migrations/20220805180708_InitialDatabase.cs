using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAO.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PETS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Raca = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Cor = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    EstaAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PETS", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PETS");
        }
    }
}
