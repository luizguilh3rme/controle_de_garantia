﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaOnuIntelbras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnuIntelbras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnuIntelbras", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnuIntelbras");
        }
    }
}
