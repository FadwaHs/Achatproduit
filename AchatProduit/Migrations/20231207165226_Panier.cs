using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AchatProduit.Migrations
{
    /// <inheritdoc />
    public partial class Panier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paniers",
                columns: table => new
                {
                    PanierID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.PanierID);
                });

            migrationBuilder.CreateTable(
                name: "LignePaniers",
                columns: table => new
                {
                    LignePanierID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PanierID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignePaniers", x => x.LignePanierID);
                    table.ForeignKey(
                        name: "FK_LignePaniers_Paniers_PanierID",
                        column: x => x.PanierID,
                        principalTable: "Paniers",
                        principalColumn: "PanierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LignePaniers_Produits_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Produits",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LignePaniers_PanierID",
                table: "LignePaniers",
                column: "PanierID");

            migrationBuilder.CreateIndex(
                name: "IX_LignePaniers_ProductID",
                table: "LignePaniers",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LignePaniers");

            migrationBuilder.DropTable(
                name: "Paniers");
        }
    }
}
