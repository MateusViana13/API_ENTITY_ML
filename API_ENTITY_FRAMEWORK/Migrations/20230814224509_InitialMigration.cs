using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ENTITY_FRAMEWORK.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalDestino = table.Column<string>(type: "varchar(150)", nullable: false),
                    Pais = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontoTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoTuristicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontoTuristicos_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontoTuristicoReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PontoTuristicoId = table.Column<int>(type: "int", nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(150)", nullable: false),
                    Review = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    DataReview = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoTuristicoReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontoTuristicoReviews_PontoTuristicos_PontoTuristicoId",
                        column: x => x.PontoTuristicoId,
                        principalTable: "PontoTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristicoReviews_PontoTuristicoId",
                table: "PontoTuristicoReviews",
                column: "PontoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristicos_DestinoId",
                table: "PontoTuristicos",
                column: "DestinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontoTuristicoReviews");

            migrationBuilder.DropTable(
                name: "PontoTuristicos");

            migrationBuilder.DropTable(
                name: "Destinos");
        }
    }
}
