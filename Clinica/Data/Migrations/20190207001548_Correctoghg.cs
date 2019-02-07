using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Clinica.Data.Migrations
{
    public partial class Correctoghg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    LocalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultoriosId = table.Column<int>(type: "int", nullable: false),
                    Direcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.LocalesId);
                    table.ForeignKey(
                        name: "FK_Locales_Consultorios_ConsultoriosId",
                        column: x => x.ConsultoriosId,
                        principalTable: "Consultorios",
                        principalColumn: "ConsultoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locales_ConsultoriosId",
                table: "Locales",
                column: "ConsultoriosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locales");
        }
    }
}
